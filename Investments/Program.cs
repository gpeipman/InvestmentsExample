using System;
using System.Linq;
using Investments.Data;

namespace Investments
{
	class Program
    {
        private static readonly DataContext _contex = new();

        static void Main()
        {
            DataGenerator.GenerateData(_contex);

            var reportingDate = DateTime.Parse("2023-04-10");
            var targetSecurable = _contex.Securables.GetByTicker("EUR");

            foreach(var account in _contex.Accounts)
            {
                if(account.TransactionEntries.Count == 0)
                {
                    continue;
                }

                var balance = account.GetBalance(reportingDate);
                if(!balance.Any(balance => balance.Amount > 0))
                {
                    continue;
                }

				Console.Write(account.Name);
				Console.WriteLine(": ");

				foreach (var item in balance)
                {
                    Console.Write("    ");
                    Console.Write(item.Securable.Ticker);
                    Console.Write(": ");
                    Console.Write(item.Amount);

                    if(item.Securable == targetSecurable)
                    {
                        Console.WriteLine("");
                        continue;
                    }

                    Console.Write(" => ");
                    Console.Write(targetSecurable.Ticker);
                    Console.Write(": ");

                    var rate = _contex.ExchangeRates.GetRate(reportingDate, item.Securable, targetSecurable);
                    if(rate != null)
                    {
						Console.WriteLine(rate.Rate * item.Amount);
					}
                    else
                    {
                        var rateConst = _contex.ExchangeRates.Convert(reportingDate, item.Securable, targetSecurable);
                        Console.WriteLine(rateConst * item.Amount);
                    }
                }
            }
        }
    }
}