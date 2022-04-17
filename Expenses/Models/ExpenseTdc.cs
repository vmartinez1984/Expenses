﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class ExpenseTdc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name= "Nombre")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cantidad")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
