using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Testing
{
	using Calculator.Configuration;
	using Calculator.Data.Clients;

	[TestClass]
	public class FrankFurterClientTestQueries
	{
		private IClient _client = null;


		[TestInitialize]
		public void Initialize()
		{
			_client = new FrankFurterClient( ConfigurationConstants.FrankFurterApiAddress );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestListAllCurrencies1()
		{
			Assert.IsFalse( _client.ListAllCurrencies().IsEmpty , "We must have a none empty collection" );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestListAllCurrencies2()
		{
			Assert.IsTrue( _client.ListAllCurrencies().Contains( "USD" ) , "Does not contains a global currency" );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestListAllCurrencies3()
		{
			Assert.IsTrue( _client.ListAllCurrencies().Contains( "EUR" ) , "Does not contains a global currency" );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestListAllCurrencies4()
		{
			Assert.IsFalse( _client.ListAllCurrencies().Contains( "UNKNOWN" ) , "Should not contains this currency" );
		}


	}
}
