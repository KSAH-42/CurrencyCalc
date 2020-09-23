using System;
using System.Configuration;

namespace Calculator.Configuration
{
	static class GlobalConfiguration
	{
		private static System.Configuration.Configuration s_configuration = null;




		static GlobalConfiguration()
		{
			Load();
		}




		public static void Load()  // public void static ReLoad()
		{
			try
			{
				s_configuration = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
			}
			catch ( Exception ex )
			{
				System.Diagnostics.Debug.WriteLine( ex );
			}
		}

		public static void Save()
		{
			if ( null != s_configuration )
			{
				return;
			}

			try
			{
				s_configuration.Save();
			}
			catch ( Exception ex )
			{
				System.Diagnostics.Debug.WriteLine( ex );
			}
		}

		public static TSection GetSection<TSection>()
			where TSection : ConfigurationSection
		{
			if ( s_configuration == null )
			{
				return null;
			}

			foreach ( var section in s_configuration.Sections )
			{
				if ( section is TSection )
				{
					return section as TSection;
				}
			}

			return null;
		}

		public static TSection GetSection<TSection>( string name )
			where TSection : ConfigurationSection
		{
			if ( s_configuration == null || string.IsNullOrWhiteSpace( name ) )
			{
				return null;
			}

			return s_configuration.GetSection( name ) as TSection;
		}


	}
}
