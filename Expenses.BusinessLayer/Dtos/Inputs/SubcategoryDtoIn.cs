using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Inputs{
    public class SubcategoryDtoIn{

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "¿Es presupuesto?")]
        public bool IsBudget { get; set; } = true;
         
        [Display(Name = "Cantidad")]
        [Range(0,4000)]
        public int Amount { get; set; }       
    }
}