using System;
using System.Collections.Generic;
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
            Person p = new Person();
            Console.WriteLine(p.getName());
            Student s = new Student();
            s.setID(5);
            Console.WriteLine(s.getID());
            Console.Read();
        }
    }
}
