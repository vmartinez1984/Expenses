using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Entities
{
    public class BaseBEntity : BaseAEntity
    {

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;
    }
}