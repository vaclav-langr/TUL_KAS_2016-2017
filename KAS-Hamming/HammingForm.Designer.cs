namespace KAS_Hamming
{
    partial class HammingForm
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
            this.decode = new System.Windows.Forms.RadioButton();
            this.encode = new System.Windows.Forms.RadioButton();
            this.inputFileButton = new System.Windows.Forms.Button();
            this.outputFileButton = new System.Windows.Forms.Button();
            this.inputFile = new System.Windows.Forms.TextBox();
            this.outputFile = new System.Windows.Forms.TextBox();
            this.doOperation = new System.Windows.Forms.Button();
            this.operationChoice = new System.Windows.Forms.GroupBox();
            this.errorChoice = new System.Windows.Forms.GroupBox();
            this.more = new System.Windows.Forms.RadioButton();
            this.one = new System.Windows.Forms.RadioButton();
            this.non = new System.Windows.Forms.RadioButton();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.totalTime = new System.Windows.Forms.TextBox();
            this.speed = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.operationChoice.SuspendLayout();
            this.errorChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // decode
            // 
            this.decode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.decode.AutoSize = true;
            this.decode.Location = new System.Drawing.Point(295, 25);
            this.decode.Name = "decode";
            this.decode.Size = new System.Drawing.Size(111, 24);
            this.decode.TabIndex = 1;
            this.decode.TabStop = true;
            this.decode.Text = "Dekódovat";
            this.decode.UseVisualStyleBackColor = true;
            this.decode.CheckedChanged += new System.EventHandler(this.radio1_CheckedChanged);
            // 
            // encode
            // 
            this.encode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.encode.AutoSize = true;
            this.encode.Checked = true;
            this.encode.Location = new System.Drawing.Point(145, 25);
            this.encode.Name = "encode";
            this.encode.Size = new System.Drawing.Size(92, 24);
            this.encode.TabIndex = 0;
            this.encode.TabStop = true;
            this.encode.Text = "Kódovat";
            this.encode.UseVisualStyleBackColor = true;
            this.encode.CheckedChanged += new System.EventHandler(this.radio1_CheckedChanged);
            // 
            // inputFileButton
            // 
            this.inputFileButton.Location = new System.Drawing.Point(12, 83);
            this.inputFileButton.Name = "inputFileButton";
            this.inputFileButton.Size = new System.Drawing.Size(139, 38);
            this.inputFileButton.TabIndex = 2;
            this.inputFileButton.Text = "Vybrat vstup";
            this.inputFileButton.UseVisualStyleBackColor = true;
            this.inputFileButton.Click += new System.EventHandler(this.inputFileButton_Click);
            // 
            // outputFileButton
            // 
            this.outputFileButton.Location = new System.Drawing.Point(12, 127);
            this.outputFileButton.Name = "outputFileButton";
            this.outputFileButton.Size = new System.Drawing.Size(139, 38);
            this.outputFileButton.TabIndex = 3;
            this.outputFileButton.Text = "Vybrat výstup";
            this.outputFileButton.UseVisualStyleBackColor = true;
            this.outputFileButton.Click += new System.EventHandler(this.outputFileButton_Click);
            // 
            // inputFile
            // 
            this.inputFile.Location = new System.Drawing.Point(157, 89);
            this.inputFile.Name = "inputFile";
            this.inputFile.Size = new System.Drawing.Size(373, 26);
            this.inputFile.TabIndex = 4;
            // 
            // outputFile
            // 
            this.outputFile.Location = new System.Drawing.Point(157, 133);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(373, 26);
            this.outputFile.TabIndex = 5;
            // 
            // doOperation
            // 
            this.doOperation.Location = new System.Drawing.Point(12, 244);
            this.doOperation.Name = "doOperation";
            this.doOperation.Size = new System.Drawing.Size(518, 53);
            this.doOperation.TabIndex = 6;
            this.doOperation.Text = "Provést operaci";
            this.doOperation.UseVisualStyleBackColor = true;
            this.doOperation.Click += new System.EventHandler(this.doOperation_Click);
            // 
            // operationChoice
            // 
            this.operationChoice.Controls.Add(this.decode);
            this.operationChoice.Controls.Add(this.encode);
            this.operationChoice.Location = new System.Drawing.Point(12, 12);
            this.operationChoice.Name = "operationChoice";
            this.operationChoice.Size = new System.Drawing.Size(518, 65);
            this.operationChoice.TabIndex = 7;
            this.operationChoice.TabStop = false;
            this.operationChoice.Text = "Volba operace";
            // 
            // errorChoice
            // 
            this.errorChoice.Controls.Add(this.more);
            this.errorChoice.Controls.Add(this.one);
            this.errorChoice.Controls.Add(this.non);
            this.errorChoice.Location = new System.Drawing.Point(12, 171);
            this.errorChoice.Name = "errorChoice";
            this.errorChoice.Size = new System.Drawing.Size(518, 67);
            this.errorChoice.TabIndex = 8;
            this.errorChoice.TabStop = false;
            this.errorChoice.Text = "Výběr chybovosti";
            // 
            // more
            // 
            this.more.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.more.AutoSize = true;
            this.more.Location = new System.Drawing.Point(333, 25);
            this.more.Name = "more";
            this.more.Size = new System.Drawing.Size(80, 24);
            this.more.TabIndex = 3;
            this.more.Text = "> chyb";
            this.more.UseVisualStyleBackColor = true;
            // 
            // one
            // 
            this.one.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.one.AutoSize = true;
            this.one.Location = new System.Drawing.Point(210, 25);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(89, 24);
            this.one.TabIndex = 2;
            this.one.TabStop = true;
            this.one.Text = "1 chyba";
            this.one.UseVisualStyleBackColor = true;
            // 
            // non
            // 
            this.non.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.non.AutoSize = true;
            this.non.Checked = true;
            this.non.Location = new System.Drawing.Point(91, 25);
            this.non.Name = "non";
            this.non.Size = new System.Drawing.Size(80, 24);
            this.non.TabIndex = 1;
            this.non.TabStop = true;
            this.non.Text = "0 chyb";
            this.non.UseVisualStyleBackColor = true;
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Location = new System.Drawing.Point(41, 309);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(92, 20);
            this.totalTimeLabel.TabIndex = 9;
            this.totalTimeLabel.Text = "Celkový čas";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(12, 345);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(121, 20);
            this.speedLabel.TabIndex = 10;
            this.speedLabel.Text = "Rychlost v MB/s";
            // 
            // totalTime
            // 
            this.totalTime.Enabled = false;
            this.totalTime.Location = new System.Drawing.Point(157, 306);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(373, 26);
            this.totalTime.TabIndex = 11;
            // 
            // speed
            // 
            this.speed.Enabled = false;
            this.speed.Location = new System.Drawing.Point(157, 342);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(373, 26);
            this.speed.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // HammingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 386);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.errorChoice);
            this.Controls.Add(this.operationChoice);
            this.Controls.Add(this.doOperation);
            this.Controls.Add(this.outputFile);
            this.Controls.Add(this.inputFile);
            this.Controls.Add(this.outputFileButton);
            this.Controls.Add(this.inputFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "HammingForm";
            this.Text = "Hamming code";
            this.operationChoice.ResumeLayout(false);
            this.operationChoice.PerformLayout();
            this.errorChoice.ResumeLayout(false);
            this.errorChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton decode;
        private System.Windows.Forms.RadioButton encode;
        private System.Windows.Forms.Button inputFileButton;
        private System.Windows.Forms.Button outputFileButton;
        private System.Windows.Forms.TextBox inputFile;
        private System.Windows.Forms.TextBox outputFile;
        private System.Windows.Forms.Button doOperation;
        private System.Windows.Forms.GroupBox operationChoice;
        private System.Windows.Forms.GroupBox errorChoice;
        private System.Windows.Forms.RadioButton more;
        private System.Windows.Forms.RadioButton one;
        private System.Windows.Forms.RadioButton non;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TextBox totalTime;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

