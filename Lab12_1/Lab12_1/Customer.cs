using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_1
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return CustomerId + "  " + Name + "   " + Email + "   " + Age;
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public int Customer { get; set; }

        public override string ToString()
        {
            return OrderId + "  " + ProductName + "  " + Description + "  " + Quantity + "  " +PurchaseDate + "  " + Customer;
        }
    }

    class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("MyShop")
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
