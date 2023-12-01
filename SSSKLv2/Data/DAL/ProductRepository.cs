using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SSSKLv2.Data.DAL.Exceptions;
using SSSKLv2.Data.DAL.Interfaces;

namespace SSSKLv2.Data.DAL;

public class ProductRepository(IDbContextFactory<ApplicationDbContext> _dbContextFactory) : IProductRepository
{
    public async Task<Product> GetById(Guid id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var entry = await context.Product.FindAsync(id);
        if (entry != null)
        {
            return entry;
        }

        throw new NotFoundException("Product not found");
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        IList<Product> list = new List<Product>();
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        list = await context.Product.ToListAsync();
        return list;
    }

    public async Task Create(Product obj)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Product.Add(obj);
        await context.SaveChangesAsync();
    }

    public async Task Update(Product obj)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Product.Add(obj);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var entry = await context.Product.FindAsync(id);
        if (entry != null)
        {
            context.Product.Remove(entry);
            await context.SaveChangesAsync();
        }
        else throw new NotFoundException("Product Not Found");
    }
}