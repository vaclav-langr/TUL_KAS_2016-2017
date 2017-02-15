using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace KAS_Hamming
{
    public partial class HammingForm : Form
    {
        #region Variables
        Hamming h;
        string input_file = "", output_file = "";
        long output_file_size;
        Stopwatch sw = new Stopwatch();
        Random r = new Random();
        List<int> indexy = new List<int>();
        int num_errors = 0;
        #endregion
        public HammingForm()
        {
            InitializeComponent();
            backgroundWorker2.RunWorkerAsync();
        }
        #region Form events
        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as RadioButton).Text.StartsWith("D")) {
                errorChoice.Visible = false;
            } else {
                errorChoice.Visible = true;
            }
            this.inputFile.Text = this.outputFile.Text = "";
        }
        private string file_dialog(string filter, FileDialog f, TextBox t)
        {
            f.Filter = filter;
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                t.Text = f.FileName.Substring(f.FileName.LastIndexOf("\\") + 1);
            }
            return f.FileName;
        }
        private void inputFileButton_Click(object sender, EventArgs e)
        {
            if (encode.Checked) {
                input_file = file_dialog("All files (*.*)|*.*", openFileDialog1, inputFile);
            } else {
                input_file = file_dialog("Hamming file (*.hamm*)|*.hamm", openFileDialog1, inputFile);
            }
        }
        private void outputFileButton_Click(object sender, EventArgs e)
        {
            if (encode.Checked) {
                output_file = file_dialog("Hamming file (*.hamm*)|*.hamm", saveFileDialog1, outputFile);
            } else {
                output_file = file_dialog("All files (*.*)|*.*", saveFileDialog1, outputFile);
            }
        }
        private void doOperation_Click(object sender, EventArgs e)
        {
            num_errors = 0;
            if (inputFile.Text != "" && outputFile.Text != "") {
                hide_show_elements();
                sw.Restart();
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void hide_show_elements()
        {
            non.Enabled = one.Enabled = more.Enabled = 
                outputFile.Enabled = inputFile.Enabled =
                encode.Enabled = decode.Enabled = 
                doOperation.Enabled = 
                inputFileButton.Enabled = outputFileButton.Enabled = 
                !outputFileButton.Enabled;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            double time = sw.ElapsedMilliseconds / 1000.0;
            totalTime.Text = time + " s";
            speed.Text = ((output_file_size / time) / 1000.0) / 1000.0 + " MB/s";
            hide_show_elements();
            if (errorChoice.Visible) {
                if (one.Checked) {
                    MessageBox.Show("Počet jednonásobných chyb: " + num_errors);
                } else if (more.Checked) {
                    MessageBox.Show("Počet dvojnásobných chyb: " + num_errors);
                }
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            h = new Hamming();
        }
        #endregion
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FileStream input = new FileStream(input_file, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(input);
            FileStream output = new FileStream(output_file, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(output);
            
            byte[] b = br.ReadBytes((int)input.Length);

            switch (encode.Checked)
            {
                case true:
                    determine_encode(bw, b);
                    break;
                case false:
                    determine_decode(bw, b);
                    break;
            }
            br.Close();
            bw.Flush();
            output_file_size = output.Length;
            bw.Close();
            b = null;
            GC.Collect();
        }
        private void determine_decode(BinaryWriter bw, byte[] bytes)
        {
            byte unused = bytes[0];
            byte[] decode;
            h.one_error = h.two_error = 0;
            BitArray ba;
            int i;
            for (i = 0; i < (bytes.Length - 1) / 5 - 1; i++ )
            {
                ba = new BitArray(new byte[] { bytes[i * 5 + 1], bytes[i * 5 + 2], bytes[i * 5 + 3], bytes[i * 5 + 4], bytes[i * 5 + 5] });
                decode = h.decode(ba);
                if(h.two_error == 0) {
                    bw.Write(decode);
                }
            }
            ba = new BitArray(new byte[] { bytes[i * 5 + 1], bytes[i * 5 + 2], bytes[i * 5 + 3], bytes[i * 5 + 4], bytes[i * 5 + 5] });
            byte[] temp = h.decode(ba);
            switch(unused) {
                case 1:
                    if(h.two_error == 0) {
                        bw.Write(temp[0]);
                    }
                    break;
                case 2:
                    if(h.two_error == 0) {
                        bw.Write(temp[0]);
                        bw.Write(temp[1]);
                    }
                    break;
                default:
                    if (h.two_error == 0)
                    {
                        bw.Write(temp);
                    }
                    break;
            }
            MessageBox.Show("Celkem jednonásobných opravitelných chyb: " + h.one_error + "\nCelkem vícenásobných neopravitelných chyb: " + h.two_error, "Statistika");
        }
        private void determine_encode(BinaryWriter bw, byte[] bytes)
        {
            if (non.Checked) {
                encode_bytes(bw, bytes, 0.0, 0);
            } else if (one.Checked) {
                encode_bytes(bw, bytes, 0.1, 1);
            } else {
                encode_bytes(bw, bytes, 0.1, 2);
            }
        }
        private void encode_bytes(BinaryWriter bw, byte[] bytes, double pst, int errors)
        {
            BitArray[] temp;
            bw.Write((byte)(bytes.Length % 3));
            for (int i = 0; i < Math.Floor(bytes.Length / 3.0); i++ )
            {
                temp = h.encode(bytes[i * 3], bytes[(i * 3) + 1], bytes[(i * 3) + 2]);
                temp = gen_error(temp, pst, errors, 0);
                bw.Write(h.array_to_bytes(temp));
            }
            switch (bytes.Length % 3)
            {
                case 1:
                    temp = h.encode(bytes[bytes.Length - 1], 0, 0);
                    temp = gen_error(temp, pst, errors, 2);
                    bw.Write(h.array_to_bytes(temp));
                    break;
                case 2:
                    temp = h.encode(bytes[bytes.Length - 2], bytes[bytes.Length - 1], 0);
                    temp = gen_error(temp, pst, errors, 1);
                    bw.Write(h.array_to_bytes(temp));
                    break;
            }
        }
        private BitArray[] gen_error(BitArray[] temp, double pst, int errors, int zeros)
        {
            int error_index;
            if (errors > 0)
            {
                for (int j = 0; j < temp.Length - zeros; j++)
                {
                    if (r.NextDouble() < pst)
                    {
                        num_errors++;
                        indexy.Add(r.Next(temp[j].Length));

                        for (int k = 1; k < errors; k++)
                        {
                            do
                            {
                                error_index = r.Next(temp[j].Length);
                            } while (indexy.Contains(error_index));
                            indexy.Add(error_index);
                        }

                        foreach (int index in indexy)
                        {
                            temp[j].Set(12 - index, !temp[j].Get(12 - index));
                        }
                        indexy.Clear();
                    }
                }
            }
            return temp;
        }
    }
}
