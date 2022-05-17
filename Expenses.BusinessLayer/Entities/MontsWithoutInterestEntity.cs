using Expenses.BusinessLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class MontsWithoutInterestEntity: BaseBEntity
    {
        public string Name { get; set; }

        public int ExpensesTotal { get; set; }

        public int Amount { get; set; }

        
        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateStart { get; set; } = DateTime.Now;
    }
}