using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class AgregarElemento
    {
        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona un producto")]
        public int ProductId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "La cantidad tiene que ser positiva")]
        public double Cantidad { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
