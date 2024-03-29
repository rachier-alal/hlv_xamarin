﻿using Hublov.EventListeners;
using Hublov.Services;
using Hublov.ViewModels.Auth;
using Hublov.Views;
using Hublov.Views.Auth;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hublov
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            HubsListener firebaseHelper = new HubsListener();
            var AllHubs = firebaseHelper.GetAllPersons();
            DependencyService.Register<MockDataStore>();
            if (DependencyService.Get<IFirebaseAuthenticator>().IsUserLoggedIn())

                MainPage = new AppShell();
            else
                MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
