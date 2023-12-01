using SSSKLv2.Data;

namespace SSSKLv2.Services.Interfaces;

public interface IProductService
{
    public Task<Product> GetProductById(Guid id);
    public Task<IEnumerable<Product>> GetAll();
    public Task CreateProduct(Product obj);
    public Task UpdateProduct(Product obj);
    public Task CreateProduct(Guid id);
}