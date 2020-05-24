

namespace Ventas.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Data;
    using Shop.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Ventas.Web.Data.Entities;


    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUsuariosAyuda usuariosAyuda;
        private readonly Random random;

        public SeedDb(DataContext context, IUsuariosAyuda usuariosAyuda)
        {
            this.context = context;
            this.usuariosAyuda = usuariosAyuda;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            await this.usuariosAyuda.CheckRoleAsync("Admin");
            await this.usuariosAyuda.CheckRoleAsync("Customer");



            var usuarios = await this.usuariosAyuda.GetUserByEmailAsync("nayka@gmail.com");
            if (usuarios == null)
            {
                usuarios = new Usuarios
                {
                    Nombre = "flor",
                    ApellidoPaterno = "matos",
                    ApellidoMaterno = "martinez",
                   /* Correo = "nayka@gmail.com",
                    NombreUsuario = "nayka@gmail.com",
                    Telefono = "3506342747",*/
                    Direccion = "Calle Luna Calle Sol",

                };

                var result = await this.usuariosAyuda.AddUserAsync(usuarios, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
                await this.usuariosAyuda.AddUserToRoleAsync(usuarios, "Admin");
                var token = await this.usuariosAyuda.GenerateEmailConfirmationTokenAsync(usuarios);
                 await this.usuariosAyuda.ConfirmEmailAsync(usuarios, token);

            }

            var isInRole = await this.usuariosAyuda.IsUserInRoleAsync(usuarios, "Admin");
            if (!isInRole)
            {
                await this.usuariosAyuda.AddUserToRoleAsync(usuarios, "Admin");
            }


            //si hay algun producto devuelve true
            if (!this.context.Products.Any())
            {
                this.AddProduct("papaya", usuarios);
                this.AddProduct("piña", usuarios);
                this.AddProduct("surtido", usuarios);
                await this.context.SaveChangesAsync();


            }
        }

        private void AddProduct(String name, Usuarios usuarios)
        {
            // a la collecion de productos adicionar un nuevo producto el q paso por parametro al igual q el precio
            this.context.Products.Add(new Product
            {
                Nombre = name,
                Precio = this.random.Next(1000),
                Disponible = true,
                Stock = this.random.Next(100)
            });

        }
    }

    
}
