using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Endpoint.Models;
using MyShop.Endpoint.Ports;

namespace MyShop.Endpoint
{
    public class MyShopDbContextProvider : IDbContextFactory
    {
        public MyshopdbContext CreateDbContext()
        {
            return new MyshopdbContext();
        }
    }
}
