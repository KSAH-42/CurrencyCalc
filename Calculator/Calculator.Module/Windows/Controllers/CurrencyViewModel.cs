namespace Calculator.Windows.Controllers
{
	public sealed class CurrencyViewModel : BaseViewModel
	{
		private string _code        = string.Empty;

		private string _displayName = string.Empty;





		public string Code
		{
			get => GetField( ref _code );
			set => SetField( ref _code , value ?? string.Empty );
		}

		public string DisplayName
		{
			get => GetField( ref _displayName );
			set => SetField( ref _displayName , value ?? string.Empty );
		}


	}
}
