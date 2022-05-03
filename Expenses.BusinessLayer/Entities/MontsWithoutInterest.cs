using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Models
{
    public class MontsWithoutInterest: BaseBEntity
    {
        public string Name { get; set; }

        public int ExpensesTotal { get; set; }

        public int Amount { get; set; }

        
        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}