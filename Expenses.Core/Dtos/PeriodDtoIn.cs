using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class PeriodDtoIn
    {
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

    public class PeriodDto: PeriodDtoIn
    {
        [Key]
        public int Id { get; set; }      

    }

    public class PeriodFullDto : PeriodDto
    {
        public List<ExpenseDto> ListExpenses { get; set; }
    }
}