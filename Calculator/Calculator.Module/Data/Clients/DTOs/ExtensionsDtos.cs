﻿
namespace Calculator.Data.Clients.DTOs
{
	internal static class ExtensionsDtos
	{
		public static decimal GetRate( this CalculationResultsDto dto , string currency )
		{
			if ( string.IsNullOrWhiteSpace( currency ) )
			{
				return 0;
			}

			var rates = dto.Rates;

			if ( null == rates )
			{
				return 0;
			}

			if ( rates.TryGetValue( currency , out decimal value ) )
			{
				return value;
			}

			return 0;
		}
	}
}
