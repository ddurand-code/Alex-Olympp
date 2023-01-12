namespace MyShop.Api.DTOs
{
    public class OfferDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductSize { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
