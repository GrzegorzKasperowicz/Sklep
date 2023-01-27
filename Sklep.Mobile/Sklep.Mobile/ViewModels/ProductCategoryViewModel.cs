using Sklep.Mobile.Models;
using Sklep.Mobile.Views;
using SklepServiceConnection;
using Xamarin.Forms;

namespace Sklep.Mobile.ViewModels
{
    public class ProductCategoryViewModel : AbstractItemViewModel<ProductCategoryForView> 
    { 
        public ProductCategoryViewModel()
            : base("Product Category")
        {
        }
        public  override async void GoToDetailsPage()
        {
            await Shell.Current.GoToAsync($"{nameof(ProductCategoryDetailsPage)}?{nameof(ProductCategoryDetailsViewModel.ItemId)}");
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewProductCategoryPage));
        }
    }
}