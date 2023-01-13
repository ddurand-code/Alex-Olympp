using System;
using System.Collections.Generic;

namespace MyShop.Endpoint.Models;

public partial class Price
{
    public int Priceid { get; set; }

    public decimal Pricevalue { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
