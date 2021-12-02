using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Transaction
    {
        public int TransactionId { get; set; }

      //  [Required]
        public DateTime TimeStamp { get; set; }

     //   [Required]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

     //   [Required]
        public double? Price { get; set; }

      //  [Required]
        public int BeforeQty { get; set; }

        public int SoldQty { get; set; }

        public string CashierName { get; set; }
    }
}
