using System;
using System.Linq;

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



		public override bool CanExecute( object parameter )
		{
			return _viewModel.Sources.Any()
				&& _viewModel.Targets.Any();
		}

		public override void Execute( object parameter )
		{
			_viewModel.SwapCurrencies();
		}
	}
}
