using SSSKLv2.Components.Pages;
using SSSKLv2.Data;

namespace SSSKLv2.Services.Interfaces;

public interface IOrderService
{
    public Task<Order> GetOrderById(Guid id);
    public Task<IQueryable<Order>> GetAllQueryable();
    public Task<IQueryable<Order>> GetPersonalQueryable(string username);
    public Task CreateOrder(Home.BestellingDTO order);
    public Task DeleteOrder(Guid id);
}