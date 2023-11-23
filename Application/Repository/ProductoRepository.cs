
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    protected readonly JardineriaContext _context;

    public ProductoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }



    

}