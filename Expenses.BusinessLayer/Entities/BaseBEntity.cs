using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.BusinessLayer.Entities
{
    public class BaseBEntity : BaseAEntity
    {

        [Required]
        public DateTime DateRegister { get; set; } = DateTime.Now;
    }
}