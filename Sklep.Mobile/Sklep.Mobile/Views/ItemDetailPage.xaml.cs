using Sklep.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Sklep.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}