using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.UnitOfWork;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories;

namespace APIMarketList.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;
        public IUserRepository User { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductShoppingRepository ProductShopping { get; private set; }
        public IShoppingRepository Shopping { get; private set; }

        public UnitOfWork(EntityContext context) => _context = context;

        public IUserRepository UserRepository
        {
            get
            {
                if (User == null)
                {
                    User = new UserRepository(_context);
                }
                return User;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (Product == null)
                {
                    Product = new ProductRepository(_context);
                }
                return Product;
            }
        }

        public IProductShoppingRepository ProductShoppingRepository
        {
            get
            {
                if (ProductShopping == null)
                {
                    ProductShopping = new ProductShoppingRepository(_context);
                }
                return ProductShopping;
            }
        }

        public IShoppingRepository ShoppingRepository
        {
            get
            {
                if (Shopping == null)
                {
                    Shopping = new ShoppingRepository(_context);
                }
                return Shopping;
            }
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
