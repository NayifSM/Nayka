using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ventas.Web.Data.Entities;
using Ventas.Web.Models;

namespace Ventas.Web.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IRepositorioProducto repositorioProducto;
        private readonly IRepositorioPedido repositorioPedido;

        public PedidosController(
            IRepositorioProducto repositorioPedido,
            IRepositorioPedido repositorioProducto)
        {
            this.repositorioProducto = repositorioPedido;
            this.repositorioPedido = repositorioProducto;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var model = await repositorioPedido.GetOrdersAsync(this.User.Identity.Name);
            return View(model);
        }
          public async Task<IActionResult> Create()
                {
                    var model = await this.repositorioPedido.GetDetailTempsAsync(this.User.Identity.Name);
                    return this.View(model);
                }
        public IActionResult AddProduct()
        {
            var model = new AgregarElemento
            {
                Cantidad = 1,
                Products = this.repositorioProducto.GetComboProducts()
            };

            return View(model);
        }
      

        [HttpPost]
        public async Task<IActionResult> AddProduct(AgregarElemento model)
        {
            if (this.ModelState.IsValid)
            {
                await this.repositorioPedido.AddItemToOrderAsync(model, this.User.Identity.Name);
                return this.RedirectToAction("Create");
            }

            return this.View(model);
        }
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await this.repositorioPedido.DeleteDetailTempAsync(id.Value);
            return this.RedirectToAction("Create");
        }

        public async Task<IActionResult> Increase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await this.repositorioPedido.ModifyOrderDetailTempQuantityAsync(id.Value, 1);
            return this.RedirectToAction("Create");
        }

        public async Task<IActionResult> Decrease(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await this.repositorioPedido.ModifyOrderDetailTempQuantityAsync(id.Value, -1);
            return this.RedirectToAction("Create");
        }
        public async Task<IActionResult> ConfirmOrder()
        {
            var response = await this.repositorioPedido.ConfirmOrderAsync(this.User.Identity.Name);
            if (response)
            {
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("Create");
        }

        public async Task<IActionResult> Deliver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await this.repositorioPedido.GetOrdersAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            var model = new Delivery
            {
                Id = order.Id,
                DeliveryFecha = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Deliver(Delivery model)
        {
            if (this.ModelState.IsValid)
            {
                await this.repositorioPedido.DeliverOrder(model);
                return this.RedirectToAction("Index");
            }

            return this.View();
        }
    }
}
