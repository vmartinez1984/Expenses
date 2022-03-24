using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class DepositPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [Range(1, 4000)]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Meta")]
        [Range(1, 50000)]
        public int Goal { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        [Display(Name = "Categoria")]
        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Subcategoria")]
        [ForeignKey(nameof(Subcategory))]
        public int SubcategoryId { get; set; }
        [Display(Name = "Subcategoria")]
        public virtual Subcategory Subcategory { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;

        public List<Deposit> ListDeposits { get; set; }
    }
}
