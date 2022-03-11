using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Askhsh2
{
    public partial class Form1 : Form
    {
        public Form1(string amka, string firstName, string lastName)
        {      
            InitializeComponent();
            label2.Text = amka;
            label3.Text = firstName;
            label4.Text = lastName;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create the Save File dialog Instance
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            //Set the Filters for the save dialog.
            saveDlg.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt"; //Don't include space when when typing *.ext. Because space is treated as extension
            saveDlg.DefaultExt = "*.rtf";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            //Show the save file dialog
            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;

            //Set the correct stream type (Rich text or Plain text?)
            RichTextBoxStreamType stream_type;
            if (saveDlg.FilterIndex == 2)
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;

            string guid = System.Guid.NewGuid().ToString();
            string applicationTime = DateTime.Now.ToString();

            
            richTextBox1.Text = richTextBox1.Text.Insert(0, $"Ονοματεπώνυμο: {label3.Text} {label4.Text} \r\nΑΜΚΑ: {label2.Text} \r\nΑριθμός πρωτοκόλλου: {guid} \r\nΗμερομηνία: {applicationTime} \r\n\r\n");

            //richTextBox1.AppendText("\r\n");
            //richTextBox1.AppendText("\r\n" + "Ονοματεπώνυμο: " + label3.Text + " " + label4.Text);
            //richTextBox1.AppendText("\r\n" + "ΑΜΚΑ: " + label2.Text);
            //richTextBox1.AppendText("\r\n" + "Αριθμός πρωτοκόλλου: " + guid);
            //richTextBox1.AppendText("\r\n" + "Ημερομηνία: " + applicationTime);
            
            
            richTextBox1.SaveFile(filename, stream_type);

            string message = "Αριθμός πρωτοκόλλου: " + guid + " Ημερομηνία: " + applicationTime;
            string title = "Επιτυχής υποβολή";
            MessageBox.Show(message, title);

            string messageQuit = "Θέλετε να τερματίσετε την εφαρμογή;";
            string titleQuit = "Κλείσιμο εφαρμογής";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messageQuit, titleQuit, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                richTextBox1.Clear();
                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }

            
        }

  
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Create instance of Open file dialog
            OpenFileDialog file_open = new OpenFileDialog();

            //Setup open file dialog before displaying it
            file_open.Filter = "Rich Text File (*.rtf)|*.rtf| Plain Text File (*.txt)|*.txt";
            file_open.FilterIndex = 1;
            file_open.Title = "Open text or RTF file";

            //Display the dialog and grab the file name
            RichTextBoxStreamType stream_type;
            stream_type = RichTextBoxStreamType.RichText;
            if (DialogResult.OK == file_open.ShowDialog())
            {
                //Set the correct stream type (Rich text or Plain text?)
                if (string.IsNullOrEmpty(file_open.FileName))
                    return;
                if (file_open.FilterIndex == 2)
                    stream_type = RichTextBoxStreamType.PlainText;
                //Open the content of the selected file
                richTextBox1.LoadFile(file_open.FileName, stream_type);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
