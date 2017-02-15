namespace KAS_AES
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.decryptRadio = new System.Windows.Forms.RadioButton();
            this.encryptRadio = new System.Windows.Forms.RadioButton();
            this.inputText = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.doOperation = new System.Windows.Forms.Button();
            this.speedText = new System.Windows.Forms.TextBox();
            this.timeText = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.inputButton = new System.Windows.Forms.Button();
            this.keyButton = new System.Windows.Forms.Button();
            this.inputDialog = new System.Windows.Forms.OpenFileDialog();
            this.keyDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.decryptRadio);
            this.groupBox1.Controls.Add(this.encryptRadio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volba operace";
            // 
            // decryptRadio
            // 
            this.decryptRadio.AutoSize = true;
            this.decryptRadio.Location = new System.Drawing.Point(247, 25);
            this.decryptRadio.Name = "decryptRadio";
            this.decryptRadio.Size = new System.Drawing.Size(113, 24);
            this.decryptRadio.TabIndex = 1;
            this.decryptRadio.TabStop = true;
            this.decryptRadio.Text = "Dešifrování";
            this.decryptRadio.UseVisualStyleBackColor = true;
            this.decryptRadio.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // encryptRadio
            // 
            this.encryptRadio.AutoSize = true;
            this.encryptRadio.Location = new System.Drawing.Point(81, 25);
            this.encryptRadio.Name = "encryptRadio";
            this.encryptRadio.Size = new System.Drawing.Size(95, 24);
            this.encryptRadio.TabIndex = 0;
            this.encryptRadio.TabStop = true;
            this.encryptRadio.Text = "Šifrování";
            this.encryptRadio.UseVisualStyleBackColor = true;
            this.encryptRadio.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(93, 77);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(363, 26);
            this.inputText.TabIndex = 2;
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(93, 116);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(363, 26);
            this.keyText.TabIndex = 4;
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(93, 155);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(363, 26);
            this.outputText.TabIndex = 6;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(12, 152);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(75, 33);
            this.outputButton.TabIndex = 5;
            this.outputButton.Text = "Výstup";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.output_Click);
            // 
            // doOperation
            // 
            this.doOperation.Location = new System.Drawing.Point(12, 191);
            this.doOperation.Name = "doOperation";
            this.doOperation.Size = new System.Drawing.Size(444, 33);
            this.doOperation.TabIndex = 7;
            this.doOperation.Text = "Provést operaci";
            this.doOperation.UseVisualStyleBackColor = true;
            this.doOperation.Click += new System.EventHandler(this.operation_Click);
            // 
            // speedText
            // 
            this.speedText.Enabled = false;
            this.speedText.Location = new System.Drawing.Point(150, 262);
            this.speedText.Name = "speedText";
            this.speedText.Size = new System.Drawing.Size(306, 26);
            this.speedText.TabIndex = 9;
            // 
            // timeText
            // 
            this.timeText.Enabled = false;
            this.timeText.Location = new System.Drawing.Point(150, 230);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(306, 26);
            this.timeText.TabIndex = 8;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(41, 233);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(92, 20);
            this.timeLabel.TabIndex = 10;
            this.timeLabel.Text = "Celkový čas";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(12, 265);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(121, 20);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "Rychlost v MB/s";
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(12, 74);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(75, 33);
            this.inputButton.TabIndex = 12;
            this.inputButton.Text = "Vstup";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.input_Click);
            // 
            // keyButton
            // 
            this.keyButton.Location = new System.Drawing.Point(12, 113);
            this.keyButton.Name = "keyButton";
            this.keyButton.Size = new System.Drawing.Size(75, 33);
            this.keyButton.TabIndex = 13;
            this.keyButton.Text = "Klíč";
            this.keyButton.UseVisualStyleBackColor = true;
            this.keyButton.Click += new System.EventHandler(this.key_Click);
            // 
            // inputDialog
            // 
            this.inputDialog.FileName = "openFileDialog1";
            // 
            // keyDialog
            // 
            this.keyDialog.FileName = "openFileDialog2";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 297);
            this.Controls.Add(this.keyButton);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.speedText);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.doOperation);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Rijndael";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button doOperation;
        private System.Windows.Forms.TextBox speedText;
        private System.Windows.Forms.TextBox timeText;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Button keyButton;
        private System.Windows.Forms.RadioButton decryptRadio;
        private System.Windows.Forms.RadioButton encryptRadio;
        private System.Windows.Forms.OpenFileDialog inputDialog;
        private System.Windows.Forms.OpenFileDialog keyDialog;
        private System.Windows.Forms.SaveFileDialog outputDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

