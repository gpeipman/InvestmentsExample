using System.Collections.Generic;

namespace Investments
{
	public class Account
    {
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public AccountTypeEnum Type { get; set; }

        public Institution Institution { get; set; }

        public List<TransactionEntry> TransactionEntries { get; private set; } = new List<TransactionEntry>();

		//public AccountBalance[] GetBalance()
  //      {
  //          return GetBalance(DateTime.Now);
  //      }

		//public AccountBalance[] GetBalance(DateTime date)
  //      {
  //          var query = TransactionEntries.Where(entry => entry.Time.Date <= date.Date)
  //                                        .GroupBy(entry => entry.Securable)
  //                                        .Select(grp => new AccountBalance { Securable = grp.Key, Amount = grp.Sum(g => g.Amount) })
  //                                        .Where(grp => grp.Amount > 0)
  //                                        .ToArray();
  //          return query;
  //      }

  //      public decimal GetBalanceInTargetSecurable(DateTime date, Securable targetSecurable, DataContext context)
  //      {
  //          var balance = GetBalance(date.Date);
  //          if (!balance.Any(balance => balance.Amount != 0))
  //          {
  //              return 0;
  //          }

  //          foreach (var item in balance)
  //          {
		//		if (item.Securable == targetSecurable)
		//		{
		//			continue;
		//		}

		//		var rate = context.ExchangeRates.GetRate(date, item.Securable, targetSecurable);
  //              var amount = 0m;
               
		//		if (rate != null)
		//		{
  //                  amount = rate.Rate * item.Amount;
		//		}
		//		else
		//		{
		//			var rateConst = context.ExchangeRates.Convert(date, item.Securable, targetSecurable) ?? 0;
		//			amount = rateConst * item.Amount;
		//		}

		//		item.Securable = targetSecurable;
  //              item.Amount = amount;
		//	}

  //          return balance.Sum(b => b.Amount);
  //      }
	}
}
