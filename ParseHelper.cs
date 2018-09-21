using System;
using System.Text.RegularExpressions;

namespace LHVFinanceReport
{
	public static class ParseHelper
    {
		public static DateTime ParseDate(string str)
		{
			var a = new Regex(@"(\d\d\d\d-\d\d-\d\d \d\d:\d\d)");
			var match = a.Match(str);
			if(match.Success)
			{
				return DateTime.Parse(match.Value);
			}
			return new DateTime();
		}
    }
}
