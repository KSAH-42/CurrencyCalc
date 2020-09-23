using System;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class ResetPreferencesCommand : Command
	{
		private readonly PreferencesViewModel _viewModel = null;




		public ResetPreferencesCommand( PreferencesViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override void Execute( object parameter )
		{
			_viewModel.BaseAddress = _viewModel.DefaultBaseAddress;
		}
	}
}
