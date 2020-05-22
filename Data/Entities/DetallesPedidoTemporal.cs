using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Data.Entities
{
    public class DetallesPedidoTemporal
    {
        public int Id { get; set; }
        /*
        [Required]
        public User User { get; set; }
        */

        [Required]
        public Product Product { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value { get { return this.Precio * (decimal)this.Cantidad; } }
    }
}
