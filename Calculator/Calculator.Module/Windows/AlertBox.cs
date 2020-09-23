using System;
using System.Windows;

namespace Calculator.Windows
{
	public static class AlertBox
	{
		public static void ShowDebug( string message )
		{
			ShowDebug( message , "Debug" );
		}

		public static void ShowDebug( string message , string caption )
		{
#if DEBUG
			Show( message , caption , MessageBoxButton.OK , MessageBoxImage.Asterisk );
#endif
		}

		public static void ShowDebug( Exception exception )
		{
			ShowDebug( exception , "Debug" );
		}

		public static void ShowDebug( Exception exception , string caption )
		{
#if DEBUG
			if ( null == exception )
			{
				return;
			}

			Show( exception.Message , caption , MessageBoxButton.OK , MessageBoxImage.Asterisk );
#endif
		}

		public static void ShowInfo( string message )
		{
			ShowInfo( message , "Informations" );
		}

		public static void ShowInfo( string message , string caption )
		{
			Show( message , caption , MessageBoxButton.OK , MessageBoxImage.Information );
		}

		public static void ShowWarning( string message )
		{
			ShowWarning( message , "Warning" );
		}

		public static void ShowWarning( string message , string caption )
		{
			Show( message , caption , MessageBoxButton.OK , MessageBoxImage.Warning );
		}

		public static void ShowError( string message )
		{
			ShowError( message , "Error" );
		}

		public static void ShowError( string message , string caption )
		{
			Show( message , caption , MessageBoxButton.OK , MessageBoxImage.Error );
		}

		public static void ShowError( Exception exception )
		{
			ShowError( exception , "Error" );
		}

		public static void ShowError( Exception exception , string caption )
		{
			if ( null == exception )
			{
				return;
			}

			Show( exception.Message , caption , MessageBoxButton.OK , MessageBoxImage.Error );
		}

		public static bool Prompt( string message , string caption )
		{
			return Show( message , caption , MessageBoxButton.YesNo , MessageBoxImage.Question ) == MessageBoxResult.Yes;
		}

		private static MessageBoxResult Show( string message , string caption , MessageBoxButton buttons , MessageBoxImage image )
		{
			return MessageBox.Show( message , caption , buttons , image );
		}


	}
}
