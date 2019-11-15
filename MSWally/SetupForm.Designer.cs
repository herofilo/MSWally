namespace MSWally
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudGraphTolerance = new System.Windows.Forms.NumericUpDown();
            this.nudGraphWallThickness = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudWallHeightMin = new System.Windows.Forms.NumericUpDown();
            this.nudWallHeightMax = new System.Windows.Forms.NumericUpDown();
            this.nudWallThicknessMax = new System.Windows.Forms.NumericUpDown();
            this.nudWallThicknessMin = new System.Windows.Forms.NumericUpDown();
            this.nudWallZOffsetMax = new System.Windows.Forms.NumericUpDown();
            this.pbSave = new System.Windows.Forms.Button();
            this.pbCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphWallThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallHeightMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallHeightMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThicknessMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThicknessMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallZOffsetMax)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudGraphWallThickness);
            this.groupBox1.Controls.Add(this.nudGraphTolerance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Graphics";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudWallZOffsetMax);
            this.groupBox2.Controls.Add(this.nudWallThicknessMax);
            this.groupBox2.Controls.Add(this.nudWallHeightMax);
            this.groupBox2.Controls.Add(this.nudWallThicknessMin);
            this.groupBox2.Controls.Add(this.nudWallHeightMin);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wall Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wall Selection Tolerance (px):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wall Thickness (px):";
            // 
            // nudGraphTolerance
            // 
            this.nudGraphTolerance.Location = new System.Drawing.Point(170, 26);
            this.nudGraphTolerance.Name = "nudGraphTolerance";
            this.nudGraphTolerance.Size = new System.Drawing.Size(53, 20);
            this.nudGraphTolerance.TabIndex = 2;
            this.nudGraphTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudGraphWallThickness
            // 
            this.nudGraphWallThickness.Location = new System.Drawing.Point(170, 58);
            this.nudGraphWallThickness.Name = "nudGraphWallThickness";
            this.nudGraphWallThickness.Size = new System.Drawing.Size(53, 20);
            this.nudGraphWallThickness.TabIndex = 3;
            this.nudGraphWallThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thickness:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Z Offset:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Minimum:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Maximum:";
            // 
            // nudWallHeightMin
            // 
            this.nudWallHeightMin.Location = new System.Drawing.Point(96, 40);
            this.nudWallHeightMin.Name = "nudWallHeightMin";
            this.nudWallHeightMin.Size = new System.Drawing.Size(53, 20);
            this.nudWallHeightMin.TabIndex = 7;
            this.nudWallHeightMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudWallHeightMax
            // 
            this.nudWallHeightMax.Location = new System.Drawing.Point(170, 40);
            this.nudWallHeightMax.Name = "nudWallHeightMax";
            this.nudWallHeightMax.Size = new System.Drawing.Size(53, 20);
            this.nudWallHeightMax.TabIndex = 8;
            this.nudWallHeightMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudWallThicknessMax
            // 
            this.nudWallThicknessMax.Location = new System.Drawing.Point(170, 72);
            this.nudWallThicknessMax.Name = "nudWallThicknessMax";
            this.nudWallThicknessMax.Size = new System.Drawing.Size(53, 20);
            this.nudWallThicknessMax.TabIndex = 10;
            this.nudWallThicknessMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudWallThicknessMin
            // 
            this.nudWallThicknessMin.Location = new System.Drawing.Point(96, 72);
            this.nudWallThicknessMin.Name = "nudWallThicknessMin";
            this.nudWallThicknessMin.Size = new System.Drawing.Size(53, 20);
            this.nudWallThicknessMin.TabIndex = 9;
            this.nudWallThicknessMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudWallZOffsetMax
            // 
            this.nudWallZOffsetMax.Location = new System.Drawing.Point(170, 106);
            this.nudWallZOffsetMax.Name = "nudWallZOffsetMax";
            this.nudWallZOffsetMax.Size = new System.Drawing.Size(53, 20);
            this.nudWallZOffsetMax.TabIndex = 12;
            this.nudWallZOffsetMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pbSave
            // 
            this.pbSave.Location = new System.Drawing.Point(283, 30);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(75, 23);
            this.pbSave.TabIndex = 2;
            this.pbSave.Text = "Save";
            this.pbSave.UseVisualStyleBackColor = true;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pbCancel.Location = new System.Drawing.Point(283, 67);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(75, 23);
            this.pbCancel.TabIndex = 3;
            this.pbCancel.Text = "Cancel";
            this.pbCancel.UseVisualStyleBackColor = true;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // SetupForm
            // 
            this.AcceptButton = this.pbSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.pbCancel;
            this.ClientSize = new System.Drawing.Size(370, 280);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphWallThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallHeightMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallHeightMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThicknessMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThicknessMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallZOffsetMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudGraphWallThickness;
        private System.Windows.Forms.NumericUpDown nudGraphTolerance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudWallZOffsetMax;
        private System.Windows.Forms.NumericUpDown nudWallThicknessMax;
        private System.Windows.Forms.NumericUpDown nudWallHeightMax;
        private System.Windows.Forms.NumericUpDown nudWallThicknessMin;
        private System.Windows.Forms.NumericUpDown nudWallHeightMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button pbSave;
        private System.Windows.Forms.Button pbCancel;
    }
}