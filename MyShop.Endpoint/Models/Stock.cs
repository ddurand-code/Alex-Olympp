using System;
using System.Collections.Generic;

namespace MyShop.Endpoint.Models;

public partial class Stock
{
    public int Stockid { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
