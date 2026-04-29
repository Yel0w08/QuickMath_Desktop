using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

/// <summary>
/// Coordinates shop queries and purchases for the current local user.
/// </summary>
public sealed class ShopService
{
    private readonly ShopRepository _shopRepository;
    private readonly UserSession _userSession;

    /// <summary>
    /// Creates the service with its repository and the current in-memory session.
    /// </summary>
    public ShopService(ShopRepository shopRepository, UserSession userSession)
    {
        _shopRepository = shopRepository;
        _userSession = userSession;
    }

    /// <summary>
    /// Returns the visible catalog for one shop category.
    /// </summary>
    public IReadOnlyList<ShopCatalogItem> GetCatalog(int userId, ShopCategory category)
    {
        return _shopRepository.GetCatalog(userId, category);
    }

    /// <summary>
    /// Commits a shop purchase and refreshes the user snapshot kept in memory.
    /// </summary>
    public PurchaseResult Purchase(int userId, IReadOnlyCollection<int> shopItemIds)
    {
        var result = _shopRepository.Purchase(userId, shopItemIds);
        _userSession.SetCurrentUser(result.UpdatedUser);
        return result;
    }
}
