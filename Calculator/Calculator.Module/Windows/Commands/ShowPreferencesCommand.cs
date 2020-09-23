using System;
using System.Windows;

namespace Calculator.Windows.Commands
{
	using Calculator.Configuration;
	using Calculator.Windows.Controllers;
	using Calculator.Windows.Views.Dialogs;

	public class ShowPreferencesCommand : Command
	{
		private readonly CalculatorViewModel _viewModel = null;




		public ShowPreferencesCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override void Execute( object parameter )
		{
			var dataContext = new PreferencesViewModel()
			{
				BaseAddress        = _viewModel.BaseAddress,
				DefaultBaseAddress = ConfigurationConstants.FrankFurterApiAddress,
			};

			var dialog      = new PreferencesDialog()
			{
				Owner       = Window.GetWindow( Application.Current.MainWindow ) ,
				DataContext = dataContext,
			};
			
			if ( dialog.ShowDialog() == true )
			{
				_viewModel.BaseAddress = dataContext.BaseAddress;
			}
		}
	}
}
