using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Categoria")]
        public virtual Category Category { get; set; }

        [Display(Name ="Cantidad")]
        [DataType(DataType.Currency)]
        public int? Amount { get; set; }

        [Display(Name ="¿Es presupuesto?")]
        public bool IsBudget { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
