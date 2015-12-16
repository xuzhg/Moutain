using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleApp.Ch08
{
    internal struct Currency
    {
        public uint Dollars;
        public ushort Cents;

        public Currency(uint dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }

        public override string ToString()
        {
            return String.Format("${0}.{1,2:00}", Dollars, Cents);
        }

        public static string GetCurrencyUint()
        {
            return "Dollar";
        }

        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint) value;
                ushort cents = (ushort) ((value - dollars)*100);
                return new Currency(dollars, cents);
            }
        }

        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents/100.0f);
        }

        public static implicit operator uint(Currency value)
        {
            return value.Dollars;
        }
    }
}
