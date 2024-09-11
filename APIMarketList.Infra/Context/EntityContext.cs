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
        public ShoppingPurchase Shoppings { get; set; }
        public User Users { get; set; }
        public ShoppingList ProductShoppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MappingGroup());
            modelBuilder.ApplyConfiguration(new MappingMember());
            modelBuilder.ApplyConfiguration(new MappingProduct());
            modelBuilder.ApplyConfiguration(new MappingShoppingList());
            modelBuilder.ApplyConfiguration(new MappingShoppingListItem());
            modelBuilder.ApplyConfiguration(new MappingShoppingPurchase());
            modelBuilder.ApplyConfiguration(new MappingUser());
        }
    }
}
