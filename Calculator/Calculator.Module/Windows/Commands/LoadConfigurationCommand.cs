namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class LoadConfigurationCommand : Command
	{
		private readonly CalculatorViewModelConfigurationMapper _configMapper = null;




		public LoadConfigurationCommand( CalculatorViewModel viewModel )
		{
			_configMapper = new CalculatorViewModelConfigurationMapper( viewModel );
		}




		public override void Execute( object parameter )
		{
			_configMapper.Load();

			_configMapper.MapClientSettings();
			_configMapper.MapCalculatorSettings();
		}
	}
}
