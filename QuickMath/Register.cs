using QuickMath.Services;

namespace QuickMath;

/// <summary>
/// Collects the local username used to create or reactivate a mono-user profile.
/// </summary>
public partial class RegisterForm : Form
{
    private readonly UserService _userService;

    /// <summary>
    /// Initializes the registration dialog with the user service.
    /// </summary>
    public RegisterForm(UserService userService)
    {
        _userService = userService;
        InitializeComponent();
        UsernameIntupt.Text = Environment.UserName;
    }

    private void Register_Click(object sender, EventArgs e)
    {
        SaveUser(UsernameIntupt.Text);
    }

    private void SkipRegisterButton_Click(object sender, EventArgs e)
    {
        SaveUser(Environment.UserName);
    }

    private void SaveUser(string userName)
    {
        try
        {
            // Registration is persisted immediately so the rest of the app can rely
            // on a valid active user stored in SQL.
            _userService.RegisterOrActivate(userName);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Registration error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void RegisterForm_Load(object sender, EventArgs e)
    {
    }

    private void UsernameIntupt_TextChanged(object sender, EventArgs e)
    {
    }
}
