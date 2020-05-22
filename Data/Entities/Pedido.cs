using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Data.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de Pedido")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime OrdenFecha { get; set; }

        [Display(Name = "Fecha de Delivery")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? DeliveryFecha { get; set; }

        [Required]
        public Usuarios Usuarios { get; set; }

        public IEnumerable<DetallesPedido> Items { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Lineas { get { return this.Items == null ? 0 : this.Items.Count(); } }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Cantidad { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Cantidad); } }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Valor); } }
        /*
        [Display(Name = "Order date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? FechaOrdenLocal
        {
            get
            {
                if (this.OrdenFecha == null)
                {
                    return null;
                }

                return this.OrdenFecha.ToLocalTime();
            }
        }*/
    }
}
