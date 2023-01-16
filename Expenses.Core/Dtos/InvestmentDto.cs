using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class InvestmentDto: InvesmentDtoIn
    {
        public int Id { get; set; }
    }

    public class InvesmentDtoIn
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "Fecha fin")]
        [DataType(DataType.Date)]
        public DateTime DateStop { get; set; }

        [Required]
        [Display(Name = "Interes")]
        public decimal Interest { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [Range(1,3)]
        public int InstructionId { get; set; }

        [Required]
        [Range(7,180)]
        public int Term { get; set; }
    }
}
