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

namespace AADT
{
    class Program
    {
        public static double totalSum { get; set; }
        public Hashtable countHash = new Hashtable();
        private static string GetLineData(ref StreamReader reader,string line)
        {
            List<double> factorList=new List<double>();
            int sumVal = 0;
            string resultString = string.Empty;
            int dayVolumeCount = 0;
            while (line != null)
            {
                if (line.Contains("/2016") && !line.Contains("No Traffic Data is Available for Site"))
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
                }
                line = reader.ReadLine();
                if(line == null)
                {
                    return "Skip!";
                }
                if (line.Contains(":") && !line.Contains("No Traffic Data is Available for Site"))
                {
                    if(line.Split(' ').Length < 5)
                    {
                        line += line + " 0";
                    }
                    int numVal = (line.Split(' ')[1]=="N/A"? 0 : Convert.ToInt32(line.Split(' ')[1])) + (line.Split(' ')[4] == "N/A" ? 0 : Convert.ToInt32(line.Split(' ')[4]));
                    if (numVal == 0)
                    {
                        return "Skip!";
                    }
                    factorList.Add(numVal);
                    sumVal += numVal;
                }
                if (line.Contains("/2016"))
                {
                    break;
                }
            }
            dayVolumeCount = sumVal;
            totalSum += sumVal;
            foreach (double i in factorList)
            {
                double factor = Math.Round(i / sumVal,5);
                resultString += factor.ToString()+"-";
            }
            return resultString+"#"+dayVolumeCount.ToString();
        }
        private void ExtractData(string fileLocation)
        {            
            string line=string.Empty;
            totalSum = 0;
            string currentATR = fileLocation.Replace(@"C:\Users\Vishnu\Downloads\ATR_Data_2016\","").Replace(".txt","");
            StreamReader reader = new StreamReader(fileLocation);
            //TextWriter writer = new StreamWriter(@"C:\Users\Vishnu\Desktop\Result.txt");
            List<string> resultList = new List<string>();
            Hashtable aadtVal = new Hashtable();
            int count = 0;
            while (line != null)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (line.Contains("/2016"))
                {
                    string resultString = currentATR + "-" + Program.GetLineData(ref reader, line);
                    if (resultString.Length > 27 && resultString!="Skip!")
                    {
                        resultList.Add(resultString);
                        count++;
                        aadtVal.Add(currentATR.ToString()+"->"+count.ToString(), resultString.Substring(resultString.IndexOf('#')+1));
                        resultString = resultString.Remove(resultString.IndexOf('#'));
                    }
                }                
            }
            TextWriter writer = File.AppendText(@"C:\Users\Vishnu\Desktop\OP\Result.txt");
            if (count > 180)
            {
                int decr=1;
                foreach (string s in resultList)
                {
                    double AADTFactor=Math.Round(Convert.ToInt32(aadtVal[currentATR.ToString() + "->" + (decr++).ToString()]) / (totalSum / count),3);
                    writer.WriteLine(s.Remove(s.IndexOf('#'))+ AADTFactor.ToString());
                }
            }
            else
            {
                Console.WriteLine(currentATR);
            }
            writer.Flush();
            reader.Close();
            writer.Close();
        }
        static void Main(string[] args)
        {
            int[] interstate = { 14, 15, 16, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 34, 42, 43, 46, 49, 50, 51, 52, 53, 54, 55, 56, 69, 70, 71, 72, 77, 80, 81, 84, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 106, 108, 109, 110, 111, 112, 113, 114, 115, 116, 118, 120, 121, 123, 124, 125, 126, 127, 128, 132, 137, 138, 139, 142, 145, 146, 150, 157 };
            int[] rural_arterial = { 1, 2, 4, 5, 9, 11, 36, 37, 38, 44, 48, 57, 58, 60, 61, 62, 63, 64, 67, 68, 74, 76, 82, 83, 105, 107, 117, 119, 122, 131, 133, 134, 135, 136, 140, 141, 149 };
            int[] urban_arterial = { 3, 6, 7, 8, 12, 13, 18, 30, 35, 40, 45, 47, 59, 66, 85, 104, 129, 130, 143, 144, 147, 148 };
            int[] arterial = { 1, 9, 11, 12, 13, 18, 30, 35, 36, 37, 38, 40, 44, 45, 47, 48, 57, 58, 59, 60, 61, 62, 63, 64, 66, 67, 68, 74, 76, 82, 83, 85, 104, 105, 107, 117, 119, 122, 129, 130, 131, 133, 134, 135, 136, 140, 141, 143, 144, 147, 148, 149 };
            int[] rural_collector = { 10, 17, 39, 65, 73, 75, 151, 158, 166 };
            int[] urban_collector = { 41, 152, 155, 159, 160, 162 };
            int[] local = { 153, 154, 156, 161, 163, 164, 165 };
            int[] collector = {10, 17, 39, 41, 65, 73, 75, 151,152,153,154,155,156, 158,159,160,161,162,163,164,165,166};
            int[] short_term = { 98, 145, 102, 50, 110 };
            int[] allATR = Enumerable.Range(1, 166).ToArray();
            int[] pilot = allATR.Except(short_term).ToArray();
            int[] pilot_interstate = interstate.Except(short_term).ToArray();
            int[] AADT = new int[166];
            int[] ATR = new int[166];

            string basePath = @"C:\Users\Vishnu\Downloads\ATR_Data_2016\";
            Program p = new Program();
            foreach(int i in allATR)
            {
                p.ExtractData(basePath+i.ToString()+".txt");
            }

            
            List<int> inputATR = new List<int>();
            List<int> trainATR = new List<int>();
            List<int> testATR = new List<int>();
            StreamReader streamReader = new StreamReader(@"C:\Users\Vishnu\Desktop\OP\Result.txt");
            string line = streamReader.ReadLine();
            while (line != null)
            {
                if (!inputATR.Contains(Convert.ToInt32(line.Substring(0,line.IndexOf('-')).ToString()))) 
                {
                    inputATR.Add(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString()));
                }                
                //Console.WriteLine(line);   
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            int x = inputATR.Count();
            int trainIndex = Convert.ToInt32(x * (0.80));
            int testIndex = x - trainIndex;
            StreamWriter trainWriter = new StreamWriter(@"C:\Users\Vishnu\Desktop\OP\Train.txt");
            StreamWriter testWriter = new StreamWriter(@"C:\Users\Vishnu\Desktop\OP\Test.txt");
            foreach (int i in Enumerable.Range(0, trainIndex))
            {
                trainATR.Add(inputATR[i]);
            }
            foreach (int i in Enumerable.Range(trainIndex, x - trainIndex))
            {
                testATR.Add(inputATR[i]);
            }
            streamReader = new StreamReader(@"C:\Users\Vishnu\Desktop\OP\Result.txt");
            line = streamReader.ReadLine();
            while (line != null)
            {
                string atr = line.Substring(0, line.IndexOf('-'));
                int colonCount = 1;
                if (trainATR.Contains(Convert.ToInt32(line.Substring(0, line.IndexOf('-')).ToString())))
                {                                       
                    string temp = String.Empty;
                    line = line.Remove(0, line.IndexOf('-')+1);
                    temp = atr;
                    string[] tempArr = line.Split('-');
                    foreach(string s in tempArr)
                    {
                       temp += " " + colonCount++.ToString() + ":" + s;                        
                    }
                    trainWriter.WriteLine(temp);
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
                    testWriter.WriteLine(temp);
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

            SVMProblem trainData = SVMProblemHelper.Load(@"C:\Users\Vishnu\Desktop\OP\Train.txt");
            SVMProblem testData = SVMProblemHelper.Load(@"C:\Users\Vishnu\Desktop\OP\Test.txt");

            trainData = trainData.Normalize(SVMNormType.L2);
            testData = testData.Normalize(SVMNormType.L2);

            SVMParameter parameter = new SVMParameter();
            parameter.Type = SVMType.C_SVC;
            parameter.Kernel = SVMKernelType.RBF;
            parameter.C = 1;
            parameter.Gamma = 1;


            double[] crossValidationResults; // output labels
            int nFold = 4;
            trainData.CrossValidation(parameter, nFold, out crossValidationResults);

            double crossValidationAccuracy = trainData.EvaluateClassificationProblem(crossValidationResults);

            

            SVMModel model = SVM.Train(trainData, parameter);
            SVM.SaveModel(model, @"C:\Users\Vishnu\Desktop\OP\AADT_model.txt");

            double[] testResults = testData.Predict(model);

            double[] target = new double[testData.Length];
            for (int i = 0; i < testData.Length; i++)
                target[i] = SVM.Predict(model, testData.X[i]);

            double accuracy = SVMHelper.EvaluateClassificationProblem(testData, target);

            Console.WriteLine("\n\nCross validation accuracy: " + crossValidationAccuracy);
            Console.WriteLine("Accuracy - " + accuracy);

            /*int[,] confusionMatrix;
            try
            {
                double testAccuracy = testData.EvaluateClassificationProblem(testResults, model.Labels, out confusionMatrix);
            }
            catch (Exception e)
            {
                Console.WriteLine("Key not found!!!!!!!");
            }

            
            Console.WriteLine("\nTest accuracy: " + testAccuracy);
            Console.WriteLine("\nConfusion matrix:\n");

            Console.Write(String.Format("{0,6}", ""));
            for (int i = 0; i < model.Labels.Length; i++)
                Console.Write(String.Format("{0,5}", "(" + model.Labels[i] + ")"));
            Console.WriteLine();
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                Console.Write(String.Format("{0,5}", "(" + model.Labels[i] + ")"));
                for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,5}", confusionMatrix[i, j]));
                Console.WriteLine();
            }
            */

            
            Console.ReadLine();
        }
    }
}
