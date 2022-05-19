using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class SubcategoryDtoOut
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        

        [Display(Name = "Cantidad")]
        public int Amount { get; set; }

        [Display(Name = "¿Es presupuesto?")]
        public bool IsBudget { get; set; }
        
    }
}