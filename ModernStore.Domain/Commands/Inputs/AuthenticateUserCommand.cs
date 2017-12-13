using System;
using System.Windows.Input;

namespace ModernStore.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
