using System.Linq;
using Investments.Models;

namespace Investments
{
	public class AccountStatementBuilder
	{
		private readonly Account _account;

		public AccountStatementBuilder(Account account)
		{
			_account = account;
		}

		public AccountStatement Build()
		{
			var statement = new AccountStatement { Account = _account };

			BuildTransactionHistory(statement);

			return statement;
		}

		private void BuildTransactionHistory(AccountStatement statement)
		{
			var transactions = _account.TransactionEntries.OrderBy(entry => entry.Time);			
			var balance = 0m;

			foreach (var transaction in transactions)
			{
				balance += transaction.Amount;

				var entry = new AccountStatementEntry();
				entry.Amount = transaction.Amount;
				entry.Description = transaction.Description;
				entry.OtherAccount = transaction.OtherAccount;
				entry.OwningAccount = transaction.OwningAccount;
				entry.Time = transaction.Time;
				entry.Balance = balance;
				entry.Securable = transaction.Securable;

				statement.Entries.Add(entry);
			}
		}
	}
}