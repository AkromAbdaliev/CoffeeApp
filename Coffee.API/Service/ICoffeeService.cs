using Coffee.API.DTOs;
using Coffee.API.Entities;

namespace Coffee.API.Service
{
    public interface ICoffeeService
    {
        Task<List<CoffeeRecordDto>> GetAllAsync();
        Task<CoffeeRecordDto?> GetByIdAsync(int id);
        Task AddAsync(CreateCoffeeDto record);
        Task DeleteAsync(int id);
    }
}
