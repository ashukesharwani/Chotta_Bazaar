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
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ashu\source\repos\Project\Project\CreatAccount.mdf;Integrated Security=True");

        //   Connection for data base

        public String gender1;

        public Form2()
        {
            InitializeComponent();
            loadcaptachaimage();
          
        }
         
        int number = 0;
        private void loadcaptachaimage()
        {
            Random r1 = new Random();
            number = r1.Next(100, 10000);
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "First")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
          
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "First";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Middle")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Middle";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Surname")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                textBox3.Text = "Surname";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loadcaptachaimage();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
                 //date time picker format to store

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            //Sql connection work-------------------------******
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Reg(F_name, M_name, L_name, Dob, Age, Gender, M_number, Ans_S_Ques, User_name, Password) values ('"+textBox1.Text+"','"+textBox2.Text+ "','" + textBox3.Text + "','"+ dateTimePicker1.Text + "','" + textBox10.Text + "','"+gender1+"','" + textBox4.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "')", con);
           
            cmd.ExecuteNonQuery();
            
            if (textBox9.Text == number.ToString())
            {
                MessageBox.Show("Row Inserted Successfully");
                con.Close();

            }
            else
            {
                MessageBox.Show("Invalid Captcha ");
                loadcaptachaimage();

            }


        }

        private void textBox8_MouseEnter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Answer the security question")
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_MouseLeave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Answer the security question";
                textBox8.ForeColor = Color.Gray;
            }
        }

        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Re-enter password ")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Re-enter password ";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan Tspan = to - from;
            double days = Tspan.TotalDays;
            textBox10.Text = (days / 365).ToString("0");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "Title";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
         //   dateTimePicker1.Value = 'reset';
            textBox10.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox3.Text= "Select";
            label7.Text = "";
            loadcaptachaimage();
            label10.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;






        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox6.Text == textBox5.Text)
            {
                label7.ForeColor = System.Drawing.Color.Green;
                label7.Text = " Matched";
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "Not Matched";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          //  if(comboBox1.SelectedValue == "Master" && comboBox1.SelectedValue == "Mr")
            //{
              //  radioButton1.Checked=radioButton1.Checked;

            //}
        }

         

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            label10.Text = "Age";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (Char)Keys.Back);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (Char)Keys.Back);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (Char)Keys.Back);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem .ToString()== "Master" || comboBox1.SelectedItem.ToString()=="Mr.")
            {
                radioButton1.Checked = true;
            }
            else
             if(comboBox1.SelectedItem.ToString() == "Miss" || comboBox1.SelectedItem.ToString() == "Mrs.")
            {
                radioButton2.Checked = true;
            }
            else
                if(comboBox1.SelectedItem.ToString() == "Mx.")
            {
                radioButton3.Checked = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            f1 form1 = new f1();
            form1.Show();
            Visible = false;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                gender1 = "Male";
            }
                    
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                gender1 = "Female";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked==true)
            {
                gender1 = "Custom";
            }
        }
    }

}


