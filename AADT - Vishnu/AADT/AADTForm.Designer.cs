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
            this.nameLabel = new System.Windows.Forms.Label();
            this.selectDataLabel = new System.Windows.Forms.Label();
            this.dataSelectUpDown = new System.Windows.Forms.NumericUpDown();
            this.predictButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(289, 47);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(92, 33);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "AADT";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // selectDataLabel
            // 
            this.selectDataLabel.AutoSize = true;
            this.selectDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDataLabel.Location = new System.Drawing.Point(61, 120);
            this.selectDataLabel.Name = "selectDataLabel";
            this.selectDataLabel.Size = new System.Drawing.Size(144, 29);
            this.selectDataLabel.TabIndex = 1;
            this.selectDataLabel.Text = "Select Data";
            // 
            // dataSelectUpDown
            // 
            this.dataSelectUpDown.AllowDrop = true;
            this.dataSelectUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSelectUpDown.Location = new System.Drawing.Point(359, 120);
            this.dataSelectUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.dataSelectUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dataSelectUpDown.Name = "dataSelectUpDown";
            this.dataSelectUpDown.Size = new System.Drawing.Size(120, 36);
            this.dataSelectUpDown.TabIndex = 2;
            this.dataSelectUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // predictButton
            // 
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictButton.Location = new System.Drawing.Point(258, 344);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(140, 50);
            this.predictButton.TabIndex = 5;
            this.predictButton.Text = "Predict";
            this.predictButton.UseVisualStyleBackColor = true;
            this.predictButton.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.Location = new System.Drawing.Point(249, 216);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(380, 30);
            this.pathTextBox.TabIndex = 3;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(12, 215);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(193, 29);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "Path to Desktop";
            // 
            // AADTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 486);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.predictButton);
            this.Controls.Add(this.dataSelectUpDown);
            this.Controls.Add(this.selectDataLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "AADTForm";
            this.Text = "AADT";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label selectDataLabel;
        private System.Windows.Forms.NumericUpDown dataSelectUpDown;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
    }
}