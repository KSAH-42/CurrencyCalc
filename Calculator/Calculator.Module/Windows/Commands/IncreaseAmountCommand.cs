using System;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class IncreaseAmountCommand : Command
	{
		private readonly CalculatorViewModel _viewModel = null;




		public IncreaseAmountCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override bool CanExecute( object parameter )
		{
			return _viewModel.CanIncreaseAmount();
		}

		public override void Execute( object parameter )
		{
			_viewModel.IncreaseAmount();
		}
	}
}
