using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int x = p.printCxt().Result;
            Console.WriteLine(x);
            Console.ReadLine();
        }

        private async Task<int> printCxt()
        {
            int result = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(SynchronizationContext.Current == null);
                await Task.Delay(1000);
                Console.WriteLine(SynchronizationContext.Current == null);
            }

            result += 1;
            return result;
        }
    }
}
