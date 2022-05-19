using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Inputs
{
    public class DepositPlanDtoIn
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]        
        [Range(1, 4000)]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        [Required]        
        [Range(1, 50000)]        
        public int Goal { get; set; }

        [Required]       
        public int SubcategoryId { get; set; }
    }
}