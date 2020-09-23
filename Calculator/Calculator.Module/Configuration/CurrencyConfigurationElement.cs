using System.Configuration;

namespace Calculator.Configuration
{
	public sealed class CurrencyConfigurationElement : ConfigurationElement
	{
		[ConfigurationProperty( "code" , IsKey = true , IsRequired = true , DefaultValue = "" )]
		public string Code
		{
			get => this["code"] as string ?? string.Empty;
			set => this["code"] = value ?? string.Empty;
		}

		[ConfigurationProperty( "displayName" , DefaultValue = "" )]
		public string DisplayName
		{
			get => this["displayName"] as string ?? string.Empty;
			set => this["displayName"] = value ?? string.Empty;
		}
	}
}
