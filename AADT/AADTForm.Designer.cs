namespace AADT
{
    partial class AADTForm
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
            this.predictButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.minionBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dataPathLabel = new System.Windows.Forms.Label();
            this.dataPathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // predictButton
            // 
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictButton.Location = new System.Drawing.Point(168, 286);
            this.predictButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(203, 54);
            this.predictButton.TabIndex = 5;
            this.predictButton.Text = "Predict AADT";
            this.predictButton.UseVisualStyleBackColor = true;
            this.predictButton.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.Location = new System.Drawing.Point(81, 97);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(370, 30);
            this.pathTextBox.TabIndex = 3;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(162, 38);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(236, 31);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "Input File Location";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(479, 93);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(99, 34);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 375);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(523, 60);
            this.progressBar1.TabIndex = 10;
            // 
            // minionBackgroundWorker
            // 
            this.minionBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.minionBackgroundWorker_DoWork);
            this.minionBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.minionBackgroundWorker_ProgressChanged);
            this.minionBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.minionBackgroundWorker_RunWorkerCompleted);
            // 
            // dataPathLabel
            // 
            this.dataPathLabel.AutoSize = true;
            this.dataPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPathLabel.Location = new System.Drawing.Point(162, 158);
            this.dataPathLabel.Name = "dataPathLabel";
            this.dataPathLabel.Size = new System.Drawing.Size(209, 31);
            this.dataPathLabel.TabIndex = 11;
            this.dataPathLabel.Text = "ATR Data folder";
            // 
            // dataPathTextBox
            // 
            this.dataPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPathTextBox.Location = new System.Drawing.Point(81, 219);
            this.dataPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataPathTextBox.Name = "dataPathTextBox";
            this.dataPathTextBox.Size = new System.Drawing.Size(370, 30);
            this.dataPathTextBox.TabIndex = 12;
            // 
            // browseButton2
            // 
            this.browseButton2.Location = new System.Drawing.Point(479, 215);
            this.browseButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton2.Name = "browseButton2";
            this.browseButton2.Size = new System.Drawing.Size(99, 34);
            this.browseButton2.TabIndex = 13;
            this.browseButton2.Text = "Browse";
            this.browseButton2.UseVisualStyleBackColor = true;
            this.browseButton2.Click += new System.EventHandler(this.browseButton2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AADT.Properties.Resources.Flat_Folder_icon;
            this.pictureBox2.Location = new System.Drawing.Point(12, 203);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(455, 300);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 21);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "New ATR Data";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AADTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 464);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.browseButton2);
            this.Controls.Add(this.dataPathTextBox);
            this.Controls.Add(this.dataPathLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.predictButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AADTForm";
            this.Text = "AADT";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AADTForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker minionBackgroundWorker;
        private System.Windows.Forms.Label dataPathLabel;
        private System.Windows.Forms.TextBox dataPathTextBox;
        private System.Windows.Forms.Button browseButton2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}