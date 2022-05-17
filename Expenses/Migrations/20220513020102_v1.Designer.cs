﻿// <auto-generated />
using System;
using Expenses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Expenses.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220513020102_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Expenses.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Pagos"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Ahorros"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Alimentación"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Gatos"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Servicios"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            Name = "Educación"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            Name = "Becas"
                        });
                });

            modelBuilder.Entity("Expenses.Models.DepositPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("DepositPlan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 200,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(2656),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Sabatico",
                            SubcategoryId = 4
                        },
                        new
                        {
                            Id = 2,
                            Amount = 500,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3001),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Afore",
                            SubcategoryId = 5
                        },
                        new
                        {
                            Id = 3,
                            Amount = 350,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3007),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Seminario",
                            SubcategoryId = 6
                        },
                        new
                        {
                            Id = 4,
                            Amount = 100,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3012),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Camioneta",
                            SubcategoryId = 7
                        },
                        new
                        {
                            Id = 5,
                            Amount = 100,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3017),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Libros Tec",
                            SubcategoryId = 8
                        },
                        new
                        {
                            Id = 6,
                            Amount = 100,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3022),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Ropa",
                            SubcategoryId = 9
                        },
                        new
                        {
                            Id = 7,
                            Amount = 400,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3027),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Tlax",
                            SubcategoryId = 10
                        },
                        new
                        {
                            Id = 8,
                            Amount = 100,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3032),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Gastos medicos",
                            SubcategoryId = 11
                        },
                        new
                        {
                            Id = 9,
                            Amount = 100,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3037),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Ahorro N",
                            SubcategoryId = 12
                        },
                        new
                        {
                            Id = 10,
                            Amount = 100,
                            DateRegister = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(3042),
                            Goal = 2000,
                            IsActive = true,
                            Name = "Vacaciones",
                            SubcategoryId = 12
                        });
                });

            modelBuilder.Entity("Expenses.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.ToTable("Entry");
                });

            modelBuilder.Entity("Expenses.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("BudgetAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepositPlanId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepositPlanId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("Expenses.Models.ExpenseTdc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MonthsWithoutInterest")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseTdc");
                });

            modelBuilder.Entity("Expenses.Models.MontsWithoutInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpensesTotal")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MontsWithoutInterest");
                });

            modelBuilder.Entity("Expenses.Models.MontsWithoutInterestDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpenseNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MontsWithoutInterestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MontsWithoutInterestId");

                    b.ToTable("MontsWithoutInterestDetails");
                });

            modelBuilder.Entity("Expenses.Models.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStop")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Period");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateStart = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(4612),
                            DateStop = new DateTime(2022, 5, 12, 21, 1, 1, 797, DateTimeKind.Local).AddTicks(4885),
                            IsActive = false,
                            Name = "Ahorros"
                        });
                });

            modelBuilder.Entity("Expenses.Models.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBudget")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            IsActive = true,
                            IsBudget = false,
                            Name = "TDC"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 600,
                            CategoryId = 1,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Semana 1"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 600,
                            CategoryId = 1,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Semana 2"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 200,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Plan sabatico"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 500,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Plan Afore"
                        },
                        new
                        {
                            Id = 6,
                            Amount = 750,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Plan Seminario"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Camioneta $100"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Libros Tec $100"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Ropa $100"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Tlaxc $400"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Gastos Medicos $100"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Ahorron $200"
                        },
                        new
                        {
                            Id = 22,
                            Amount = 100,
                            CategoryId = 2,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Vacaciones"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Alimentación corriente"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Por App"
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Golosinas"
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            IsActive = true,
                            IsBudget = false,
                            Name = "Gatos"
                        },
                        new
                        {
                            Id = 17,
                            Amount = 90,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Internet Tlax"
                        },
                        new
                        {
                            Id = 18,
                            Amount = 175,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Internet CDMX"
                        },
                        new
                        {
                            Id = 19,
                            Amount = 75,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Agua CDMX"
                        },
                        new
                        {
                            Id = 20,
                            Amount = 75,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Luz Tlax"
                        },
                        new
                        {
                            Id = 21,
                            Amount = 150,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Luz CDMX"
                        },
                        new
                        {
                            Id = 23,
                            Amount = 1200,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Doña"
                        },
                        new
                        {
                            Id = 24,
                            Amount = 400,
                            CategoryId = 5,
                            IsActive = true,
                            IsBudget = true,
                            Name = "Mili"
                        });
                });

            modelBuilder.Entity("Expenses.Models.Tdc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateCute")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Decimal(5,2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Tdc");
                });

            modelBuilder.Entity("Expenses.Models.TermAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TermAccount");
                });

            modelBuilder.Entity("Expenses.Models.DepositPlan", b =>
                {
                    b.HasOne("Expenses.Models.Subcategory", "Subcategory")
                        .WithMany()
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Expenses.Models.Entry", b =>
                {
                    b.HasOne("Expenses.Models.Period", "Period")
                        .WithMany("ListEntries")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Period");
                });

            modelBuilder.Entity("Expenses.Models.Expense", b =>
                {
                    b.HasOne("Expenses.Models.DepositPlan", "DepositPlan")
                        .WithMany("ListExpenses")
                        .HasForeignKey("DepositPlanId");

                    b.HasOne("Expenses.Models.Period", "Period")
                        .WithMany("ListExpenses")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Expenses.Models.Subcategory", "Subcategory")
                        .WithMany()
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepositPlan");

                    b.Navigation("Period");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Expenses.Models.MontsWithoutInterestDetails", b =>
                {
                    b.HasOne("Expenses.Models.MontsWithoutInterest", "MontsWithoutInterest")
                        .WithMany()
                        .HasForeignKey("MontsWithoutInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MontsWithoutInterest");
                });

            modelBuilder.Entity("Expenses.Models.Subcategory", b =>
                {
                    b.HasOne("Expenses.Models.Category", "Category")
                        .WithMany("ListSubcategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Expenses.Models.Category", b =>
                {
                    b.Navigation("ListSubcategory");
                });

            modelBuilder.Entity("Expenses.Models.DepositPlan", b =>
                {
                    b.Navigation("ListExpenses");
                });

            modelBuilder.Entity("Expenses.Models.Period", b =>
                {
                    b.Navigation("ListEntries");

                    b.Navigation("ListExpenses");
                });
#pragma warning restore 612, 618
        }
    }
}