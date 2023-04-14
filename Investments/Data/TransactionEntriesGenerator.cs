using System;
using System.Collections.Generic;
using System.Linq;

namespace Investments.Data
{
	public static class TransactionEntriesGenerator
	{
		public static IList<TransactionEntry> GetTransactionEntries(DataContext context) 
		{ 
			var list = new List<TransactionEntry>();

			list.AddRange(Get1004MsftBuy(context));
			list.AddRange(Get0604CashTransfer(context));

			return list;
		}

		private static IList<TransactionEntry> Get1004MsftBuy(DataContext context)
		{
			var transaction = context.Transactions[0];
			var swedAccount = context.Accounts.FirstOrDefault(x => x.Name == "Põhikonto");
			var lhvAccount = context.Accounts.FirstOrDefault(x => x.Name == "LHV tavakonto");
			var stocksAccount = context.Accounts.FirstOrDefault(x => x.Name == "Aktsiad");

			var eur = context.Securables.GetByTicker("EUR");
			var usd = context.Securables.GetByTicker("USD");
			var msft = context.Securables.GetByTicker("MSFT");

			var list = new List<TransactionEntry>
			{
				// Ülekanne Swed => LHV 50 EUR (LHV-sse sisse)
				new TransactionEntry
				{
					TransactionId = "234923492349",
					Time = DateTime.Parse("2023-04-10 17:00:00"),
					OwningAccount = lhvAccount, // Põhikonto Swedbankis
					OtherAccount = swedAccount, // Tavaline konto LHV-s
					Amount = 50,
					Securable = eur, // EUR
					Type = TransactionTypeEnum.Transfer, // Tavaline ülekanne
					Transaction = transaction,
					Description = "Investeerimiseks"
				},

				// Ülekanne LHV tavakonto => LHV väärtpaberikonto (tavakontolt maha)
				new TransactionEntry
				{
					TransactionId = "56634563465456",
					Time = DateTime.Parse("2023-04-10 17:05:00"),
					OwningAccount = lhvAccount, // Tavaline konto LHV-s
					OtherAccount = stocksAccount, // Väärtpaberikonto LHV-s
					Amount = -50,
					Securable = eur, // EUR
					Type = TransactionTypeEnum.Transfer, // Tavaline ülekanne
					Transaction = transaction,
					Description = "MSFT ostmiseks"
				},

				// Ülekanne LHV tavakonto => LHV väärtpaberikonto (väärtpaberikontole)
				new TransactionEntry
				{
					TransactionId = "56634563465456",
					Time = DateTime.Parse("2023-04-10 17:05:00"),
					OwningAccount = stocksAccount, // Tavaline konto LHV-s
					OtherAccount = lhvAccount, // Väärtpaberikonto LHV-s
					Amount = 50,
					Securable = eur, // EUR
					Type = TransactionTypeEnum.Transfer, // Tavaline ülekanne
					Transaction = transaction,
					Description = "MSFT ostmiseks"
				},

				// Microsofti aktsia ostmine (eurod välja)
				new TransactionEntry
				{
					TransactionId = "7142234234",
					Time = DateTime.Parse("2023-04-10 17:07:00"),
					OwningAccount = stocksAccount, // Väärtpaberikonto LHV-s
					OtherAccount = stocksAccount, // Väärtpaberikonto LHV-s
					Amount = -40,
					Securable = eur, // EUR
					Type = TransactionTypeEnum.Buy, // Tavaline ülekanne
					Transaction = transaction,
					Description = "Ostuorder NY388473"
				},

				// Microsofti aktsia ostmine (Microsofti aktsiad sisse)
				new TransactionEntry
				{
					TransactionId = "7142234234",
					Time = DateTime.Parse("2023-04-10 17:07:00"),
					OwningAccount = stocksAccount, // Väärtpaberikonto LHV-s
					OtherAccount = stocksAccount, // Väärtpaberikonto LHV-s
					Amount = 0.171m,
					Securable = msft, // Microsoft
					Type = TransactionTypeEnum.Buy, // Tavaline ülekanne
					Transaction = transaction,
					Description = "Ostuorder NY388473"
				},

				// Teenustasu LHV-s aktsiate ostmise eest
				new TransactionEntry
				{
					TransactionId = "234923492349",
					Time = DateTime.Parse("2023-04-10 17:07:00"),
					OwningAccount = stocksAccount, // Väärtpaberikonto LHV-s
												 //ToAccount = Accounts[0], // Tavaline konto LHV-s
					Amount = -5,
					Securable = eur, // EUR
					Type = TransactionTypeEnum.ServiceFee, // Teenustasu
					Transaction = transaction,
					Description = "Teenustasu"
				}
			};

			transaction.Entries.AddRange(list);

			var accounts = list.Select(l => l.OwningAccount).Distinct();
			foreach(var account in accounts)
			{
				var entries = list.Where(l => l.OwningAccount == account).ToList();
				account.TransactionEntries.AddRange(entries);
			}

			return list;
		}

		private static IList<TransactionEntry> Get0604CashTransfer(DataContext context)
		{
			var eur = context.Securables.GetByTicker("EUR");
			var lhvAccount = context.Accounts.FirstOrDefault(x => x.Name == "LHV tavakonto");

			var list = new List<TransactionEntry>
			{
				// Ülekanne Swed => LHV 50 EUR (LHV-sse sisse)
				new TransactionEntry
				{
					TransactionId = "234923492349",
					Time = DateTime.Parse("2023-04-10 17:00:00"),
					OwningAccount = lhvAccount, // Põhikonto Swedbankis
					//OtherAccount = swedAccount, // Tavaline konto LHV-s
					Amount = 200,
					Securable = eur, // EUR
					Type = TransactionTypeEnum.Transfer, // Tavaline ülekanne
					Transaction = null,
					Description = "Varu"
				}
			};

			lhvAccount.TransactionEntries.AddRange(list);

			return list;
		}
	}
}
