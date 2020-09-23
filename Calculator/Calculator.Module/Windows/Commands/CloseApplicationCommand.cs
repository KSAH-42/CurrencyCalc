using System.Windows;

namespace Calculator.Windows.Commands
{
	public class CloseApplicationCommand : Command
	{
		public override void Execute( object parameter )
		{
			Application.Current.Shutdown();
		}
	}
}
