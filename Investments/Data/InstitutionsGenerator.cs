using System.Collections.Generic;

namespace Investments.Data
{
	public static class InstitutionsGenerator
	{
		public static IList<Institution> GetInstitutions()
		{
			var list = new List<Institution>
			{
				new Institution { Name = "LHV" },
				new Institution { Name = "Swedbank" },
				new Institution { Name = "Binance" }
			};

			return list;
		}
	}
}