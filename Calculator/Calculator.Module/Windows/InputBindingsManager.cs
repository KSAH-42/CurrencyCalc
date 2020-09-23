using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Calculator.Windows
{
	public static class InputBindingsManager
	{
		public static readonly DependencyProperty UpdatePropertySourceWhenEnterPressedProperty = DependencyProperty.RegisterAttached("UpdatePropertySourceWhenEnterPressed", typeof(DependencyProperty), typeof(InputBindingsManager), new PropertyMetadata(null, OnUpdatePropertySourceWhenEnterPressedPropertyChanged));




		public static void SetUpdatePropertySourceWhenEnterPressed( DependencyObject dependencyObject , DependencyProperty value )
		{
			dependencyObject.SetValue( UpdatePropertySourceWhenEnterPressedProperty , value );
		}

		public static DependencyProperty GetUpdatePropertySourceWhenEnterPressed( DependencyObject dependencyObject )
		{
			return (DependencyProperty) dependencyObject.GetValue( UpdatePropertySourceWhenEnterPressedProperty );
		}

		private static void OnUpdatePropertySourceWhenEnterPressedPropertyChanged( DependencyObject dependencyObject , DependencyPropertyChangedEventArgs e )
		{
			var element = dependencyObject as UIElement;

			if ( element == null )
			{
				return;
			}

			if ( e.OldValue != null )
			{
				element.PreviewKeyDown -= HandlePreviewKeyDown;
			}

			if ( e.NewValue != null )
			{
				element.PreviewKeyDown += new KeyEventHandler( HandlePreviewKeyDown );
			}
		}

		private static void HandlePreviewKeyDown( object sender , KeyEventArgs e )
		{
			if ( e.Key == Key.Enter )
			{
				DoUpdateSource( e.Source );
			}
		}

		private static void DoUpdateSource( object source )
		{
			var element = source as UIElement;

			if ( element == null )
			{
				return;
			}

			var property = GetUpdatePropertySourceWhenEnterPressed(source as DependencyObject);

			if ( property == null )
			{
				return;
			}

			var binding = BindingOperations.GetBindingExpression( element , property );

			if ( binding != null )
			{
				binding.UpdateSource();
			}
		}
	}
}
