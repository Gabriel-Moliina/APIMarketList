using APIMarketList.Domain.Entities;
using APIMarketList.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        public Product Products { get; set; }
        public Shopping Shoppings { get; set; }
        public User Users { get; set; }
        public ProductShopping ProductShoppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MappingProduct());
            modelBuilder.ApplyConfiguration(new MappingShopping());
            modelBuilder.ApplyConfiguration(new MappingUser());
        }
    }
}
