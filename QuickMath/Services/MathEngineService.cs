using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

public sealed class MathEngineService
{
    private readonly ExerciseRepository _exerciseRepository;
    private readonly Random _random = new();

    public MathEngineService(ExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public ExerciseProblem CreateExercise(int userId, MathOperation operation, DifficultyLevel difficulty)
    {
        var definition = _exerciseRepository.GetDifficultyForUser(userId, operation, difficulty);
        if (!definition.IsUnlocked)
        {
            throw new InvalidOperationException("This difficulty must be unlocked in the shop first.");
        }

        var leftOperand = _random.Next(definition.MinOperand, definition.MaxOperand + 1);
        var rightOperand = _random.Next(definition.MinOperand, definition.MaxOperand + 1);
        var expectedAnswer = operation switch
        {
            MathOperation.Addition => leftOperand + rightOperand,
            MathOperation.Subtraction => leftOperand - rightOperand,
            _ => throw new ArgumentOutOfRangeException(nameof(operation)),
        };

        return new ExerciseProblem
        {
            Operation = operation,
            Difficulty = difficulty,
            LeftOperand = leftOperand,
            RightOperand = rightOperand,
            ExpectedAnswer = expectedAnswer,
        };
    }

    public ExerciseSubmissionResult SubmitAnswer(int userId, ExerciseProblem problem, int submittedAnswer)
    {
        return _exerciseRepository.SaveAttempt(userId, problem, submittedAnswer);
    }
}
