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
            this.selectDataLabel = new System.Windows.Forms.Label();
            this.predictButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.roadWayComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.minionBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectDataLabel
            // 
            this.selectDataLabel.AutoSize = true;
            this.selectDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDataLabel.Location = new System.Drawing.Point(64, 64);
            this.selectDataLabel.Name = "selectDataLabel";
            this.selectDataLabel.Size = new System.Drawing.Size(500, 31);
            this.selectDataLabel.TabIndex = 1;
            this.selectDataLabel.Text = "Select Roadway Functional Class Model";
            // 
            // predictButton
            // 
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictButton.Location = new System.Drawing.Point(205, 400);
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
            this.pathTextBox.Location = new System.Drawing.Point(55, 263);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(523, 30);
            this.pathTextBox.TabIndex = 3;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(231, 201);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(168, 31);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "File Location";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(253, 326);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(98, 35);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // roadWayComboBox
            // 
            this.roadWayComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roadWayComboBox.FormattingEnabled = true;
            this.roadWayComboBox.Items.AddRange(new object[] {
            "Interstate",
            "Arterial",
            "Collector"});
            this.roadWayComboBox.Location = new System.Drawing.Point(205, 135);
            this.roadWayComboBox.Name = "roadWayComboBox";
            this.roadWayComboBox.Size = new System.Drawing.Size(213, 33);
            this.roadWayComboBox.TabIndex = 8;
            this.roadWayComboBox.SelectedIndexChanged += new System.EventHandler(this.roadWayComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADT.Properties.Resources.Flat_Folder_icon;
            this.pictureBox1.Location = new System.Drawing.Point(169, 314);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 481);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(523, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Value = 100;
            // 
            // minionBackgroundWorker
            // 
            this.minionBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.minionBackgroundWorker_DoWork);
            this.minionBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.minionBackgroundWorker_ProgressChanged);
            this.minionBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.minionBackgroundWorker_RunWorkerCompleted);
            // 
            // AADTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 516);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.roadWayComboBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.predictButton);
            this.Controls.Add(this.selectDataLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AADTForm";
            this.Text = "AADT";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AADTForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label selectDataLabel;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox roadWayComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker minionBackgroundWorker;
    }
}