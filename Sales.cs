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
    public partial class Sales : Form
    {
     
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ashu\source\repos\Project\Project\product.mdf;Integrated Security=True");
        public Sales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select ProId,Name,Price From  pro where ProId = '" + textBox1.Text + "'", con);
            con.Open();
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            // method to display
            dataGridView1.DataSource = dtbl;
            con.Close();

             
                dataGridView1.Rows[0].Cells[0].Value =0+1;
                dataGridView1.Rows[0].Cells[1].Value = textBox4.Text;
                string value = dataGridView1.Rows[0].Cells[5].Value.ToString();
                dataGridView1.Rows[0].Cells[2].Value = (float.Parse(textBox4.Text)*float.Parse(value));


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {  
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 s = new Form3();
            s.Show();
            Visible = false;
        }
    }
}
