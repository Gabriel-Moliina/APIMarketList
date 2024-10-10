using APIMarketList.Domain.DTO.Member;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(EntityContext context) : base(context)
        {
        }

        public async Task<IList<ShoppingListDTO>> GetByUser(int userId)
        {
            var query = (from shoppingList in _dbSet.AsNoTracking()
                         join members in _context.Members on shoppingList.Id equals members.ShoppingListId
                         where members.UserId == userId
                         select new ShoppingListDTO
                         {
                             Description = shoppingList.Description,
                             TargetDate = shoppingList.TargetDate,
                             Status = shoppingList.Status
                         });

            return await query.ToListAsync();
        }

        public async Task<ShoppingListDTO?> Get(int id)
        {
            var query = (from shoppingList in _dbSet.AsNoTracking()
                         where id == 0 || shoppingList.Id == id
                         select new ShoppingListDTO
                         {
                             Description = shoppingList.Description,
                             TargetDate = shoppingList.TargetDate,
                             Status = shoppingList.Status,
                             Members = (from users in _context.Users.AsNoTracking()
                                        join members in _context.Members on users.Id equals members.UserId
                                        where members.ShoppingListId == shoppingList.Id
                                        select new MemberDTO
                                        {
                                            CanUpdate = members.CanUpdate,
                                            Email = users.Email,
                                            IsAdmin = members.IsAdmin,
                                            Name = users.Name
                                        }).ToList()
                         });

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<ShoppingListDTO>> GetAll()
        {
            var query = (from shoppingList in _dbSet.AsNoTracking()
                         select new ShoppingListDTO
                         {
                             Description = shoppingList.Description,
                             TargetDate = shoppingList.TargetDate,
                             Status = shoppingList.Status,
                             Members = (from users in _context.Users.AsNoTracking()
                                        join members in _context.Members on users.Id equals members.UserId
                                        where members.ShoppingListId == shoppingList.Id
                                        select new MemberDTO
                                        {
                                            CanUpdate = members.CanUpdate,
                                            Email = users.Email,
                                            IsAdmin = members.IsAdmin,
                                            Name = users.Name
                                        }).ToList()
                         });

            return await query.ToListAsync();
        }

        public async Task<bool> Exists(int id) => await _dbSet.AnyAsync(x => x.Id == id);

        public async Task<bool> IsUserInShoppingList(int shoppingListId, int userId)
        {
            return await _dbSet
                .Where(x => x.Id == shoppingListId)
                    .Include(x => x.Members)
                        .Where(x => x.Members.Any(m => m.UserId == userId)).AnyAsync();
        }
    }
}
