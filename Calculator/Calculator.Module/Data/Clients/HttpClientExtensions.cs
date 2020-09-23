using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calculator.Data.Clients
{
	public static class HttpClientExtensions
	{
		public static async Task<string> ReadTextAsync( this HttpClient client , string uri )
		{
			if ( string.IsNullOrWhiteSpace( uri ) )
			{
				throw new ArgumentNullException( nameof( uri ) );
			}

			using ( var response = await client.GetAsync( uri ).ConfigureAwait( false ) )
			{
				if ( response == null || !response.IsSuccessStatusCode )
				{
					return await Task.FromResult<string>( string.Empty );
				}

				return await response.Content.ReadAsStringAsync().ConfigureAwait( false ) ?? string.Empty;
			}
		}

		public static async Task<T> ReadAsync<T>( this HttpClient client , string uri )
		{
			if ( string.IsNullOrWhiteSpace( uri ) )
			{
				throw new ArgumentNullException( nameof( uri ) );
			}

			using ( var response = await client.GetAsync( uri ).ConfigureAwait( false ) )
			{
				if ( response == null || !response.IsSuccessStatusCode )
				{
					return await Task.FromResult<T>( default( T ) );
				}

				string text = await response.Content.ReadAsStringAsync().ConfigureAwait( false );

				if ( string.IsNullOrWhiteSpace( text ) )
				{
					return await Task.FromResult<T>( default( T ) );
				}

				T obj = await Task.Factory.StartNew( () => JsonConvert.DeserializeObject<T>( text ) ).ConfigureAwait( false );

				if ( null == obj )
				{
					return await Task.FromResult<T>( default( T ) );
				}

				return obj;
			}
		}
	}
}
