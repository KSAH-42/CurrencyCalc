using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Testing
{
	using Calculator.Configuration;
	using Calculator.Data.Clients;

	[TestClass]
	public class ListAllCurrenciesTests
	{
		private IClient _client = null;


		[TestInitialize]
		public void Initialize()
		{
			_client = new FrankFurterClient( ConfigurationConstants.FrankFurterApiAddress );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void Should_CurrencyList_Expected_NotEmpty()
		{
			Assert.IsFalse( _client.ListAllCurrencies().IsEmpty , "We must have a none empty collection" );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void Should_CurrencyList_Expected_Contains_USD()
		{
			Assert.IsTrue( _client.ListAllCurrencies().Contains( "USD" ) , "Does not contains a global currency" );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void Should_CurrencyList_Expected_Contains_EUR()
		{
			Assert.IsTrue( _client.ListAllCurrencies().Contains( "EUR" ) , "Does not contains a global currency" );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void Should_CurrencyList_Expected_Not_Contains()
		{
			Assert.IsFalse( _client.ListAllCurrencies().Contains( "UNKNOWN" ) , "Should not contains this currency" );
		}


	}
}
