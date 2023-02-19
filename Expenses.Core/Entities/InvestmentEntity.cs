using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Entities
{
    public class InvestmentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateStop { get; set; }

        [Required]
        public decimal Interest { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public decimal Amount { get; set; }
                
        public decimal AmountFinal { get; set; }

        [Required]
        public int InstructionId { get; set; }

        [Required]
        public int Term { get; set; }

        public string Note { get; set; }
    }
}
