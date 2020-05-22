using Microsoft.EntityFrameworkCore;
using Shop.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Web.Models;

namespace Ventas.Web.Data.Entities
{
    public class RepositorioPedidos 
    {
        private readonly DataContext context;
        public RepositorioPedidos(DataContext context) 
        {
            this.context = context;
        }
        public async Task<IQueryable<Pedido>> GetOrdersAsync(string userName)
        {
            return this.context.Pedido
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrdenFecha);

        }
        public async Task<IQueryable<DetallesPedidoTemporal>> GetDetailTempsAsync(string userName)
        {

            return this.context.DetallesPedidoTemporal
                .Include(o => o.Product)
                .OrderBy(o => o.Product.Nombre);
        }
        public async Task AddItemToOrderAsync(AgregarElemento model, string userName)
        {
            var product = await this.context.Products.FindAsync(model.ProductId);
            if (product == null)
            {
                return;
            }

            var DetallesPedidoTemporal = await this.context.DetallesPedidoTemporal
                .FirstOrDefaultAsync();
            if (DetallesPedidoTemporal == null)
            {
                DetallesPedidoTemporal = new DetallesPedidoTemporal
                {
                    Precio = product.Precio,
                    Product = product,
                    Cantidad = model.Cantidad,

                };

                this.context.DetallesPedidoTemporal.Add(DetallesPedidoTemporal);
            }
            else
            {
                DetallesPedidoTemporal.Cantidad += model.Cantidad;
                this.context.DetallesPedidoTemporal.Update(DetallesPedidoTemporal);
            }

            await this.context.SaveChangesAsync();
        }
        public async Task ModifyOrderDetailTempQuantityAsync(int id, double quantity)
        {
            var DetallesPedidoTemporal = await this.context.DetallesPedidoTemporal.FindAsync(id);
            if (DetallesPedidoTemporal == null)
            {
                return;
            }

            DetallesPedidoTemporal.Cantidad += quantity;
            if (DetallesPedidoTemporal.Cantidad > 0)
            {
                this.context.DetallesPedidoTemporal.Update(DetallesPedidoTemporal);
                await this.context.SaveChangesAsync();
            }
        }
        public async Task DeleteDetailTempAsync(int id)
        {
            var DetallesPedidoTemporal = await this.context.DetallesPedidoTemporal.FindAsync(id);
            if (DetallesPedidoTemporal == null)
            {
                return;
            }

            this.context.DetallesPedidoTemporal.Remove(DetallesPedidoTemporal);
            await this.context.SaveChangesAsync();
        }
        public async Task<bool> ConfirmOrderAsync(string userName)
        {


            var orderTmps = await this.context.DetallesPedidoTemporal
                .Include(o => o.Product)
                .ToListAsync();

            if (orderTmps == null || orderTmps.Count == 0)
            {
                return false;
            }

            var details = orderTmps.Select(o => new DetallesPedido
            {
                Precio = o.Precio,
                Product = o.Product,
                Cantidad = o.Cantidad
            }).ToList();

            var order = new Pedido
            {
                OrdenFecha = DateTime.UtcNow,
                Items = details,
            };

            this.context.Pedido.Add(order);
            this.context.DetallesPedidoTemporal.RemoveRange(orderTmps);
            await this.context.SaveChangesAsync();
            return true;
        }
        public async Task DeliverOrder(Delivery model)
        {
            var order = await this.context.Pedido.FindAsync(model.Id);
            if (order == null)
            {
                return;
            }

            order.DeliveryFecha = model.DeliveryFecha;
            this.context.Pedido.Update(order);
            await this.context.SaveChangesAsync();
        }
        public async Task<Pedido> GetOrdersAsync(int id)
        {
            return await this.context.Pedido.FindAsync(id);
        }
    }
}
