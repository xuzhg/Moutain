using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleApp
{
    public abstract class AbstractTest
    {
        public AbstractTest(string title)
        {
            Title = title;
        }

        private string Title { get; set; }

        public bool Run()
        {
            Console.WriteLine("\nRunning test cases from [ " + Title + "]");
            return RunInternal();
        }

        protected abstract bool RunInternal();
    }
}
