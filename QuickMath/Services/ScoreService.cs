using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

public sealed class ScoreService
{
    private readonly ScoreRepository _scoreRepository;

    public ScoreService(ScoreRepository scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    public UserStatistics GetStatistics(int userId) => _scoreRepository.GetStatistics(userId);
}
