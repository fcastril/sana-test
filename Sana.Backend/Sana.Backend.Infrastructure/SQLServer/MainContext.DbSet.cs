
using Microsoft.EntityFrameworkCore;
using Sana.Backend.Domain.Entities;
namespace Sana.Backend.Infrastructure.SQLServer
{
    public partial class MainContext
    {
        public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderDetail> OrdersDetails { get; set; }

	}
}
