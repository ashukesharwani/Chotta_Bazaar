using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class f1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ashu\source\repos\Project\Project\CreatAccount.mdf;Integrated Security=True");
        public f1()
        {
            InitializeComponent();
            loadcaptachaimage();
        }
        int number = 0;
        private void loadcaptachaimage()
        {
            Random r1 = new Random();
            number = r1.Next(100, 10000);
            var image = new Bitmap(this.pictureBox4.Width, this.pictureBox4.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox4.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Do you want to exit.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string abc;
            SqlCommand comm1 = new SqlCommand("Select password From  Reg where User_name = '" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader DR1 = comm1.ExecuteReader();


            if (textBox3.Text == number.ToString())
            {
                while (DR1.Read())
                {
                    abc = DR1.GetValue(0).ToString();


                    if (textBox2.Text != abc)
                    {
                        MessageBox.Show("Invalid User");
                    }
                    else
                    {

                        this.Hide();
                        Form3 ss = new Form3("Welcome: " + textBox1.Text);
                        ss.Show();
                    }
                }
              //  MessageBox.Show("Invalid User");
            }
            else
            {
                MessageBox.Show("The Captch is invalid");
                loadcaptachaimage();
            }
            con.Close();
        }

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            Form2 tt = new Form2();
            tt.Show();
         

        }

          

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            loadcaptachaimage();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(textBox2.PasswordChar=='*')
            {
                textBox2.PasswordChar = '\0';
            }
            else 
            {
                if (textBox2.PasswordChar == '\0')
                {
                    textBox2.PasswordChar = '*';
                }
            }
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
                textBox2.PasswordChar = '\0';
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
             
        }

        private void f1_Load(object sender, EventArgs e)
        {

        }
    }
    
}