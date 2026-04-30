namespace QuickMath
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            UsernameIntupt = new TextBox();
            Register = new Button();
            SkipRegisterButton = new Button();
            RegisterButton_v2 = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // UsernameIntupt
            // 
            resources.ApplyResources(UsernameIntupt, "UsernameIntupt");
            UsernameIntupt.Name = "UsernameIntupt";
            UsernameIntupt.TextChanged += UsernameIntupt_TextChanged;
            // 
            // Register
            // 
            Register.BackColor = Color.White;
            resources.ApplyResources(Register, "Register");
            Register.ForeColor = Color.Black;
            Register.Name = "Register";
            Register.UseVisualStyleBackColor = false;
            Register.Click += Register_Click;
            // 
            // SkipRegisterButton
            // 
            resources.ApplyResources(SkipRegisterButton, "SkipRegisterButton");
            SkipRegisterButton.ForeColor = Color.Red;
            SkipRegisterButton.Name = "SkipRegisterButton";
            SkipRegisterButton.UseVisualStyleBackColor = true;
            SkipRegisterButton.Click += SkipRegisterButton_Click;
            // 
            // RegisterButton_v2
            // 
            resources.ApplyResources(RegisterButton_v2, "RegisterButton_v2");
            RegisterButton_v2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            RegisterButton_v2.Depth = 0;
            RegisterButton_v2.HighEmphasis = true;
            RegisterButton_v2.Icon = null;
            RegisterButton_v2.MouseState = MaterialSkin.MouseState.HOVER;
            RegisterButton_v2.Name = "RegisterButton_v2";
            RegisterButton_v2.NoAccentTextColor = Color.Empty;
            RegisterButton_v2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            RegisterButton_v2.UseAccentColor = false;
            RegisterButton_v2.UseVisualStyleBackColor = true;
            RegisterButton_v2.Click += RegisterButton_v2_Click;
            // 
            // RegisterForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(RegisterButton_v2);
            Controls.Add(SkipRegisterButton);
            Controls.Add(Register);
            Controls.Add(UsernameIntupt);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameIntupt;
        private Button Register;
        private Button SkipRegisterButton;
        private MaterialSkin.Controls.MaterialButton RegisterButton_v2;
    }
}
