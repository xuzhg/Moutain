using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfInheritanceCodeFirst
{
    class Program
    {
        private static void Main(string[] args)
        {
            // CreateBillingModel();
            // QueryBillingModel();

            // CreateCustomerModel();

            Guid a = Guid.NewGuid();
            Type t = typeof(string);

            bool b = t.IsAssignableFrom(typeof (int));
            Console.WriteLine(b);

            //int i = 9;
            //string iaa = i;
            //    t.IsAssignableFrom()

            BillingDetail d = new BillingDetail();
            BankAccount ad = null;
            BillingCustomer customer = new BillingCustomer();

            if (null is BankAccount)
            {
                Console.WriteLine("null is BankAccount");
            }

            if (null is BillingCustomer)
            {
                Console.WriteLine("null is BillingCustomer");
            }

            if (customer.Billing is BillingDetail)
            {
                
            }

            if (customer.Billing is BillingDetail)
            {
                Console.Write("Billing is BillingDetail");
            }

            if (customer.Billing is CreditCard)
            {
                Console.Write("Billing is CreditCard");
            }

            if (customer.Billing is BankAccount)
            {
                Console.Write("Billing is BankAccount");
            }

            string sa = null;
            Console.WriteLine(sa.IndexOf("123", StringComparison.Ordinal));
        }

        private static void QueryBillingModel()
        {
            EfInheritanceContext db = new EfInheritanceContext();

            Console.WriteLine("Billing Item number: " + db.Billings.Count());

            foreach (var billing in db.Billings)
            {
                Console.WriteLine("\tBilling: " + billing.Id + ", " + billing.Number + ", " + billing.Owner);
            }
            Console.WriteLine();

            Console.WriteLine("CreditCard Item number: " + db.CreditCards.Count());
            foreach (var creditCard in db.CreditCards)
            {
                Console.WriteLine("\tCreditCard: " + creditCard.Id + ", " + creditCard.Number + ", " + creditCard.Owner + ", " + creditCard.CardType + "," +
                                  creditCard.ExpiryYear + ", " + creditCard.ExpiryMonth);
            }
            Console.WriteLine();

            Console.WriteLine("BankAccount Item number: " + db.BankAccounts.Count());
            foreach (var bankAccount in db.BankAccounts)
            {
                Console.WriteLine("\tBankAccount: " + bankAccount.Id + ", " + bankAccount.Number + ", " + bankAccount.Owner + ", " + bankAccount.BankName + "," +
                                  bankAccount.Swift);
            }
            Console.WriteLine();
        }


        private static void CreateBillingModel()
        {
            EfInheritanceContext db = new EfInheritanceContext();

            CreditCard cc = new CreditCard
            {
                CardType = CardType.CreditCard,
                ExpiryMonth = 11,
                ExpiryYear = 2015,
                Number = 11,
                Owner = "Owner"
            };

            db.CreditCards.Add(cc);
            db.Billings.Add(cc);


            BankAccount ba = new BankAccount
            {
                BankName = "CCNC",
                Number = 9,
                Owner = "CN",
                Swift = 88
            };
            db.BankAccounts.Add(ba);

            BillingDetail bd = new BillingDetail
            {
                Number = 101,
                Owner = "Billing"
            };

            db.Billings.Add(bd);

            db.SaveChanges();

        }

        private static void CreateCustomerModel()
        {
            EfInheritanceContext db = new EfInheritanceContext();

            VipCustomer cc = new VipCustomer
            {
                Name = "VipCustomer",
                VipNum = 999
            };

            db.Customers.Add(cc);

            SupperCustomer ba = new SupperCustomer
            {
                Name = "SupperCustomer",
                SupperNums = 888,
            };
            db.Customers.Add(ba);
            db.SaveChanges();
        }
    }
}
