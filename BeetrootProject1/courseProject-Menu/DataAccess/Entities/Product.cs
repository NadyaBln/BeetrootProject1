
namespace courseProject_Menu.Entities
{
    class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public float Calories { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsAlcohol { get; set; }
        public bool IsSeason { get; set; }
        public bool IsActive { get; set; }
        public int AllergenId { get; set; }
    }
}
