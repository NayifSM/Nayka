using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Delivery")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryFecha { get; set; }
    }
}
