using Hublov.ViewModels.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hublov.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewPageModel(Navigation);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}