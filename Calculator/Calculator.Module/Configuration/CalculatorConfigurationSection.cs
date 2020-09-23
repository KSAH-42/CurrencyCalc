using System.Configuration;

namespace Calculator.Configuration
{
	public class CalculatorConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty( "amount" , DefaultValue = "1.0" )]
		public decimal Amount
		{
			get => (decimal) this["amount"];
			set => this["amount"] = value;
		}

		[ConfigurationProperty( "selectedSource" , DefaultValue = "USD" )]
		public string SelectedSource
		{
			get => this["selectedSource"] as string ?? string.Empty;
			set => this["selectedSource"] = value ?? string.Empty;
		}

		[ConfigurationProperty( "selectedTarget" , DefaultValue = "EUR" )]
		public string SelectedTarget
		{
			get => this["selectedTarget"] as string ?? string.Empty;
			set => this["selectedTarget"] = value ?? string.Empty;
		}


		[ConfigurationProperty( "targets" )]
		[ConfigurationCollection( typeof( CurrencyConfigurationElementCollection ) , AddItemName = "add" , RemoveItemName = "remove" , ClearItemsName = "clear" )]
		public CurrencyConfigurationElementCollection Targets
		{
			get => this["targets"] as CurrencyConfigurationElementCollection;
		}

		[ConfigurationProperty( "sources" )]
		[ConfigurationCollection( typeof( CurrencyConfigurationElementCollection ) , AddItemName = "add" , RemoveItemName = "remove" , ClearItemsName = "clear" )]
		public CurrencyConfigurationElementCollection Sources
		{
			get => this["sources"] as CurrencyConfigurationElementCollection;
		}
	}
}
