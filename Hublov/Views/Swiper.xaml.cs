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
        ObservableCollection<string> cartoes;
        public ObservableCollection<string> Cartoes
        {
            get { return cartoes; }
            set { cartoes = value; RaisePropertyChanged(); }
        }
        public Swiper()
        {
            cartoes = new ObservableCollection<string>
            {
                "Nintendo Switch",
                "Playstation 4",
                "Xbox One",
                "PC"
            };
        }
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}