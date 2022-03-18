using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class PeriodDtoOut
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]
        public DateTime DateStart { get; set; } = DateTime.Now;
                
        [DataType(DataType.Date)]
        [Display(Name = "Fecha fin")]
        public DateTime? DateStop { get; set; }

        public bool IsActive { get; set; }
    }
}
