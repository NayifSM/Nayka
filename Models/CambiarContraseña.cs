using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class CambiarContraseña
    {
        [Required]
        [Display(Name = "Antigua Contraseña")]
        public string AntiguaContraseña { get; set; }

        [Required]
        [Display(Name = "Nueva contraseña")]
        public string NuevaContraseña { get; set; }

        [Required]
        [Compare("NuevaContraseña")]
        public string Confirmar { get; set; }

    }
}
