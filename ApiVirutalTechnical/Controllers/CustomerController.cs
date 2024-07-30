using Application.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiVirutalTechnical.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TblClientes>> GetAllCustomer()
        {
            List<TblClientes> tblClientes = await _mediator.Send(new GetAllTblClientesQuery());
            return tblClientes;
        }
    }
}
