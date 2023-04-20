using System;
using System.Linq;
using Investments.Models;

namespace Investments
{
	public class AccountStatementBuilder
	{
		public Account Account { get; private set; }
		public DateTime? FromDate { get; private set; }
		public DateTime? ToDate { get; private set; }

		public AccountStatementBuilder(Account account, DateTime? fromDate, DateTime? toDate)
		{
			Account = account;
			FromDate = fromDate;
			ToDate = toDate;
		}

		public AccountStatement Build()
		{
			var statement = new AccountStatement { Account = Account };

			BuildHeader(statement);
			BuildTransactionHistory(statement);

			return statement;
		}

		private decimal GetBalanceForDate(DateTime date) 
		{
			var dateToUse = date.Date.AddDays(1).AddMicroseconds(1);

			return Account.TransactionEntries.Where(entry => entry.Time <= dateToUse)
											 .Sum(entry => entry.Amount);
		}

		private void BuildHeader(AccountStatement statement)
		{
			statement.Header.StartingBalance = GetBalanceForDate(DateTime.Now);
			statement.Header.Balance = GetBalanceForDate(DateTime.Now);
			statement.Header.FromDate = FromDate;
			statement.Header.ToDate = ToDate;
		}

		private void BuildTransactionHistory(AccountStatement statement)
		{
			var transactions = Account.TransactionEntries.OrderBy(entry => entry.Time);			
			var balance = 0m;

			foreach (var transaction in transactions)
			{
				balance += transaction.Amount;

				var entry = new AccountStatementEntry
				{
					Amount = transaction.Amount,
					Description = transaction.Description,
					OtherAccount = transaction.OtherAccount,
					OwningAccount = transaction.OwningAccount,
					Time = transaction.Time,
					Balance = balance,
					Securable = transaction.Securable
				};

				statement.Entries.Add(entry);
			}
		}
	}
}