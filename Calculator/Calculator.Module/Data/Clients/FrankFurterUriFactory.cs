using System;

namespace Calculator.Data.Clients
{
	public static class FrankFurterUriFactory
	{
		public static string NewCalculateURI( string currencySource , string currencyTarget , decimal amount )
		{
			if ( string.IsNullOrWhiteSpace( currencySource ) )
			{
				throw new ArgumentNullException( nameof( currencySource ) );
			}

			if ( string.IsNullOrWhiteSpace( currencyTarget ) )
			{
				throw new ArgumentNullException( nameof( currencyTarget ) );
			}

			if ( 0 == string.Compare( currencySource , currencyTarget , true ) )
			{
				throw new ArgumentException( "can't not convert when currencies are the sames" );
			}

			return $"latest?amount={amount.ToString( "0.00" , System.Globalization.CultureInfo.InvariantCulture )}&from={currencySource}&to={currencyTarget}";
		}

		public static string NewListAllCurrenciesURI()
		{
			return "currencies";
		}
	}
}
