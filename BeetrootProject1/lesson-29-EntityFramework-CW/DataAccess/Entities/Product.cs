
namespace lesson_29_EntityFramework_CW.DataAccess.Entities
{
    //products has category
    class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public virtual Category Category { get; set; }
    }
}
