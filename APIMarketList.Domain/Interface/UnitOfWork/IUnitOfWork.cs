using APIMarketList.Domain.Interface.Repositories;

namespace APIMarketList.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IProductRepository Product { get; }
        IProductShoppingRepository ProductShopping { get; }
        IShoppingRepository Shopping { get; }
    }
}
