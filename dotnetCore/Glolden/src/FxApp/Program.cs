﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace FxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The answer is {new Thing().Get(42)} from .NET Framework.");
        }
    }
}
