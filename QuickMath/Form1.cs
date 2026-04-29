using QuickMath.Domain;
using QuickMath.Services;

namespace QuickMath;

public partial class QuickMath : Form
{
    private readonly ApplicationServices _services;
    private ExerciseProblem? _currentProblem;
    private bool _isInitializing;

    public QuickMath(ApplicationServices services)
    {
        _services = services;
        InitializeComponent();
        InitializeGui();
    }

    private void InitializeGui()
    {
        _isInitializing = true;

        try
        {
            RefreshUserSummary();
            DifficultySelect.SelectedItem = "medium";
            TypeOfMath.SelectedItem = "addition";
            GenerateExercise();
        }
        finally
        {
            _isInitializing = false;
        }
    }

    private void RefreshUserSummary()
    {
        // The form never mutates coins or XP directly; it always refreshes the
        // current snapshot from the service layer after a business operation.
        var user = _services.UserService.RefreshCurrentUser();
        GrettingLabel.Text = $"Welcome back {user.UserName}!";
        GrettingLabel.ForeColor = Color.Black;
        XPpointLabel.Text = user.XP.ToString();
        CoinsLabel.Text = user.Coins.ToString("0.##");
    }

    private void GenerateExercise()
    {
        try
        {
            var operation = GetSelectedOperation();
            var difficulty = GetSelectedDifficulty();

            // Difficulty checks stay in the service/repository path so unlock
            // rules are enforced consistently across the whole app.
            _currentProblem = _services.MathEngineService.CreateExercise(
                _services.UserSession.CurrentUserId,
                operation,
                difficulty);

            MathToResolveText.Text = operation == MathOperation.Addition
                ? $"{_currentProblem.LeftOperand} + {_currentProblem.RightOperand}"
                : $"{_currentProblem.LeftOperand} - {_currentProblem.RightOperand}";
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Exercise error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DifficultySelect.SelectedItem = "medium";
        }
    }

    private MathOperation GetSelectedOperation()
    {
        return TypeOfMath.SelectedItem?.ToString() switch
        {
            "addition" => MathOperation.Addition,
            "subtraction" => MathOperation.Subtraction,
            _ => throw new InvalidOperationException("Please select a supported math operation."),
        };
    }

    private DifficultyLevel GetSelectedDifficulty()
    {
        return DifficultySelect.SelectedItem?.ToString() switch
        {
            "easy++" => DifficultyLevel.EasyPlusPlus,
            "easy" => DifficultyLevel.Easy,
            "medium" => DifficultyLevel.Medium,
            "hard" => DifficultyLevel.Hard,
            "insane" => DifficultyLevel.Insane,
            _ => throw new InvalidOperationException("Please select a difficulty."),
        };
    }

    private void TrySubmitAnswer()
    {
        if (_currentProblem is null || !int.TryParse(MathUserIntupt.Text, out var submittedAnswer))
        {
            return;
        }

        // A submission writes the attempt and reward transaction atomically in SQL.
        var result = _services.MathEngineService.SubmitAnswer(
            _services.UserSession.CurrentUserId,
            _currentProblem,
            submittedAnswer);

        if (!result.IsCorrect)
        {
            return;
        }

        _services.UserSession.SetCurrentUser(result.UpdatedUser);
        RefreshUserSummary();
        MathUserIntupt.Text = string.Empty;
        GenerateExercise();
    }

    private void TypeOfMath_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isInitializing)
        {
            return;
        }

        if (TypeOfMath.SelectedItem?.ToString() == "more coming !")
        {
            MessageBox.Show("More math operations will be added in the future!");
            TypeOfMath.SelectedItem = "addition";
            return;
        }

        GenerateExercise();
    }

    private void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isInitializing)
        {
            return;
        }

        GenerateExercise();
    }

    private void MathUserIntupt_TextChanged(object sender, EventArgs e)
    {
        TrySubmitAnswer();
    }

    private void OpenShopButton_Click(object sender, EventArgs e)
    {
        using var shop = new Shop(_services.ShopService, _services.UserService, _services.UserSession);
        shop.ShowDialog();
        RefreshUserSummary();
        GenerateExercise();
    }

    private void statistic_button_Click(object sender, EventArgs e)
    {
        using var statistics = new Statistics(_services.ScoreService, _services.UserSession);
        statistics.ShowDialog();
        RefreshUserSummary();
    }

    private void ReSetButton_Click(object sender, EventArgs e)
    {
        MathUserIntupt.Text = string.Empty;
        GenerateExercise();
    }

    private void MathToResolveText_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click_1(object sender, EventArgs e)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
}
