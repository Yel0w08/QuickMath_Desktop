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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TypeOfMath = new ComboBox();
            MathToResolveText = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            MathUserIntupt = new TextBox();
            MidelTextBetweenUserIntuptAndMath = new Label();
            XPEqualLabel = new Label();
            XPpointLabel = new Label();
            start_button = new Button();
            stopbutton = new Button();
            MinimumRandomNumber_trackbar = new TrackBar();
            MaximumRandomNumber_trackbar = new TrackBar();
            _trackbar = new Label();
            MaximumRandomNumber_intupt = new MaskedTextBox();
            MinimumRandomNumber_intupt = new MaskedTextBox();
            Verify_button = new Button();
            ((System.ComponentModel.ISupportInitialize)MinimumRandomNumber_trackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaximumRandomNumber_trackbar).BeginInit();
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
            MathToResolveText.Location = new Point(12, 339);
            MathToResolveText.Name = "MathToResolveText";
            MathToResolveText.Size = new Size(52, 30);
            MathToResolveText.TabIndex = 1;
            MathToResolveText.Text = "1+1";
            MathToResolveText.Click += MathToResolveText_Click;
            // 
            // MathUserIntupt
            // 
            MathUserIntupt.Font = new Font("Segoe UI", 16F);
            MathUserIntupt.Location = new Point(46, 398);
            MathUserIntupt.Name = "MathUserIntupt";
            MathUserIntupt.Size = new Size(300, 36);
            MathUserIntupt.TabIndex = 2;
            MathUserIntupt.TextChanged += MathUserIntupt_TextChanged;
            // 
            // MidelTextBetweenUserIntuptAndMath
            // 
            MidelTextBetweenUserIntuptAndMath.AutoSize = true;
            MidelTextBetweenUserIntuptAndMath.Font = new Font("Segoe UI", 16F);
            MidelTextBetweenUserIntuptAndMath.Location = new Point(12, 398);
            MidelTextBetweenUserIntuptAndMath.Name = "MidelTextBetweenUserIntuptAndMath";
            MidelTextBetweenUserIntuptAndMath.Size = new Size(28, 30);
            MidelTextBetweenUserIntuptAndMath.TabIndex = 3;
            MidelTextBetweenUserIntuptAndMath.Text = "=";
            MidelTextBetweenUserIntuptAndMath.Click += label1_Click;
            // 
            // XPEqualLabel
            // 
            XPEqualLabel.AutoSize = true;
            XPEqualLabel.Font = new Font("Segoe UI", 16F);
            XPEqualLabel.Location = new Point(12, 50);
            XPEqualLabel.Name = "XPEqualLabel";
            XPEqualLabel.Size = new Size(59, 30);
            XPEqualLabel.TabIndex = 4;
            XPEqualLabel.Text = "XP =";
            XPEqualLabel.Click += label1_Click_1;
            // 
            // XPpointLabel
            // 
            XPpointLabel.AutoSize = true;
            XPpointLabel.Font = new Font("Segoe UI", 16F);
            XPpointLabel.Location = new Point(66, 50);
            XPpointLabel.Name = "XPpointLabel";
            XPpointLabel.Size = new Size(25, 30);
            XPpointLabel.TabIndex = 5;
            XPpointLabel.Text = "0";
            // 
            // start_button
            // 
            start_button.Location = new Point(139, 12);
            start_button.Name = "start_button";
            start_button.Size = new Size(75, 23);
            start_button.TabIndex = 6;
            start_button.Text = "start";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += button1_Click;
            // 
            // stopbutton
            // 
            stopbutton.Location = new Point(220, 12);
            stopbutton.Name = "stopbutton";
            stopbutton.Size = new Size(75, 23);
            stopbutton.TabIndex = 7;
            stopbutton.Text = "stop";
            stopbutton.UseVisualStyleBackColor = true;
            stopbutton.Click += stopbutton_Click;
            // 
            // MinimumRandomNumber_trackbar
            // 
            MinimumRandomNumber_trackbar.Location = new Point(684, 63);
            MinimumRandomNumber_trackbar.Maximum = 1000;
            MinimumRandomNumber_trackbar.Minimum = 1;
            MinimumRandomNumber_trackbar.Name = "MinimumRandomNumber_trackbar";
            MinimumRandomNumber_trackbar.Size = new Size(104, 45);
            MinimumRandomNumber_trackbar.TabIndex = 9;
            MinimumRandomNumber_trackbar.Value = 1;
            // 
            // MaximumRandomNumber_trackbar
            // 
            MaximumRandomNumber_trackbar.Location = new Point(684, 12);
            MaximumRandomNumber_trackbar.Maximum = 1000;
            MaximumRandomNumber_trackbar.Minimum = 10;
            MaximumRandomNumber_trackbar.Name = "MaximumRandomNumber_trackbar";
            MaximumRandomNumber_trackbar.Size = new Size(104, 45);
            MaximumRandomNumber_trackbar.TabIndex = 10;
            MaximumRandomNumber_trackbar.Value = 10;
            // 
            // _trackbar
            // 
            _trackbar.AutoSize = true;
            _trackbar.Location = new Point(716, 42);
            _trackbar.Name = "_trackbar";
            _trackbar.Size = new Size(0, 15);
            _trackbar.TabIndex = 11;
            // 
            // MaximumRandomNumber_intupt
            // 
            MaximumRandomNumber_intupt.Location = new Point(649, 13);
            MaximumRandomNumber_intupt.Name = "MaximumRandomNumber_intupt";
            MaximumRandomNumber_intupt.Size = new Size(29, 23);
            MaximumRandomNumber_intupt.TabIndex = 12;
            MaximumRandomNumber_intupt.Text = "99";
            MaximumRandomNumber_intupt.TextAlign = HorizontalAlignment.Right;
            // 
            // MinimumRandomNumber_intupt
            // 
            MinimumRandomNumber_intupt.Location = new Point(649, 63);
            MinimumRandomNumber_intupt.Name = "MinimumRandomNumber_intupt";
            MinimumRandomNumber_intupt.Size = new Size(29, 23);
            MinimumRandomNumber_intupt.TabIndex = 13;
            MinimumRandomNumber_intupt.Text = "1";
            MinimumRandomNumber_intupt.TextAlign = HorizontalAlignment.Right;
            // 
            // Verify_button
            // 
            Verify_button.Location = new Point(352, 397);
            Verify_button.Name = "Verify_button";
            Verify_button.RightToLeft = RightToLeft.Yes;
            Verify_button.Size = new Size(75, 40);
            Verify_button.TabIndex = 14;
            Verify_button.Text = "Verify";
            Verify_button.UseVisualStyleBackColor = true;
            Verify_button.Click += Verify_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(Verify_button);
            Controls.Add(MinimumRandomNumber_intupt);
            Controls.Add(MaximumRandomNumber_intupt);
            Controls.Add(_trackbar);
            Controls.Add(MaximumRandomNumber_trackbar);
            Controls.Add(MinimumRandomNumber_trackbar);
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
            ((System.ComponentModel.ISupportInitialize)MinimumRandomNumber_trackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaximumRandomNumber_trackbar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TypeOfMath;
        private Label MathToResolveText;
        private System.Windows.Forms.Timer timer1;
        private TextBox MathUserIntupt;
        private Label MidelTextBetweenUserIntuptAndMath;
        private Label XPEqualLabel;
        private Label XPpointLabel;
        private Button start_button;
        private Button stopbutton;
        private TrackBar MinimumRandomNumber_trackbar;
        private TrackBar MaximumRandomNumber_trackbar;
        private Label _trackbar;
        private MaskedTextBox MaximumRandomNumber_intupt;
        private MaskedTextBox MinimumRandomNumber_intupt;
        private Button Verify_button;
    }
}
