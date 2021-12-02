using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;

        public TransactionInMemoryRepository()
        {
            _transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions; 
            }

            return _transactions.Where(t => string.Equals(t.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDate(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions.Where(x => x.TimeStamp.Date == date.Date);
            }

            return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) && x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            int maxId = 1;
            if (_transactions != null && _transactions.Any())
            {
                maxId = _transactions.Max(x => x.TransactionId) + 1;
            }

            _transactions.Add(new Transaction
            {
                TransactionId = maxId,
                TimeStamp = DateTime.UtcNow,
                ProductId = productId,
                ProductName = productName,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName,
            });
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date);
            }

            return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.AddDays(1).Date);

        }
    }
}
