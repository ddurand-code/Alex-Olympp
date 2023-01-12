using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entities
{
    public class OfferEntity
    {
        public OfferEntity(int id, string name, string brand, string size, int quantity, double price)
        {
            ProductId = id;
            ProductName = name;
            ProductBrand = brand;
            ProductSize = size;
            Quantity = quantity;
            Price = price;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductSize { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
