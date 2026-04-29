using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

public sealed class ShopService
{
    private readonly ShopRepository _shopRepository;
    private readonly UserSession _userSession;

    public ShopService(ShopRepository shopRepository, UserSession userSession)
    {
        _shopRepository = shopRepository;
        _userSession = userSession;
    }

    public IReadOnlyList<ShopCatalogItem> GetCatalog(int userId, ShopCategory category)
    {
        return _shopRepository.GetCatalog(userId, category);
    }

    public PurchaseResult Purchase(int userId, IReadOnlyCollection<int> shopItemIds)
    {
        var result = _shopRepository.Purchase(userId, shopItemIds);
        _userSession.SetCurrentUser(result.UpdatedUser);
        return result;
    }
}
