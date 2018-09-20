

using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace LHVFinanceReport
{
	public sealed class SideConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if(value is PaymentSide side)
			{
				return side == PaymentSide.Credit ? new SolidColorBrush(Color.FromArgb(255, 0, 128, 0)) : new SolidColorBrush(Color.FromArgb(255, 128, 0, 0));
			}
			return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
