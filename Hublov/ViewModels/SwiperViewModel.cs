using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Hublov.ViewModels
{
    public class SwiperViewModel : INotifyPropertyChanged
    {
        ObservableCollection<string> cartoes;
        public ObservableCollection<string> Cartoes
        {
            get => cartoes;
            set
            {
                if (cartoes == value)
                    return;
                cartoes = value;
                OnPropertyChanged(nameof(Cartoes));
            }
        }
        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void INotifyPropertyChanged(string cartoes)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cartoes));
        }

    }
}
