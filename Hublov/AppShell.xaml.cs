using Hublov.ViewModels;
using Hublov.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Hublov
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
