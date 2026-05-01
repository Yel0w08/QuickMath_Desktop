using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickMath
{
    public partial class AboutBox1 : MaterialSkin.Controls.MaterialForm
    {
        public AboutBox1()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager.Instance.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
        
        }
    
        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
