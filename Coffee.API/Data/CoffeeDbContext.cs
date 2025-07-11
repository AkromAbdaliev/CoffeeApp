﻿using Coffee.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee.API.Data
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
            : base(options)
        {
        }
        public DbSet<CoffeeRecord> CoffeeRecords { get; set; } = null!;
    }
}
