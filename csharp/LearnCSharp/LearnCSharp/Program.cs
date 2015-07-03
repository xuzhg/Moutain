using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ToBase64();
        }

        private static void ToBase64()
        {
            byte[] myBytes = {1, 2, 4};
            string base64 = Convert.ToBase64String(myBytes);

            Console.WriteLine(base64);
        }
    }
}
