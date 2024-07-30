using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetAllProductQuery : IRequest<List<CatProductos>>
    {
    }
}
