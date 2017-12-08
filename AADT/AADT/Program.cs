using LibSVMsharp;
using LibSVMsharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Collections;

namespace AADT
{
    class Program
    {
        private static string GetLineData(ref StreamReader reader,string line)
        {
            List<double> factorList=new List<double>();
            int sumVal = 0;
            string resultString = string.Empty;
            while (line != null)
            {
                if (line.Contains("/2016") && !line.Contains("No Traffic Data is Available for Site"))
                {
                    DateTime date = DateTime.ParseExact(line, "d", CultureInfo.InvariantCulture);
                    string binaryMonth = Convert.ToString(date.Month, 2);
                    binaryMonth = binaryMonth.PadLeft(4, '0');
                    resultString += "-" + binaryMonth;
                    string binaryDayOfWeek = Convert.ToString(Convert.ToInt32(date.DayOfWeek) + 1, 2);
                    binaryDayOfWeek = binaryDayOfWeek.PadLeft(3, '0');
                    resultString += "-" + binaryDayOfWeek;
                }
                line = reader.ReadLine();
                if(line == null)
                {
                    break;
                }
                if (line.Contains(":") && !line.Contains("No Traffic Data is Available for Site"))
                {
                    if(line.Split(' ').Length < 5)
                    {
                        line += line + " 0";
                    }
                    int numVal = (line.Split(' ')[1]=="N/A"? 0 : Convert.ToInt32(line.Split(' ')[1])) + (line.Split(' ')[4] == "N/A" ? 0 : Convert.ToInt32(line.Split(' ')[4]));
                    factorList.Add(numVal);
                    sumVal += numVal;
                }
                if (line.Contains("/2016"))
                {
                    break;
                }
            }
            foreach (double i in factorList)
            {
                double factor = Math.Round(i / sumVal,5);
                resultString += "-" + factor.ToString();
            }
            return resultString;
        }
        private void ExtractData(string fileLocation)
        {            
            string line=string.Empty;
            string currentATR = fileLocation.Replace(@"C:\Users\Vishnu\Downloads\ATR_Data_2016\","").Replace(".txt","");
            if (currentATR == "0")
            {
                Console.WriteLine();
            }
            StreamReader reader = new StreamReader(fileLocation);
            //TextWriter writer = new StreamWriter(@"C:\Users\Vishnu\Desktop\Result.txt");
            List<string> resultList = new List<string>();
            while (line != null)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (line.Contains("/2016"))
                {
                    string resultString = currentATR+Program.GetLineData(ref reader, line);
                    resultList.Add(resultString);
                }                
            }
            TextWriter writer = File.AppendText(@"C:\Users\Vishnu\Desktop\Result.txt");
            foreach(string s in resultList)
            {
                writer.WriteLine(s);
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
            

            /*
            SVMProblem problem = SVMProblemHelper.Load(@"C:\Users\Vishnu\Desktop\1.txt");
            SVMProblem testProblem = SVMProblemHelper.Load(@"test_dataset_path.txt");

            SVMParameter parameter = new SVMParameter();
            parameter.Type = SVMType.C_SVC;
            parameter.Kernel = SVMKernelType.RBF;
            parameter.C = 1;
            parameter.Gamma = 1;

            SVMModel model = SVM.Train(problem, parameter);

            double[] target = new double[testProblem.Length];
            for (int i = 0; i < testProblem.Length; i++)
                target[i] = SVM.Predict(model, testProblem.X[i]);

            double accuracy = SVMHelper.EvaluateClassificationProblem(testProblem, target);
            */
        }
    }
}
