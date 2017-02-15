namespace KAS_Huffman
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.input_file_label = new System.Windows.Forms.Label();
            this.input_file_name = new System.Windows.Forms.Label();
            this.input_button = new System.Windows.Forms.Button();
            this.output_button = new System.Windows.Forms.Button();
            this.output_file_name = new System.Windows.Forms.Label();
            this.output_file_label = new System.Windows.Forms.Label();
            this.func_button = new System.Windows.Forms.Button();
            this.input_file_label2 = new System.Windows.Forms.Label();
            this.input_size_label = new System.Windows.Forms.Label();
            this.output_file_label2 = new System.Windows.Forms.Label();
            this.output_size_label = new System.Windows.Forms.Label();
            this.compress_ratio = new System.Windows.Forms.Label();
            this.compress_ratio_label = new System.Windows.Forms.Label();
            this.time_text_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.show_encoding = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(29, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Kódování";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(152, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Dekódování";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // input_file_label
            // 
            this.input_file_label.AutoSize = true;
            this.input_file_label.Location = new System.Drawing.Point(12, 40);
            this.input_file_label.Name = "input_file_label";
            this.input_file_label.Size = new System.Drawing.Size(37, 13);
            this.input_file_label.TabIndex = 2;
            this.input_file_label.Text = "Vstup:";
            // 
            // input_file_name
            // 
            this.input_file_name.AutoSize = true;
            this.input_file_name.Location = new System.Drawing.Point(55, 40);
            this.input_file_name.Name = "input_file_name";
            this.input_file_name.Size = new System.Drawing.Size(0, 13);
            this.input_file_name.TabIndex = 3;
            // 
            // input_button
            // 
            this.input_button.Location = new System.Drawing.Point(197, 35);
            this.input_button.Name = "input_button";
            this.input_button.Size = new System.Drawing.Size(75, 23);
            this.input_button.TabIndex = 4;
            this.input_button.Text = "Vybrat";
            this.input_button.UseVisualStyleBackColor = true;
            this.input_button.Click += new System.EventHandler(this.input_button_Click);
            // 
            // output_button
            // 
            this.output_button.Location = new System.Drawing.Point(197, 64);
            this.output_button.Name = "output_button";
            this.output_button.Size = new System.Drawing.Size(75, 23);
            this.output_button.TabIndex = 7;
            this.output_button.Text = "Vybrat";
            this.output_button.UseVisualStyleBackColor = true;
            this.output_button.Click += new System.EventHandler(this.output_button_Click);
            // 
            // output_file_name
            // 
            this.output_file_name.AutoSize = true;
            this.output_file_name.Location = new System.Drawing.Point(60, 69);
            this.output_file_name.Name = "output_file_name";
            this.output_file_name.Size = new System.Drawing.Size(0, 13);
            this.output_file_name.TabIndex = 6;
            // 
            // output_file_label
            // 
            this.output_file_label.AutoSize = true;
            this.output_file_label.Location = new System.Drawing.Point(12, 69);
            this.output_file_label.Name = "output_file_label";
            this.output_file_label.Size = new System.Drawing.Size(42, 13);
            this.output_file_label.TabIndex = 5;
            this.output_file_label.Text = "Výstup:";
            // 
            // func_button
            // 
            this.func_button.Location = new System.Drawing.Point(12, 93);
            this.func_button.Name = "func_button";
            this.func_button.Size = new System.Drawing.Size(260, 23);
            this.func_button.TabIndex = 8;
            this.func_button.Text = "Provést operaci";
            this.func_button.UseVisualStyleBackColor = true;
            this.func_button.Click += new System.EventHandler(this.func_button_Click);
            // 
            // input_file_label2
            // 
            this.input_file_label2.AutoSize = true;
            this.input_file_label2.Location = new System.Drawing.Point(14, 154);
            this.input_file_label2.Name = "input_file_label2";
            this.input_file_label2.Size = new System.Drawing.Size(79, 13);
            this.input_file_label2.TabIndex = 9;
            this.input_file_label2.Text = "Vstupní soubor";
            // 
            // input_size_label
            // 
            this.input_size_label.AutoSize = true;
            this.input_size_label.Location = new System.Drawing.Point(104, 154);
            this.input_size_label.Name = "input_size_label";
            this.input_size_label.Size = new System.Drawing.Size(0, 13);
            this.input_size_label.TabIndex = 10;
            // 
            // output_file_label2
            // 
            this.output_file_label2.AutoSize = true;
            this.output_file_label2.Location = new System.Drawing.Point(14, 167);
            this.output_file_label2.Name = "output_file_label2";
            this.output_file_label2.Size = new System.Drawing.Size(84, 13);
            this.output_file_label2.TabIndex = 12;
            this.output_file_label2.Text = "Výstupní soubor";
            // 
            // output_size_label
            // 
            this.output_size_label.AutoSize = true;
            this.output_size_label.Location = new System.Drawing.Point(104, 167);
            this.output_size_label.Name = "output_size_label";
            this.output_size_label.Size = new System.Drawing.Size(0, 13);
            this.output_size_label.TabIndex = 11;
            // 
            // compress_ratio
            // 
            this.compress_ratio.AutoSize = true;
            this.compress_ratio.Location = new System.Drawing.Point(104, 180);
            this.compress_ratio.Name = "compress_ratio";
            this.compress_ratio.Size = new System.Drawing.Size(0, 13);
            this.compress_ratio.TabIndex = 14;
            // 
            // compress_ratio_label
            // 
            this.compress_ratio_label.AutoSize = true;
            this.compress_ratio_label.Location = new System.Drawing.Point(14, 180);
            this.compress_ratio_label.Name = "compress_ratio_label";
            this.compress_ratio_label.Size = new System.Drawing.Size(54, 13);
            this.compress_ratio_label.TabIndex = 13;
            this.compress_ratio_label.Text = "Komprese";
            // 
            // time_text_label
            // 
            this.time_text_label.AutoSize = true;
            this.time_text_label.Location = new System.Drawing.Point(14, 193);
            this.time_text_label.Name = "time_text_label";
            this.time_text_label.Size = new System.Drawing.Size(25, 13);
            this.time_text_label.TabIndex = 15;
            this.time_text_label.Text = "Čas";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(104, 193);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 13);
            this.time_label.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(173, 157);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // show_encoding
            // 
            this.show_encoding.Location = new System.Drawing.Point(12, 122);
            this.show_encoding.Name = "show_encoding";
            this.show_encoding.Size = new System.Drawing.Size(260, 23);
            this.show_encoding.TabIndex = 18;
            this.show_encoding.Text = "Zobrazit tabulku kódování";
            this.show_encoding.UseVisualStyleBackColor = true;
            this.show_encoding.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.show_encoding);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.time_text_label);
            this.Controls.Add(this.compress_ratio);
            this.Controls.Add(this.compress_ratio_label);
            this.Controls.Add(this.output_file_label2);
            this.Controls.Add(this.output_size_label);
            this.Controls.Add(this.input_size_label);
            this.Controls.Add(this.input_file_label2);
            this.Controls.Add(this.func_button);
            this.Controls.Add(this.output_button);
            this.Controls.Add(this.output_file_name);
            this.Controls.Add(this.output_file_label);
            this.Controls.Add(this.input_button);
            this.Controls.Add(this.input_file_name);
            this.Controls.Add(this.input_file_label);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Huffman code";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Label input_file_label;
        private System.Windows.Forms.Label input_file_name;
        private System.Windows.Forms.Button input_button;
        private System.Windows.Forms.Button output_button;
        private System.Windows.Forms.Label output_file_name;
        private System.Windows.Forms.Label output_file_label;
        private System.Windows.Forms.Button func_button;
        private System.Windows.Forms.Label input_file_label2;
        private System.Windows.Forms.Label input_size_label;
        private System.Windows.Forms.Label output_file_label2;
        private System.Windows.Forms.Label output_size_label;
        private System.Windows.Forms.Label compress_ratio;
        private System.Windows.Forms.Label compress_ratio_label;
        private System.Windows.Forms.Label time_text_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button show_encoding;

    }
}

