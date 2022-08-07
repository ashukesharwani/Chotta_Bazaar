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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ashu\source\repos\Project\Project\product.mdf;Integrated Security=True");
        public Form3(  String Username  )
        {
            InitializeComponent();
            label1.Text = Username;
        }

        public Form3()
        {
            InitializeComponent();
           
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void helToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Do you want to exit.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            { }
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Sales s = new Sales();
            s.Show();
            Visible = false;

        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            f1 form1 = new f1();
            form1.Show();
            Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from pro", con);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            // method to display
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insert i = new Insert();
            i.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sales s = new Sales();
            s.Show();
            Visible = false;
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from pro", con);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            // method to display
            dataGridView1.DataSource = dtbl;
            con.Close();
        }

        private void modifyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert i = new Insert();
            i.Show();
            Visible = false;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert i = new Insert();
            i.Show();
            Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert i = new Insert();
            i.Show();
            Visible = false;
        }
    }
}
