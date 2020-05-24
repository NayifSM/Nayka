using Microsoft.AspNetCore.Http;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Models
{
    public class ProductModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }//IFormFiles es un archivo en memoria donde se guardara un archivo momentaneamente


    }
}
