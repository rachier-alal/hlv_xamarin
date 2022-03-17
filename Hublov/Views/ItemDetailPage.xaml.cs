using Hublov.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Hublov.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}