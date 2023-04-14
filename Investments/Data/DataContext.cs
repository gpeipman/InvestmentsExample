using System.Collections.Generic;

namespace Investments.Data
{
	public class DataContext
	{
		public InstitutionsCollection Institutions { get; private set; } = new InstitutionsCollection();
		public List<Account> Accounts { get; private set; } = new List<Account>();
		public SecurablesCollection Securables { get; private set; } = new SecurablesCollection();
		public ExchangeRatesCollection ExchangeRates { get; private set; } = new ExchangeRatesCollection();
		public List<Transaction> Transactions { get; private set; } = new List<Transaction>();
		public List<TransactionEntry> TransactionEntries { get; private set; } = new List<TransactionEntry>();
	}
}