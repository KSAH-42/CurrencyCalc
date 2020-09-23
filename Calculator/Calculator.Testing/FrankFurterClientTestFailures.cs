using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Testing
{
	using Calculator.Configuration;
	using Calculator.Data.Clients;

	[TestClass]
	public class FrankFurterClientTestFailures
	{
		private IClient _client = null;


		[TestInitialize]
		public void Initialize()
		{
			_client = new FrankFurterClient( ConfigurationConstants.FrankFurterApiAddress );
		}

		[TestMethod]
		[Timeout(5000)]
		public void TestArgumentException()
		{
			Assert.ThrowsException<ArgumentException>( () => _client.CalculateCurrency( "USD" , "USD" , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestArgumentNullException()
		{
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( null   , "EUR" , 1 ) );
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( "USD"  , null  , 1 ) );
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( null   , null , 1  ) );
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( "   " , "  " , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestBadCurrency1()
		{
			Assert.AreEqual<decimal>( 0 , _client.CalculateCurrency( "  AUD  " , "  USD  " , 10000 ) );
		}


		[TestMethod]
		[Timeout( 5000 )]
		public void TestBadCurrency2()
		{
			Assert.AreEqual<decimal>( 0 , _client.CalculateCurrency( "AZEZAE" , "IIIII" , 10000 ) );
		}
	}
}
