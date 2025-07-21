using SO_OMS.Application.Usecases.Auth;
using System;
using System.ComponentModel;

namespace SO_OMS.Presentation.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; } = string.Empty;
        public string Password { private get; set; } = string.Empty;
        public string ErrorMessage { get; private set; } = string.Empty;

        private readonly LoginUseCase _loginUseCase;

        public LoginViewModel(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        public bool Login()
        {
            try
            {
                var admin = _loginUseCase.Execute(Username, Password);
                ErrorMessage = string.Empty;
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
