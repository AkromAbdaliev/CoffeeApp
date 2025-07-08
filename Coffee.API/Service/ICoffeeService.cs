using Coffee.API.Entities;

namespace Coffee.API.Service
{
    public interface ICoffeeService
    {
        Task<List<CoffeeRecord>> GetAllAsync();
        Task<CoffeeRecord?> GetByIdAsync(int id);
        Task AddAsync(CoffeeRecord record);
    }
}
