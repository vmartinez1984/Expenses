using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class EntryDtoOut
    {
        [Key]
        public int Id { get; set; }
                
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }
                
        [Display(Name = "Fecha de registro")]
        public DateTime DateRegister { get; set; } = DateTime.Now;

        public int PeriodId {get; set;}
    }
}