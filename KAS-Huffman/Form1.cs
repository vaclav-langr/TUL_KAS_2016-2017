using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace KAS_Huffman
{
    public partial class Form1 : Form
    {
        #region Variables
        string input_file = "";
        string output_file = "";
        Stopwatch sw = new Stopwatch();
        string[] extensions = { " B", " kB", " MB", " GB" };
        Dictionary<byte, BitArray> encoding;
        #endregion
        #region Functions
        public Form1()
        {
            InitializeComponent();
        }
        private void func_button_Click(object sender, EventArgs e)
        {
            hide_show_elements();
            bw.RunWorkerAsync();
        }

        private void hide_show_elements()
        {
            pictureBox1.Visible = !pictureBox1.Visible;
            show_encoding.Enabled = radioButton1.Enabled = radioButton2.Enabled = func_button.Enabled = input_button.Enabled = output_button.Enabled = !output_button.Enabled;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                MessageBox.Show("Author: Václav Langr", "Author", MessageBoxButtons.OK);
            }
        }
        #endregion
        #region BG_worker
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds);

            hide_show_elements();

            decimal input_size = new FileInfo(input_file).Length;
            decimal output_size = new FileInfo(output_file).Length;
            double ratio = Decimal.ToDouble(100 * output_size / input_size);

            int extension1 = 0;
            while(input_size > 1024) {
                input_size = input_size / 1024;
                extension1++;
            }

            int extension2 = 0;
            while (output_size > 1024)
            {
                output_size = output_size / 1024;
                extension2++;
            }

            input_size_label.Text = Math.Ceiling(input_size) + extensions[extension1];
            output_size_label.Text = Math.Ceiling(output_size) + extensions[extension2];
            compress_ratio.Text = String.Format("{0:N} %", ratio);
            time_label.Text = t.ToString(@"hh\:mm\:ss\.fff");
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            sw.Reset();
            sw.Start();
            Huffman h = new Huffman();
            switch (radioButton1.Checked)
            {
                case true:
                    encoding = h.encode(input_file, output_file);
                    break;
                case false:
                    encoding = h.decode(input_file, output_file);
                    break;
            }
        }
        #endregion
        #region File_dialogs
        private void input_button_Click(object sender, EventArgs e)
        {
            switch(radioButton1.Checked) {
                case true:
                    input_file = file_dialog("All files (*.*)|*.*", openFile, input_file_name);
                    break;
                case false:
                    input_file = file_dialog("Huffman file (*.huff)|*.huff", openFile, input_file_name);
                    break;
            }
        }

        private string file_dialog(string filter, FileDialog f, Label l)
        {
            f.Filter = filter;
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                l.Text = f.FileName.Substring(f.FileName.LastIndexOf("\\") + 1);
            }
            return f.FileName;
        }

        private void output_button_Click(object sender, EventArgs e)
        {
            switch (radioButton1.Checked)
            {
                case true:
                    output_file = file_dialog("Huffman file (*.huff)|*.huff", saveFile, output_file_name);
                    break;
                case false:
                    output_file = file_dialog("All files (*.*)|*.*", saveFile, output_file_name);
                    break;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            input_file_name.Text = output_file_name.Text = output_file = input_file = "";
            encoding = null;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            switch (radioButton1.Checked)
            {
                case true:
                    s = "Kódování";
                    break;
                case false:
                    s = "Dekódování";
                    break;
            }
            if (encoding != null) {
                Form2 f = new Form2(s, encoding);
                f.Show();
            }
        }
    }
}
