
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    protected readonly JardineriaContext _context;

    public ClienteRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .FirstOrDefaultAsync(p => p.CodigoCliente == id);
    }

    public async Task<IEnumerable<object>> ObtenerClientesNoPagosYRepresentantesConCiudadOficina()
    {
        var clientesSinPagosYRepresentantes = await _context.Clientes
            .Include(c => c.CodigoEmpleadoRepVentasNavigation)
            .ThenInclude(e => e.CodigoOficinaNavigation)
            .Where(c => c.CodigoEmpleadoRepVentasNavigation != null && !c.Pagos.Any())
            .Select(c => new
            {
                NombreCliente = c.NombreCliente,
                NombreRepresentante = c.CodigoEmpleadoRepVentasNavigation.Nombre,
                ApellidoRepresentante = c.CodigoEmpleadoRepVentasNavigation.Apellido1,
                CiudadOficinaRepresentante = c.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Ciudad
            })
            .ToListAsync();

        return clientesSinPagosYRepresentantes;
    }

    public async Task<IEnumerable<object>> EmpleadosSinClientesConJefe()
    {
        var query = from empleado in _context.Empleados
                    where empleado.Clientes.Count == 0
                    select new
                    {
                        empleado.CodigoEmpleado,
                        empleado.Nombre,
                        empleado.Apellido1,
                        empleado.Apellido2,
                        empleado.Extension,
                        empleado.Email,
                        JefeNombre = empleado.CodigoJefeNavigation != null
                            ? $"{empleado.CodigoJefeNavigation.Nombre} {empleado.CodigoJefeNavigation.Apellido1}"
                            : null,
                        JefeEmail = empleado.CodigoJefeNavigation != null ? empleado.CodigoJefeNavigation.Email : null
                    };

        return await query.ToListAsync();
    }



    



}
