using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace meanmediancalc2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // data structure for input
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
                    enableButtons();
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
            bool canCalculate = canBeCalulated();
            if (canCalculate == true)
            {
                btn_mean.Enabled = true;
                btn_median.Enabled = true;
            }
        }

        private void disableButtons()
        {
            btn_mean.Enabled = false;
            btn_median.Enabled = false;
        }

        // checks to see if list only has one item -- it needs at least two.
        private bool canBeCalulated()
        {
            bool canCalculate = false;
            int count = enteredValues.Count();

            if (count > 1)
            {
                return canCalculate = true;
            }

            else
            {
                return canCalculate;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            disableButtons();
            richTextBox1.Clear();
            enteredValues.Clear();
        }

        private void btn_mean_Click(object sender, EventArgs e)
        {
            int total = 0;
            int avg = 0;
            int count = enteredValues.Count();

            for (int i = 0; i < enteredValues.Count; i++)
            {
                total += enteredValues[i];
            }

            avg = total / count;
            MessageBox.Show("The mean is: " + avg);
        }

        private void btn_median_Click(object sender, EventArgs e)
        {
            int count = enteredValues.Count();
            int median = 0;

            if (count % 2 == 0)
            {
                enteredValues.Sort();
                int pair1 = enteredValues[(count / 2) - 1];
                int pair2 = enteredValues[(count / 2)];
                median = (pair1 + pair2) / 2;
                MessageBox.Show("The median is: " + median);
                return;
            }

            else if (count % 2 != 0)
            {
                enteredValues.Sort();
                count += 1;
                median = enteredValues[(count / 2) - 1];

                MessageBox.Show("The median is: " + median);
                return;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string startUpPath = Application.StartupPath;
            string location = startUpPath + @"\save.txt";

            // sets size of array to size of list and copies for system.io writeline
            string[] enterValuesArr = new string[enteredValues.Count];

            for (int i = 0; i < enteredValues.Count; i++)
            {
                enterValuesArr[i] = enteredValues[i].ToString();
            }

            System.IO.File.WriteAllLines(@location, enterValuesArr);

            // checks to see if file was created
            if (File.Exists(location))
            {
                MessageBox.Show("Text File Created!");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string startUpPath = Application.StartupPath;
            string location = startUpPath + @"\save.txt";

            if (!File.Exists(location))
            {
                MessageBox.Show("No File Found.");
                return;
            }

            if (File.Exists(location))
            {
                File.Delete(location);

                if (!File.Exists(location))
                {
                    MessageBox.Show("Text File Deleted!");
                }
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string startUpPath = Application.StartupPath;
            string location = startUpPath + @"\save.txt";
            richTextBox1.Clear();

            if (!File.Exists(location))
            {
                MessageBox.Show("No File Found.");
                return;
            }

            if (File.Exists(location))
            {
                // read from text file


                // display in list
            }

        }
    }
}
