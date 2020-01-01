using System;
using System.Collections.Generic;
using System.Text;


namespace ViewModel
{
    public class Command
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;


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