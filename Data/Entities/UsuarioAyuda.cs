using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Web.Data.Entities;

namespace Ventas.Web.Data
{
    public class UsuarioAyuda :IUsuariosAyuda
    {
        //private readonly UserManager<Usuarios> UsuarioAdministrador;


        public async Task<IdentityResult> AñadirUsuario(Usuarios usuarios  )
        {
            return await this.AñadirUsuario(usuarios);
        }
        public async Task<Usuarios> ObtenerUsuarioNombreAsync(string Nombre)
        {
            return await this.ObtenerUsuarioNombreAsync(Nombre);
        }
        public async Task<IdentityResult> ActulizarUsuarioAsync(Usuarios usuarios)
        {
            return await this.ActulizarUsuarioAsync(usuarios);
        }
        public async Task<Usuarios> ObtenerUsuarioIDAsync(string userId)
        {
            return await this.FindByIdAsync(userId);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await this.userManager.Users
                .Include(u => u.City)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }
        public async Task DeleteUserAsync(User user)
        {
            await this.userManager.DeleteAsync(user);
        }
    }
}
