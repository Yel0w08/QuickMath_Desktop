namespace QuickMath
{
    partial class QuickMath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickMath));
            TypeOfMath = new ComboBox();
            MathToResolveText = new Label();
            MathUserIntupt = new TextBox();
            MidelTextBetweenUserIntuptAndMath = new Label();
            XPEqualLabel = new Label();
            XPpointLabel = new Label();
            _trackbar = new Label();
            DifficultySelect = new ComboBox();
            GrettingLabel = new Label();
            CoinsEqualStaticLabel = new Label();
            CoinsLabel = new Label();
            OpenShopButton = new Button();
            statistic_button = new Button();
            button1 = new Button();
            ReSetButton = new Button();
            SuspendLayout();
            // 
            // TypeOfMath
            // 
            TypeOfMath.FormattingEnabled = true;
            TypeOfMath.Items.AddRange(new object[] { "addition", "subtraction", "more coming !" });
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
            MathToResolveText.Location = new Point(3, 264);
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
            MathUserIntupt.Size = new Size(380, 36);
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
            XPpointLabel.Location = new Point(56, 71);
            XPpointLabel.Name = "XPpointLabel";
            XPpointLabel.Size = new Size(19, 21);
            XPpointLabel.TabIndex = 5;
            XPpointLabel.Text = "0";
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
            DifficultySelect.Items.AddRange(new object[] { "easy++", "easy", "medium", "hard", "insane" });
            DifficultySelect.Location = new Point(12, 39);
            DifficultySelect.Name = "DifficultySelect";
            DifficultySelect.Size = new Size(121, 23);
            DifficultySelect.TabIndex = 12;
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
            // CoinsEqualStaticLabel
            // 
            CoinsEqualStaticLabel.AutoSize = true;
            CoinsEqualStaticLabel.Font = new Font("Segoe UI", 12F);
            CoinsEqualStaticLabel.Location = new Point(12, 92);
            CoinsEqualStaticLabel.Name = "CoinsEqualStaticLabel";
            CoinsEqualStaticLabel.Size = new Size(41, 21);
            CoinsEqualStaticLabel.TabIndex = 15;
            CoinsEqualStaticLabel.Text = "∑∑=";
            // 
            // CoinsLabel
            // 
            CoinsLabel.AutoSize = true;
            CoinsLabel.Font = new Font("Segoe UI", 12F);
            CoinsLabel.Location = new Point(56, 92);
            CoinsLabel.Name = "CoinsLabel";
            CoinsLabel.Size = new Size(19, 21);
            CoinsLabel.TabIndex = 16;
            CoinsLabel.Text = "0";
            // 
            // OpenShopButton
            // 
            OpenShopButton.Location = new Point(306, 12);
            OpenShopButton.Name = "OpenShopButton";
            OpenShopButton.Size = new Size(110, 21);
            OpenShopButton.TabIndex = 17;
            OpenShopButton.Text = " shop ";
            OpenShopButton.UseVisualStyleBackColor = true;
            OpenShopButton.Click += OpenShopButton_Click;
            // 
            // statistic_button
            // 
            statistic_button.Location = new Point(138, 12);
            statistic_button.Name = "statistic_button";
            statistic_button.Size = new Size(66, 21);
            statistic_button.TabIndex = 18;
            statistic_button.Text = "stats";
            statistic_button.UseVisualStyleBackColor = true;
            statistic_button.Click += statistic_button_Click;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(209, 12);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(92, 22);
            button1.TabIndex = 19;
            button1.Text = "WIP";
            button1.UseVisualStyleBackColor = true;
            // 
            // ReSetButton
            // 
            ReSetButton.BackColor = Color.Transparent;
            ReSetButton.FlatAppearance.BorderColor = Color.White;
            ReSetButton.FlatAppearance.BorderSize = 0;
            ReSetButton.FlatStyle = FlatStyle.Flat;
            ReSetButton.Location = new Point(388, 286);
            ReSetButton.Name = "ReSetButton";
            ReSetButton.Size = new Size(29, 21);
            ReSetButton.TabIndex = 20;
            ReSetButton.Text = "🔄️";
            ReSetButton.UseVisualStyleBackColor = false;
            ReSetButton.Click += ReSetButton_Click;
            // 
            // QuickMath
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(427, 361);
            Controls.Add(ReSetButton);
            Controls.Add(button1);
            Controls.Add(statistic_button);
            Controls.Add(OpenShopButton);
            Controls.Add(CoinsLabel);
            Controls.Add(CoinsEqualStaticLabel);
            Controls.Add(GrettingLabel);
            Controls.Add(DifficultySelect);
            Controls.Add(_trackbar);
            Controls.Add(XPpointLabel);
            Controls.Add(XPEqualLabel);
            Controls.Add(MidelTextBetweenUserIntuptAndMath);
            Controls.Add(MathUserIntupt);
            Controls.Add(MathToResolveText);
            Controls.Add(TypeOfMath);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "QuickMath";
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
        private Label _trackbar;
        private ComboBox DifficultySelect;
        private Label GrettingLabel;
        private Label CoinsEqualStaticLabel;
        private Label CoinsLabel;
        private Button OpenShopButton;
        private Button statistic_button;
        private Button button1;
        private Button ReSetButton;
    }
}
