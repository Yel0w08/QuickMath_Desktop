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
            if (TypeOfMath.SelectedItem.ToString() == "more coming !") { MessageBox.Show("More math operations will be added in the future !"); TypeOfMath.Text = ""; } else { }
            //tell the user more is coming if selecter more is coming....
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //start_button
        {



            if (TypeOfMath.SelectedItem.ToString() == string.Empty) { }//why dont it work
            else if (TypeOfMath.SelectedItem.ToString() == "addition")
            {
                LockGUI();
                StartMath_addition();

            }
            else if (TypeOfMath.SelectedItem.ToString() == "subtraction")
            {
                LockGUI();
                //StartMath_subtraction();
            }
            else if (TypeOfMath.SelectedItem.ToString() == "multiplication")
            {
                LockGUI();

            }
            else if (TypeOfMath.SelectedItem.ToString() == "division")
            {

                LockGUI();

            }
            else { MessageBox.Show("Please select a math operation before starting !"); }//to chekc if thez intput isint null 

        }

        private void StartMath_addition()
        {
            

        }

        private void UnlockGUI()
        {
            TypeOfMath.Enabled = true;

        }

        private void LockGUI()
        {
            TypeOfMath.Enabled = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            UnlockGUI();

        }
    }
}
