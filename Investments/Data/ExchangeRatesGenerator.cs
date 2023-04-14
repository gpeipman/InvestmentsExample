using System;
using System.Collections.Generic;

namespace Investments.Data
{
	public static class ExchangeRatesGenerator
	{
		public static IList<ExchangeRate> GetExchangeRates(DataContext context) 
		{
			var list = new List<ExchangeRate>();

			list.AddRange(GetMsftUsd(context));
			list.AddRange(GetUsdEur(context));

			return list;
		}

		private static IList<ExchangeRate> GetMsftUsd(DataContext context)
		{
			var msft = context.Securables.GetByTicker("MSFT");
			var usd = context.Securables.GetByTicker("USD");

			var list = new List<ExchangeRate>
			{
				new ExchangeRate { Date = DateTime.Parse("2023-04-01"), Rate = 288.30m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-03"), Rate = 287.23m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-04"), Rate = 287.18m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-05"), Rate = 284.34m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-06"), Rate = 291.60m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-07"), Rate = 291.60m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-08"), Rate = 291.60m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-09"), Rate = 291.60m, From = msft, To = usd },
				new ExchangeRate { Date = DateTime.Parse("2023-04-10"), Rate = 289.39m, From = msft, To = usd }
			};

			return list;
		}

		private static IList<ExchangeRate> GetUsdEur(DataContext context)
		{
			var usd = context.Securables.GetByTicker("USD");
			var eur = context.Securables.GetByTicker("EUR");

			var list = new List<ExchangeRate>
			{
				new ExchangeRate { Date = DateTime.Parse("2023-04-01"), Rate = 0.92021m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-02"), Rate = 0.92422m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-03"), Rate = 0.91706m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-04"), Rate = 0.91257m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-05"), Rate = 0.91665m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-06"), Rate = 0.91605m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-07"), Rate = 0.90949m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-08"), Rate = 0.90951m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-09"), Rate = 0.90951m, From = usd, To = eur },
				new ExchangeRate { Date = DateTime.Parse("2023-04-10"), Rate = 0.92040m, From = usd, To = eur }
			};

			return list;
		}
	}
}
