using System;
using System.Collections.Generic;

namespace courseProject_Menu.Entities
{
    class Orders
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        //public virtual ICollection<Product> ProductId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int GuestId { get; set; }
        public int TableNumber { get; set; }
    }
}
