using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class DepositPlanDtoOut
    {
        public int Id { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Display(Name="Cantidad")]
        public int Amount { get; set; }

        [Display(Name="Meta")]
        public int Goal { get; set; }

        [Display(Name="Total")]
        [DataType(DataType.Currency)]
        public int Total { get; set; }

        [Display(Name="Subcategoria")]
        public string SubcategoryName { get; set; }

        [JsonIgnore]
        public int SubcategoryId { get; set; }

        [Display(Name="Fecha de registro")]
        public DateTime DateRegister { get; set; }
    }

    public class DepositPlanFullDtoOut: DepositPlanDtoOut
    {
        public List<ExpenseDtoOut> ListExpenses { get; set; }
    }
}