using System;

namespace ConsoleApp1
{
    class Program
    {
        static string PrintChar(string str)
        {
            if(String.IsNullOrEmpty(str))
            {
                return "";
            }
            Console.Write(str[0] + "\n");
            return PrintChar(str.Substring(1));
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Vishnu");
            Console.ReadLine();
        }
    }
}

