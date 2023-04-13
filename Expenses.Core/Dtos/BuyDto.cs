using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class BuyDto : BuyDtoIn
    {
        public int Id { get; set; }

        [Display(Name = "No de pago")]
        public int PayNumber { get; set; }

        [Display(Name = "Fecha de corte")]
        [DataType(DataType.Date)]
        public DateTime DateCut { get; set; }

        [Display(Name = "Fecha de pago")]
        [DataType(DataType.Date)]
        public DateTime DatePay { get; set; }
    }

    public class BuyDtoIn
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "MSI")]
        public int MonthsWhithoutInterest { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; } = DateTime.Now;
              

        public List<PayDto> ListPays { get; set; }

        [Display(Name = "Pago")]
        [DataType(DataType.Currency)]
        public decimal Pay { get; set; }

        public List<DatePayDto> ListDatePays { get; set; }
    }

    public class DatePayDto
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "No de pago")]
        public int PayNumber { get; set; }

        public bool IsCurrent { get; set; }
    }
}
