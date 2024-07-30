using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infrastructure.Context
{
    public class VirtualRepository
    {
        private readonly string _connectionString;

        public VirtualRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<TblClientes>> GetAllTblClientes()
        {
            var TblClientes = new List<TblClientes>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "select tbc.Id, tbc.RazonSocial, ctcl.TipoCliente, tbc.FechaCreacion, tbc.RFC from TblClientes tbc\r\nleft join CatTipoCliente ctCl on  tbc.IdTipoCliente = ctCl.Id";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var customer = new TblClientes
                            {
                                Id = (int)reader["Id"],
                                TipoCliente = (string)reader["TipoCliente"],
                                RazonSocial = (string)reader["RazonSocial"],
                                FechaCreacion = (DateTime)reader["FechaCreacion"],
                                RFC = (string)reader["RFC"]
                            };
                            TblClientes.Add(customer);
                        }
                    }
                }
            }

            return TblClientes;
        }


        public async Task<List<CatProductos>> GetAllCatProductos()
        {
            var catProduct = new List<CatProductos>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "select Id, NombreProducto, ImagenProducto, PrecioUnitario, ext from CatProductos ";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var products = new CatProductos
                            {
                                Id = (int)reader["Id"],
                                NombreProducto = (string)reader["NombreProducto"],
                                ImagenProducto = (byte[])reader["ImagenProducto"],
                                PrecioUnitario = (decimal)reader["PrecioUnitario"],
                                Ext = (string)reader["ext"]
                            };
                            catProduct.Add(products);
                        }
                    }
                }
            }

            return catProduct;
        }

        public async Task<List<TblFacturas>> GetInvoiceByIdCustomer(int id)
        {
            var tblFacturas = new List<TblFacturas>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "select tbf.Id, FechaEmisionFactura,tblc.RazonSocial, NumeroFactura, NumeroTotalArticulos, SubTotalFacturas, TotalImpuestos, TotalFactura  from TblFacturas tbf\r\nleft join TblClientes tblc on tbf.IdCliente = tblc.Id  where tbf.IdCliente =@Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var invocie = new TblFacturas
                            {
                                Id = (int)reader["Id"],
                                FechaEmisionFactura = (DateTime)reader["FechaEmisionFactura"],
                                NumeroFactura = (int)reader["NumeroFactura"],
                                NumeroTotalArticulos = (int)reader["NumeroTotalArticulos"],
                                TotalImpuestos = (decimal)reader["TotalImpuestos"],
                                SubTotalFactura = (decimal)reader["SubTotalFactura"],
                                RazonSocial = (string)reader["RazonSocial"]
                            };
                            tblFacturas.Add(invocie);
                        }
                    }
                }
            }

            return tblFacturas;
        }
    }
}
