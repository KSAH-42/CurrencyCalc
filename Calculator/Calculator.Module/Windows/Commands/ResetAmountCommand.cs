using System;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class ResetAmountCommand : Command
	{
		private readonly CalculatorViewModel _viewModel = null;




		public ResetAmountCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override void Execute( object parameter )
		{
			_viewModel.ClearAmount();
			_viewModel.ClearAmountConverted();
		}
	}
}
