using System;
using Hublov.Views;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Hublov.Views.Auth;
using System.Threading.Tasks;

namespace Hublov.ViewModels.Auth
{
    public class LoginPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
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
        public LoginPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.RegisterCommand = new Command(async () => await RegisterButtonClicked());
            PageService = new PageService();
            LoginCommand = new Command(OnLoginButtonClicked);
        }

        #endregion

        #region Methods


        private async Task RegisterButtonClicked()
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void OnLoginButtonClicked()
        {
            try { 
                if (!(string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password)))
                {
                    
                    var token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(Email, Password);
                    if (token != null )
                    {
                        //await Shell.Current.GoToAsync(nameof(Swiper));
                        await Navigation.PushAsync(new AboutPage());
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
                await PageService.DisplayAlert("Error", "Login failed !" + e, "Ok");
            }
        }

        #endregion
    }
}
