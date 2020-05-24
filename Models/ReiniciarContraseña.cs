using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class ReiniciarContraseña
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Contraseña")]
        public string ConfirmarContraseña { get; set; }

        [Required]
        public string Token { get; set; }

    }
}
