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
    public partial class Insert : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ashu\source\repos\Project\Project\product.mdf;Integrated Security=True");
        public Insert()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            SqlCommand comm1 = new SqlCommand("insert into pro (ProId,Name,Price,Qun) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
            con.Open();
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "")
            {
                comm1.ExecuteNonQuery();
                MessageBox.Show("row inserted");

                con.Close();
            }
            {
                MessageBox.Show("Please Enter the complete detail");
            }

        }

        private void Insert_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand comm1 = new SqlCommand("delete from pro where ProId='" + textBox1.Text + "'", con);
            SqlCommand comm2 = new SqlCommand("delete from pro where Name='" + textBox2.Text + "'", con);
            con.Open();
            if (textBox1.Text!= "")
            {


                DialogResult dr = MessageBox.Show("Do you want to Delete.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    comm1.ExecuteNonQuery();
                    comm2.ExecuteNonQuery();
                    MessageBox.Show("Row deleted Sucessfully");
                }
                else
                {
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please insert the Proid to delete");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm1 = new SqlCommand("update pro set ProId='" + textBox1.Text + "', Price='" + textBox3.Text + "', Qun='" + textBox4.Text + "' where name = '" + textBox2.Text + "'", con);
            SqlCommand comm2 = new SqlCommand("update pro set Name='" + textBox2.Text + "', Price='" + textBox3.Text + "', Qun='" + textBox4.Text + "' where ProId = '" + textBox1.Text + "'", con);
            DialogResult dr = MessageBox.Show("Do you want to Update.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                comm1.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
                MessageBox.Show("Row updated Sucessfully");
            }
            else
            {
            }
           
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from pro",con);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            // method to display
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 s = new Form3();
            s.Show();
            Visible = false;
        }
    }
}
