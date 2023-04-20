using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Investments
{
	public class ExchangeRatesCollection : IList<ExchangeRate>
	{
		private readonly List<ExchangeRate> _rates = new();

		public void Add(ExchangeRate item)
		{
			if(_rates.Contains(item))
			{
				throw new Exception("Item already exists in collection: " + item.Date + ", " + item.From.Ticker + " => " + item.To.Ticker);
			}

			_rates.Add(item);
		}

		public void AddRange(IEnumerable<ExchangeRate> rates)
		{
			foreach(var rate in rates)
			{  
				Add(rate); 
			}
		}

		public int Count
		{
			get { return _rates.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public ExchangeRate this[int i]
		{
			get { return _rates[i]; }
			set { _rates[i] = value; }
		}

		public ExchangeRate GetRate(DateTime date, Securable fromSecurable, Securable toSecurable)
        {
            return this.Where(rate => rate.Date == date.Date &&
                                      rate.From == fromSecurable &&
                                      rate.To == toSecurable)
                       .FirstOrDefault();
        }

        public decimal? Convert(DateTime date, Securable fromSecurable, Securable toSecurable)
        {
            if(fromSecurable == toSecurable)
            {
                return 1;
            }

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

		public int IndexOf(ExchangeRate item)
		{
			return _rates.IndexOf(item);
		}

		public void Insert(int index, ExchangeRate item)
		{
			_rates.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			_rates.RemoveAt(index);
		}

		public void Clear()
		{
			_rates.Clear();
		}

		public bool Contains(ExchangeRate item)
		{
			return _rates.Contains(item);
		}

		public void CopyTo(ExchangeRate[] array, int arrayIndex)
		{
			_rates.CopyTo(array, arrayIndex);
		}

		public bool Remove(ExchangeRate item)
		{
			return _rates.Remove(item);
		}

		public IEnumerator<ExchangeRate> GetEnumerator()
		{
			return _rates.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _rates.GetEnumerator();
		}
	}
}