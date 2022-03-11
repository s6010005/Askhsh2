using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Askhsh2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 11)
            {           
                string amka = textBox1.Text;
                Regex regex = new Regex(@"^[0-9]{11}$");
                Match match = regex.Match(amka);
                if (!match.Success)
                {
                    label13.Text = "Λάθος ΑΜΚΑ";
                }
                else
                {
                    string datetime = amka.Substring(0, 6);
                    DateTime result = new DateTime();
                    if (!DateTime.TryParseExact(datetime, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    {
                        label13.Text = "Λάθος ΑΜΚΑ";
                    }                      
                    else
                    {                      
                        if (checkLuhn(amka))
                        {
                            label13.Text = "";
                            textBox1.ReadOnly = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            comboBox1.Enabled = true;
                            comboBox2.Enabled = true;
                            comboBox3.Enabled = true;
                            checkedListBox1.Enabled = true;
                            textBox11.Enabled = true;
                            textBox12.Enabled = true;
                            button1.Enabled = true;
                        }
                        else
                            label13.Text = "Λάθος ΑΜΚΑ";
                    }
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        static bool checkLuhn(String myamka)
        {
            int nDigits = myamka.Length;
            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = myamka[i] - '0';
                if (isSecond == true)
                    d = d * 2;
                nSum += d / 10;
                nSum += d % 10;
                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0 && textBox3.TextLength > 0)
            {
                this.Hide();

                var form1 = new Form1(this.textBox1.Text, this.textBox2.Text, textBox3.Text);
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το ονοματεπώνυμό σας");
            }
            

            //Form targetform = new Form1();
            //targetform.Show();
        }
    }
}
