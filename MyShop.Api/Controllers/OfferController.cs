using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Queries;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IQueryRouter _queryRouter;
        private readonly ILogger<OfferController> _logger;

        public OfferController(ILogger<OfferController> logger, IQueryRouter queryRouter)
        {
            _logger = logger;
            _queryRouter = queryRouter;
        }

        [HttpGet("/offer/all")]
        public async Task<ActionResult<IEnumerable<OfferEntity>>> GetAllOffer()
        {
            var res = await new GetAllOffersQuery().QueryAsync(_queryRouter);

            return StatusCode(200, res);
        }

        [HttpPost("/offer/all")]
        public async Task<ActionResult<string>> CreateOffer()
        {
            return StatusCode(200, "Ok");
        }

        [HttpPut("/offer/all")]
        public async Task<ActionResult<string>> UpdateOffer()
        {
            return StatusCode(200, "Ok");
        }
    }
}