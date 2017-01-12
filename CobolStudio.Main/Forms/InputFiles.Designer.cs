namespace CobolStudio.Main.Forms
{
    partial class InputFiles
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
            this.lblInputFile = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.txtInputFileDesc = new System.Windows.Forms.TextBox();
            this.lblInputFileDesc = new System.Windows.Forms.Label();
            this.lblInputFileType = new System.Windows.Forms.Label();
            this.comboInputFileType = new System.Windows.Forms.ComboBox();
            this.lblInputFileLayout = new System.Windows.Forms.Label();
            this.btnManualInputLayout = new System.Windows.Forms.Button();
            this.lblCopybook = new System.Windows.Forms.Label();
            this.comboCopybooks = new System.Windows.Forms.ComboBox();
            this.btnAddCopybook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileLayout = new System.Windows.Forms.TextBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(16, 29);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(81, 13);
            this.lblInputFile.TabIndex = 0;
            this.lblInputFile.Text = "Input File Name";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(171, 26);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(122, 20);
            this.txtInputFile.TabIndex = 1;
            this.txtInputFile.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            // 
            // txtInputFileDesc
            // 
            this.txtInputFileDesc.Location = new System.Drawing.Point(171, 69);
            this.txtInputFileDesc.Multiline = true;
            this.txtInputFileDesc.Name = "txtInputFileDesc";
            this.txtInputFileDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputFileDesc.Size = new System.Drawing.Size(201, 84);
            this.txtInputFileDesc.TabIndex = 3;
            this.txtInputFileDesc.WordWrap = false;
            // 
            // lblInputFileDesc
            // 
            this.lblInputFileDesc.AutoSize = true;
            this.lblInputFileDesc.Location = new System.Drawing.Point(16, 72);
            this.lblInputFileDesc.Name = "lblInputFileDesc";
            this.lblInputFileDesc.Size = new System.Drawing.Size(106, 13);
            this.lblInputFileDesc.TabIndex = 2;
            this.lblInputFileDesc.Text = "Input File Description";
            // 
            // lblInputFileType
            // 
            this.lblInputFileType.AutoSize = true;
            this.lblInputFileType.Location = new System.Drawing.Point(432, 26);
            this.lblInputFileType.Name = "lblInputFileType";
            this.lblInputFileType.Size = new System.Drawing.Size(77, 13);
            this.lblInputFileType.TabIndex = 4;
            this.lblInputFileType.Text = "Input File Type";
            // 
            // comboInputFileType
            // 
            this.comboInputFileType.FormattingEnabled = true;
            this.comboInputFileType.Items.AddRange(new object[] {
            "Sequential",
            "Indexed"});
            this.comboInputFileType.Location = new System.Drawing.Point(565, 23);
            this.comboInputFileType.Name = "comboInputFileType";
            this.comboInputFileType.Size = new System.Drawing.Size(121, 21);
            this.comboInputFileType.TabIndex = 5;
            this.comboInputFileType.Text = "Sequential";
            // 
            // lblInputFileLayout
            // 
            this.lblInputFileLayout.AutoSize = true;
            this.lblInputFileLayout.Location = new System.Drawing.Point(16, 182);
            this.lblInputFileLayout.Name = "lblInputFileLayout";
            this.lblInputFileLayout.Size = new System.Drawing.Size(85, 13);
            this.lblInputFileLayout.TabIndex = 6;
            this.lblInputFileLayout.Text = "Input File Layout";
            // 
            // btnManualInputLayout
            // 
            this.btnManualInputLayout.Location = new System.Drawing.Point(162, 265);
            this.btnManualInputLayout.Name = "btnManualInputLayout";
            this.btnManualInputLayout.Size = new System.Drawing.Size(88, 23);
            this.btnManualInputLayout.TabIndex = 8;
            this.btnManualInputLayout.Text = "User Defined Layout";
            this.btnManualInputLayout.UseVisualStyleBackColor = true;
            this.btnManualInputLayout.Click += new System.EventHandler(this.btnManualInputLayout_Click);
            // 
            // lblCopybook
            // 
            this.lblCopybook.AutoSize = true;
            this.lblCopybook.Location = new System.Drawing.Point(160, 179);
            this.lblCopybook.Name = "lblCopybook";
            this.lblCopybook.Size = new System.Drawing.Size(245, 13);
            this.lblCopybook.TabIndex = 9;
            this.lblCopybook.Text = "Select Copybook if any and click \"Add Copybook\"";
            // 
            // comboCopybooks
            // 
            this.comboCopybooks.FormattingEnabled = true;
            this.comboCopybooks.Items.AddRange(new object[] {
            "W000",
            "W2168",
            "W2170",
            "W332",
            "W999"});
            this.comboCopybooks.Location = new System.Drawing.Point(168, 197);
            this.comboCopybooks.Name = "comboCopybooks";
            this.comboCopybooks.Size = new System.Drawing.Size(121, 21);
            this.comboCopybooks.TabIndex = 10;
            // 
            // btnAddCopybook
            // 
            this.btnAddCopybook.Location = new System.Drawing.Point(309, 195);
            this.btnAddCopybook.Name = "btnAddCopybook";
            this.btnAddCopybook.Size = new System.Drawing.Size(88, 23);
            this.btnAddCopybook.TabIndex = 11;
            this.btnAddCopybook.Text = "Add Copybook";
            this.btnAddCopybook.UseVisualStyleBackColor = true;
            this.btnAddCopybook.Click += new System.EventHandler(this.btnAddCopybook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Click below button if user defined layout is required";
            // 
            // txtFileLayout
            // 
            this.txtFileLayout.Enabled = false;
            this.txtFileLayout.Location = new System.Drawing.Point(435, 69);
            this.txtFileLayout.Multiline = true;
            this.txtFileLayout.Name = "txtFileLayout";
            this.txtFileLayout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileLayout.Size = new System.Drawing.Size(251, 249);
            this.txtFileLayout.TabIndex = 13;
            this.txtFileLayout.WordWrap = false;
            // 
            // btnAddFile
            // 
            this.btnAddFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddFile.Location = new System.Drawing.Point(598, 347);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(88, 23);
            this.btnAddFile.TabIndex = 14;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            // 
            // InputFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 382);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.txtFileLayout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCopybook);
            this.Controls.Add(this.comboCopybooks);
            this.Controls.Add(this.lblCopybook);
            this.Controls.Add(this.btnManualInputLayout);
            this.Controls.Add(this.lblInputFileLayout);
            this.Controls.Add(this.comboInputFileType);
            this.Controls.Add(this.lblInputFileType);
            this.Controls.Add(this.txtInputFileDesc);
            this.Controls.Add(this.lblInputFileDesc);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.lblInputFile);
            this.Name = "InputFiles";
            this.Text = "InputFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.TextBox txtInputFileDesc;
        private System.Windows.Forms.Label lblInputFileDesc;
        private System.Windows.Forms.Label lblInputFileType;
        private System.Windows.Forms.ComboBox comboInputFileType;
        private System.Windows.Forms.Label lblInputFileLayout;
        private System.Windows.Forms.Button btnManualInputLayout;
        private System.Windows.Forms.Label lblCopybook;
        private System.Windows.Forms.ComboBox comboCopybooks;
        private System.Windows.Forms.Button btnAddCopybook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileLayout;
        private System.Windows.Forms.Button btnAddFile;
    }
}