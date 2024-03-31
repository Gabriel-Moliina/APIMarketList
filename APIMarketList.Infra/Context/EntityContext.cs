using APIMarketList.Domain.Entities;
using APIMarketList.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Context
{
    internal class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        public Product Products { get; set; }
        public Shopping Shoppings { get; set; }
        public User Users { get; set; }
        public UserShopping UserShoppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MappingProduct());  
            modelBuilder.ApplyConfiguration(new MappingShopping());  
        }
    }
}
