﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Windows.Commands
{
	public abstract class AsyncCommand : ICommand
	{
		public event EventHandler CanExecuteChanged
		{
			add    => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}



		public virtual bool CanExecute( object parameter )
		{
			return true;
		}

		public async void Execute( object parameter )
		{
			await ExecuteAsync( parameter );

			CommandManager.InvalidateRequerySuggested();
		}




		protected abstract Task ExecuteAsync( object parameter );
	}
}
