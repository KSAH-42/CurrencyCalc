using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Calculator.Windows.Controllers
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate { };





		private bool _isDirty = false;






		public virtual bool IsDirty
		{
			get => GetField( ref _isDirty );
			set => SetField( ref _isDirty , value );
		}






		protected TValue GetField<TValue>( ref TValue memberValue , [CallerMemberName] string propertyName = null )
		{
			if ( string.IsNullOrWhiteSpace( propertyName ) )
			{
				throw new ArgumentNullException( nameof( propertyName ) );
			}

			return memberValue;
		}

		protected void SetField<TValue>( ref TValue memberValue , TValue value , [CallerMemberName] string propertyName = null )
		{
			if ( string.IsNullOrWhiteSpace( propertyName ) )
			{
				throw new ArgumentNullException( nameof( propertyName ) );
			}

			if ( memberValue is ValueType )
			{
				if ( memberValue.Equals( value ) )
				{
					return;
				}
			}
			else
			{
				if ( object.ReferenceEquals( memberValue , value ) )
				{
					return;
				}

				if ( memberValue != null && memberValue.Equals( value ) )
				{
					return;
				}
			}

			memberValue = value;

			OnPropertyChanged( new PropertyChangedEventArgs( propertyName ) );
		}









		protected virtual void OnPropertyChanged( PropertyChangedEventArgs e )
		{
			if ( e == null )
			{
				throw new ArgumentNullException( nameof( e ) );
			}

			if ( e.PropertyName != nameof( IsDirty ) )
			{
				_isDirty = true;
			}

			try
			{
				var handler = PropertyChanged;

				handler?.Invoke( this , e );
			}
			catch ( Exception ex )
			{
				System.Diagnostics.Debug.WriteLine( ex );
			}
		}
	}
}
