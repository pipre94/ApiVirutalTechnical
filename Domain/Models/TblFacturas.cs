using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TblFacturas
    {
        public int Id { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public int IdCliente { get; set; }
        public int NumeroFactura {  get; set; }
        public int NumeroTotalArticulos { get; set; }
        public decimal TotalImpuestos {  get; set; }
        public decimal TotalFactura { get; set; }
        public decimal SubTotalFactura { get; set; }
        public string RazonSocial {  get; set; }
    }
}
