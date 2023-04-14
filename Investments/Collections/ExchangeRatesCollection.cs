using System;
using System.Collections.Generic;
using System.Linq;

namespace Investments
{
	public class ExchangeRatesCollection : List<ExchangeRate>
    {
        public ExchangeRate GetRate(DateTime date, Securable fromSecurable, Securable toSecurable)
        {
            return this.Where(rate => rate.Date == date.Date &&
                                      rate.From == fromSecurable &&
                                      rate.To == toSecurable)
                       .FirstOrDefault();
        }

        public decimal? Convert(DateTime date, Securable fromSecurable, Securable toSecurable)
        {
            var rate = GetRate(date, fromSecurable, toSecurable);
            if(rate != null)
            {
                return rate.Rate;
            }

            var rates = this.Where(rate => rate.Date == date.Date &&
                                           rate.From == fromSecurable)
                            .ToList();

            foreach(var rateToCheck in rates)
            {
                var finalRate = GetRate(date, rateToCheck.To, toSecurable);
                if(finalRate != null)
                {
                    return rateToCheck.Rate * finalRate.Rate;
                }
            }

            return null;
        }
    }
}