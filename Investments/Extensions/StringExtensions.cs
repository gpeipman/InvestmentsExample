namespace Investments
{
	public static class StringExtensions
	{
		public static string SubstringSafe(this string str, int startIndex, int length)
		{
			if(startIndex + length > str.Length)
			{
				return str.Substring(startIndex);
			}

			return str.Substring(startIndex, length);
		}
	}
}
