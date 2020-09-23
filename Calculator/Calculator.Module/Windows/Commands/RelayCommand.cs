using System;

namespace Calculator.Windows.Commands
{
	public sealed class RelayCommand : Command
	{
		private readonly Action<object> _execute = null;

		private readonly Predicate<object> _canExecute = null;




		public RelayCommand( Action<object> execute )
		{
			_execute = execute ?? throw new ArgumentNullException( nameof( execute ) );
		}

		public RelayCommand( Action<object> execute , Predicate<object> canExecute )
		{
			_execute = execute ?? throw new ArgumentNullException( nameof( execute ) );
			_canExecute = canExecute ?? throw new ArgumentNullException( nameof( canExecute ) );
		}



		public override bool CanExecute( object parameter )
		{
			return _canExecute == null || _canExecute.Invoke( parameter );
		}

		public override void Execute( object parameter )
		{
			_execute.Invoke( parameter );
		}
	}
}
