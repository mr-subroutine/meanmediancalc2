using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meanmediancalc2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> enteredValues = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_mean.Enabled = false;
            btn_median.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }
    }
}
