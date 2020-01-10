using System;
using System.Windows.Input;


namespace ViewModel
{
    public class Command : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        public event EventHandler CanExecuteChanged;


        public Command(Action execute) : this(execute, null) { }


        public Command(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }              
                
            else return canExecute();
        }


        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}