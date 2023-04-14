using System;
using System.Collections.Generic;
using System.Linq;

namespace Investments
{
	public class Account
    {
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public AccountTypeEnum Type { get; set; }

        public Institution Institution { get; set; }

        public List<TransactionEntry> TransactionEntries { get; private set; } = new List<TransactionEntry>();

		public AccountBalance[] GetBalance()
        {
            return GetBalance(DateTime.Now);
        }

		public AccountBalance[] GetBalance(DateTime date)
        {
            var query = TransactionEntries.Where(entry => entry.Time.Date <= date.Date)
                                          .GroupBy(entry => entry.Securable)
                                          .Select(grp => new AccountBalance { Securable = grp.Key, Amount = grp.Sum(g => g.Amount) })
                                          .Where(grp => grp.Amount > 0)
                                          .ToArray();
            return query;
        }
    }
}
