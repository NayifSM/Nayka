using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Web.Models;

namespace Ventas.Web.Data.Entities
{
    public interface ICorreoAyuda
    {
        void SendMail(string to, string subject, string body);
    }
}
