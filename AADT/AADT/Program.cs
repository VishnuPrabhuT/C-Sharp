using LibSVMsharp;
using LibSVMsharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;
using LibSVMsharp.Extensions;
using System.Windows.Forms;

namespace AADT
{
    class Program
    {
        public static double totalSum { get; set; }
        public Hashtable countHash = new Hashtable();
        StreamReader reader;
        static string path { get; set; }
        private List<string> GetLineData(StreamReader reader)
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
                        double factor = Math.Round(i / sumVal, 5);
                        resultString += factor.ToString() + "-";
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
            Program p = new Program();
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

            TextWriter writer = File.AppendText(path + @"\OP\Result.txt");
            TextWriter aadtWriter = File.AppendText(path + @"\OP\AADTVal.txt");
            aadtWriter.WriteLine(currentATR + " - " + totalSum / count);
            if (count >= 180)
            {
                int decr = 1;
                foreach (string s in writeList)
                {
                    double AADTFactor = Math.Round(Convert.ToInt32(aadtVal[currentATR.ToString() + "->" + (decr++).ToString()]) / (totalSum / count), 3);
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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //UI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            AADTForm aadt = new AADTForm();
            Application.Run(aadt);
            string n = aadt.name;
            path = aadt.path;
            int dataSelected = aadt.dataSelected;


            int[] interstate = { 14, 15, 16, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 34, 42, 43, 46, 49, 50, 51, 52, 53, 54, 55, 56, 69, 70, 71, 72, 77, 80, 81, 84, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 106, 108, 109, 110, 111, 112, 113, 114, 115, 116, 118, 120, 121, 123, 124, 125, 126, 127, 128, 132, 137, 138, 139, 142, 145, 146, 150, 157 };
            int[] rural_arterial = { 1, 2, 4, 5, 9, 11, 36, 37, 38, 44, 48, 57, 58, 60, 61, 62, 63, 64, 67, 68, 74, 76, 82, 83, 105, 107, 117, 119, 122, 131, 133, 134, 135, 136, 140, 141, 149 };
            int[] urban_arterial = { 3, 6, 7, 8, 12, 13, 18, 30, 35, 40, 45, 47, 59, 66, 85, 104, 129, 130, 143, 144, 147, 148 };
            int[] arterial = { 1, 9, 11, 12, 13, 18, 30, 35, 36, 37, 38, 40, 44, 45, 47, 48, 57, 58, 59, 60, 61, 62, 63, 64, 66, 67, 68, 74, 76, 82, 83, 85, 104, 105, 107, 117, 119, 122, 129, 130, 131, 133, 134, 135, 136, 140, 141, 143, 144, 147, 148, 149 };
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
            switch (dataSelected)
            {
                case 1:
                    trainingSet = interstate;
                    break;
                case 2:
                    trainingSet = arterial;
                    break;
                case 3:
                    trainingSet = local;
                    break;
                default:
                    trainingSet = allATR;
                    break;
            }

            string basePath = path + @"\ATR_Data_2016\";
            Program p = new Program();
            StreamReader ipReader = new StreamReader(path + @"\OP\Input.txt");
            string ip = ipReader.ReadToEnd();
            ip = ip.Replace("\r", "");
            string[] ipArray = ip.Split('\n');
            string currentATR = "";
            int count = 3;
            string resultString = "";
            StreamWriter testWriter = new StreamWriter(path + @"\OP\Test.txt");
            while (count < ipArray.Length)
            {
                if (count % 3 == 0)
                {
                    //resultString = "0 ";
                    DateTime date = DateTime.ParseExact(ipArray[count - 1], "d", CultureInfo.InvariantCulture);
                    string binaryMonth = Convert.ToString(date.Month, 2);
                    binaryMonth = binaryMonth.PadLeft(4, '0');
                    binaryMonth = Regex.Replace(binaryMonth, ".{1}", "$0-");
                    resultString += binaryMonth;
                    string binaryDayOfWeek = Convert.ToString(Convert.ToInt32(date.DayOfWeek) + 1, 2);
                    binaryDayOfWeek = binaryDayOfWeek.PadLeft(3, '0');
                    binaryDayOfWeek = Regex.Replace(binaryDayOfWeek, ".{1}", "$0-");
                    resultString += binaryDayOfWeek;
                    count++;
                    resultString = resultString.Remove(resultString.Length - 1);
                }
                else
                {
                    currentATR += ipArray[count - 1] + "-";

                    count++;
                    int dayVolumeSum = ipArray[count - 1].Split(' ').Select(int.Parse).ToArray().Sum();
                    foreach (string s in ipArray[count - 1].Split(' '))
                    {
                        resultString += "-" + Math.Round(Convert.ToDecimal(s) / dayVolumeSum, 5);
                    }
                    //resultString.Replace("--", "-");
                    count++;
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

            StreamReader streamReader = new StreamReader(path + @"\OP\Result.txt");

            string line = streamReader.ReadLine();
            while (line != null)
            {
                if (!inputATR.Contains(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString())))
                {
                    inputATR.Add(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString()));
                }
                //Console.WriteLine(line);   
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            int x = inputATR.Count();
            int trainIndex = Convert.ToInt32(x * (1));
            int testIndex = x - trainIndex;
            StreamWriter trainWriter = new StreamWriter(path + @"\OP\Train.txt");

            foreach (int i in Enumerable.Range(0, trainIndex))
            {
                trainATR.Add(inputATR[i]);
            }
            foreach (int i in Enumerable.Range(trainIndex, x - trainIndex))
            {
                testATR.Add(inputATR[i]);
            }
            streamReader = new StreamReader(path + @"\OP\Result.txt");
            line = streamReader.ReadLine();
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

            int[] xtrain = Enumerable.Range(1, 31).ToArray();
            int[] xtest = Enumerable.Range(1, 31).ToArray();
            int[] ytrain = Enumerable.Range(32, 1).ToArray();
            int[] ytest = Enumerable.Range(32, 1).ToArray();


            SVMProblem trainData = SVMProblemHelper.Load(path + @"\OP\Train.txt");
            SVMProblem testData = SVMProblemHelper.Load(path + @"\OP\Test.txt");

            trainData = trainData.Normalize(SVMNormType.L1);
            testData = testData.Normalize(SVMNormType.L1);

            SVMParameter parameter = new SVMParameter();
            parameter.Type = SVMType.NU_SVR;
            parameter.Kernel = SVMKernelType.RBF;
            parameter.C = 1;
            parameter.Gamma = 1;

            SVMModel model = SVM.Train(trainData, parameter);
            SVM.SaveModel(model, path + @"\OP\AADT_model.txt");
            //SVMModel model = SVM.LoadModel(@"\OP\AADT_model.txt");

            double[] testResults = testData.Predict(model);
            StreamWriter outputWriter = new StreamWriter(path + @"\OP\Output.txt");

            for (int i = 0; i < testData.Length; i++)
            {
                outputWriter.WriteLine(atrs[i] + " - " + testResults[i]);
            }
            outputWriter.Flush();
            outputWriter.Close();
            double[] target = new double[testData.Length];
            for (int i = 0; i < testData.Length; i++)
            {
                target[i] = SVM.Predict(model, testData.X[i]);
            }

            //double[] crossValidationResults; // output labels
            //int nFold = 4;
            //trainData.CrossValidation(parameter, nFold, out crossValidationResults);

            //double crossValidationAccuracy = trainData.EvaluateClassificationProblem(crossValidationResults);

            /*double accuracy = SVMHelper.EvaluateClassificationProblem(testData, target);

            Console.WriteLine("\n\nCross validation accuracy: " + crossValidationAccuracy);
            Console.WriteLine("Accuracy - " + accuracy);

            int[,] confusionMatrix;

            double testAccuracy = testData.EvaluateClassificationProblem(testResults, model.Labels, out confusionMatrix);


            Console.WriteLine("Key not found!!!!!!!");



            Console.WriteLine("\nTest accuracy: " + testAccuracy);

            Console.WriteLine("\nConfusion matrix:\n");
            Console.Write(String.Format("{0,6}", ""));
            for (int i = 0; i < model.Labels.Length; i++)
                Console.Write(String.Format("{0,5}", "(" + model.Labels[i] + ")"));
            //Console.WriteLine();
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                Console.Write(String.Format("{0,5}", "(" + model.Labels[i] + ")"));
                for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,5}", confusionMatrix[i, j]));
                Console.WriteLine();
            }
            */

            //Application.Run(new AADTForm());
            //Console.ReadLine();
        }
    }
}
