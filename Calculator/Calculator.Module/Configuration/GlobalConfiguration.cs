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
			s_configuration = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
		}

		public static void Save()
		{
			if ( null != s_configuration )
			{
				s_configuration?.Save();
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
