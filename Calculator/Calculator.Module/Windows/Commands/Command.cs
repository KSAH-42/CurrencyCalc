using System;
using System.Windows.Input;

namespace Calculator.Windows.Commands
{
	public abstract class Command : ICommand
	{

		public event EventHandler CanExecuteChanged
		{
			add     => CommandManager.RequerySuggested += value;
			remove  => CommandManager.RequerySuggested -= value;
		}



		public virtual bool CanExecute( object parameter )
		{
			return true;
		}

		public abstract void Execute( object parameter );
	}
}
