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

        public int Balance { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha fin")]
        public DateTime? DateStop { get; set; }

        [Display(Name = "¿Esta activo?")]
        public bool IsActive { get; set; }
    }
}