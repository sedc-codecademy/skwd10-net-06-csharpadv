using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public Order()
        {
            Status = OrderStatus.Processing;
        }
        public Order(int id, string title, string desc, OrderStatus status)
        {
            Id = id;
            Title = title;
            Description = desc;
            Status = status;
        }
        public string Print()
        {
            // We can use the helper class anywhere we need it without an instance
            return $"{TextHelper.CapitalFirstLetter(Title)} - {Description}";
        }

    }

    // This enum can be in a separate file
    // It can also be implemented with class that it is used in
    public enum OrderStatus
    {
        Processing,
        Delivered,
        DeliveryInProgress,
        CouldNotDeliver
    }
}
