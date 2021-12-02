using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext _db;
        public TransactionRepository(MarketContext db)
        {
            _db = db;
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _db.Transactions;
            }

            return _db.Transactions.Where(t => t.CashierName.ToLower() == cashierName.ToLower());

        }

        public IEnumerable<Transaction> GetByDate(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            }

            return _db.Transactions.Where(
                x => x.CashierName.ToLower() == cashierName.ToLower() && x.TimeStamp.Date == date.Date);

        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            Transaction trans = new Transaction
            {
                TimeStamp = DateTime.Now,
                ProductId = productId,
                ProductName = productName,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName,
            };

            _db.Transactions.Add(trans);
            _db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date);
            }

            return _db.Transactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower()
                && x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);

        }
    }
}
