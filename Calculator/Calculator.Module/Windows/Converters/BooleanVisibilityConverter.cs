using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Calculator.Windows.Converters
{
	public class BooleanVisibilityConverter : IValueConverter
	{
		public object Convert( object value , Type targetType , object parameter , CultureInfo culture )
		{
			return ( value is bool ) && value.Equals( true ) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack( object value , Type targetType , object parameter , CultureInfo culture )
		{
			return ( value is Visibility ) && value.Equals( Visibility.Visible );
		}
	}
}
