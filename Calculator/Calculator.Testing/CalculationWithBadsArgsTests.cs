using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Testing
{
	using Calculator.Configuration;
	using Calculator.Data.Clients;

	[TestClass]
	public class CalculationWithBadsArgsTests
	{
		private IClient _client = null;


		[TestInitialize]
		public void Initialize()
		{
			_client = new FrankFurterClient( ConfigurationConstants.FrankFurterApiAddress );
		}

		[TestMethod]
		[Timeout(5000)]
		public void Should_ThowException_When_Args_Are_Same()
		{
			Assert.ThrowsException<ArgumentException>( () => _client.CalculateCurrency( "USD" , "USD" , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void Should_ThowException_When_Args_Equal_Null()
		{
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( null   , "EUR" , 1 ) );
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( "USD"  , null  , 1 ) );
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( null   , null , 1  ) );
			Assert.ThrowsException<ArgumentNullException>( () => _client.CalculateCurrency( "   " , "  " , 1 ) );
		}

		[TestMethod]
		[Timeout( 5000 )]
		public void Should_EqualToZero_When_Args_Has_Spaces()
		{
			Assert.AreEqual<decimal>( 0 , _client.CalculateCurrency( "  AUD  " , "  USD  " , 10000 ) );
		}


		[TestMethod]
		[Timeout( 5000 )]
		public void Should_EqualToZero_When_Args_Has_Unknown()
		{
			Assert.AreEqual<decimal>( 0 , _client.CalculateCurrency( "AZEZAE" , "IIIII" , 10000 ) );
		}
	}
}
