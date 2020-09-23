using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Data
{
	public sealed class CurrencyList : IEnumerable<Currency>
	{
		private readonly IDictionary<string,Currency> _collection = new Dictionary<string,Currency>();


		public CurrencyList()
		{
		}



		public int Count
		{
			get => _collection.Count;
		}

		public bool IsEmpty
		{
			get => _collection.Count == 0;
		}





		public Currency this[int index]
		{
			get => GetAt( index );
		}

		public Currency this[string code]
		{
			get => Get( code );
		}





		public IEnumerator<Currency> GetEnumerator()
		{
			return _collection.Values.ToList().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _collection.Values.ToList().GetEnumerator();
		}

		public bool Contains( string code )
		{
			return _collection.ContainsKey( code ?? string.Empty );
		}

		public bool Contains( Currency element )
		{
			if ( null == element )
			{
				return false;
			}

			return _collection.Values.Contains( element );
		}

		public bool Add( Currency element )
		{
			if ( element == null || object.ReferenceEquals( element , Currency.Empty ) )
			{
				return false;
			}

			if ( _collection.ContainsKey( element.Code ) )
			{
				return false;
			}

			_collection[element.Code] = element;

			return true;
		}

		public int AddRange( IEnumerable<Currency> collection )
		{
			if ( collection == null )
			{
				return 0;
			}

			int results = 0;

			foreach ( var element in collection )
			{
				if ( element == null || object.ReferenceEquals( element , Currency.Empty ) )
				{
					continue;
				}

				if ( _collection.ContainsKey( element.Code ) )
				{
					continue;
				}

				_collection[element.Code] = element;

				++results;
			}

			return results;
		}

		public Currency Find( string code )
		{
			if ( _collection.TryGetValue( code ?? string.Empty , out Currency result ) )
			{
				return result;
			}

			return null;
		}

		public Currency FindAt( int index )
		{
			if ( index < 0 || index >= _collection.Values.Count )
			{
				return null;
			}

			return _collection.Values.ElementAt( index );
		}

		public Currency Get( string code )
		{
			return Find( code ) ?? Currency.Empty;
		}

		public Currency GetAt( int index )
		{
			return FindAt( index ) ?? Currency.Empty;
		}

		public IList<Currency> GetAll()
		{
			return _collection.Values.ToList();
		}

		public IList<Currency> GetAll( Func<Currency , bool> predicate )
		{
			if ( predicate == null )
			{
				throw new ArgumentNullException( nameof( predicate ) );
			}

			return _collection.Values.Where( predicate ).ToList();
		}

		public bool Remove( string code )
		{
			return _collection.Remove( code ?? string.Empty );
		}

		public bool RemoveAt( int index )
		{
			if ( index < 0 || index >= _collection.Count )
			{
				return false;
			}

			return _collection.Remove( _collection.ElementAt( index ).Key ?? string.Empty );
		}

		public void Clear()
		{
			_collection.Clear();
		}
	}
}
