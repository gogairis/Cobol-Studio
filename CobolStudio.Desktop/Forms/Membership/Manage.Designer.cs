using System.Drawing;

namespace CobolStudio.Desktop.Forms.Membership
{
    partial class Manage
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
            this.Header = new System.Windows.Forms.TextBox();
            this.PrintReport = new System.Drawing.Printing.PrintDocument();
            this.CodeGenerate = new System.Windows.Forms.TabPage();
            this.btnCodeGenrate = new System.Windows.Forms.Button();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.btnDeleteOutputFile = new System.Windows.Forms.Button();
            this.btnDeleteInputFile = new System.Windows.Forms.Button();
            this.btnAddOutputFile = new System.Windows.Forms.Button();
            this.lblOutputFiles = new System.Windows.Forms.Label();
            this.btnAddInputFile = new System.Windows.Forms.Button();
            this.lblInputFiles = new System.Windows.Forms.Label();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNameRequired = new System.Windows.Forms.Label();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            this.CodeGenerate.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.Control;
            this.Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Enabled = false;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DimGray;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1050, 31);
            this.Header.TabIndex = 0;
            this.Header.Text = "Cobol Studio";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CodeGenerate
            // 
            this.CodeGenerate.Controls.Add(this.btnCodeGenrate);
            this.CodeGenerate.Location = new System.Drawing.Point(4, 24);
            this.CodeGenerate.Name = "CodeGenerate";
            this.CodeGenerate.Size = new System.Drawing.Size(1027, 466);
            this.CodeGenerate.TabIndex = 3;
            this.CodeGenerate.Text = "Genrate Code";
            this.CodeGenerate.UseVisualStyleBackColor = true;
            // 
            // btnCodeGenrate
            // 
            this.btnCodeGenrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodeGenrate.Location = new System.Drawing.Point(770, 314);
            this.btnCodeGenrate.Name = "btnCodeGenrate";
            this.btnCodeGenrate.Size = new System.Drawing.Size(132, 36);
            this.btnCodeGenrate.TabIndex = 0;
            this.btnCodeGenrate.Text = "Generate Code";
            this.btnCodeGenrate.UseVisualStyleBackColor = true;
            this.btnCodeGenrate.Click += new System.EventHandler(this.CodeGenrate_Click);
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.btnDeleteOutputFile);
            this.tabFiles.Controls.Add(this.btnDeleteInputFile);
            this.tabFiles.Controls.Add(this.btnAddOutputFile);
            this.tabFiles.Controls.Add(this.lblOutputFiles);
            this.tabFiles.Controls.Add(this.btnAddInputFile);
            this.tabFiles.Controls.Add(this.lblInputFiles);
            this.tabFiles.Controls.Add(this.btnNext2);
            this.tabFiles.Location = new System.Drawing.Point(4, 24);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(1027, 466);
            this.tabFiles.TabIndex = 2;
            this.tabFiles.Text = "File Details";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOutputFile
            // 
            this.btnDeleteOutputFile.Image = global::CobolStudio.Desktop.Properties.Resources.negative_sign2;
            this.btnDeleteOutputFile.Location = new System.Drawing.Point(812, 29);
            this.btnDeleteOutputFile.Name = "btnDeleteOutputFile";
            this.btnDeleteOutputFile.Size = new System.Drawing.Size(42, 39);
            this.btnDeleteOutputFile.TabIndex = 8;
            this.btnDeleteOutputFile.UseVisualStyleBackColor = true;
            this.btnDeleteOutputFile.Click += new System.EventHandler(this.btnDeleteOutputFile_Click);
            // 
            // btnDeleteInputFile
            // 
            this.btnDeleteInputFile.Image = global::CobolStudio.Desktop.Properties.Resources.negative_sign2;
            this.btnDeleteInputFile.Location = new System.Drawing.Point(279, 29);
            this.btnDeleteInputFile.Name = "btnDeleteInputFile";
            this.btnDeleteInputFile.Size = new System.Drawing.Size(42, 39);
            this.btnDeleteInputFile.TabIndex = 7;
            this.btnDeleteInputFile.UseVisualStyleBackColor = true;
            this.btnDeleteInputFile.Click += new System.EventHandler(this.btnDeleteInputFile_Click);
            // 
            // btnAddOutputFile
            // 
            this.btnAddOutputFile.Image = global::CobolStudio.Desktop.Properties.Resources.Plus_sign2;
            this.btnAddOutputFile.Location = new System.Drawing.Point(729, 29);
            this.btnAddOutputFile.Name = "btnAddOutputFile";
            this.btnAddOutputFile.Size = new System.Drawing.Size(42, 39);
            this.btnAddOutputFile.TabIndex = 6;
            this.btnAddOutputFile.UseVisualStyleBackColor = true;
            this.btnAddOutputFile.Click += new System.EventHandler(this.btnAddOutputFile_Click);
            // 
            // lblOutputFiles
            // 
            this.lblOutputFiles.AutoSize = true;
            this.lblOutputFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputFiles.Location = new System.Drawing.Point(580, 35);
            this.lblOutputFiles.Name = "lblOutputFiles";
            this.lblOutputFiles.Size = new System.Drawing.Size(123, 24);
            this.lblOutputFiles.TabIndex = 5;
            this.lblOutputFiles.Text = "Output Files";
            // 
            // btnAddInputFile
            // 
            this.btnAddInputFile.Image = global::CobolStudio.Desktop.Properties.Resources.Plus_sign2;
            this.btnAddInputFile.Location = new System.Drawing.Point(202, 29);
            this.btnAddInputFile.Name = "btnAddInputFile";
            this.btnAddInputFile.Size = new System.Drawing.Size(42, 39);
            this.btnAddInputFile.TabIndex = 4;
            this.btnAddInputFile.UseVisualStyleBackColor = true;
            this.btnAddInputFile.Click += new System.EventHandler(this.btnAddInputFile_Click);
            // 
            // lblInputFiles
            // 
            this.lblInputFiles.AutoSize = true;
            this.lblInputFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputFiles.Location = new System.Drawing.Point(50, 35);
            this.lblInputFiles.Name = "lblInputFiles";
            this.lblInputFiles.Size = new System.Drawing.Size(107, 24);
            this.lblInputFiles.TabIndex = 2;
            this.lblInputFiles.Text = "Input Files";
            // 
            // btnNext2
            // 
            this.btnNext2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext2.Location = new System.Drawing.Point(905, 392);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(92, 30);
            this.btnNext2.TabIndex = 1;
            this.btnNext2.Text = "Next";
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.GoToNextSection_Click);
            // 
            // tabBasic
            // 
            this.tabBasic.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabBasic.Controls.Add(this.tabControl2);
            this.tabBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBasic.Location = new System.Drawing.Point(4, 24);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(1027, 466);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic Details";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabRegister);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(8, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(642, 260);
            this.tabControl2.TabIndex = 5;
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.txtDescription);
            this.tabRegister.Controls.Add(this.label6);
            this.tabRegister.Controls.Add(this.lblNameRequired);
            this.tabRegister.Controls.Add(this.btnNext1);
            this.tabRegister.Controls.Add(this.txtName);
            this.tabRegister.Controls.Add(this.lblName);
            this.tabRegister.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRegister.Location = new System.Drawing.Point(4, 25);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(634, 231);
            this.tabRegister.TabIndex = 0;
            this.tabRegister.Text = "Member";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(111, 71);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(190, 37);
            this.txtDescription.TabIndex = 24;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Description";
            // 
            // lblNameRequired
            // 
            this.lblNameRequired.AutoSize = true;
            this.lblNameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameRequired.ForeColor = System.Drawing.Color.Red;
            this.lblNameRequired.Location = new System.Drawing.Point(53, 17);
            this.lblNameRequired.Name = "lblNameRequired";
            this.lblNameRequired.Size = new System.Drawing.Size(21, 25);
            this.lblNameRequired.TabIndex = 18;
            this.lblNameRequired.Text = "*";
            // 
            // btnNext1
            // 
            this.btnNext1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext1.Location = new System.Drawing.Point(481, 179);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(115, 28);
            this.btnNext1.TabIndex = 9;
            this.btnNext1.Text = "Next";
            this.btnNext1.UseVisualStyleBackColor = true;
            this.btnNext1.Click += new System.EventHandler(this.GoToFilesSection_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(111, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 21);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabBasic);
            this.tab.Controls.Add(this.tabFiles);
            this.tab.Controls.Add(this.CodeGenerate);
            this.tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(6, 35);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1035, 494);
            this.tab.TabIndex = 0;
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1050, 537);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.tab);
            this.IsMdiContainer = true;
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobol Studio - Template Generator";
            this.CodeGenerate.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.tabFiles.PerformLayout();
            this.tabBasic.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Header;
        private System.Drawing.Printing.PrintDocument PrintReport;
        private System.Windows.Forms.TextBox[] inputFileArray;
        private System.Windows.Forms.TextBox[] inputFileDescArray;
        private System.Windows.Forms.TextBox[] outputFileArray;
        private System.Windows.Forms.TextBox[] outputFileDescArray;
        private System.Windows.Forms.TabPage CodeGenerate;
        private System.Windows.Forms.Button btnCodeGenrate;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.Button btnDeleteOutputFile;
        private System.Windows.Forms.Button btnDeleteInputFile;
        private System.Windows.Forms.Button btnAddOutputFile;
        private System.Windows.Forms.Label lblOutputFiles;
        private System.Windows.Forms.Button btnAddInputFile;
        private System.Windows.Forms.Label lblInputFiles;
        private System.Windows.Forms.Button btnNext2;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNameRequired;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tab;
        
    }
}