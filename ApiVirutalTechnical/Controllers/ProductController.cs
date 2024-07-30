using Application.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiVirutalTechnical.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<CatProductos>> GetAllProduct()
        {
            List<CatProductos> catProductos = await _mediator.Send(new GetAllProductQuery());
            return catProductos;

        }

    }
}
