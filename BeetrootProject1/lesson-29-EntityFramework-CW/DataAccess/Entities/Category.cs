using System.Collections.Generic;

namespace lesson_29_EntityFramework_CW.DataAccess.Entities
{
    //category has products
    class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
