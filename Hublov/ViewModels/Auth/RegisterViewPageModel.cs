using System;
using System.Windows.Input;
using Xamarin.Forms;
using Hublov.Views.Auth;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hublov.ViewModels.Auth
{
    public class RegisterViewPageModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        #region Fields
        private string _email;

        private string _username;

        private string _password;

        private string _confirmPassword;


        #endregion
        #region Properties

        /// <summary>
        /// get or set confirmationPassword
        /// </summary>
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword == value)
                    return;
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// gets or sets  Password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; OnPropertyChanged();
            }
        }


        /// <summary>
        /// gets or sets  Username
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// gets or sets  Property
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
        /// gets or sets command Property
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// gets or sets command Property
        /// </summary>
        public ICommand LoginCommand { get; set; }
        #endregion

        #region Constructors 
        public RegisterViewPageModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.LoginCommand = new Command(async () => await LoginButton_Clicked());
            PageService = new PageService();
            RegisterCommand = new Command(SignUpButton_Clicked);
        }


        /// <summary>
        /// Method called when Login button is clicked
        /// </summary>
        /// <param name="obj"></param>
        private async Task LoginButton_Clicked()
        {
            await Navigation.PushAsync(new LoginPage());
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method called signup button is clicked
        /// </summary>
        public async void SignUpButton_Clicked()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)))
                {
                    ///Dependency Service for firebase native authentication 
                    var token = await DependencyService.Get<IFirebaseAuthenticator>().SignupWithEmailPassword(Email, Password);
                    await PageService.DisplayAlert("Success", "User Created with token " + token, "Ok");
                    if(token != null)
                    {
                        await Navigation.PushAsync(new RegistrationPage());
                    }
                }
                else
                {
                    await PageService.DisplayAlert("Error", "Please fill all fields", "Ok");
                }
            }
            catch (Exception e)
            {
                await PageService.DisplayAlert("Failed", "User Not Created " + e, "Retry");
                await Navigation.PushAsync(new RegistrationPage());
            }

        }
        #endregion

    }
}
