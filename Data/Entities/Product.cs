using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ventas.Web.Data.Entities;

namespace Shop.Web.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        /// <summary>
        /// antes de la tragedia
        /// </summary>
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name ="Image")]
        public string ImageUrl { get; set; }
        
        [Display(Name = "Ultima Compra")]
        public string UltimaCompra { get; set; }

        [Display(Name = "Ultima Venta")]
        public string UltimaVenta { get; set; }
        
        [Display(Name = "Disponible")]
        public string Disponible { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]

        [Required]
        public double Stock { get; set; }

        public Usuarios Usuarios { get; set; }
        
    }

}
