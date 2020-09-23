using System;
using System.Globalization;
using System.Windows.Data;

namespace Calculator.Windows.Converters
{
	public class DecimalStringConverter : IValueConverter
	{
		public object Convert( object value , Type targetType , object parameter , CultureInfo culture )
		{
			return ( value is decimal ) ? ( (decimal) value ).ToString( "0.00" , System.Globalization.CultureInfo.InvariantCulture )
										: string.Empty;
		}

		public object ConvertBack( object value , Type targetType , object parameter , CultureInfo culture )
		{
			if ( !string.IsNullOrWhiteSpace( value as string ) && decimal.TryParse( value.ToString() , NumberStyles.AllowDecimalPoint , CultureInfo.InvariantCulture , out decimal result ) )
			{
				return result;
			}

			return 0;
		}
	}
}
