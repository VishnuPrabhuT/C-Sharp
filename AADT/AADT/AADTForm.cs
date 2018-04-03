using System;
using System.Threading;
using System.Windows.Forms;
using LibSVMsharp;
using LibSVMsharp.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;
using LibSVMsharp.Extensions;

namespace AADT
{
    public partial class AADTForm : Form
    {
        public AADTForm()
        {
            InitializeComponent();
            //name = this.nameLabel.Text;
            dataSelected = this.roadWayComboBox.Items.ToString();
        }
        public string name
        {
            get;
            set;
        }
        public static string path
        {
            get;
            set;
        }

        public string dataSelected
        {
            get;
            set;
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            path = pathTextBox.Text;
            minionBackgroundWorker.WorkerReportsProgress = true;
            minionBackgroundWorker.RunWorkerAsync();

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTextBox.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void minionBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string[] todelete = { "Train", "Test", "Result", "Output", "AADT_model", "AADTVal" };
            path = AADTForm.path;
            foreach (string s in todelete)
            {
                File.Delete(path + @"\" + s + ".txt");
            }
            //string dataSelected = roadWayComboBox.SelectedItem.ToString();


            int[] interstate = { 14, 15, 16, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 34, 42, 43, 46, 49, 50, 51, 52, 53, 54, 55, 56, 69, 70, 71, 72, 77, 80, 81, 84, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 106, 108, 109, 110, 111, 112, 113, 114, 115, 116, 118, 120, 121, 123, 124, 125, 126, 127, 128, 132, 137, 138, 139, 142, 145, 146, 150, 157 };
            int[] rural_arterial = { 1, 2, 4, 5, 9, 11, 36, 37, 38, 44, 48, 57, 58, 60, 61, 62, 63, 64, 67, 68, 74, 76, 82, 83, 105, 107, 117, 119, 122, 131, 133, 134, 135, 136, 140, 141, 149 };
            int[] urban_arterial = { 3, 6, 7, 8, 12, 13, 18, 30, 35, 40, 45, 47, 59, 66, 85, 104, 129, 130, 143, 144, 147, 148 };
            int[] arterial = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 18, 30, 35, 36, 37, 38, 40, 44, 45, 47, 48, 57, 58, 59, 60, 61, 62, 63, 64, 66, 67, 68, 74, 76, 82, 83, 85, 104, 105, 107, 117, 119, 122, 129, 130, 131, 133, 134, 135, 136, 140, 141, 143, 144, 147, 148, 149 };
            int[] rural_collector = { 10, 17, 39, 65, 73, 75, 151, 158, 166 };
            int[] urban_collector = { 41, 152, 155, 159, 160, 162 };
            int[] local = { 153, 154, 156, 161, 163, 164, 165 };
            int[] collector = { 10, 17, 39, 41, 65, 73, 75, 151, 152, 153, 154, 155, 156, 158, 159, 160, 161, 162, 163, 164, 165, 166 };
            int[] short_term = { 98, 145, 102, 50, 110 };
            int[] allATR = Enumerable.Range(1, 166).ToArray();
            int[] pilot = allATR.Except(short_term).ToArray();
            int[] pilot_interstate = interstate.Except(short_term).ToArray();
            int[] AADT = new int[166];
            int[] ATR = new int[166];
            int[] trainingSet;

            Dictionary<int, int> modelDict = new Dictionary<int, int> {
                { 12, 1 },
                { 2, 2},
                { 3, 2},
                { 13, 2},
                { 14, 2},
                { 4, 3},
                { 5, 3},
                { 9, 3},
                { 15, 3},
                { 18, 3}
                };

            //StreamReader ipReader = new StreamReader(path + @"\SuggestedInputFormat.csv");
            string ip = File.ReadAllText(path + @"\Input.csv");
            string[] ipArray = ip.Replace("County,Station,Date,FClass,Hour1,Hour2,Hour3,Hour4,Hour5,Hour6,Hour7,Hour8,Hour9,Hour10,Hour11,Hour12,Hour13,Hour14,Hour15,Hour16,Hour17,Hour18,Hour19,Hour20,Hour21,Hour22,Hour23,Hour24\r\n", "").Replace(',', ' ').Replace("\n", "").Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string basePath = path + @"\ATR_Data_2016\";
            AADTForm p = new AADTForm();
            minionBackgroundWorker.ReportProgress(10);
            string currentATR = "";
            //int count = 3;
            int mytot = ipArray.Length;
            int mycount = 0;
            int[] vol = new int[mytot];
            string resultString = "";
            StreamWriter testWriter = new StreamWriter(path + @"\Test.txt");
            List<int> fClass = new List<int>();
            foreach (string ss in ipArray)
            {
                string[] tempy = ss.Split(new char[] { ' ' }, 5);

                fClass.Add(Convert.ToInt32(tempy[3]));

                DateTime date = DateTime.ParseExact(tempy[2], "d", CultureInfo.InvariantCulture);
                string binaryMonth = Convert.ToString(date.Month, 2);
                binaryMonth = binaryMonth.PadLeft(4, '0');
                binaryMonth = Regex.Replace(binaryMonth, ".{1}", "$0-");
                resultString += binaryMonth;
                string binaryDayOfWeek = Convert.ToString(Convert.ToInt32(date.DayOfWeek) + 1, 2);
                binaryDayOfWeek = binaryDayOfWeek.PadLeft(3, '0');
                binaryDayOfWeek = Regex.Replace(binaryDayOfWeek, ".{1}", "$0-");
                resultString += binaryDayOfWeek;
                //count++;
                resultString = resultString.Remove(resultString.Length - 1);


                currentATR += tempy[1] + "-";
                //count++;
                int dayVolumeSum = tempy[4].Split(' ').Select(int.Parse).ToArray().Sum();
                vol[mycount] = dayVolumeSum;
                mycount++;
                foreach (string s in tempy[4].Split(' '))
                {
                    resultString += "-" + Math.Round(Convert.ToDecimal(s) / dayVolumeSum, 5);
                }
                //resultString.Replace("--", "-");
                //count++;
                string result = "0 ";
                int itemCount = 1;
                foreach (string s in resultString.Split('-'))
                {
                    result += itemCount + ":" + s + " ";
                    itemCount++;
                }
                testWriter.WriteLine(result);
                resultString = "";


            }
            minionBackgroundWorker.ReportProgress(30);
            int fclass = modelDict[fClass[0]];
            switch (fclass)
            {
                case 1:
                    trainingSet = interstate;
                    break;
                case 2:
                    trainingSet = arterial;
                    break;
                case 3:
                    trainingSet = collector;
                    break;
                default:
                    trainingSet = allATR;
                    break;
            }
            currentATR = currentATR.TrimEnd('-');
            string[] atrs = currentATR.Split('-');
            foreach (int i in trainingSet.Except(atrs.Select(int.Parse).ToArray()))
            {
                p.ExtractData(basePath + i.ToString() + ".txt");
            }

            //Train:Test - Split
            List<int> inputATR = new List<int>();
            List<int> trainATR = new List<int>();
            List<int> testATR = new List<int>();

            StreamReader streamReader = new StreamReader(path + @"\Result.txt");
            minionBackgroundWorker.ReportProgress(40);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                if (!inputATR.Contains(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString())))
                {
                    inputATR.Add(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString()));
                }
                line = streamReader.ReadLine();
            }
            minionBackgroundWorker.ReportProgress(50);
            streamReader.Close();
            int x = inputATR.Count();
            int trainIndex = Convert.ToInt32(x * (1));
            int testIndex = x - trainIndex;
            StreamWriter trainWriter = new StreamWriter(path + @"\Train.txt");

            foreach (int i in Enumerable.Range(0, trainIndex))
            {
                trainATR.Add(inputATR[i]);
            }
            foreach (int i in Enumerable.Range(trainIndex, x - trainIndex))
            {
                testATR.Add(inputATR[i]);
            }
            streamReader = new StreamReader(path + @"\Result.txt");
            line = streamReader.ReadLine();
            minionBackgroundWorker.ReportProgress(60);
            while (line != null)
            {
                string atr = line.Substring(0, line.IndexOf('-'));
                int colonCount = 1;
                if (trainATR.Contains(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString())))
                {
                    string temp = String.Empty;
                    line = line.Remove(0, line.IndexOf('-') + 1);
                    temp = atr;
                    string[] tempArr = line.Split('-');
                    foreach (string s in tempArr)
                    {
                        temp += " " + colonCount++.ToString() + ":" + s;
                    }
                    string v = temp.Remove(0, temp.IndexOf("32:") + 3) + " " + temp.Remove(0, temp.IndexOf(' ') + 1).Remove(temp.IndexOf("32:") - 4);// + " 32:" + temp.Substring(0, temp.IndexOf(" "));
                    trainWriter.WriteLine(v);
                }
                if (testATR.Contains(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString())))
                {
                    string temp = String.Empty;
                    line = line.Remove(0, line.IndexOf('-') + 1);
                    temp = atr;
                    string[] tempArr = line.Split('-');
                    foreach (string s in tempArr)
                    {
                        temp += " " + colonCount++.ToString() + ":" + s;
                    }
                    string v = temp.Remove(0, temp.IndexOf("32:") + 3) + " " + temp.Remove(0, temp.IndexOf(' ') + 1).Remove(temp.IndexOf("32:") - 4);// + " 32:"+temp.Substring(0, temp.IndexOf(" "));
                                                                                                                                                     //testWriter.WriteLine(v);
                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            trainWriter.Flush();
            trainWriter.Close();
            testWriter.Flush();
            testWriter.Close();
            minionBackgroundWorker.ReportProgress(70);
            int[] xtrain = Enumerable.Range(1, 31).ToArray();
            int[] xtest = Enumerable.Range(1, 31).ToArray();
            int[] ytrain = Enumerable.Range(32, 1).ToArray();
            int[] ytest = Enumerable.Range(32, 1).ToArray();


            SVMProblem trainData = SVMProblemHelper.Load(path + @"\Train.txt");
            SVMProblem testData = SVMProblemHelper.Load(path + @"\Test.txt");

            trainData = trainData.Normalize(SVMNormType.L1);
            testData = testData.Normalize(SVMNormType.L1);

            SVMParameter parameter = new SVMParameter
            {
                Type = SVMType.EPSILON_SVR,
                Kernel = SVMKernelType.RBF,

                C = 1,
                Gamma = 1
            };
            minionBackgroundWorker.ReportProgress(80);
            SVMModel model = SVM.Train(trainData, parameter);
            minionBackgroundWorker.ReportProgress(90);
            SVM.SaveModel(model, path + @"\AADT_model.txt");
            //SVMModel model = SVM.LoadModel(@"\OP\AADT_model.txt");

            double[] testResults = testData.Predict(model);
            StreamWriter outputWriter = new StreamWriter(path + @"\Output.txt");
            //outputWriter.WriteLine("ATR Number" + " - " + "Predicted AADT" + " - " + "Actual AADT" + " - " + "Error(%)");
            minionBackgroundWorker.ReportProgress(100);
            for (int i = 0; i < testData.Length; i++)
            {
                //aadtarray[i] = allAADT[Convert.ToInt32(atrs[i])-1];
                //outputWriter.WriteLine(atrs[i] + " - " + Math.Round(vol[i]/testResults[i]) + " - " + Convert.ToInt32(allAADT[Convert.ToInt32(atrs[i])-1]) + " - " + Math.Round(Math.Abs((Math.Round(vol[i] / testResults[i])) - Convert.ToInt32(allAADT[Convert.ToInt32(atrs[i]) - 1])) * 100 / Convert.ToInt32(allAADT[Convert.ToInt32(atrs[i]) - 1])));
                outputWriter.WriteLine(Math.Round(vol[i] / testResults[i]));
            }
            outputWriter.Flush();
            outputWriter.Close();
            double[] target = new double[testData.Length];
            for (int i = 0; i < testData.Length; i++)
            {
                target[i] = SVM.Predict(model, testData.X[i]);
            }
        }

        private void roadWayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSelected = roadWayComboBox.SelectedItem.ToString();
        }

        private void minionBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Application.OpenForms["AADTForm"].Hide();
            DoneForm done = new DoneForm();
            done.Controls["outputLinkLabel"].Text = path + @"\Output.txt";
            done.ShowDialog();
        }

        private void AADTForm_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public static double totalSum { get; set; }
        public Hashtable countHash = new Hashtable();
        StreamReader reader;
        //static string path { get; set; }
        public List<string> GetLineData(StreamReader reader)
        {
            List<double> factorList = new List<double>();
            int sumVal = 0;
            string resultString = string.Empty;
            int dayVolumeCount = 0;
            string line = reader.ReadToEnd();
            //Console.WriteLine(line);
            line = line.Replace("\r", "");
            line = line.Replace("Time Northbound Southbound", "");
            line = line.Replace("Vehicle Count Average Speed (MPH) Vehicle Count Average Speed (MPH)", "");
            line = line.Replace("Current Historical Current Historical", "");
            string[] res = line.Split('\n');
            List<string> resultStrings = new List<string>();
            foreach (string str in res)
            {
                line = str;
                //Console.WriteLine(line);
                if (line == null || line.Contains("No"))
                {
                    if (line.Contains("No"))
                    {
                        resultString = "Skip!";
                    }
                    continue;
                }
                if (line.Contains("/2016"))
                {
                    DateTime date = DateTime.ParseExact(line, "d", CultureInfo.InvariantCulture);
                    string binaryMonth = Convert.ToString(date.Month, 2);
                    binaryMonth = binaryMonth.PadLeft(4, '0');
                    binaryMonth = Regex.Replace(binaryMonth, ".{1}", "$0-");
                    resultString += binaryMonth;
                    string binaryDayOfWeek = Convert.ToString(Convert.ToInt32(date.DayOfWeek) + 1, 2);
                    binaryDayOfWeek = binaryDayOfWeek.PadLeft(3, '0');
                    binaryDayOfWeek = Regex.Replace(binaryDayOfWeek, ".{1}", "$0-");
                    resultString += binaryDayOfWeek;
                    dayVolumeCount = 0;
                    sumVal = 0;
                    factorList = new List<double>();
                }
                if (line.Contains(":"))
                {
                    if (line.Split(' ').Length < 5)
                    {
                        line += line + " 0";
                    }
                    int numVal = (line.Split(' ')[1] == "N/A" ? 0 : Convert.ToInt32(line.Split(' ')[1])) + (line.Split(' ')[4] == "N/A" ? 0 : Convert.ToInt32(line.Split(' ')[4]));
                    if (numVal != 0)
                    {
                        factorList.Add(numVal);
                        sumVal += numVal;
                    }
                    else
                    {
                        resultString = "Skip!";
                        continue;
                    }
                }

                dayVolumeCount = sumVal;
                totalSum += sumVal;
                if (factorList.Count > 23)
                {
                    foreach (double i in factorList)
                    {
                        double factor = Math.Round(i / sumVal, 3);
                        resultString += factor.ToString("0.###") + "-";
                    }

                    resultStrings.Add(resultString + "#" + dayVolumeCount.ToString());
                    resultString = "";
                }
                else
                {
                    if (resultString.Contains("Skip!"))
                    {
                        //resultString = "";
                    }
                }
            }
            if (resultStrings.Count != 0)
            {
                resultStrings.RemoveAt(resultStrings.Count - 1);
            }

            return resultStrings;
        }
        private void ExtractData(string fileLocation)
        {
            string line = string.Empty;
            totalSum = 0;
            string currentATR = fileLocation.Replace(path + @"\ATR_Data_2016\", "").Replace(".txt", "");
            reader = new StreamReader(fileLocation);
            List<string> resultList = new List<string>();
            Hashtable aadtVal = new Hashtable();
            int count = 0;
            //Program p = new Program();
            AADTForm p = new AADTForm();
            List<string> writeList = new List<string>();
            resultList = p.GetLineData(reader);
            if (currentATR == "80")
            {
                Console.WriteLine(totalSum);
            }
            foreach (string resultString in resultList)
            {
                string tempStr = currentATR + "-" + resultString;
                if (tempStr.Length > 10 && !tempStr.Contains("Skip!"))
                {
                    //resultList.Add(resultString);
                    count++;
                    aadtVal.Add(currentATR.ToString() + "->" + count.ToString(), tempStr.Substring(tempStr.IndexOf('#') + 1));
                    tempStr = Convert.ToInt32(tempStr.Split('-')[0]) < 9 ? tempStr.Remove(resultString.IndexOf('#') + 3) : Convert.ToInt32(tempStr.Split('-')[0]) < 100 ? tempStr.Remove(resultString.IndexOf('#') + 4) : tempStr.Remove(resultString.IndexOf('#') + 5);
                    writeList.Add(tempStr);
                }
            }

            TextWriter writer = File.AppendText(path + @"\Result.txt");
            TextWriter aadtWriter = File.AppendText(path + @"\AADTVal.txt");
            aadtWriter.WriteLine(currentATR + " - " + Math.Round(totalSum / count));
            if (count >= 180)
            {
                int decr = 1;
                foreach (string s in writeList)
                {
                    double AADTFactor = Math.Round(Convert.ToInt32(aadtVal[currentATR.ToString() + "->" + (decr++).ToString()]) / Math.Round(totalSum / count), 3);
                    writer.WriteLine(s.Remove(s.IndexOf('#')) + AADTFactor.ToString());
                }
            }
            else
            {
                Console.WriteLine(currentATR);
            }
            writer.Flush();
            aadtWriter.Flush();
            reader.Close();
            writer.Close();
            aadtWriter.Close();
        }

        private void minionBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Text = "Progress: " + e.ProgressPercentage.ToString() + "%";
        }
    }
}



