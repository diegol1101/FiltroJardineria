using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPedido :IGenericRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> PedidosNoEntregadosATiempo();
        Task<IEnumerable<object>> ProductosMasVendidos();
    }
}