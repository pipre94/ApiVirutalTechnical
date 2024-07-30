using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllTblClienteQueryHandle : IRequestHandler<GetAllTblClientesQuery, List<TblClientes>>
    {
        private readonly IVirtualServices _virtualServices;

        public GetAllTblClienteQueryHandle(IVirtualServices virtualServices)
        {
            _virtualServices = virtualServices;
        }

        public async Task<List<TblClientes>> Handle(GetAllTblClientesQuery query, CancellationToken cancellationToken)
        {
            List<TblClientes> tblClientes = new();
            tblClientes = await _virtualServices.GetAllTblClientesAsync();
            return tblClientes;
        }
    }
}
