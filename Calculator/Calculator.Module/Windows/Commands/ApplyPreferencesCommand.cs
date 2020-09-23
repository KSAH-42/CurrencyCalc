using System;
using System.Windows;

namespace Calculator.Windows.Commands
{
	using Calculator.Windows.Controllers;

	public class ApplyPreferencesCommand : Command
	{
		private readonly PreferencesViewModel _viewModel = null;




		public ApplyPreferencesCommand( PreferencesViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override bool CanExecute( object parameter )
		{
			return _viewModel.Validate();
		}

		public override void Execute( object parameter )
		{
			var dialog = parameter as Window;

			if ( null != dialog )
			{
				dialog.DialogResult = true;
				dialog.Close();
			}
		}
	}
}
