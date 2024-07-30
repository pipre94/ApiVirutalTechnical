using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetInvoiceByIdCustomerQuery :IRequest<List<TblFacturas>>
    {
        public int IdCustomer { get; set; }

        public GetInvoiceByIdCustomerQuery(int id) 
        { 
            IdCustomer = id;
        }
    }
}
