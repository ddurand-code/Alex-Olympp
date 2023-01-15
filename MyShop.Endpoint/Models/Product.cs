using System;
using System.Collections.Generic;

namespace MyShop.Endpoint.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public string Productbrand { get; set; } = null!;

    public string Productsize { get; set; } = null!;

    public int Stockid { get; set; }

    public int Priceid { get; set; }

    public virtual Price Price { get; set; } = null!;

    public virtual Stock Stock { get; set; } = null!;
}
