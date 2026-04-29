using QuickMath.Domain;
using QuickMath.Presentation;
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
            DifficultySelect.SelectedItem = MathUiMappings.MediumDifficultyLabel;
            TypeOfMath.SelectedItem = MathUiMappings.AdditionLabel;
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

            MathToResolveText.Text = MathUiMappings.FormatProblem(_currentProblem);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Exercise error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DifficultySelect.SelectedItem = MathUiMappings.MediumDifficultyLabel;
        }
    }

    private MathOperation GetSelectedOperation() =>
        MathUiMappings.ParseOperation(TypeOfMath.SelectedItem?.ToString());

    private DifficultyLevel GetSelectedDifficulty() =>
        MathUiMappings.ParseDifficulty(DifficultySelect.SelectedItem?.ToString());

    private void TrySubmitAnswer()
    {
        if (_currentProblem is null || !int.TryParse(MathUserIntupt.Text, out var submittedAnswer))
        {
            return;
        }

        // While the user is typing, intermediate numeric values must not be stored
        // as failed attempts. We only persist the attempt once the full expected
        // answer has been entered.
        if (submittedAnswer != _currentProblem.ExpectedAnswer)
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

        if (TypeOfMath.SelectedItem?.ToString() == MathUiMappings.ComingSoonLabel)
        {
            MessageBox.Show("More math operations will be added in the future!");
            TypeOfMath.SelectedItem = MathUiMappings.AdditionLabel;
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
