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
    public partial class ProductTypePage : ContentPage
    {
        ProductTypeViewModel _viewModel;
        public ProductTypePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProductTypeViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}