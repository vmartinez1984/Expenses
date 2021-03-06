using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Dtos.Inputs
{
    public class PeriodDtoIn
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        public DateTime? DateStop { get; set; }

        public bool IsActive { get; set; }
    }
}