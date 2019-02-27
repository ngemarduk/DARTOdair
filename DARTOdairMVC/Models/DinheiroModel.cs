using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DARTOdairMVC.Models
{
    public class DinheiroModel
    {
        [Display(Name = "Valor Total")]
        [Required(ErrorMessage = "Digite o valor total.")]
        [DataType(DataType.Currency)]
        public decimal valorTotal { get; set;}

        [Display(Name = "Valor Pago")]
        [Required(ErrorMessage = "Digite o valor pago.")]
        [DataType(DataType.Currency)]
        public decimal valorPago { get; set; }

    }
}
