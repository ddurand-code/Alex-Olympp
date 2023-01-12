using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using MyShop.Api.DTOs;
using MyShop.Domain.Commands;
using MyShop.Domain.Entities;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Ports.Commands;
using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Queries;

namespace MyShop.Controllers
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
        public async Task<ActionResult<List<OfferEntity>>> GetAllOffer()
        {
            try
            {
                var res = await new GetAllOffersQuery().QueryAsync(_queryRouter);
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

        [HttpPost("/offer/all")]
        public async Task<ActionResult<string>> CreateOffer([FromQuery] OfferDTO dto)
        {
            try
            {
                var tmpOffer = new OfferEntity(dto.ProductId, dto.ProductName, dto.ProductBrand, dto.ProductSize,
                    dto.Quantity, dto.Price);

                var res = await new CreateOfferCommand(tmpOffer).CommandAsync(_commandRouter);
                return StatusCode(200, res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPut("/offer/all")]
        public async Task<ActionResult<string>> UpdateOffer([FromQuery] OfferDTO dto)
        {
            var tmpOffer = new OfferEntity(dto.ProductId, dto.ProductName, dto.ProductBrand, dto.ProductSize,
                dto.Quantity, dto.Price);

            var res = await new UpdateOfferCommand(tmpOffer).CommandAsync(_commandRouter);
            return StatusCode(200, res);
        }
    }
}