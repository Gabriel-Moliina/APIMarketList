using APIMarketList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public void Seed()
        {
            if (!Roles.Any(r => r.Name == "Admin")) Roles.Add(new Role { Name = "Admin" });
            if (!Roles.Any(r => r.Name == "Observer")) Roles.Add(new Role { Name = "Observer" });
            if (!Roles.Any(r => r.Name == "Moderator")) Roles.Add(new Role { Name = "Moderator" });
            SaveChanges();
        }
    }
}
