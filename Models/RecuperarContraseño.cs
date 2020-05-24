using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class RecuperarContraseño
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
