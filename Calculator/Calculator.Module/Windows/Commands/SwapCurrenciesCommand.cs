using System;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class SwapCurrenciesCommand : Command
	{
		private readonly CalculatorViewModel _viewModel = null;




		public SwapCurrenciesCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override void Execute( object parameter )
		{
			_viewModel.SwapCurrencies();
		}
	}
}
