namespace QuickMath
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TypeOfMath = new ComboBox();
            MathToResolveText = new Label();
            MathUserIntupt = new TextBox();
            MidelTextBetweenUserIntuptAndMath = new Label();
            XPEqualLabel = new Label();
            XPpointLabel = new Label();
            start_button = new Button();
            stopbutton = new Button();
            _trackbar = new Label();
            DifficultySelect = new ComboBox();
            GrettingLabel = new Label();
            SuspendLayout();
            // 
            // TypeOfMath
            // 
            TypeOfMath.FormattingEnabled = true;
            TypeOfMath.Items.AddRange(new object[] { "addition", "more coming !" });
            TypeOfMath.Location = new Point(12, 12);
            TypeOfMath.Name = "TypeOfMath";
            TypeOfMath.Size = new Size(121, 23);
            TypeOfMath.TabIndex = 0;
            TypeOfMath.SelectedIndexChanged += TypeOfMath_SelectedIndexChanged;
            // 
            // MathToResolveText
            // 
            MathToResolveText.AutoSize = true;
            MathToResolveText.Font = new Font("Segoe UI", 16F);
            MathToResolveText.Location = new Point(3, 261);
            MathToResolveText.Name = "MathToResolveText";
            MathToResolveText.Size = new Size(52, 30);
            MathToResolveText.TabIndex = 1;
            MathToResolveText.Text = "1+1";
            MathToResolveText.Click += MathToResolveText_Click;
            // 
            // MathUserIntupt
            // 
            MathUserIntupt.Font = new Font("Segoe UI", 16F);
            MathUserIntupt.Location = new Point(37, 313);
            MathUserIntupt.Name = "MathUserIntupt";
            MathUserIntupt.Size = new Size(268, 36);
            MathUserIntupt.TabIndex = 2;
            MathUserIntupt.TextChanged += MathUserIntupt_TextChanged;
            // 
            // MidelTextBetweenUserIntuptAndMath
            // 
            MidelTextBetweenUserIntuptAndMath.AutoSize = true;
            MidelTextBetweenUserIntuptAndMath.Font = new Font("Segoe UI", 16F);
            MidelTextBetweenUserIntuptAndMath.Location = new Point(3, 313);
            MidelTextBetweenUserIntuptAndMath.Name = "MidelTextBetweenUserIntuptAndMath";
            MidelTextBetweenUserIntuptAndMath.Size = new Size(28, 30);
            MidelTextBetweenUserIntuptAndMath.TabIndex = 3;
            MidelTextBetweenUserIntuptAndMath.Text = "=";
            MidelTextBetweenUserIntuptAndMath.Click += label1_Click;
            // 
            // XPEqualLabel
            // 
            XPEqualLabel.AutoSize = true;
            XPEqualLabel.Font = new Font("Segoe UI", 12F);
            XPEqualLabel.Location = new Point(12, 71);
            XPEqualLabel.Name = "XPEqualLabel";
            XPEqualLabel.Size = new Size(43, 21);
            XPEqualLabel.TabIndex = 4;
            XPEqualLabel.Text = "XP =";
            XPEqualLabel.Click += label1_Click_1;
            // 
            // XPpointLabel
            // 
            XPpointLabel.AutoSize = true;
            XPpointLabel.Font = new Font("Segoe UI", 12F);
            XPpointLabel.Location = new Point(46, 71);
            XPpointLabel.Name = "XPpointLabel";
            XPpointLabel.Size = new Size(19, 21);
            XPpointLabel.TabIndex = 5;
            XPpointLabel.Text = "0";
            // 
            // start_button
            // 
            start_button.Location = new Point(139, 12);
            start_button.Name = "start_button";
            start_button.Size = new Size(85, 23);
            start_button.TabIndex = 6;
            start_button.Text = "start";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += button1_Click;
            // 
            // stopbutton
            // 
            stopbutton.Location = new Point(230, 12);
            stopbutton.Name = "stopbutton";
            stopbutton.Size = new Size(75, 23);
            stopbutton.TabIndex = 7;
            stopbutton.Text = "stop";
            stopbutton.UseVisualStyleBackColor = true;
            stopbutton.Click += stopbutton_Click;
            // 
            // _trackbar
            // 
            _trackbar.AutoSize = true;
            _trackbar.Location = new Point(716, 42);
            _trackbar.Name = "_trackbar";
            _trackbar.Size = new Size(0, 15);
            _trackbar.TabIndex = 11;
            // 
            // DifficultySelect
            // 
            DifficultySelect.FormattingEnabled = true;
            DifficultySelect.Items.AddRange(new object[] { "default (1 - 100)" });
            DifficultySelect.Location = new Point(12, 39);
            DifficultySelect.Name = "DifficultySelect";
            DifficultySelect.Size = new Size(121, 23);
            DifficultySelect.TabIndex = 12;
            DifficultySelect.Text = "default (1 - 100)";
            DifficultySelect.Visible = false;
            DifficultySelect.SelectedIndexChanged += Difficulty_SelectedIndexChanged;
            // 
            // GrettingLabel
            // 
            GrettingLabel.AutoSize = true;
            GrettingLabel.Location = new Point(139, 42);
            GrettingLabel.Name = "GrettingLabel";
            GrettingLabel.Size = new Size(28, 15);
            GrettingLabel.TabIndex = 14;
            GrettingLabel.Text = "Hi...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(317, 361);
            Controls.Add(GrettingLabel);
            Controls.Add(DifficultySelect);
            Controls.Add(_trackbar);
            Controls.Add(stopbutton);
            Controls.Add(start_button);
            Controls.Add(XPpointLabel);
            Controls.Add(XPEqualLabel);
            Controls.Add(MidelTextBetweenUserIntuptAndMath);
            Controls.Add(MathUserIntupt);
            Controls.Add(MathToResolveText);
            Controls.Add(TypeOfMath);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "QuickMath";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TypeOfMath;
        private Label MathToResolveText;
        private TextBox MathUserIntupt;
        private Label MidelTextBetweenUserIntuptAndMath;
        private Label XPEqualLabel;
        private Label XPpointLabel;
        private Button start_button;
        private Button stopbutton;
        private Label _trackbar;
        private ComboBox DifficultySelect;
        private Label GrettingLabel;
    }
}
