using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sana.Backend.Domain.Common.Constants;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port.Base;

namespace Sana.Backend.Infrastructure.SQLServer
{
    public partial class MainContext : DbContext, IMainContext
    {
        private readonly IConfiguration _configuration;
        public MainContext(DbContextOptions<MainContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            base.ChangeTracker.AutoDetectChangesEnabled = false;


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relation:Collation", SQLServerConstants.RelationCollation);
            modelBuilder.HasDefaultSchema(SQLServerConstants.DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);

            base.OnModelCreating(modelBuilder);

            AddDataSeeding(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration[$"{nameof(Configurations.SQLServer)}:{nameof(Configurations.SQLServer.ConnectionString)}"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        private void AddDataSeeding(ModelBuilder modelBuilder)
        {
            var ComputersId = new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6");
            var Category1 = new Category()
            {
                Id = ComputersId,
                Code = "0001",
                Description = "Computers"

            };
            var LaptosId = new Guid("b087fc74-f27d-45fe-adec-27230ee0f0e0");
            var Category2 = new Category()
            {
                Id = LaptosId,
                Code = "0002",
                Description = "Laptops"

            };
            var TabletsId = new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e");
            var Category3 = new Category()
            {
                Id = TabletsId,
                Code = "0003",
                Description = "Tablets"

            };
            modelBuilder.Entity<Category>().HasData(Category1, Category2, Category3);

            var Product1 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR001",
                Name = "Torre Gamer Amd Ryzen 5 5600g +16gb Ram +ssd 240 Radeon 7 P",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_890513-MCO72408954235_102023-O.jpg",
                CategoryId = ComputersId,
                Stock = 10,
                Price = 1539000
            };
            var Product2 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR002",
                Name = "Torre Cpu Gamer Athlon 3000g Vega 3 1tb 16gb Led 22 Pc",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_674835-MCO71845670112_092023-O.jpg",
                CategoryId = ComputersId,
                Stock = 5,
                Price = 1529000
            };
            var Product3 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR003",
                Name = "Cpu Torre Core I5 +16ram+hd500 Monitor 19 (Reacondicionado)",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_956627-MCO75513168527_042024-O.jpg",
                CategoryId = ComputersId,
                Stock = 3,
                Price = 713000
            };

            var Product4 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR004",
                Name = "Cpu Intel Core I5 Tercera Generacion Ssd 480 Gb Ram 8gb",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_942517-MCO54964311414_042023-O.jpg",
                CategoryId = ComputersId,
                Stock = 1,
                Price = 630000
            };

            var Product5 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR005",
                Name = "Apple iPad (9ª generación) 10.2\" Wi-Fi 64GB - Gris espacial ",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_912069-MLA74807972777_022024-O.jpg",
                CategoryId = TabletsId,
                Stock = 2,
                Price = 2200000
            };
            var Product6 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR006",
                Name = "iPad Apple Pro 4th generation 4th generation A2759 11\" 128GB gris espacial y 8GB de memoria RAM ",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_893788-MLA52850734025_122022-O.jpg",
                CategoryId = TabletsId,
                Stock = 1,
                Price = 3500000
            };
            var Product7 = new Product()
            {
                Id = Guid.NewGuid(),
                Code = "PR007",
                Name = "Mac Air 2020 Pulgadas I7 + 16gb + 500 Ssd Como Nuevo En Caja",
                UrlImage = "https://http2.mlstatic.com/D_NQ_NP_607176-MCO69416858664_052023-O.jpg",
                CategoryId = LaptosId,
                Stock = 1,
                Price = 5800000
            };
            modelBuilder.Entity<Product>().HasData(Product1, Product2, Product3, Product4, Product5, Product6, Product7);

            var Customer1 = new Customer()
            {
                Id = Guid.NewGuid(),
                Document = "71775186",
                Name = "Fabian Mauricio Castrillon Franco",
                Address = "Hatillo frente a la iglesia Santa Marta",
                Telephone = "3137977225",
                Cellphone = "3137977225",
                City = "Barbosa - Antioquia - Colombia"

            };
            var Customer2 = new Customer()
            {
                Id = Guid.NewGuid(),
                Document = "98123456",
                Name = "Robert C. Martin",
                Address = "Calle principal via al Centro Km 12 Casa 3",
                Telephone = "4320987771",
                Cellphone = "4320987771",
                City = "Los Angeles - California - EEUU"

            };
            modelBuilder.Entity<Customer>().HasData(Customer1, Customer2);

        }

        public int ExecuteQuery(string query)
        {
            return Database.ExecuteSqlRaw(query);
        }
        public int ExecuteQuery(string query, params SqlParameter[] sqlParameters)
        {
            return Database.ExecuteSqlRaw(query, sqlParameters);
        }
        public Task<int> ExecuteQueryAsync(string query)
        {
            return Database.ExecuteSqlRawAsync(query);
        }
        public Task<int> ExecuteQueryAsync(string query, params SqlParameter[] sqlParameters)
        {
            return Database.ExecuteSqlRawAsync(query, sqlParameters);
        }
    }
}
