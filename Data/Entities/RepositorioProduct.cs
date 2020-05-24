﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Web.Data.Entities
{
    public class RepositorioProduct : RepositorioGenerico<Product>,IRepositorioProduct
    {
		private readonly DataContext context;

		public RepositorioProduct(DataContext context) : base(context) 
		{
			this.context = context;
		}
		public IQueryable GetAllWithUsers()
		{
			return this.context.Products.Include(p => p.Usuarios);
		}
		public IEnumerable<SelectListItem> GetComboProducts()
		{
			var list = this.context.Products.Select(p => new SelectListItem
			{
				Text = p.Nombre,
				Value = p.Id.ToString()
			}).ToList();

			list.Insert(0, new SelectListItem
			{
				Text = "(Select a product...)",
				Value = "0"
			});

			return list;
		}

	}
}
