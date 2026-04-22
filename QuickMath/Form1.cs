namespace QuickMath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MathToResolveText_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TypeOfMath_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (TypeOfMath.SelectedItem.ToString() == "addition")
            {


            }
            else if (TypeOfMath.SelectedItem.ToString() == "subtraction")
            {

            }
            else if (TypeOfMath.SelectedItem.ToString() == "multiplication")
            {

            }
            else if (TypeOfMath.SelectedItem.ToString() == "division")
            {

            }
            else if (TypeOfMath.SelectedItem.ToString() == "more coming !")
            {
                MessageBox.Show("More math operations will be added in the future !");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//start_and_stop_button
        {

        }
    }
}
