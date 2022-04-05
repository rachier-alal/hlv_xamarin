using Hublov.ViewModels.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hublov.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel(Navigation);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}