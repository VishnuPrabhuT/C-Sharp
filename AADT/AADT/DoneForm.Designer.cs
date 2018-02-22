namespace AADT
{
    partial class DoneForm
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
            this.doneLabel = new System.Windows.Forms.Label();
            this.outputLocationLabel = new System.Windows.Forms.Label();
            this.outputLinkLabel = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doneLabel
            // 
            this.doneLabel.AutoSize = true;
            this.doneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneLabel.Location = new System.Drawing.Point(251, 33);
            this.doneLabel.Name = "doneLabel";
            this.doneLabel.Size = new System.Drawing.Size(150, 24);
            this.doneLabel.TabIndex = 0;
            this.doneLabel.Text = "Prediction Done!";
            // 
            // outputLocationLabel
            // 
            this.outputLocationLabel.AutoSize = true;
            this.outputLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLocationLabel.Location = new System.Drawing.Point(251, 71);
            this.outputLocationLabel.Name = "outputLocationLabel";
            this.outputLocationLabel.Size = new System.Drawing.Size(142, 24);
            this.outputLocationLabel.TabIndex = 1;
            this.outputLocationLabel.Text = "Output Location";
            // 
            // outputLinkLabel
            // 
            this.outputLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.outputLinkLabel.Location = new System.Drawing.Point(150, 109);
            this.outputLinkLabel.Name = "outputLinkLabel";
            this.outputLinkLabel.Size = new System.Drawing.Size(340, 23);
            this.outputLinkLabel.TabIndex = 4;
            this.outputLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.outputLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.outputLinkLabel_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(283, 147);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 43);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // DoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 202);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.outputLinkLabel);
            this.Controls.Add(this.outputLocationLabel);
            this.Controls.Add(this.doneLabel);
            this.Name = "DoneForm";
            this.Text = "DoneForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label doneLabel;
        private System.Windows.Forms.Label outputLocationLabel;
        private System.Windows.Forms.LinkLabel outputLinkLabel;
        private System.Windows.Forms.Button okButton;
    }
}