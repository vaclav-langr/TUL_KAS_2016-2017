using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KAS_AES
{
    public partial class Form1 : Form
    {
        String input, key, output;
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            inputText.Text = keyText.Text = outputText.Text = input = key = output = "";
        }

        private void input_Click(object sender, EventArgs e)
        {
            if (encryptRadio.Checked) {
                inputDialog.Filter = "All files (*.*)|*.*";
            } else {
                inputDialog.Filter = "Rijndael files (*.rijn)|*.rijn";
            }
            DialogResult dr = inputDialog.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK) {
                input = inputDialog.FileName;
                inputText.Text = input.Substring(input.LastIndexOf("\\") + 1);
            }
        }

        private void key_Click(object sender, EventArgs e)
        {
            keyDialog.Filter = "All files (*.*)|*.*";
            DialogResult dr = keyDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                key = keyDialog.FileName;
                keyText.Text = key.Substring(key.LastIndexOf("\\") + 1);
            }
        }

        private void output_Click(object sender, EventArgs e)
        {
            if (!encryptRadio.Checked)
            {
                outputDialog.Filter = "All files (*.*)|*.*";
            }
            else
            {
                outputDialog.Filter = "Rijndael files (*.rijn)|*.rijn";
            }
            DialogResult dr = outputDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                output = outputDialog.FileName;
                outputText.Text = output.Substring(output.LastIndexOf("\\") + 1);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo fi = new FileInfo(key);
            if(fi.Length < 16) {
                MessageBox.Show("Klíč není dostatečně dlouhý. Zvolte, prosím, soubor co má alespoň 16 bytů.");
                return;
            }
            BinaryReader br = new BinaryReader(File.Open(key, FileMode.Open));
            Rijndael_KAS r = new Rijndael_KAS(br.ReadBytes(16));
            if (encryptRadio.Checked) {
                r.encrypt(input, output);
            }
            else
            {
                r.decrypt(input, output);
            }
            br.Close();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            inputButton.Enabled = keyButton.Enabled = outputButton.Enabled = doOperation.Enabled =
                inputText.Enabled = keyText.Enabled = outputText.Enabled =
                encryptRadio.Enabled = decryptRadio.Enabled = true;
            sw.Stop();
            timeText.Text = (sw.ElapsedMilliseconds / 1000.0) + " s";
            speedText.Text = ((new FileInfo(input).Length / (sw.ElapsedMilliseconds / 1000.0)) / 1000000) + " MB/s";
        }

        private void operation_Click(object sender, EventArgs e)
        {
            if(input.Equals("") || output.Equals("") || key.Equals("")) {
                string polozky = "";
                polozky += input.Equals("") ? "vstupní soubor, " : "";
                polozky += output.Equals("") ? "výstupní soubor, " : "";
                polozky += key.Equals("") ? "šifrovací klíč, " : "";
                MessageBox.Show("Vyplňte, prosím, položky: " + polozky.Remove(polozky.LastIndexOf(',')));
                return;
            }
            inputButton.Enabled = keyButton.Enabled = outputButton.Enabled = doOperation.Enabled = 
                inputText.Enabled = keyText.Enabled = outputText.Enabled = 
                encryptRadio.Enabled = decryptRadio.Enabled = false;
            backgroundWorker.RunWorkerAsync();
            sw.Restart();
        }
    }
}
