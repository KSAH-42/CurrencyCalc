using System;

namespace Calculator.Windows.Controllers
{
	using Calculator.Configuration;

	/// <summary>
	/// Represent a simple class used to map configuration object to view model
	/// </summary>
	internal sealed class CalculatorViewModelConfigurationMapper
	{
		private readonly CalculatorViewModel _viewModel = null;


		public CalculatorViewModelConfigurationMapper( CalculatorViewModel viewModel )
		{
			_viewModel = viewModel ?? throw new ArgumentNullException( nameof( viewModel ) );
		}



		public void Load()
		{
			GlobalConfiguration.Load();
		}

		public void Save()
		{
			GlobalConfiguration.Save();
		}

		public void MapClientSettings()
		{
			var section = GlobalConfiguration.GetSection<ClientConfigurationSection>();

			if ( section != null )
			{
				_viewModel.BaseAddress = section.BaseAddress;
			}
		}

		public void MapCalculatorSettings()
		{
			var section = GlobalConfiguration.GetSection<CalculatorConfigurationSection>();

			if ( section != null )
			{
				_viewModel.Amount = section.Amount;

				foreach ( CurrencyConfigurationElement currency in section.Sources )
				{
					_viewModel.Sources.Add( new CurrencyViewModel() { Code = currency.Code , DisplayName = currency.DisplayName } );
				}

				foreach ( CurrencyConfigurationElement currency in section.Targets )
				{
					_viewModel.Targets.Add( new CurrencyViewModel() { Code = currency.Code , DisplayName = currency.DisplayName } );
				}

				_viewModel.SelectSource( section.SelectedSource );
				_viewModel.SelectTarget( section.SelectedTarget );
			}
		}




		// ------------------------------------------------------------------------------------------------



		public void UnMapClientSettings()
		{
			var section = GlobalConfiguration.GetSection<ClientConfigurationSection>();

			if ( section != null )
			{
				section.BaseAddress = _viewModel.BaseAddress;
			}
		}

		public void UnMapCalculatorSettings()
		{
			var section = GlobalConfiguration.GetSection<CalculatorConfigurationSection>();

			if ( section != null )
			{
				section.Amount = _viewModel.Amount;
				section.SelectedSource = _viewModel.SelectedSource?.Code;
				section.SelectedTarget = _viewModel.SelectedTarget?.Code;

				section.Sources.Clear();

				foreach ( var currency in _viewModel.Sources )
				{
					section.Sources.AddElement( new CurrencyConfigurationElement() { Code = currency.Code , DisplayName = currency.DisplayName } );
				}

				section.Targets.Clear();

				foreach ( var currency in _viewModel.Targets )
				{
					section.Targets.AddElement( new CurrencyConfigurationElement() { Code = currency.Code , DisplayName = currency.DisplayName } );
				}
			}
		}
	}
}
