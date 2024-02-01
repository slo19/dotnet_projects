using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System;

namespace SportsStore.Context {
    public class StoreDbContext : DbContext {

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options){

        }

        public DbSet<Product> Products => Set<Product>();
    }
}