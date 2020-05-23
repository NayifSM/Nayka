using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Data.Entities
{
    
    public interface IRepositorioProducto : IRepositorioGenerico<Product>
    {
        IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboProducts();
    }
}
