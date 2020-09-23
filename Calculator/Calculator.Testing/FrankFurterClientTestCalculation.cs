using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Testing
{
	using Calculator.Configuration;
	using Calculator.Data.Clients;

	/*
	 I don't if we can add equality tests here because, it is possible that the value of currency can change depending the currency market
	 AFAIK, USD doesn't change, but currency values can change every days excepts when the market is closed during the sunday
	 */


	[TestClass]
	public class FrankFurterClientTestCalculation
	{
		private IClient _client = null;


		[TestInitialize]
		public void Initialize()
		{
			_client = new FrankFurterClient( ConfigurationConstants.FrankFurterApiAddress );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestCalculate1()
		{
			Assert.AreNotEqual<decimal>( 0 , _client.CalculateCurrency( "AUD" , "USD" , 1 ) );
		}

		[TestMethod]
		[Timeout(5000)]
		public void TestCalculate2()
		{
			Assert.AreNotEqual<decimal>( 0 , _client.CalculateCurrency( "USD" , "EUR" , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestCalculate3()
		{
			Assert.AreNotEqual<decimal>( 0 ,  _client.CalculateCurrency( "EUR" , "USD" , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestCalculate4()
		{
			Assert.AreNotEqual<decimal>( 0 , _client.CalculateCurrency( "USD" , "AUD" , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestCalculate5()
		{
			Assert.AreEqual<decimal>( 0 , _client.CalculateCurrency( "USD" , "AUD" , 0 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void TestCalculate6()
		{
			Assert.AreEqual<decimal>( 0 , _client.CalculateCurrency( "AUD" , "USD" , 0 ) );
		}

		
	}
}
