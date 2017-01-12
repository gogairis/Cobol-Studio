namespace CobolStudio.Main.Forms
{
    partial class InputFile
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
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.lblInputFileDescription = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblInputFileLayout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(169, 36);
            this.txtInputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(229, 26);
            this.txtInputFile.TabIndex = 0;
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(21, 40);
            this.lblInputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(107, 18);
            this.lblInputFile.TabIndex = 1;
            this.lblInputFile.Text = "Input File Name";
            // 
            // lblInputFileDescription
            // 
            this.lblInputFileDescription.AutoSize = true;
            this.lblInputFileDescription.Location = new System.Drawing.Point(21, 102);
            this.lblInputFileDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputFileDescription.Name = "lblInputFileDescription";
            this.lblInputFileDescription.Size = new System.Drawing.Size(140, 18);
            this.lblInputFileDescription.TabIndex = 2;
            this.lblInputFileDescription.Text = "Input File Description";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 93);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(229, 90);
            this.textBox1.TabIndex = 3;
            this.textBox1.WordWrap = false;
            // 
            // lblInputFileLayout
            // 
            this.lblInputFileLayout.AutoSize = true;
            this.lblInputFileLayout.Location = new System.Drawing.Point(27, 229);
            this.lblInputFileLayout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputFileLayout.Name = "lblInputFileLayout";
            this.lblInputFileLayout.Size = new System.Drawing.Size(116, 18);
            this.lblInputFileLayout.TabIndex = 4;
            this.lblInputFileLayout.Text = "Select File Layout";
            // 
            // InputFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 292);
            this.Controls.Add(this.lblInputFileLayout);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblInputFileDescription);
            this.Controls.Add(this.lblInputFile);
            this.Controls.Add(this.txtInputFile);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InputFile";
            this.Text = "InputFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.Label lblInputFileDescription;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblInputFileLayout;
    }
}