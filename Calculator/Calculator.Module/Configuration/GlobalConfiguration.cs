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




		public static bool IsLoaded
		{
			get => s_configuration != null;
		}




		public static void Load()
		{
			s_configuration = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
		}

		public static void Save()
		{
			if ( null != s_configuration )
			{
				s_configuration.Save( ConfigurationSaveMode.Full , true );
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


	}
}
