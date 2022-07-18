using courseProject_Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject_Menu
{
    class AdminActions
    {
        public static async Task AddProductAsync (string Title, int Price, string Description, int CategoryId, bool IsAlcohol, bool IsSeason, int AllergenId, bool IsActive)
        {
            var context = new MenuDataContext();
            //add product
            await context.Products.AddAsync(new Product
            {
                Title = Title,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                IsAlcohol = IsAlcohol,
                IsSeason = IsSeason,
                AllergenId = AllergenId,
                IsActive = IsActive
            });
            await context.SaveChangesAsync();
        }

        public static async Task AddAllergenAsync(string AllergenName)
        {
            var context = new MenuDataContext();
            await context.Allergens.AddAsync(new Allergen
            {
                AllergenName = AllergenName
            });
            await context.SaveChangesAsync();
        }

        public static async Task AddCategoriesAsync(string CategoryName, string Description)
        {
            var context = new MenuDataContext();
            await context.Categories.AddAsync(new Categories
            {
                CategoryName = CategoryName,
                Description = Description
            });
            await context.SaveChangesAsync();
        }
    }
}
