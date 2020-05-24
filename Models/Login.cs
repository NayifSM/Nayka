using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string NombreUsuario { get; set; }

        [Required]
        [MinLength(6)]
        public string Contraseña { get; set; }

        public bool Recuerdame { get; set; }

    }
}
