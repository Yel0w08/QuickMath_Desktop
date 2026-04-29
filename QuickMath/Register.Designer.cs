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
            // RegisterForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
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
    }
}
