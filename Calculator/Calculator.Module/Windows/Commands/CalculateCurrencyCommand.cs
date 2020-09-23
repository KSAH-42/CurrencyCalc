using System;
using System.Threading.Tasks;

namespace Calculator.Windows.Commands
{
	using Calculator.Data.Clients;
	using Calculator.Windows.Controllers;

	public class CalculateCurrencyCommand : AsyncCommand
	{
		private readonly CalculatorViewModel _viewModel = null;




		public CalculateCurrencyCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override bool CanExecute( object parameter )
		{
			return _viewModel.Validate() && !_viewModel.IsConverting;
		}

		protected override async Task ExecuteAsync( object parameter )
		{
			_viewModel.ClearAmountConverted();
			_viewModel.IsConverting = true;

			try
			{
				using ( var client = new FrankFurterClient( _viewModel.BaseAddress ) )
				{
					_viewModel.AmountConverted = await client.CalculateCurrencyAsync( _viewModel.SelectedSource.Code , _viewModel.SelectedTarget.Code , _viewModel.Amount );
				}
			}
			catch ( Exception ex )
			{
				AlertBox.ShowError( ex );
			}

			_viewModel.AmountCurrencyCode = _viewModel.SelectedTarget?.Code;
			_viewModel.IsConverting = false;
		}
	}
}
