using System;
using Hublov.Views;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Hublov.Views.Auth;

namespace Hublov.ViewModels.Auth
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Fields
        private string _email;
        private string _password;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value)
                    return;

                _email = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// gets or set password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                    return;

                _password = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or Sets Login button command
        /// </summary>
        public ICommand LoginCommand { get; set; }


        /// <summary>
        /// Gets or Sets Register button command
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        #endregion

        /// <summary>
        /// Initializes Commands and page Services 
        /// </summary>
        #region Constructors
        public LoginPageViewModel()
        {
            PageService = new PageService();
            LoginCommand = new Command(OnLoginButtonClicked);
            RegisterCommand = new Command(OnRegisterButtonClicked);
        }

        #endregion

        #region Methods


        private async void OnRegisterButtonClicked()
        {
            //Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }

        private async void OnLoginButtonClicked()
        {
            try { 
                if (!(string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password)))
                {
                    
                    var token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(Email, Password);
                    if (token != null )
                    {
                        await Shell.Current.GoToAsync(nameof(Swiper));
                    }
                    //await PageService.DisplayAlert("Success", "User Created with token ", "Ok");

                }
                else
                {
                    await PageService.DisplayAlert("Error", "Please fill all fields", "Ok");
                }
            }
            catch (Exception e)
            {
               
            }
        }

        #endregion
    }
}
