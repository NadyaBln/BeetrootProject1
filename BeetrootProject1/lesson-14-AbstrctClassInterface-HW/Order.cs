using System;

namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public class Order : IPrint, IDelivery
        {
            public DateTime CreationDateTime { get; set; }
            public int OrderId { get; set; }
            public Clothes[] BuyersOrder { get; set; }
            public Buyer Buyer { get; set; }
            public OrderStatus OrderStatuses { get; set; }

            public enum OrderStatus
            {
                Done,
                InProcess,
                New
            }

            public Order(DateTime creationDateTime, int orderId, Clothes[] buyersOrder, Buyer buyer, OrderStatus orderStatuses)
            {
                this.CreationDateTime = creationDateTime;
                this.OrderId = orderId;
                this.BuyersOrder = buyersOrder;
                this.Buyer = buyer;
                this.OrderStatuses = orderStatuses;
            }
            public Order()
            {

            }

            public void Print(IPrint print)
            {
                Console.WriteLine($"{Buyer.FullName}'s order is in status: {OrderStatuses}.");
                Console.WriteLine($"In cart {BuyersOrder.Length} items:");

                int index = 1;
                foreach (var item in BuyersOrder)
                {
                    Console.WriteLine($"{index}. {item.ItemName}");
                    index++;
                }
            }

            public void Delivery(Order order, bool answer)
            {
                if (answer == true) Console.WriteLine($"Yes, I need a delivery for Order ID {order.OrderId}");

                else Console.WriteLine($"No, I don't.");
            }
        }
    }
}
