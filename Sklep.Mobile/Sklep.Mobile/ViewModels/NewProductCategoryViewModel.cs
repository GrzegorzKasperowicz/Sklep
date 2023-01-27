using Sklep.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Mobile.ViewModels
{
    public class NewProductCategoryViewModel : AbstractNewItemViewModel<ProductCategoryForView>
    {
        private int idProductCategory;
        private string title;
        private string description;

        public NewProductCategoryViewModel()
            : base()
        {
        }

        public override bool ValidateSave()
        {
            return IdProductCategory > 0
                && !String.IsNullOrWhiteSpace(Title);
        }

        public int IdProductCategory
        {
            get => idProductCategory;
            set => SetProperty(ref idProductCategory, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public override ProductCategoryForView SetItem()
        {
            return new ProductCategoryForView()
            {
                IdProductCategory = this.IdProductCategory,
                Title = Title,
                Description = description
            };
        }
    }
}