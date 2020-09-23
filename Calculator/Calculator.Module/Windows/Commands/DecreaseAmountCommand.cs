using System;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class DecreaseAmountCommand : Command
	{
		private readonly CalculatorViewModel _viewModel = null;




		public DecreaseAmountCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override bool CanExecute( object parameter )
		{
			return _viewModel.CanDecreaseAmount();
		}

		public override void Execute( object parameter )
		{
			_viewModel.DecreaseAmount();
		}
	}
}
