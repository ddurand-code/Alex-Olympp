using Microsoft.EntityFrameworkCore;
using MyShop.Endpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Endpoint.Ports
{
    public interface IDbContextFactory : IDbContextFactory<MyshopdbContext>
    {
    }
}
