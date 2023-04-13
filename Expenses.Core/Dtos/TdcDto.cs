using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class TdcDto
    {
        public int Id { get; set; }

        [DataType(DataType.Date)] 
        public DateTime DateCut { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePay { get; set; }
    }
}
