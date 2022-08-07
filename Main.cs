using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class First : Form
    {
        public First()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f1 form1 = new f1();
            form1.Show();
            Visible = false;
        }
    }
}
