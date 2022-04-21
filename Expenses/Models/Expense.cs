using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [Range(1,4000)]
        public int Amount { get; set; }

        [Display(Name = "Presupuesto")]
        [DataType(DataType.Currency)]
        [Range(1, 4000)]
        public int? BudgetAmount { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [NotMapped]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Subcategoria")]
        [ForeignKey(nameof(Subcategory))]
        public int SubcategoryId { get; set; }
        [Display(Name = "Subcategoria")]
        public virtual Subcategory Subcategory { get; set; }

        [ForeignKey(nameof(DepositPlan))]
        public int? DepositPlanId { get; set; }
        public virtual DepositPlan DepositPlan { get; set; }

        [Required]
        [ForeignKey(nameof(Period))]
        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }

        [Display(Name = "Periodo")]
        public virtual Period Period { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
