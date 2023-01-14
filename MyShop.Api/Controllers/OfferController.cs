using Microsoft.AspNetCore.Mvc;
using MyShop.Api.DTOs;
using MyShop.Domain.Commands;
using MyShop.Domain.Entities;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Ports.Commands;
using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Queries;

namespace MyShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IQueryRouter _queryRouter;
        private readonly ICommandRouter _commandRouter;
        private readonly ILogger<OfferController> _logger;

        public OfferController(ILogger<OfferController> logger, IQueryRouter queryRouter, ICommandRouter commandRouter)
        {
            _logger = logger;
            _queryRouter = queryRouter;
            _commandRouter = commandRouter;
        }

        [HttpGet("/offer/all")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAllOffer()
        {
            try
            {
                var res = await new GetAllProductsQuery().QueryAsync(_queryRouter);
                return StatusCode(200, res);
            }
            catch (Exception e)
            {
                if (e is EntityNotFoundException entityNotFoundException)
                {
                    Console.WriteLine(entityNotFoundException.Message);
                    return StatusCode(204);
                }
                throw;
            }
        }

        [HttpPost("/offer/add")]
        public async Task<ActionResult<string>> CreateOffer([FromQuery] ProductDTO dto)
        {
            var entity = new ProductEntity(0, dto.ProductName, dto.ProductBrand, dto.ProductSize,
                dto.Quantity, dto.Price);

            var res = await new CreateProductCommand(entity).CommandAsync(_commandRouter);
            return StatusCode(200, res);
        }

        [HttpPut("/offer/update")]
        public async Task<ActionResult<string>> UpdateOffer([FromQuery] ProductDTO dto)
        {
            var entity = new ProductEntity(dto.ProductId, dto.ProductName, dto.ProductBrand, dto.ProductSize,
                dto.Quantity, dto.Price);

            try
            {
                var res = await new UpdateProductCommand(entity).CommandAsync(_commandRouter);
                return StatusCode(200, res);
            }
            catch (Exception e)
            {
                if (e is EntityNotFoundException entityNotFoundException)
                {
                    Console.WriteLine(entityNotFoundException.Message);
                    return StatusCode(204);
                }
                throw;
            }

        }
    }
}