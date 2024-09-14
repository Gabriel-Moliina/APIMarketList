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

        public Group? Groups { get; set; }
        public Member? Members { get; set; }
        public Product? Products { get; set; }
        public ShoppingList? ShoppingLists { get; set; }
        public ShoppingListItem? ShoppingListItems { get; set; }
        public ShoppingPurchase? ShoppingPurchases { get; set; }
        public User? Users { get; set; }

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
