using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleApp.Ch06
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            int result = String.CompareOrdinal(this.LastName, other.LastName);
            if (result == 0)
            {
                result = String.CompareOrdinal(this.FirstName, other.FirstName);
            }

            return result;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
