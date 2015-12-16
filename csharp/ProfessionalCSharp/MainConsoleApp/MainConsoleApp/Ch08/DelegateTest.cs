using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleApp.Ch08
{
    public class DelegateTest : AbstractTest
    {
        private delegate string GetAString();

        public DelegateTest()
            : base("DelegateTest")
        {
        }

        protected override bool RunInternal()
        {
            int x = 40;
            //GetAString firstStringMethod = new GetAString(x.ToString);

            GetAString firstStringMethod = x.ToString;

            Type type = firstStringMethod.GetType();

            Console.WriteLine(firstStringMethod.GetType());

            Console.WriteLine("String is {0}", firstStringMethod());

            return true;
        }
    }
}
