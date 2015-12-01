using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfInheritanceCodeFirst
{
    public class EfInheritanceContext : DbContext
    {
        public DbSet<BillingDetail> Billings { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }


        // abstract
        public DbSet<Customer> Customers { get; set; }

        //public DbSet<VipCustomer> VipCustomers { get; set; }

        //public DbSet<SupperCustomer> SupperCustomers { get; set; }
    }

    public class EfInheritanceContextBase : DbContext
    {
        
    }
}
