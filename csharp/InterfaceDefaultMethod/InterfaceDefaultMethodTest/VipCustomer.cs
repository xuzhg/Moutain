using InterfaceDefaultMethodLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDefaultMethodTest
{
    internal class VipCustomer : DefaultCustomer, ICustomer
    {
        public VipCustomer(string name, DateOnly birthday, double discountRate) : base(name, birthday)
        {
            DiscountRate = discountRate;
        }

        public double DiscountRate { get; }

        public override string ToString()
        {
            return $"{Name}: 'VIP'\n\t|-VIP customer, Birthday at: {Birthday}:\n\t|-DiscountRate is {DiscountRate}\n";
        }

        public  string GetDisplay() => "VIP";
    }
}
