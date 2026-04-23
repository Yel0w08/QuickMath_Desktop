using System.Security.Cryptography.X509Certificates;

namespace QuickMath
{
    public partial class Form1 : Form
    {
        private int result;
        public int XP = 0; //public stuff

        public Form1()
        {
            InitializeComponent();
            ResetGUI();

         
        }

        bool DoAwserIsCorect;
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

        public async Task StartMath_addition()
        {
            MinimumRandomNumber_trackbar.Show();
            MinimumRandomNumber_intupt.Show();
            MaximumRandomNumber_trackbar.Show();
            MaximumRandomNumber_intupt.Show();
            MinimumRandomNumber_intupt.Text = MinimumRandomNumber_trackbar.Text;
            MaximumRandomNumber_trackbar.Text = MaximumRandomNumber_intupt.Text;

            int min_number_addition = 1;
            int max_number_addition = 100;

            Random random = new Random();
            int random_1 = random.Next(min_number_addition, max_number_addition);
            int random_2 = random.Next(min_number_addition, max_number_addition);
            result = random_1 + random_2;
            MathToResolveText.Text = $"{random_1} + {random_2}";
            
            CheckAwser(result); 
           
            
        
        
        
        
        
        
        
        
        
        }



        private void CheckAwser(int result)
        {
            if (MathUserIntupt.Text == result.ToString())
            {
                DoAwserIsCorect = true;
            }
        }



        void ResetGUI()
        {
            MinimumRandomNumber_trackbar.Hide();
            MinimumRandomNumber_intupt.Hide();
            MaximumRandomNumber_trackbar.Hide();
            MaximumRandomNumber_intupt.Hide();


        }

        void ReLoadGUI()
        {
             
            XPpointLabel.Text = XP.ToString();

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

        private void MathUserIntupt_TextChanged(object sender, EventArgs e)
        {
            if (MathUserIntupt.Text == result.ToString())
            {
                DoAwserIsCorect = true;
                XP += 10;
                ReLoadGUI();
                MathUserIntupt.Text = string.Empty;
                StartMath_addition();
            }
        }

        private void Verify_button_Click(object sender, EventArgs e)
        {
            CheckAwser(result);
        }
    }
}
