using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVirtualServices
    {
        Task<List<TblClientes>> GetAllTblClientesAsync();
        //Task<TblFacturas> AddNewInvoiceAsync(TblFacturas factura);
        Task<List<TblFacturas>> GetInvoiceByIdCustomerAsync(int idCustomer);
        Task<List<CatProductos>> GetCatProductosAsync();
    }
}
