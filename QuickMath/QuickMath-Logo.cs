using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickMath
{
    public partial class QuickMath_Logo : MaterialSkin.Controls.MaterialForm
    {
        public QuickMath_Logo()
        {
            InitializeComponent();
             MaterialSkin.MaterialSkinManager.Instance.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
        }

        private void QuickMath_Logo_Load(object sender, EventArgs e)
        {

        }
    }
}
