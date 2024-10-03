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

        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<ShoppingPurchase> ShoppingPurchases { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
