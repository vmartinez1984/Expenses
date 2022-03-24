using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Expenses.Models;

namespace Expenses.Models
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Category> Category { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<DepositPlan> DepositPlan { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Period> Period { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, IsActive = true, Name = "Pagos" },
                new Category { Id = 2, IsActive = true, Name = "Ahorros" },
                new Category { Id = 3, IsActive = true, Name = "Alimentación" },
                new Category { Id = 4, IsActive = true, Name = "Gatos" },
                new Category { Id = 5, IsActive = true, Name = "Servicios" },
                new Category { Id = 6, IsActive = true, Name = "Educación" }
            );

            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory {Id=1, IsActive = true, Name ="TDC", CategoryId = 1},
                new Subcategory {Id=2, IsActive = true, Name ="Doña $1200", CategoryId = 1},
                new Subcategory {Id=3, IsActive = true, Name ="Mili $400", CategoryId = 1},

                new Subcategory {Id=4, IsActive = true, Name ="Plan sabatico $200", CategoryId = 2},
                new Subcategory {Id=5, IsActive = true, Name ="Plan Afore $500", CategoryId = 2},
                new Subcategory {Id=6, IsActive = true, Name ="Plan Seminario $350", CategoryId = 2},
                new Subcategory {Id=7, IsActive = true, Name ="Camioneta $100", CategoryId = 2},
                new Subcategory {Id=8, IsActive = true, Name ="Libros Tec $100", CategoryId = 2},
                new Subcategory {Id=9, IsActive = true, Name ="Ropa $100", CategoryId = 2},
                new Subcategory {Id=10, IsActive = true, Name ="Tlaxc $400", CategoryId = 2},
                new Subcategory {Id=11, IsActive = true, Name ="Gastos Medicos $400", CategoryId = 2},
                new Subcategory {Id=12, IsActive = true, Name ="Ahorron $200", CategoryId = 2},

                new Subcategory {Id=13, IsActive = true, Name ="Alimentación corriente", CategoryId = 3},
                new Subcategory {Id=14, IsActive = true, Name ="Por App", CategoryId = 3},
                new Subcategory {Id=15, IsActive = true, Name ="Golosinas", CategoryId = 3},
                new Subcategory {Id=16, IsActive = true, Name ="Gatos", CategoryId = 4},
                new Subcategory {Id=17, IsActive = true, Name ="Internet", CategoryId = 5},
                new Subcategory {Id=18,  IsActive = true, Name ="Agua", CategoryId = 5},
                new Subcategory {Id=19,  IsActive = true, Name ="Luz", CategoryId = 5}
            );
        }       

    }//end class
}