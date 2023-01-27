using Sklep.Mobile.ViewModels;
using Sklep.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Sklep.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewProductCategoryPage), typeof(NewProductCategoryPage));
            Routing.RegisterRoute(nameof(NewProductTypePage), typeof(NewProductTypePage));
            Routing.RegisterRoute(nameof(ProductCategoryPage), typeof(ProductCategoryPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
