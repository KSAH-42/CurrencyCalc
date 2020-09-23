using System;

namespace Calculator.Data
{
	public sealed class Currency
	{
		public readonly static Currency   Empty           = new Currency();


		private readonly string           _code           = string.Empty;

		private readonly string           _displayName    = string.Empty;




		private Currency()
		{
		}


		public Currency( string code )
			: this( code , string.Empty )
		{

		}

		public Currency( string code , string displayName )
		{
			if ( string.IsNullOrWhiteSpace( code ) )
			{
				throw new ArgumentNullException( nameof( code ) );
			}

			_code = code;
			_displayName = displayName ?? string.Empty;
		}





		public string Code
		{
			get => _code;
		}

		public string DisplayName
		{
			get => _displayName;
		}
	}
}
