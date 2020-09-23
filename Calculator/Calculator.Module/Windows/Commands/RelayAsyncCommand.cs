using System;
using System.Threading.Tasks;

namespace Calculator.Windows.Commands
{
	public sealed class RelayAsyncCommand : AsyncCommand
	{
		private readonly Func<object,Task> _execute = null;

		private readonly Predicate<object> _canExecute = null;




		public RelayAsyncCommand( Func<object , Task> execute )
		{
			_execute = execute ?? throw new ArgumentNullException( nameof( execute ) );
		}

		public RelayAsyncCommand( Func<object , Task> execute , Predicate<object> canExecute )
		{
			_execute = execute ?? throw new ArgumentNullException( nameof( execute ) );
			_canExecute = canExecute ?? throw new ArgumentNullException( nameof( canExecute ) );
		}



		public override bool CanExecute( object parameter )
		{
			return _canExecute == null || _canExecute.Invoke( parameter );
		}

		protected override async Task ExecuteAsync( object parameter )
		{
			await _execute( parameter );
		}
	}
}
