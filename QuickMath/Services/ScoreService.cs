using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

/// <summary>
/// Exposes read-only score and statistics use cases to the UI.
/// </summary>
public sealed class ScoreService
{
    private readonly ScoreRepository _scoreRepository;

    /// <summary>
    /// Creates the service with its SQL-backed repository.
    /// </summary>
    public ScoreService(ScoreRepository scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    /// <summary>
    /// Loads aggregated player statistics for the requested user.
    /// </summary>
    public UserStatistics GetStatistics(int userId) => _scoreRepository.GetStatistics(userId);
}
