
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

    public class GamaProductoRepository : GenericRepository<GamaProducto>, IGamaProducto
    {
        protected readonly JardineriaContext _context;

        public GamaProductoRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }


    }