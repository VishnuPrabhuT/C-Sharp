using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concepts
{
    public class Person
    {
        public string getName() { return name; }
        public void setName(string n) { name = n; }
        private string name { get; set; }
    }

    class Student : Person
    {
        public int getID() { return id; }
        public void setID(int n) { id = n; }
        private int id;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person();
            //Console.WriteLine(p.getName());
            //Student s = new Student();
            //s.setID(5);
            //Console.WriteLine(s.getID());
            string[] strArr = File.ReadAllLines(@"C:\Users\vishnu\Desktop\15004441_ISM2019-02-09-759.xml");
            string content = string.Join("", strArr);

            //Parallel.ForEach(content.Split(new string[] { "xmlns=\"http://www.naxml.org/POSBO/Vocabulary/2003-10-16\"" }, StringSplitOptions.None), (text) =>
            //{
            int pos = content.IndexOf("xmlns=\"http://www.naxml.org/POSBO/Vocabulary/2003-10-16\"");
            Console.WriteLine(pos);
            Console.WriteLine(content.Substring(pos, "xmlns=\"http://www.naxml.org/POSBO/Vocabulary/2003-10-16\"".Length));
            content = (pos > 0)
                            ? new StringBuilder(content).Replace(
                                    "xmlns=\"http://www.naxml.org/POSBO/Vocabulary/2003-10-16\""
                                    , ""
                                    , pos
                                    , "xmlns=\"http://www.naxml.org/POSBO/Vocabulary/2003-10-16\"".Length
                                  ).ToString()
                            : content;
            
            //}
            //);

            //foreach(string text in content.Split(new string[] { "xmlns" }, StringSplitOptions.None))
            //{
            //    Console.WriteLine(text.IndexOf("xmlns=\"http://www.naxml.org/POSBO/Vocabulary/2003-10-16\""));
            //}


            Console.Read();

        }
    }
}
