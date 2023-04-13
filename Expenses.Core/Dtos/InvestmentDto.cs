using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Core.Dtos
{
    public class InvestmentDto: InvesmentDtoIn
    {
        public int Id { get; set; }
    }

    public class InvesmentDtoIn
    {
        [Required(ErrorMessage ="El nombre no puede ser vacio")]
        [StringLength(255)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Fecha fin")]
        [DataType(DataType.Date)]
        public DateTime DateStop { get; set; } = DateTime.Now.AddDays(30);

        [Required]
        [Display(Name = "Interes")]
        [Range(1, 12)]
        public decimal Interest { get; set; }       

        [Required]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [Range(1, 100000,ErrorMessage ="La cantida debe ser entre {1} y {2}")]
        public decimal Amount { get; set; }
                
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [Range(1, 100000, ErrorMessage = "La cantida debe ser entre {1} y {2}")]
        public decimal AmountFinal { get; set; }
                
        [Required(ErrorMessage ="Elija una opción")]
        [Range(1,3)]
        [Display(Name = "Instrucción")]
        public int InstructionId { get; set; }

        [Required(ErrorMessage ="Elija una opción")]
        [Range(1,180)]
        [Display(Name = "Plazo")]
        public int Term { get; set; }

        [StringLength(250)]
        [Display(Name = "Nota")]
        public string Note { get; set; }

        [DisplayName("Vence")]
        public int ExpireState { 
            get {
                TimeSpan dateDiference;

                dateDiference = this.DateStop.Date - DateTime.Now.Date;

                return dateDiference.Days;
            }  
        }
    }
}