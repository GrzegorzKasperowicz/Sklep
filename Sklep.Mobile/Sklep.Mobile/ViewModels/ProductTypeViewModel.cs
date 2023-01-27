using Sklep.Mobile.Models;
using Sklep.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sklep.Mobile.ViewModels
{
    public class ProductTypeViewModel:AbstractItemViewModel<ProductTypeForView>
    {
        public ProductTypeViewModel()
             : base("Product Type")
        {
        }
#pragma warning disable CS1998 // W tej metodzie asynchronicznej brakuje operatorów „await”, dlatego będzie wykonywana synchronicznie. Rozważ możliwość użycia operatora „await” w celu zdefiniowania oczekiwania na nieblokujące wywołania interfejsów API albo wyrażenia „await Task.Run(...)” w celu przeniesienia wykonywania zadań intensywnie angażujących procesor do wątku w tle.
        public override async void GoToDetailsPage()
#pragma warning restore CS1998 // W tej metodzie asynchronicznej brakuje operatorów „await”, dlatego będzie wykonywana synchronicznie. Rozważ możliwość użycia operatora „await” w celu zdefiniowania oczekiwania na nieblokujące wywołania interfejsów API albo wyrażenia „await Task.Run(...)” w celu przeniesienia wykonywania zadań intensywnie angażujących procesor do wątku w tle.
        {
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewProductTypePage));
        }
    }
}
