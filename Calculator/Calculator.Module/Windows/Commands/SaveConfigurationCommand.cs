using System.Windows;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class SaveConfigurationCommand : Command
	{
		private readonly CalculatorViewModelConfigurationMapper _mapper = null;




		public SaveConfigurationCommand( CalculatorViewModel viewModel )
		{
			_mapper = new CalculatorViewModelConfigurationMapper( viewModel );
		}




		public override void Execute( object parameter )
		{
			if ( MessageBox.Show( "Would you like to save the configuration ?" , "Save application settings" , MessageBoxButton.YesNo , MessageBoxImage.Question ) != MessageBoxResult.Yes )
			{
				return;
			}

			_mapper.UnMapClientSettings();
			_mapper.UnMapCalculatorSettings();
			_mapper.Save();
		}
	}
}
