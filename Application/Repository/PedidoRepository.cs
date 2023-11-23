
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    protected readonly JardineriaContext _context;

    public PedidoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> PedidosNoEntregadosATiempo()
    {
        var pedidos = await _context.Pedidos
                        .Where(p => p.FechaEntrega.HasValue && p.FechaEntrega > p.FechaEsperada)
                        .ToListAsync();
        return pedidos;
    }

    public async Task<IEnumerable<object>> ProductosMasVendidos()
    {
        var productosVendidos = await _context.DetallePedidos
            .GroupBy(dp => dp.CodigoProducto)
            .Select(group => new
            {
                CodigoProducto = group.Key,
                TotalUnidadesVendidas = group.Sum(dp => dp.Cantidad)
            })
            .OrderByDescending(result => result.TotalUnidadesVendidas)
            .Take(20)
            .ToListAsync();

        return productosVendidos;
    }

     



}