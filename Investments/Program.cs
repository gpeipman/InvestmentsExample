using System;
using Investments.Data;
using Investments.Printers;

namespace Investments
{
	class Program
    {
        private static readonly DataContext _context = new();

        static void Main()
        {
            DataGenerator.GenerateData(_context);

			var eur = _context.Securables.GetByTicker("EUR");
			var reportingDate = DateTime.Parse("2023-04-10");
            var targetSecurable = _context.Securables.GetByTicker("EUR");

            foreach(var account in _context.Accounts)
            {
                var builder = new AccountStatementBuilder(account);
                var statement = builder.Build();
                var columns = new[] { "TransactionId", "Time", "Account", "Amount", "Description", "Balance", "Currency" };
                var tablePrinter = new TextTablePrinter(columns);

                Console.WriteLine(account.Name);

                foreach(var entry in statement.Entries)
                {
                    tablePrinter.AddRow(entry.TransactionId, entry.Time, entry.OtherAccount?.Name, 
                                        entry.Amount, entry.Description?.SubstringSafe(0, 10), 
                                        entry.Balance, entry.Securable.Ticker);
                }

                Console.WriteLine(tablePrinter.ToString());

                //if(account.TransactionEntries.Count == 0)
                //{
                //    continue;
                //}

                //var balance = account.GetBalance(reportingDate);
                //if(!balance.Any(balance => balance.Amount != 0))
                //{
                //    continue;
                //}

                //var balance2 = account.GetBalance(reportingDate);

                //Console.Write(account.Name);
                //Console.WriteLine(": ");

                //foreach (var item in balance2)
                //{
                //    Console.Write("    ");
                //    Console.Write(item.Securable.Ticker);
                //    Console.Write(": ");
                //    Console.Write(item.Amount);

                //    if (item.Securable == targetSecurable)
                //    {
                //        Console.WriteLine("");
                //        continue;
                //    }

                //    Console.Write(" => ");
                //    Console.Write(targetSecurable.Ticker);
                //    Console.Write(": ");

                //    var rate = _context.ExchangeRates.GetRate(reportingDate, item.Securable, targetSecurable);
                //    if (rate != null)
                //    {
                //        Console.WriteLine(rate.Rate * item.Amount);
                //    }
                //    else
                //    {
                //        var rateConst = _context.ExchangeRates.Convert(reportingDate, item.Securable, targetSecurable);
                //        Console.WriteLine(rateConst * item.Amount);
                //    }
                //}

                //Console.Write("    Total: ");
                //Console.WriteLine(account.GetBalanceInTargetSecurable(reportingDate, eur, _context));

            }
        }
    }
}