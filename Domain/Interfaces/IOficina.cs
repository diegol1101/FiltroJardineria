using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOficina :IGenericRepository<Oficina>
    {
        Task<IEnumerable<Oficina>> OficinasNoEmFrutales();
    }
}