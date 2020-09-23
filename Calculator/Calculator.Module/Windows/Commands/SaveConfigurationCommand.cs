using System.Windows;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class SaveConfigurationCommand : Command
	{
		private readonly CalculatorViewModelConfigurationMapper _configMapper = null;




		public SaveConfigurationCommand( CalculatorViewModel viewModel )
		{
			_configMapper = new CalculatorViewModelConfigurationMapper( viewModel );
		}




		public override void Execute( object parameter )
		{
			if ( AlertBox.Prompt( "Would you like to save the configuration ?" , "Save application settings" ) )
			{
				_configMapper.UnMapClientSettings();
				_configMapper.UnMapCalculatorSettings();

				_configMapper.Save();
			}
		}
	}
}
