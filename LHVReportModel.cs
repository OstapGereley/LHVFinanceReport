using System;

namespace LHVFinanceReport
{
	public class LHVReportModel
	{
		public DateTime BookDate { get; set; }
		public DateTime TransactionDateTime { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public PaymentSide Side { get; set; }
		public string CounterpartyInfo { get; set; }

	}

	public enum PaymentSide
	{
		Debit = 1, 
		Credit = 2
	}
}
