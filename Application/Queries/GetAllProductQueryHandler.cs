using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<CatProductos>>
    {
        private readonly IVirtualServices  _virtualServices;

        public GetAllProductQueryHandler(IVirtualServices virtualServices)
        {
            _virtualServices = virtualServices;
        }

        public async Task<List<CatProductos>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            List<CatProductos> catProductos = new();
            catProductos = await _virtualServices.GetCatProductosAsync();
            return catProductos;
        }


    }
}
