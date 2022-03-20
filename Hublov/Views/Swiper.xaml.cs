using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hublov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Swiper : INotifyPropertyChanged
    {
        private ObservableCollection<string> cartoes = new ObservableCollection<string>
            {
                "Nintendo Switch",
                "Playstation 4",
                "Xbox One",
                "something",
                "cool",
                "just",
                "happened",
                "so",
                "ima",
                "stop ",
                "here"
            };
    
        public ObservableCollection<string> Cartoes
        {
            get => cartoes;
            set
            {
                if (cartoes == value)
                    return;
                cartoes = value;
                OnPropertyChanged(nameof(cartoes));
            }
        }
        public Swiper()
        {
            InitializeComponent();
            Title = "The Hub";
            Cartoes = new ObservableCollection<string>(Cartoes);
            BindingContext = this;
        }
        // INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
    }
}