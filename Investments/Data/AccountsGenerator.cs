using System.Collections.Generic;

namespace Investments.Data
{
	public static class AccountsGenerator
	{
		public static IList<Account> GetAccounts(DataContext context)
		{
			var list = new List<Account>
			{
				new Account { Name = "Põhikonto", Institution = context.Institutions.GetByName("Swedbank"), Type = AccountTypeEnum.BankAccount },
				new Account { Name = "LHV tavakonto", Institution = context.Institutions.GetByName("LHV"), Type = AccountTypeEnum.BankAccount },
				new Account { Name = "Aktsiad", Institution = context.Institutions.GetByName("LHV"), Type = AccountTypeEnum.StockAccount }
			};

			return list;
		}
	}
}