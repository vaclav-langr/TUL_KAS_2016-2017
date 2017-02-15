using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace KAS_Huffman
{
    public partial class Form2 : Form
    {
        private Dictionary<byte, BitArray> encoding;
        private string typ;

        public Form2()
        {
            InitializeComponent();
        }

        private void fill_table()
        {
            string s;
            foreach (byte b in encoding.Keys)
            {
                s = "";
                for (int i = 0; i < encoding[b].Length; i++)
                {
                    s += (encoding[b][i] ? "1" : "0");
                }
                this.dataGridView1.Rows.Add(new object[] { b, s });
            }
        }

        public Form2(string s, Dictionary<byte, BitArray> encoding) : this()
        {
            this.typ = s;
            this.encoding = encoding;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + typ;
            fill_table();
        }
    }
}
