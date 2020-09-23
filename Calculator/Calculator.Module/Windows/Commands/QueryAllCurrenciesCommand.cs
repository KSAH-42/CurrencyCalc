using System;
using System.Collections.Generic;
using System.Windows;

namespace Calculator.Windows.Commands
{
	using Calculator.Data.Clients;
	using Calculator.Windows.Controllers;

	public class QueryAllCurrenciesCommand : Command
	{
		private readonly CalculatorViewModel _viewModel = null;




		public QueryAllCurrenciesCommand( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}




		public override bool CanExecute( object parameter )
		{
			return _viewModel.CanQueryCurrencies();
		}

		public async override void Execute( object parameter )
		{
			_viewModel.ClearAllCurrencies();
			_viewModel.ClearAmountConverted();

			_viewModel.IsFetching = true;

			try
			{
				var sources = new List<CurrencyViewModel>();
				var targets = new List<CurrencyViewModel>();

				using ( var client = new FrankFurterClient( _viewModel.BaseAddress ) )
				{
					var currencies = await client.ListAllCurrenciesAsync();

					if ( currencies == null || currencies.IsEmpty )
					{
						MessageBox.Show( "There is no currencies available" , "Information" , MessageBoxButton.OK , MessageBoxImage.Information );

						return;
					}

					foreach ( var currency in currencies )
					{
						sources.Add( new CurrencyViewModel() { Code = currency.Code , DisplayName = currency.DisplayName } );
						targets.Add( new CurrencyViewModel() { Code = currency.Code , DisplayName = currency.DisplayName } );
					}
				}

				foreach ( var element in sources )
				{
					_viewModel.Sources.Add( element );
				}

				foreach ( var element in targets )
				{
					_viewModel.Targets.Add( element );
				}

				_viewModel.SelectFirstSource();
				_viewModel.SelectFirstTarget();
			}
			catch ( Exception ex )
			{
				AlertBox.ShowError( ex );
			}

			_viewModel.IsFetching = false;
		}
	}
}
