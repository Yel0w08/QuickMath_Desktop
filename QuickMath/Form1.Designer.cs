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
            SuspendLayout();
            // 
            // TypeOfMath
            // 
            TypeOfMath.FormattingEnabled = true;
            TypeOfMath.Location = new Point(12, 12);
            TypeOfMath.Name = "TypeOfMath";
            TypeOfMath.Size = new Size(121, 23);
            TypeOfMath.TabIndex = 0;
            // 
            // MathToResolveText
            // 
            MathToResolveText.AutoSize = true;
            MathToResolveText.Font = new Font("Segoe UI", 16F);
            MathToResolveText.Location = new Point(12, 339);
            MathToResolveText.Name = "MathToResolveText";
            MathToResolveText.Size = new Size(127, 30);
            MathToResolveText.TabIndex = 1;
            MathToResolveText.Text = "(Math here)";
            MathToResolveText.Click += MathToResolveText_Click;
            // 
            // MathUserIntupt
            // 
            MathUserIntupt.Font = new Font("Segoe UI", 16F);
            MathUserIntupt.Location = new Point(12, 402);
            MathUserIntupt.Name = "MathUserIntupt";
            MathUserIntupt.Size = new Size(300, 36);
            MathUserIntupt.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MathUserIntupt);
            Controls.Add(MathToResolveText);
            Controls.Add(TypeOfMath);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "QuickMath";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TypeOfMath;
        private Label MathToResolveText;
        private System.Windows.Forms.Timer timer1;
        private TextBox MathUserIntupt;
    }
}
