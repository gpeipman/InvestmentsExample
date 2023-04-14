using System.Collections.Generic;

namespace Investments.Data
{
	public static class SecurablesGenerator
	{
		public static List<Securable> GetSecurables()
		{
			var usd = new Securable { Ticker = "USD", Name = "USD" };
			var list = new List<Securable>
			{
				new Securable { Ticker = "EUR", Name = "Euro" },
				usd,
				new Securable { Ticker = "MSFT", Name = "Microsoft", BaseSecurable = usd },
				new Securable { Ticker = "AAPL", Name = "Apple" },
				new Securable { Ticker = "GOOG", Name = "Google" }
			};

			return list;
		}
	}
}
