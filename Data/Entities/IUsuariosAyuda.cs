using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Data.Entities
{
    public interface IUsuariosAyuda
    {


        Task<IdentityResult> AñadirUsuario(Usuarios usuarios);
        Task<Usuarios> ObtenerUsuarioNombreAsync(string Nombre);

        Task<IdentityResult> ActulizarUsuarioAsync(Usuarios usuarios);
        Task<   Usuarios> ObtenerUsuarioIDAsync(string userId);

        Task<List<Usuarios>> ObtenertodosUsuairosAsync();
        Task EliminarUsuarioAsync(Usuarios usuarios);

    }
}

