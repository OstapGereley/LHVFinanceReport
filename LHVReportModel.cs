using System;

namespace LHVFinanceReport
{
	public class LHVReportModel
	{
		public DateTime TransactionDateTime { get; set; }
		public decimal Amount { get; set; }
		public override string ToString()
		{
			return Amount.ToString();
		}
	}
}
