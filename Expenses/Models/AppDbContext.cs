using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Expenses.Models
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Category> Category { get; set; }        
        public DbSet<DepositPlan> DepositPlan { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseTdc> ExpenseTdc { get; set; }
        public DbSet<Expenses.Models.MontsWithoutInterest> MontsWithoutInterest { get; set; }
        public DbSet<Expenses.Models.MontsWithoutInterestDetails> MontsWithoutInterestDetails { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<TermAccount> TermAccount { get; set; }
        public DbSet<Tdc> Tdc { get; set;}


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
                new Category { Id = 6, IsActive = true, Name = "Educación" },
                new Category { Id = 7, IsActive = true, Name = "Becas" }
            );

            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { Id = 1, IsActive = true, Name = "TDC", CategoryId = 1 },
                new Subcategory { Id = 2, IsActive = true, Name = "Semana 1", CategoryId = 1,IsBudget = true, Amount= 600 },
                new Subcategory { Id = 3, IsActive = true, Name = "Semana 2", CategoryId = 1,IsBudget = true, Amount= 600 },

                new Subcategory { Id = 4, IsActive = true, Name = "Plan sabatico", CategoryId = 2, IsBudget = true, Amount= 200 },
                new Subcategory { Id = 5, IsActive = true, Name = "Plan Afore", CategoryId = 2, IsBudget = true, Amount= 500 },
                new Subcategory { Id = 6, IsActive = true, Name = "Plan Seminario", CategoryId = 2, IsBudget = true, Amount= 750 },
                new Subcategory { Id = 7, IsActive = true, Name = "Camioneta $100", CategoryId = 2 },
                new Subcategory { Id = 8, IsActive = true, Name = "Libros Tec $100", CategoryId = 2 },
                new Subcategory { Id = 9, IsActive = true, Name = "Ropa $100", CategoryId = 2 },
                new Subcategory { Id = 10, IsActive = true, Name = "Tlaxc $400", CategoryId = 2 },
                new Subcategory { Id = 11, IsActive = true, Name = "Gastos Medicos $100", CategoryId = 2 },
                new Subcategory { Id = 12, IsActive = true, Name = "Ahorron $200", CategoryId = 2 },
                new Subcategory { Id = 22, IsActive = true, Name = "Vacaciones", CategoryId = 2, IsBudget = true, Amount= 100 },

                new Subcategory { Id = 13, IsActive = true, Name = "Alimentación corriente", CategoryId = 3 },
                new Subcategory { Id = 14, IsActive = true, Name = "Por App", CategoryId = 3 },
                new Subcategory { Id = 15, IsActive = true, Name = "Golosinas", CategoryId = 3 },
                new Subcategory { Id = 16, IsActive = true, Name = "Gatos", CategoryId = 4 },


                new Subcategory { Id = 17, IsActive = true, Name = "Internet Tlax", CategoryId = 5, IsBudget = true, Amount= 90 },
                new Subcategory { Id = 18, IsActive = true, Name = "Internet CDMX", CategoryId = 5, IsBudget = true, Amount= 175 },
                new Subcategory { Id = 19, IsActive = true, Name = "Agua CDMX", CategoryId = 5, IsBudget = true, Amount= 75  },
                new Subcategory { Id = 20, IsActive = true, Name = "Luz Tlax", CategoryId = 5, IsBudget = true, Amount= 75 },
                new Subcategory { Id = 21, IsActive = true, Name = "Luz CDMX", CategoryId = 5, IsBudget = true, Amount= 150 },

                new Subcategory { Id = 23, IsActive = true, Name = "Doña", CategoryId = 5, IsBudget = true, Amount= 1200 },
                new Subcategory { Id = 24, IsActive = true, Name = "Mili", CategoryId = 5, IsBudget = true, Amount= 400 }
            );

            modelBuilder.Entity<DepositPlan>().HasData(
                new DepositPlan { Id = 1, Amount = 200, SubcategoryId = 4, Goal = 2000, IsActive = true, Name = "Sabatico", DateRegister = DateTime.Now },
                new DepositPlan { Id = 2, Amount = 500, SubcategoryId = 5, Goal = 2000, IsActive = true, Name = "Afore", DateRegister = DateTime.Now },
                new DepositPlan { Id = 3, Amount = 350, SubcategoryId = 6, Goal = 2000, IsActive = true, Name = "Seminario", DateRegister = DateTime.Now },
                new DepositPlan { Id = 4, Amount = 100, SubcategoryId = 7, Goal = 2000, IsActive = true, Name = "Camioneta", DateRegister = DateTime.Now },
                new DepositPlan { Id = 5, Amount = 100, SubcategoryId = 8, Goal = 2000, IsActive = true, Name = "Libros Tec", DateRegister = DateTime.Now },
                new DepositPlan { Id = 6, Amount = 100, SubcategoryId = 9, Goal = 2000, IsActive = true, Name = "Ropa", DateRegister = DateTime.Now },
                new DepositPlan { Id = 7, Amount = 400, SubcategoryId = 10, Goal = 2000, IsActive = true, Name = "Tlax", DateRegister = DateTime.Now },
                new DepositPlan { Id = 8, Amount = 100, SubcategoryId = 11, Goal = 2000, IsActive = true, Name = "Gastos medicos", DateRegister = DateTime.Now },
                new DepositPlan { Id = 9, Amount = 100, SubcategoryId = 12, Goal = 2000, IsActive = true, Name = "Ahorro N", DateRegister = DateTime.Now },
                new DepositPlan { Id = 10, Amount = 100, SubcategoryId = 12, Goal = 2000, IsActive = true, Name = "Vacaciones", DateRegister = DateTime.Now }
            );

            modelBuilder.Entity<Period>().HasData
            (
                new Period {Id= 1,DateStart =DateTime.Now, DateStop = DateTime.Now, IsActive= false, Name= "Ahorros"}
            );
        }       
    }//end class
}