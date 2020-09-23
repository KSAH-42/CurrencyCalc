using System.Configuration;

namespace Calculator.Configuration
{
	public class ClientConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty( "baseAddress" , DefaultValue = ConfigurationConstants.FrankFurterApiAddress , IsRequired = true )]
		public string BaseAddress
		{
			get => this["baseAddress"] as string ?? string.Empty;
			set => this["baseAddress"] = value ?? string.Empty;
		}

	}
}
