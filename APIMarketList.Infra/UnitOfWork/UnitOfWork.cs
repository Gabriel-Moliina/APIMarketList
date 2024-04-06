using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.UnitOfWork;
using APIMarketList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;
        public IUserRepository User { get; }
        public IProductRepository Product { get; }
        public IProductShoppingRepository ProductShopping { get; }
        public IShoppingRepository Shopping { get; }

        public UnitOfWork(EntityContext context,
            IUserRepository userRepository,
            IProductRepository productRepository,
            IProductShoppingRepository productShoppingRepository,
            IShoppingRepository shoppingRepository)
        {
            _context = context;

            User = userRepository;
            Product = productRepository;
            ProductShopping = productShoppingRepository;
            Shopping = shoppingRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
