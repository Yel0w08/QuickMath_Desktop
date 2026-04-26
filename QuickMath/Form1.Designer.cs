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
            TypeOfMath.Location = new Point(14, 16);
            TypeOfMath.Margin = new Padding(3, 4, 3, 4);
            TypeOfMath.Name = "TypeOfMath";
            TypeOfMath.Size = new Size(138, 28);
            TypeOfMath.TabIndex = 0;
            TypeOfMath.SelectedIndexChanged += TypeOfMath_SelectedIndexChanged;
            // 
            // MathToResolveText
            // 
            MathToResolveText.AutoSize = true;
            MathToResolveText.Font = new Font("Segoe UI", 16F);
            MathToResolveText.Location = new Point(3, 352);
            MathToResolveText.Name = "MathToResolveText";
            MathToResolveText.Size = new Size(65, 37);
            MathToResolveText.TabIndex = 1;
            MathToResolveText.Text = "1+1";
            MathToResolveText.Click += MathToResolveText_Click;
            // 
            // MathUserIntupt
            // 
            MathUserIntupt.Font = new Font("Segoe UI", 16F);
            MathUserIntupt.Location = new Point(42, 417);
            MathUserIntupt.Margin = new Padding(3, 4, 3, 4);
            MathUserIntupt.Name = "MathUserIntupt";
            MathUserIntupt.Size = new Size(434, 43);
            MathUserIntupt.TabIndex = 2;
            MathUserIntupt.TextChanged += MathUserIntupt_TextChanged;
            // 
            // MidelTextBetweenUserIntuptAndMath
            // 
            MidelTextBetweenUserIntuptAndMath.AutoSize = true;
            MidelTextBetweenUserIntuptAndMath.Font = new Font("Segoe UI", 16F);
            MidelTextBetweenUserIntuptAndMath.Location = new Point(3, 417);
            MidelTextBetweenUserIntuptAndMath.Name = "MidelTextBetweenUserIntuptAndMath";
            MidelTextBetweenUserIntuptAndMath.Size = new Size(35, 37);
            MidelTextBetweenUserIntuptAndMath.TabIndex = 3;
            MidelTextBetweenUserIntuptAndMath.Text = "=";
            MidelTextBetweenUserIntuptAndMath.Click += label1_Click;
            // 
            // XPEqualLabel
            // 
            XPEqualLabel.AutoSize = true;
            XPEqualLabel.Font = new Font("Segoe UI", 12F);
            XPEqualLabel.Location = new Point(14, 95);
            XPEqualLabel.Name = "XPEqualLabel";
            XPEqualLabel.Size = new Size(54, 28);
            XPEqualLabel.TabIndex = 4;
            XPEqualLabel.Text = "XP =";
            XPEqualLabel.Click += label1_Click_1;
            // 
            // XPpointLabel
            // 
            XPpointLabel.AutoSize = true;
            XPpointLabel.Font = new Font("Segoe UI", 12F);
            XPpointLabel.Location = new Point(64, 95);
            XPpointLabel.Name = "XPpointLabel";
            XPpointLabel.Size = new Size(23, 28);
            XPpointLabel.TabIndex = 5;
            XPpointLabel.Text = "0";
            // 
            // _trackbar
            // 
            _trackbar.AutoSize = true;
            _trackbar.Location = new Point(818, 56);
            _trackbar.Name = "_trackbar";
            _trackbar.Size = new Size(0, 20);
            _trackbar.TabIndex = 11;
            // 
            // DifficultySelect
            // 
            DifficultySelect.FormattingEnabled = true;
            DifficultySelect.Items.AddRange(new object[] { "easy++", "easy", "medium", "hard", "insane" });
            DifficultySelect.Location = new Point(14, 52);
            DifficultySelect.Margin = new Padding(3, 4, 3, 4);
            DifficultySelect.Name = "DifficultySelect";
            DifficultySelect.Size = new Size(138, 28);
            DifficultySelect.TabIndex = 12;
            DifficultySelect.SelectedIndexChanged += Difficulty_SelectedIndexChanged;
            // 
            // GrettingLabel
            // 
            GrettingLabel.AutoSize = true;
            GrettingLabel.Location = new Point(159, 56);
            GrettingLabel.Name = "GrettingLabel";
            GrettingLabel.Size = new Size(33, 20);
            GrettingLabel.TabIndex = 14;
            GrettingLabel.Text = "Hi...";
            // 
            // CoinsEqualStaticLabel
            // 
            CoinsEqualStaticLabel.AutoSize = true;
            CoinsEqualStaticLabel.Font = new Font("Segoe UI", 12F);
            CoinsEqualStaticLabel.Location = new Point(14, 123);
            CoinsEqualStaticLabel.Name = "CoinsEqualStaticLabel";
            CoinsEqualStaticLabel.Size = new Size(50, 28);
            CoinsEqualStaticLabel.TabIndex = 15;
            CoinsEqualStaticLabel.Text = "∑∑=";
            // 
            // CoinsLabel
            // 
            CoinsLabel.AutoSize = true;
            CoinsLabel.Font = new Font("Segoe UI", 12F);
            CoinsLabel.Location = new Point(64, 123);
            CoinsLabel.Name = "CoinsLabel";
            CoinsLabel.Size = new Size(23, 28);
            CoinsLabel.TabIndex = 16;
            CoinsLabel.Text = "0";
            // 
            // OpenShopButton
            // 
            OpenShopButton.Location = new Point(350, 16);
            OpenShopButton.Margin = new Padding(3, 4, 3, 4);
            OpenShopButton.Name = "OpenShopButton";
            OpenShopButton.Size = new Size(126, 28);
            OpenShopButton.TabIndex = 17;
            OpenShopButton.Text = " shop ";
            OpenShopButton.UseVisualStyleBackColor = true;
            OpenShopButton.Click += OpenShopButton_Click;
            // 
            // statistic_button
            // 
            statistic_button.Location = new Point(158, 16);
            statistic_button.Margin = new Padding(3, 4, 3, 4);
            statistic_button.Name = "statistic_button";
            statistic_button.Size = new Size(75, 28);
            statistic_button.TabIndex = 18;
            statistic_button.Text = "stats";
            statistic_button.UseVisualStyleBackColor = true;
            statistic_button.Click += statistic_button_Click;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(239, 16);
            button1.Name = "button1";
            button1.Size = new Size(105, 29);
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
            ReSetButton.Location = new Point(443, 381);
            ReSetButton.Margin = new Padding(3, 4, 3, 4);
            ReSetButton.Name = "ReSetButton";
            ReSetButton.Size = new Size(33, 28);
            ReSetButton.TabIndex = 20;
            ReSetButton.Text = "🔄️";
            ReSetButton.UseVisualStyleBackColor = false;
            ReSetButton.Click += ReSetButton_Click;
            // 
            // QuickMath
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(488, 481);
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
            Margin = new Padding(3, 4, 3, 4);
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
