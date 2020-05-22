using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;
using Ventas.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class DataContext : DbContext
    {
        public  DbSet <Product> Products { get; set; }
        public DbSet <Usuarios> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetallesPedido> DetallesOrden { get; set; }
        public DbSet<DetallesPedidoTemporal> DetallesPedidoTemporal { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
    }
}
 