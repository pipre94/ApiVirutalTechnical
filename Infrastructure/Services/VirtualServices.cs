using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Services
{
    public class VirtualServices : IVirtualServices
    {
        private readonly VirtualRepository _repository;

        public VirtualServices(VirtualRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<List<TblClientes>> GetAllTblClientesAsync()
        {
            return await _repository.GetAllTblClientes();
        }
        public async Task<List<CatProductos>> GetCatProductosAsync()
        {
            return await _repository.GetAllCatProductos();
        }

        public async Task<List<TblFacturas>> GetInvoiceByIdCustomerAsync(int idCustomer)
        {
            return await _repository.GetInvoiceByIdCustomer(idCustomer);
        }
    }
}
