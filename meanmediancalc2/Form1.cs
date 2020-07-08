using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            // prevent user from messing with entered data
            richTextBox1.ReadOnly = true;

            // disable buttons since a new form has nothing to calculate
            btn_mean.Enabled = false;
            btn_median.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            enterValues();
        }

        private void enterValues()
        {
            bool repeatInput = true;
            int returnedValue;
            while (repeatInput != false)
            {
                try
                {
                    returnedValue = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter a number or Type \"n\" to close.", "Value Entry"));
                }

                catch (System.FormatException)
                {
                    return;
                }

                // exiting loop if user selects "n" 
                if (returnedValue.ToString() == "n".ToLower())
                {
                    //MessageBox.Show("No Selected No Value Added");
                    return;
                }

                else if (returnedValue != 0)
                {
                    //MessageBox.Show("Value added");
                    enteredValues.Add(returnedValue);
                    writeToRichTextBox(returnedValue);
                }
            }
        }

        private void writeToRichTextBox(int value)
        {
            richTextBox1.Text += value.ToString();
            richTextBox1.Text += Environment.NewLine;
        }

        private void enableButtons()
        {
            btn_mean.Enabled = true;
            btn_median.Enabled = true;
        }

        // checks to see if list only has one item -- it needs at least two.
        private void canBeCalulated()
        {

        }
    }
}
