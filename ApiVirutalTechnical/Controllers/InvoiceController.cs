using Application.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiVirutalTechnical.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{idCustomer}")]
        public async Task<List<TblFacturas>> GetInvoiceByIdCustomer(int idCustomer)
        {
            List<TblFacturas> tblFacturas = await _mediator.Send(new GetInvoiceByIdCustomerQuery(idCustomer));
            return tblFacturas;
        }
    }
}
