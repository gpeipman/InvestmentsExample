using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Investments.Printers
{
	// Credits: genert.org - https://genert.org/blog/csharp-programming/
	public class TextTablePrinter
	{
		private readonly List<object> _columns;
		private readonly List<object[]> _rows;

		public TextTablePrinter(params string[] columns)
		{
			if (columns == null || columns.Length == 0)
			{
				throw new ArgumentException("Parameter cannot be null nor empty", nameof(columns));
			}

			_columns = new List<object>(columns);
			_rows = new List<object[]>();
		}

		public void AddRow(params object[] values)
		{
			if (values == null)
			{
				throw new ArgumentException("Parameter cannot be null", nameof(values));
			}

			if (values.Length != _columns.Count)
			{
				throw new Exception("The number of values in row does not match columns count.");
			}

			_rows.Add(values);
		}

		public override string ToString()
		{
			var tableString = new StringBuilder();
			List<int> columnsLength = GetColumnsMaximumStringLengths();

			var rowStringFormat = Enumerable
				.Range(0, _columns.Count)
				.Select(i => " | {" + i + ",-" + columnsLength[i] + "}")
				.Aggregate((total, nextValue) => total + nextValue) + " |";

			string columnHeaders = string.Format(rowStringFormat, _columns.ToArray());
			List<string> results = _rows.Select(row => string.Format(rowStringFormat, row)).ToList();

			int maximumRowLength = Math.Max(0, _rows.Any() ? _rows.Max(row => string.Format(rowStringFormat, row).Length) : 0);
			int maximumLineLength = Math.Max(maximumRowLength, columnHeaders.Length);

			string dividerLine = string.Join("", Enumerable.Repeat("-", maximumLineLength - 1));
			string divider = $" {dividerLine} ";

			tableString.AppendLine(divider);
			tableString.AppendLine(columnHeaders);

			foreach (var row in results)
			{
				tableString.AppendLine(divider);
				tableString.AppendLine(row);
			}

			tableString.AppendLine(divider);

			return tableString.ToString();
		}

		private List<int> GetColumnsMaximumStringLengths()
		{
			var columnsLength = new List<int>();

			for (int i = 0; i < _columns.Count; i++)
			{
				var columnRow = new List<object>();
				int max = 0;

				columnRow.Add(_columns[i]);

				for (int j = 0; j < _rows.Count; j++)
				{
					columnRow.Add(_rows[j][i]);
				}

				for (int n = 0; n < columnRow.Count; n++)
				{
					int len = (columnRow[n] ?? "").ToString().Length;

					if (len > max)
					{
						max = len;
					}
				}

				columnsLength.Add(max);
			}

			return columnsLength;
		}
	}
}