using System;
using System.Configuration;

namespace Calculator.Configuration
{
	public sealed class CurrencyConfigurationElementCollection : ConfigurationElementCollection
	{
		public CurrencyConfigurationElementCollection()
		{
		}



		public CurrencyConfigurationElement this[int index]
		{
			get => GetElementAt( index );
		}



		protected override ConfigurationElement CreateNewElement()
		{
			return new CurrencyConfigurationElement();
		}

		protected override object GetElementKey( ConfigurationElement element )
		{
			if ( element is CurrencyConfigurationElement )
			{
				return ( (CurrencyConfigurationElement) element ).Code;
			}

			throw new ArgumentException( nameof( element ) );
		}

		public void AddElement( CurrencyConfigurationElement element )
		{
			if ( element == null )
			{
				return;
			}

			BaseAdd( element );
		}

		public CurrencyConfigurationElement GetElement( string code )
		{
			if ( string.IsNullOrWhiteSpace( code ) )
			{
				return null;
			}

			return BaseGet( code ) as CurrencyConfigurationElement;
		}

		public CurrencyConfigurationElement GetElementAt( int index )
		{
			if ( index < 0 || index >= Count )
			{
				return null;
			}

			return BaseGet( index ) as CurrencyConfigurationElement;
		}

		public void Clear()
		{
			BaseClear();
		}
	}
}
