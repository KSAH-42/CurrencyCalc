using System.Windows.Input;

namespace Calculator.Windows.Controllers
{
	using Calculator.Windows.Commands;

	public sealed class PreferencesViewModel : BaseViewModel, IValidable
	{
		private string _baseAddress        = string.Empty;

		private string _defaultBaseAddress = string.Empty;


		private readonly ICommand _applyCommand = null;

		private readonly ICommand _resetCommand = null;



		public PreferencesViewModel()
		{
			_applyCommand = new ApplyPreferencesCommand( this );
			_resetCommand = new ResetPreferencesCommand( this );
		}

		public void Prepare()
		{
			if ( string.IsNullOrWhiteSpace( BaseAddress ) )
			{
				BaseAddress = DefaultBaseAddress;
			}
		}

		public ICommand ApplyCommand
		{
			get => _applyCommand;
		}

		public ICommand ResetCommand
		{
			get => _resetCommand;
		}



		public string BaseAddress
		{
			get => GetField( ref _baseAddress );
			set => SetField( ref _baseAddress , value ?? string.Empty );
		}

		public string DefaultBaseAddress
		{
			get => GetField( ref _defaultBaseAddress );
			set => SetField( ref _defaultBaseAddress , value ?? string.Empty );
		}


		public bool Validate()
		{
			if ( string.IsNullOrWhiteSpace( _baseAddress ) )
			{
				return false;
			}

			if ( string.IsNullOrWhiteSpace( _defaultBaseAddress ) )
			{
				return false;
			}

			return true;
		}


	}
}
