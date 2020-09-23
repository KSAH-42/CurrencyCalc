using System;
using System.Collections.Generic;

namespace Calculator.Data.Clients.DTOs
{
	using Newtonsoft.Json;

	public sealed class CalculationResultsDto
	{
		[JsonProperty( "amount" )]
		public decimal Amout
		{
			get;
			set;
		}

		[JsonProperty( "base" )]
		public string Base
		{
			get;
			set;
		}

		[JsonProperty( "date" )]
		public DateTime Date
		{
			get;
			set;
		}

		[JsonProperty( "rates" )]
		public IDictionary<string , decimal> Rates
		{
			get;
			set;
		}
	}
}
