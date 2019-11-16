namespace MSWally
{
    partial class WallAlterForm
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
            this.lblText = new System.Windows.Forms.Label();
            this.nudIncrement = new System.Windows.Forms.NumericUpDown();
            this.pbUpdate = new System.Windows.Forms.Button();
            this.pbCancel = new System.Windows.Forms.Button();
            this.tbWarning = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrement)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 30);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(35, 13);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label1";
            // 
            // nudIncrement
            // 
            this.nudIncrement.DecimalPlaces = 1;
            this.nudIncrement.Location = new System.Drawing.Point(207, 28);
            this.nudIncrement.Name = "nudIncrement";
            this.nudIncrement.Size = new System.Drawing.Size(62, 20);
            this.nudIncrement.TabIndex = 1;
            this.nudIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pbUpdate
            // 
            this.pbUpdate.Location = new System.Drawing.Point(119, 109);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(75, 23);
            this.pbUpdate.TabIndex = 2;
            this.pbUpdate.Text = "Update";
            this.pbUpdate.UseVisualStyleBackColor = true;
            this.pbUpdate.Click += new System.EventHandler(this.pbUpdate_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pbCancel.Location = new System.Drawing.Point(200, 109);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(75, 23);
            this.pbCancel.TabIndex = 3;
            this.pbCancel.Text = "Cancel";
            this.pbCancel.UseVisualStyleBackColor = true;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // tbWarning
            // 
            this.tbWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWarning.ForeColor = System.Drawing.Color.Red;
            this.tbWarning.Location = new System.Drawing.Point(21, 54);
            this.tbWarning.Multiline = true;
            this.tbWarning.Name = "tbWarning";
            this.tbWarning.ReadOnly = true;
            this.tbWarning.Size = new System.Drawing.Size(248, 49);
            this.tbWarning.TabIndex = 23;
            this.tbWarning.Text = "PLEASE NOTE that the ceiling height is set globally on a scene set basis, and it " +
    "should be set accordingly with wall height in the set";
            this.tbWarning.Visible = false;
            // 
            // WallAlterForm
            // 
            this.AcceptButton = this.pbUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.pbCancel;
            this.ClientSize = new System.Drawing.Size(283, 140);
            this.Controls.Add(this.tbWarning);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbUpdate);
            this.Controls.Add(this.nudIncrement);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WallAlterForm";
            this.Text = "WallAlterForm";
            this.Load += new System.EventHandler(this.WallAlterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.NumericUpDown nudIncrement;
        private System.Windows.Forms.Button pbUpdate;
        private System.Windows.Forms.Button pbCancel;
        private System.Windows.Forms.TextBox tbWarning;
    }
}