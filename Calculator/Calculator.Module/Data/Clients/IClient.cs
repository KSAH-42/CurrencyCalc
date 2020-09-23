using System.Threading.Tasks;

namespace Calculator.Data.Clients
{
	public interface IClient
	{
		decimal CalculateCurrency( string source , string target , decimal amout );
		Task<decimal> CalculateCurrencyAsync( string source , string target , decimal amout );

		CurrencyList ListAllCurrencies();
		Task<CurrencyList> ListAllCurrenciesAsync();
	}
}
