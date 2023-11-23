
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        protected readonly JardineriaContext _context;

        public EmpleadoRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }


    }