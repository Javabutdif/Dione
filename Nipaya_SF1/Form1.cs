using System.Text.RegularExpressions;

namespace Nipaya_SF1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Raiden Concert");
            comboBox1.Items.Add("Kaeya Concert");
            comboBox1.Items.Add("Klee Concert");
            comboBox1.Items.Add("Hu Tao Concert");
            comboBox1.Items.Add("Ganyu Concert");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string name = "";
        string email = "";
        int tickets = 0;

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Please enter your name!");
            }
            else
            {
                name = txtName.Text;
                errorProvider1.SetError(txtName, "");
            }
                
        }
        //
        Regex check = new Regex(@"^\w+[\w-\-]+\@\w{5}\.[a-z]{2,3}$");
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {


            if (txtEmail.Text == "")
            {
                errorProvider1.SetError(txtEmail, "Please enter your email");
            }
            else if (check.IsMatch(txtEmail.Text))
            {
                email = txtEmail.Text;
                errorProvider1.SetError(txtEmail, "");
            }
            else
                errorProvider1.SetError(txtEmail, "Email Format Invalid");




        }

        private void txtTickets_TextChanged(object sender, EventArgs e)
        {
           
           
                string getTickets = txtTickets.Text;
                if (Int32.TryParse(getTickets, out int num))
                {
                    if (num > 0) tickets = num;
                    else errorProvider1.SetError(txtEmail, "Must positive number");

            }
            

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if(name != "" && email != "" && tickets != 0)
            {
                MessageBox.Show("ORDER NOTED\nName: "+name +"\n Email: "+email+"\n Tickets: "+tickets +"\nYou've purchased " + comboBox1.Text, "Nipaya Ticket Booth", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtTickets.Text = "";
                txtEmail.Text = "";
                txtName.Text = "";
                name = "";
                tickets = 0;
                email = "";
            }
            else
            {
                MessageBox.Show("Must contain correct format");
            }
        }
    }
}