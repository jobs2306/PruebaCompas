using BackEndCompas.Models;
using BackEndCompas.Services.Interfaces;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

public class ProductoService : IProductoService
{
    private readonly string _connectionString;

    public ProductoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Producto>> GetProductosAsync()
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            return await conn.QueryAsync<Producto>("sp_GetProductos", commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<Producto?> GetProductoByIdAsync(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            return await conn.QueryFirstOrDefaultAsync<Producto>(
                "sp_GetProductoById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }

    public async Task<Producto> AddProductoAsync(Producto producto)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            var id = await conn.ExecuteScalarAsync<int>(
                "sp_AddProducto",
                new { producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock },
                commandType: CommandType.StoredProcedure
            );

            producto.Id = id;
            return producto;
        }
    }

    public async Task<bool> UpdateProductoAsync(int id, Producto producto)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            var rowsAffected = await conn.ExecuteAsync(
                "sp_UpdateProducto",
                new { Id = id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock },
                commandType: CommandType.StoredProcedure
            );

            return rowsAffected > 0;
        }
    }

    public async Task<bool> DeleteProductoAsync(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            var rowsAffected = await conn.ExecuteAsync(
                "sp_DeleteProducto",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            return rowsAffected > 0;
        }
    }
}
