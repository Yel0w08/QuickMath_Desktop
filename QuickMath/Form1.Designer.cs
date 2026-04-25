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
            start_button = new Button();
            stopbutton = new Button();
            _trackbar = new Label();
            DifficultySelect = new ComboBox();
            GrettingLabel = new Label();
            CoinsEqualStaticLabel = new Label();
            CoinsLabel = new Label();
            OpenShopButton = new Button();
            SuspendLayout();
            // 
            // TypeOfMath
            // 
            TypeOfMath.FormattingEnabled = true;
            TypeOfMath.Items.AddRange(new object[] { "addition", "more coming !" });
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
            MathToResolveText.Location = new Point(3, 348);
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
            XPpointLabel.Location = new Point(53, 95);
            XPpointLabel.Name = "XPpointLabel";
            XPpointLabel.Size = new Size(23, 28);
            XPpointLabel.TabIndex = 5;
            XPpointLabel.Text = "0";
            // 
            // start_button
            // 
            start_button.Location = new Point(158, 16);
            start_button.Margin = new Padding(3, 4, 3, 4);
            start_button.Name = "start_button";
            start_button.Size = new Size(90, 28);
            start_button.TabIndex = 6;
            start_button.Text = "start";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += button1_Click;
            // 
            // stopbutton
            // 
            stopbutton.Location = new Point(254, 16);
            stopbutton.Margin = new Padding(3, 4, 3, 4);
            stopbutton.Name = "stopbutton";
            stopbutton.Size = new Size(90, 28);
            stopbutton.TabIndex = 7;
            stopbutton.Text = "stop";
            stopbutton.UseVisualStyleBackColor = true;
            stopbutton.Click += stopbutton_Click;
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
            DifficultySelect.Items.AddRange(new object[] { "easy++ (1 - 10)", "easy (1 - 50)", "medium (1 - 100)", "hard (50 - 500)", "insane (100 - 1000)" });
            DifficultySelect.Location = new Point(14, 52);
            DifficultySelect.Margin = new Padding(3, 4, 3, 4);
            DifficultySelect.Name = "DifficultySelect";
            DifficultySelect.Size = new Size(138, 28);
            DifficultySelect.TabIndex = 12;
            DifficultySelect.Text = "medium (1 - 100)";
            DifficultySelect.Visible = false;
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
            CoinsLabel.Location = new Point(53, 123);
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
            // QuickMath
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(488, 481);
            Controls.Add(OpenShopButton);
            Controls.Add(CoinsLabel);
            Controls.Add(CoinsEqualStaticLabel);
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
        private Button start_button;
        private Button stopbutton;
        private Label _trackbar;
        private ComboBox DifficultySelect;
        private Label GrettingLabel;
        private Label CoinsEqualStaticLabel;
        private Label CoinsLabel;
        private Button OpenShopButton;
    }
}
