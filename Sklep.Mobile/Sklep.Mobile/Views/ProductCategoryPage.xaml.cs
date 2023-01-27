using Sklep.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sklep.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCategoryPage : ContentPage
    {
        ProductCategoryViewModel _viewModel;
        public ProductCategoryPage()
        {

            InitializeComponent();
            BindingContext = _viewModel = new ProductCategoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}