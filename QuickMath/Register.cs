using QuickMath.Services;

namespace QuickMath;

public partial class RegisterForm : Form
{
    private readonly UserService _userService;

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
