using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICliente :IGenericRepository<Cliente>
    {
        Task<IEnumerable<object>> ObtenerClientesNoPagosYRepresentantesConCiudadOficina();
        Task<IEnumerable<object>> EmpleadosSinClientesConJefe();
    }
}