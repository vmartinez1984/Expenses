using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Dtos.Inputs
{
    public class CategoryDtoIn
    {
        [StringLength(20)]
        public string Name { get; set; }

    }
}
