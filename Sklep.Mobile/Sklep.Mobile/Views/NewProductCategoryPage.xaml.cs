using Sklep.Mobile.Models;
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
    public partial class NewProductCategoryPage : ContentPage
    {
        public ProductCategoryForView Item { get; set; }
        public NewProductCategoryPage()
        {
            InitializeComponent();
            BindingContext = new NewProductCategoryViewModel();
        }

    }
}