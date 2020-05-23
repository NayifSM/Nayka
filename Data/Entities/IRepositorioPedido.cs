using Shop.Web.Data.Entities;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Web.Models;

namespace Ventas.Web.Data.Entities
{

    //username=nombre
    public interface IRepositorioPedido : IRepositorioGenerico<Pedido>
    {
        Task<IQueryable<Pedido>> GetOrdersAsync(string Nombre);

        Task<Pedido> GetOrdersAsync(int id);

        Task<IQueryable<DetallesPedidoTemporal>> GetDetailTempsAsync(string Nombre);

        Task AddItemToOrderAsync(AgregarElemento model, string Nombre);

        Task ModifyOrderDetailTempQuantityAsync(int id, double Cantidad);

        Task DeleteDetailTempAsync(int id);

        Task<bool> ConfirmOrderAsync(string Nombre);

        Task DeliverOrder(Delivery model);
    }

}
