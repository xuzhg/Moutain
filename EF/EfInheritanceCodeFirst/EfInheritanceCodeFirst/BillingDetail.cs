using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EfInheritanceCodeFirst
{
    public class BillingCustomer
    {
        public int Id { get; set; }

        public BillingDetail Billing { get; set; }
    }

    public class BillingDetail
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public string Owner { get; set; }
    }

    public class CreditCard : BillingDetail
    {
        public CardType CardType { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }
    }

    public class BankAccount : BillingDetail
    {
        public string BankName { get; set; }

        public int Swift { get; set; }
    }

    public enum CardType
    {
        VSA,
        Master,
        CreditCard
    }

    public abstract class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class VipCustomer : Customer
    {
        public int VipNum { get; set; }
    }

    public class SupperCustomer : Customer
    {
        public int SupperNums { get; set; }
    }
}
