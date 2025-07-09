using Coffee.API.Data;
using Coffee.API.DTOs;
using Coffee.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee.API.Service
{
    public class CoffeeService : ICoffeeService
    {
        private readonly CoffeeDbContext _context;
        public CoffeeService(CoffeeDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(CreateCoffeeDto record)
        {
            var entity = new CoffeeRecord
            {
                Type = record.Type,
                Bean = record.Bean,
                Location = record.Location,
                NoOfShots = record.NoOfShots,
                Score = record.Score,
                Price = record.Price,
                DateCreated = DateTime.UtcNow
            };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, CreateCoffeeDto record)
        {
            var exists = await _context.CoffeeRecords.FindAsync(id);
            if (exists == null) 
            {
                return false;
            }
            
            exists.Type = record.Type;
            exists.Bean = record.Bean;
            exists.Location = record.Location;
            exists.NoOfShots = record.NoOfShots;
            exists.Score = record.Score;
            exists.Price = record.Price;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.CoffeeRecords.FindAsync(id);
            if(record is not null)
            {
                _context.CoffeeRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CoffeeRecordDto>> GetAllAsync()
        {
            var records = await _context.CoffeeRecords
        .OrderByDescending(r => r.DateCreated)
        .ToListAsync();

            return records.Select(r => new CoffeeRecordDto
            {
                Id = r.Id,
                Type = r.Type,
                Bean = r.Bean,
                Location = r.Location,
                DateCreated = r.DateCreated,
                NoOfShots = r.NoOfShots,
                Score = r.Score,
                Price = r.Price
            }).ToList();
        }

        public async Task<CoffeeRecordDto?> GetByIdAsync(int id)
        {
            var record = await _context.CoffeeRecords.FindAsync(id);
            if (record == null)
                return null;

            return new CoffeeRecordDto
            {
                Id = record.Id,
                Type = record.Type,
                Bean = record.Bean,
                Location = record.Location,
                DateCreated = record.DateCreated,
                NoOfShots = record.NoOfShots,
                Score = record.Score,
                Price = record.Price
            };
        }

    }
}
