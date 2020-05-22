using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Data.Entities
{
    public class Usuarios 
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Apellido_Paterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string Apellido_Materno { get; set; }
        

        [MaxLength(100, ErrorMessage = "El valor {0} no es valido {1} characters length.")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        

    }
}