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
            this.newDataCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.parameterTextBox = new System.Windows.Forms.TextBox();
            this.browseButton4 = new System.Windows.Forms.Button();
            this.factorsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // predictButton
            // 
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictButton.Location = new System.Drawing.Point(280, 458);
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
            this.pathTextBox.Size = new System.Drawing.Size(542, 30);
            this.pathTextBox.TabIndex = 3;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(264, 41);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(236, 31);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "Input File Location";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(650, 97);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(99, 30);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(81, 537);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(668, 60);
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
            this.dataPathLabel.Location = new System.Drawing.Point(274, 356);
            this.dataPathLabel.Name = "dataPathLabel";
            this.dataPathLabel.Size = new System.Drawing.Size(209, 31);
            this.dataPathLabel.TabIndex = 11;
            this.dataPathLabel.Text = "ATR Data folder";
            // 
            // dataPathTextBox
            // 
            this.dataPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPathTextBox.Location = new System.Drawing.Point(81, 407);
            this.dataPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataPathTextBox.Name = "dataPathTextBox";
            this.dataPathTextBox.Size = new System.Drawing.Size(542, 30);
            this.dataPathTextBox.TabIndex = 12;
            // 
            // browseButton2
            // 
            this.browseButton2.Location = new System.Drawing.Point(650, 407);
            this.browseButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton2.Name = "browseButton2";
            this.browseButton2.Size = new System.Drawing.Size(99, 30);
            this.browseButton2.TabIndex = 13;
            this.browseButton2.Text = "Browse";
            this.browseButton2.UseVisualStyleBackColor = true;
            this.browseButton2.Click += new System.EventHandler(this.browseButton2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AADT.Properties.Resources.Flat_Folder_icon;
            this.pictureBox2.Location = new System.Drawing.Point(12, 392);
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
            // newDataCheckBox
            // 
            this.newDataCheckBox.AutoSize = true;
            this.newDataCheckBox.Location = new System.Drawing.Point(626, 481);
            this.newDataCheckBox.Name = "newDataCheckBox";
            this.newDataCheckBox.Size = new System.Drawing.Size(123, 21);
            this.newDataCheckBox.TabIndex = 15;
            this.newDataCheckBox.Text = "New ATR Data";
            this.newDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // browseButton3
            // 
            this.browseButton3.Location = new System.Drawing.Point(650, 200);
            this.browseButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton3.Name = "browseButton3";
            this.browseButton3.Size = new System.Drawing.Size(99, 30);
            this.browseButton3.TabIndex = 18;
            this.browseButton3.Text = "Browse";
            this.browseButton3.UseVisualStyleBackColor = true;
            this.browseButton3.Click += new System.EventHandler(this.browseButton3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "Parameter File Location";
            // 
            // parameterTextBox
            // 
            this.parameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterTextBox.Location = new System.Drawing.Point(81, 200);
            this.parameterTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.parameterTextBox.Name = "parameterTextBox";
            this.parameterTextBox.Size = new System.Drawing.Size(542, 30);
            this.parameterTextBox.TabIndex = 16;
            // 
            // browseButton4
            // 
            this.browseButton4.Location = new System.Drawing.Point(650, 305);
            this.browseButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton4.Name = "browseButton4";
            this.browseButton4.Size = new System.Drawing.Size(99, 30);
            this.browseButton4.TabIndex = 21;
            this.browseButton4.Text = "Browse";
            this.browseButton4.UseVisualStyleBackColor = true;
            this.browseButton4.Click += new System.EventHandler(this.browseButton4_Click);
            // 
            // factorsTextBox
            // 
            this.factorsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factorsTextBox.Location = new System.Drawing.Point(81, 305);
            this.factorsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.factorsTextBox.Name = "factorsTextBox";
            this.factorsTextBox.Size = new System.Drawing.Size(542, 30);
            this.factorsTextBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 31);
            this.label2.TabIndex = 19;
            this.label2.Text = "Factors File Location";
            // 
            // AADTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 632);
            this.Controls.Add(this.browseButton4);
            this.Controls.Add(this.factorsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parameterTextBox);
            this.Controls.Add(this.newDataCheckBox);
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
        private System.Windows.Forms.CheckBox newDataCheckBox;
        private System.Windows.Forms.Button browseButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox parameterTextBox;
        private System.Windows.Forms.Button browseButton4;
        private System.Windows.Forms.TextBox factorsTextBox;
        private System.Windows.Forms.Label label2;
    }
}