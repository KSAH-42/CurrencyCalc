using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Calculator.Windows.Controllers
{
	using Calculator.Windows.Commands;

	public sealed class CalculatorViewModel : BaseViewModel, IValidable
	{
		private readonly ObservableCollection<CurrencyViewModel> _sources = new ObservableCollection<CurrencyViewModel>();

		private readonly ObservableCollection<CurrencyViewModel> _targets = new ObservableCollection<CurrencyViewModel>();

		private CurrencyViewModel _selectedSource = null;

		private CurrencyViewModel _selectedTarget = null;

		private decimal _amount = 0;

		private decimal _amountConverted = 0;

		private bool _isFetching = false;

		private bool _isConverting = false;

		private string _amountCurrencyCode = string.Empty;

		private bool _isLoading = false;

		private string _defaultCurrencySource = string.Empty;

		private string _defaultCurrencyTarget = string.Empty;

		private decimal _defaultAmout = 0;

		private string _baseAddress = string.Empty;




		private readonly ICommand _calculateCurrencyCommand = null;

		private readonly ICommand _queryAllCurrenciesCommand = null;

		private readonly ICommand _swapCurrenciesCommand = null;

		private readonly ICommand _resetAmountCommand = null;

		private readonly ICommand _increaseAmountCommand = null;

		private readonly ICommand _decreaseAmountCommand = null;

		private readonly ICommand _closeApplicationCommand = null;

		private readonly ICommand _saveConfigurationCommand = null;

		private readonly ICommand _loadConfigurationCommand = null;

		private readonly ICommand _showPreferencesCommand = null;



		public CalculatorViewModel()
		{
			_calculateCurrencyCommand = new CalculateCurrencyCommand( this );
			_queryAllCurrenciesCommand = new QueryAllCurrenciesCommand( this );
			_swapCurrenciesCommand = new SwapCurrenciesCommand( this );
			_resetAmountCommand = new ResetAmountCommand( this );
			_increaseAmountCommand = new IncreaseAmountCommand( this );
			_decreaseAmountCommand = new DecreaseAmountCommand( this );
			_closeApplicationCommand = new CloseApplicationCommand();
			_saveConfigurationCommand = new SaveConfigurationCommand( this );
			_loadConfigurationCommand = new LoadConfigurationCommand( this );
			_showPreferencesCommand = new ShowPreferencesCommand( this );
			_loadConfigurationCommand.Execute( null );
		}


		public ICommand CalculateCurrencyCommand
		{
			get => _calculateCurrencyCommand;
		}

		public ICommand QueryAllCurrenciesCommand
		{
			get => _queryAllCurrenciesCommand;
		}

		public ICommand SwapCurrenciesCommand
		{
			get => _swapCurrenciesCommand;
		}

		public ICommand ResetAmountCommand
		{
			get => _resetAmountCommand;
		}

		public ICommand IncreaseAmountCommand
		{
			get => _increaseAmountCommand;
		}

		public ICommand DecreaseAmountCommand
		{
			get => _decreaseAmountCommand;
		}

		public ICommand CloseApplicationCommand
		{
			get => _closeApplicationCommand;
		}

		public ICommand SaveConfigurationCommand
		{
			get => _saveConfigurationCommand;
		}

		public ICommand LoadConfigurationCommand
		{
			get => _loadConfigurationCommand;
		}

		public ICommand ShowPreferencesCommand
		{
			get => _showPreferencesCommand;
		}



		public string BaseAddress
		{
			get => GetField( ref _baseAddress );
			set => SetField( ref _baseAddress , value ?? string.Empty );
		}

		public string DefaultCurrencySource
		{
			get => GetField( ref _defaultCurrencySource );
			set => SetField( ref _defaultCurrencySource , value ?? string.Empty );
		}

		public string DefaultCurrencyTarget
		{
			get => GetField( ref _defaultCurrencyTarget );
			set => SetField( ref _defaultCurrencyTarget , value ?? string.Empty );
		}

		public decimal DefaultAmount
		{
			get => GetField( ref _defaultAmout );
			set => SetField( ref _defaultAmout , value );
		}

		public bool IsLoading
		{
			get => GetField( ref _isLoading );
			set => SetField( ref _isLoading , value );
		}

		public bool IsFetching
		{
			get => GetField( ref _isFetching );
			set => SetField( ref _isFetching , value );
		}

		public bool IsConverting
		{
			get => GetField( ref _isConverting );
			set => SetField( ref _isConverting , value );
		}

		public decimal Amount
		{
			get => GetField( ref _amount );
			set => SetField( ref _amount , value );
		}

		public decimal AmountConverted
		{
			get => GetField( ref _amountConverted );
			set => SetField( ref _amountConverted , value );
		}

		public CurrencyViewModel SelectedSource
		{
			get => GetField( ref _selectedSource );
			set => SetField( ref _selectedSource , value );
		}

		public CurrencyViewModel SelectedTarget
		{
			get => GetField( ref _selectedTarget );
			set => SetField( ref _selectedTarget , value );
		}

		public string AmountCurrencyCode
		{
			get => GetField( ref _amountCurrencyCode );
			set => SetField( ref _amountCurrencyCode , value ?? string.Empty );
		}

		public ObservableCollection<CurrencyViewModel> Targets
		{
			get => _targets;
		}



		public ObservableCollection<CurrencyViewModel> Sources
		{
			get => _sources;
		}


		public bool Validate()
		{
			if ( _amount <= 0 )
			{
				return false;
			}

			if ( null == _selectedSource || _selectedTarget == null )
			{
				return false;
			}

			if ( 0 == string.Compare( _selectedSource.Code , _selectedTarget.Code , true ) )
			{
				return false;
			}

			if ( string.IsNullOrWhiteSpace( _baseAddress ) )
			{
				return false;
			}

			return true;
		}

		public bool CanQueryCurrencies()
		{
			return !string.IsNullOrWhiteSpace( _baseAddress );
		}

		public bool CanIncreaseAmount()
		{
			return _amount < decimal.MaxValue;
		}

		public bool CanDecreaseAmount()
		{
			return _amount > 0;
		}

		public void IncreaseAmount()
		{
			IncreaseAmount( 1 );
		}

		public void IncreaseAmount( int value )
		{
			Amount += value;
		}

		public void DecreaseAmount()
		{
			DecreaseAmount( 1 );
		}

		public void DecreaseAmount( int value )
		{
			Amount -= value;
		}

		public void SwapCurrencies()
		{
			string sourceName = _selectedSource?.Code ?? string.Empty;
			string targetName = _selectedTarget?.Code ?? string.Empty;

			SelectSource( targetName );
			SelectTarget( sourceName );
		}

		public void SelectSource( string code )
		{
			if ( string.IsNullOrWhiteSpace( code ) )
			{
				SelectedSource = null;
				return;
			}

			foreach ( var element in _sources )
			{
				if ( 0 == string.Compare( element.Code ?? string.Empty , code ?? string.Empty , true ) )
				{
					SelectedSource = element;
					return;
				}
			}
		}

		public void SelectTarget( string code )
		{
			if ( string.IsNullOrWhiteSpace( code ) )
			{
				SelectedTarget = null;
				return;
			}

			foreach ( var element in _targets )
			{
				if ( 0 == string.Compare( element.Code ?? string.Empty , code ?? string.Empty , true ) )
				{
					SelectedTarget = element;
					return;
				}
			}
		}

		public void SelectFirstSource()
		{
			if ( _sources.Any() )
			{
				SelectedSource = _sources.FirstOrDefault();
			}
		}

		public void SelectFirstTarget()
		{
			if ( _targets.Any() )
			{
				SelectedTarget = _targets.FirstOrDefault();
			}
		}

		public void ClearAmount()
		{
			Amount = 0;
		}

		public void ClearAmountConverted()
		{
			AmountConverted = 0;
		}

		public void ClearSelectedCurrencies()
		{
			SelectedSource = null;
			SelectedTarget = null;
			AmountCurrencyCode = string.Empty;
		}

		public void ClearAllCurrencies()
		{
			SelectedSource = null; Sources.Clear();
			SelectedTarget = null; Targets.Clear();
			AmountCurrencyCode = string.Empty;
		}

		public void ClearAll()
		{
			IsFetching = false;
			IsConverting = false;
			Amount = 0;
			AmountConverted = 0;
			SelectedSource = null;
			SelectedTarget = null;
			AmountCurrencyCode = string.Empty;
			Sources.Clear();
			Targets.Clear();
		}

		public void Setup()
		{
			SelectSource( DefaultCurrencySource );
			SelectTarget( DefaultCurrencyTarget );
			Amount = DefaultAmount;
		}
	}
}
