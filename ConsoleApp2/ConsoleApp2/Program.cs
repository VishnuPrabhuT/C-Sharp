using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcdef";
            string sub = "bbb";
            string[] ss = new string[2] { s, sub };
            string longerStr = ss[Convert.ToInt32(s.Length < sub.Length)];
            string smallerStr = ss[Convert.ToInt32(s.Length > sub.Length)];
            int ptr = 0;
            for(int i=0; i < longerStr.Length; i++)
            {
                if (ptr >= smallerStr.Length)
                {
                    break;
                }
                if (smallerStr[ptr] == longerStr[i])
                {
                    ptr += 1;
                }
                else
                {
                    ptr = 0;
                }
                
            }
            Console.WriteLine(ptr >= smallerStr.Length);
            Console.Read();
        }
    }
}
