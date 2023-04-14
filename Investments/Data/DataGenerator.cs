namespace Investments.Data
{
	public static class DataGenerator
	{
		public static void GenerateData(DataContext context)
		{
			context.Institutions.AddRange(InstitutionsGenerator.GetInstitutions());
			context.Accounts.AddRange(AccountsGenerator.GetAccounts(context));
			context.Securables.AddRange(SecurablesGenerator.GetSecurables());
			context.ExchangeRates.AddRange(ExchangeRatesGenerator.GetExchangeRates(context));
			context.Transactions.AddRange(TransactionsGenerator.GetTransactions());
			context.TransactionEntries.AddRange(TransactionEntriesGenerator.GetTransactionEntries(context));
		}
	}
}