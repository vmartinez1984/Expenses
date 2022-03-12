using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
