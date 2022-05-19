using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class TermAccountDtoOut
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Cantidad")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de vencimiento")]
        public DateTime DateExpiration { get; set; } = DateTime.Now;

        [Required]
        [Display(Name= "Plazo días")]
        public int Term { get; set; }
    }
}