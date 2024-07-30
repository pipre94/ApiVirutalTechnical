using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetInvoiceByIdCustomerQueryHandler :IRequestHandler<GetInvoiceByIdCustomerQuery, List<TblFacturas>>
    {
        private readonly IVirtualServices _virtualServices;

        public GetInvoiceByIdCustomerQueryHandler(IVirtualServices virtualServices)
        {
            _virtualServices = virtualServices;
        }
        public async Task<List<TblFacturas>> Handle(GetInvoiceByIdCustomerQuery query, CancellationToken cancellationToken)
        {
            List<TblFacturas> tblFacturas = await _virtualServices.GetInvoiceByIdCustomerAsync(query.IdCustomer);
            return tblFacturas;
        }
    }
}
