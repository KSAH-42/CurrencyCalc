namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class LoadConfigurationCommand : Command
	{
		private readonly CalculatorViewModelConfigurationMapper _mapper = null;




		public LoadConfigurationCommand( CalculatorViewModel viewModel )
		{
			_mapper = new CalculatorViewModelConfigurationMapper( viewModel );
		}




		public override void Execute( object parameter )
		{
			_mapper.Load();

			_mapper.MapClientSettings();
			_mapper.MapCalculatorSettings();
		}
	}
}
