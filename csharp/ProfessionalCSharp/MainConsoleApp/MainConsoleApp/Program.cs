using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainConsoleApp.Ch06;

namespace MainConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new[]
            {
                new ArrayTest()
            };

            int success = 0;
            int failed = 0;
            foreach (var test in tests)
            {
                bool ok = test.Run();
                if (ok)
                {
                    success++;
                }
                else
                {
                    failed++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Finished. Successes: " + success + ", Failed: " + failed);
        }
    }
}
