using Sklep.Mobile.Services;
using Sklep.Mobile.Views;
using SklepServiceConnection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sklep.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ProductCategoryDataStore>();
            DependencyService.Register<ProductTypeDataStore>();

            MainPage = new AppShell();
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
