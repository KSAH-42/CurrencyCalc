using Calculator.Data.Clients.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Calculator.Data.Clients
{
	/// <summary>
	/// The API documentation can found here:  https://www.frankfurter.app/docs/
	/// </summary>
	public sealed class FrankFurterClient : IClient, IDisposable
	{
		private readonly HttpClient _client = null;


		public FrankFurterClient( string baseAddress )
		{
			if ( string.IsNullOrWhiteSpace( baseAddress ) )
			{
				throw new ArgumentNullException( nameof( baseAddress ) );
			}

			_client = new HttpClient()
			{
				BaseAddress = new Uri( baseAddress ) ,
			};

			_client.DefaultRequestHeaders.Clear();
			_client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
		}

		public void Dispose()
		{
			_client.Dispose();
		}




		public decimal CalculateCurrency( string source , string target , decimal amout )
		{
			return CalculateCurrencyAsync( source , target , amout ).GetAwaiter().GetResult();
		}

		public async Task<decimal> CalculateCurrencyAsync( string source , string target , decimal amout )
		{
			var data = await _client.GetObjectAsync<CalculationResultsDto>( FrankFurterUriFactory.NewCalculateURI( source , target , amout ) );

			return data != null ? data.GetRate( target ) : 0;
		}

		public CurrencyList ListAllCurrencies()
		{
			return ListAllCurrenciesAsync().GetAwaiter().GetResult();
		}

		public async Task<CurrencyList> ListAllCurrenciesAsync()
		{
			var elements = await _client.GetObjectAsync<CurrencyInfoListDto>( FrankFurterUriFactory.NewListAllCurrenciesURI() );

			var results = new CurrencyList();

			if ( null != elements )
			{
				foreach ( var element in elements )
				{
					if ( !string.IsNullOrWhiteSpace( element.Key ) || string.IsNullOrWhiteSpace( element.Value ) )
					{
						results.Add( new Currency( element.Key , element.Value ) );
					}
				}
			}

			return results;
		}

	}
}
