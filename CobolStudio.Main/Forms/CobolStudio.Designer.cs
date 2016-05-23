namespace CobolStudio.Main.Forms
{
    partial class CobolStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CobolStudio));
            this.Header = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabCodeGenerate = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblProgName = new System.Windows.Forms.Label();
            this.grpProgDetails = new System.Windows.Forms.GroupBox();
            this.comboRestart = new System.Windows.Forms.ComboBox();
            this.radioNonRestart = new System.Windows.Forms.RadioButton();
            this.radioRestart = new System.Windows.Forms.RadioButton();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.grpProgDesc = new System.Windows.Forms.GroupBox();
            this.tabInputFiles = new System.Windows.Forms.TabPage();
            this.btnDeleteInputFile = new System.Windows.Forms.Button();
            this.btnModifyInputFile = new System.Windows.Forms.Button();
            this.comboAccessType = new System.Windows.Forms.ComboBox();
            this.radioBtnSeq = new System.Windows.Forms.RadioButton();
            this.radioBtnInd = new System.Windows.Forms.RadioButton();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtFileLayout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddCopybook = new System.Windows.Forms.Button();
            this.comboCopybooks = new System.Windows.Forms.ComboBox();
            this.lblCopybook = new System.Windows.Forms.Label();
            this.btnManualInputLayout = new System.Windows.Forms.Button();
            this.lblInputFileLayout = new System.Windows.Forms.Label();
            this.txtInputFileDesc = new System.Windows.Forms.TextBox();
            this.lblInputFileDesc = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.grpInputFiles = new System.Windows.Forms.GroupBox();
            this.gridViewInputFiles = new System.Windows.Forms.DataGridView();
            this.tabDBRecords = new System.Windows.Forms.TabPage();
            this.grpDBRecords = new System.Windows.Forms.GroupBox();
            this.btnDeleteDBRecord = new System.Windows.Forms.Button();
            this.btnAddDBRecord = new System.Windows.Forms.Button();
            this.tabCopyCodes = new System.Windows.Forms.TabPage();
            this.tabInitialProcessing = new System.Windows.Forms.TabPage();
            this.tabMainProcessing = new System.Windows.Forms.TabPage();
            this.tabEndProcessing = new System.Windows.Forms.TabPage();
            this.tabCodeGeneration = new System.Windows.Forms.TabPage();
            this.btnCodeGenerate = new System.Windows.Forms.Button();
            this.tabOutputFiles = new System.Windows.Forms.TabPage();
            this.grpOutputFiles = new System.Windows.Forms.GroupBox();
            this.btnAddOutputFile = new System.Windows.Forms.Button();
            this.btnDeleteOutputFile = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabCodeGenerate.SuspendLayout();
            this.grpProgDetails.SuspendLayout();
            this.grpProgDesc.SuspendLayout();
            this.tabInputFiles.SuspendLayout();
            this.grpInputFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputFiles)).BeginInit();
            this.tabDBRecords.SuspendLayout();
            this.grpDBRecords.SuspendLayout();
            this.tabCodeGeneration.SuspendLayout();
            this.tabOutputFiles.SuspendLayout();
            this.grpOutputFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Header.BackColor = System.Drawing.SystemColors.Control;
            this.Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Header.Enabled = false;
            this.Header.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DimGray;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1362, 33);
            this.Header.TabIndex = 1;
            this.Header.Text = "Cobol Studio";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(18, 29);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(950, 159);
            this.txtDescription.TabIndex = 29;
            this.txtDescription.WordWrap = false;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(200, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 27);
            this.txtName.TabIndex = 26;
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabCodeGenerate);
            this.tab.Controls.Add(this.tabInputFiles);
            this.tab.Controls.Add(this.tabDBRecords);
            this.tab.Controls.Add(this.tabCopyCodes);
            this.tab.Controls.Add(this.tabInitialProcessing);
            this.tab.Controls.Add(this.tabMainProcessing);
            this.tab.Controls.Add(this.tabEndProcessing);
            this.tab.Controls.Add(this.tabCodeGeneration);
            this.tab.Controls.Add(this.tabOutputFiles);
            this.tab.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(0, 32);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1369, 698);
            this.tab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tab.TabIndex = 3;
            // 
            // tabCodeGenerate
            // 
            this.tabCodeGenerate.Controls.Add(this.label1);
            this.tabCodeGenerate.Controls.Add(this.button1);
            this.tabCodeGenerate.Controls.Add(this.lblProgName);
            this.tabCodeGenerate.Controls.Add(this.grpProgDetails);
            this.tabCodeGenerate.Controls.Add(this.grpProgDesc);
            this.tabCodeGenerate.Location = new System.Drawing.Point(4, 28);
            this.tabCodeGenerate.Name = "tabCodeGenerate";
            this.tabCodeGenerate.Size = new System.Drawing.Size(1361, 666);
            this.tabCodeGenerate.TabIndex = 3;
            this.tabCodeGenerate.Text = "Basic Details";
            this.tabCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Version Number";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(939, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 29);
            this.button1.TabIndex = 27;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblProgName
            // 
            this.lblProgName.AutoSize = true;
            this.lblProgName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgName.Location = new System.Drawing.Point(28, 53);
            this.lblProgName.Name = "lblProgName";
            this.lblProgName.Size = new System.Drawing.Size(105, 19);
            this.lblProgName.TabIndex = 25;
            this.lblProgName.Text = "Program Name";
            // 
            // grpProgDetails
            // 
            this.grpProgDetails.Controls.Add(this.comboRestart);
            this.grpProgDetails.Controls.Add(this.radioNonRestart);
            this.grpProgDetails.Controls.Add(this.radioRestart);
            this.grpProgDetails.Controls.Add(this.lblAuthor);
            this.grpProgDetails.Controls.Add(this.txtAuthor);
            this.grpProgDetails.Controls.Add(this.txtName);
            this.grpProgDetails.Controls.Add(this.txtVersion);
            this.grpProgDetails.Location = new System.Drawing.Point(26, 14);
            this.grpProgDetails.Name = "grpProgDetails";
            this.grpProgDetails.Size = new System.Drawing.Size(982, 151);
            this.grpProgDetails.TabIndex = 34;
            this.grpProgDetails.TabStop = false;
            this.grpProgDetails.Text = "Program Details";
            // 
            // comboRestart
            // 
            this.comboRestart.FormattingEnabled = true;
            this.comboRestart.Items.AddRange(new object[] {
            "Database",
            "File"});
            this.comboRestart.Location = new System.Drawing.Point(814, 26);
            this.comboRestart.Name = "comboRestart";
            this.comboRestart.Size = new System.Drawing.Size(90, 27);
            this.comboRestart.TabIndex = 38;
            this.comboRestart.Visible = false;
            // 
            // radioNonRestart
            // 
            this.radioNonRestart.AutoSize = true;
            this.radioNonRestart.Checked = true;
            this.radioNonRestart.Location = new System.Drawing.Point(552, 26);
            this.radioNonRestart.Name = "radioNonRestart";
            this.radioNonRestart.Size = new System.Drawing.Size(93, 23);
            this.radioNonRestart.TabIndex = 37;
            this.radioNonRestart.TabStop = true;
            this.radioNonRestart.Text = "Rerunable";
            this.radioNonRestart.UseVisualStyleBackColor = true;
            this.radioNonRestart.CheckedChanged += new System.EventHandler(this.radioNonRestart_CheckedChanged);
            // 
            // radioRestart
            // 
            this.radioRestart.AutoSize = true;
            this.radioRestart.Location = new System.Drawing.Point(693, 26);
            this.radioRestart.Name = "radioRestart";
            this.radioRestart.Size = new System.Drawing.Size(102, 23);
            this.radioRestart.TabIndex = 36;
            this.radioRestart.Text = "Restartable";
            this.radioRestart.UseVisualStyleBackColor = true;
            this.radioRestart.CheckedChanged += new System.EventHandler(this.radioRestart_CheckedChanged);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(2, 109);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(94, 19);
            this.lblAuthor.TabIndex = 32;
            this.lblAuthor.Text = "Author Name";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthor.Location = new System.Drawing.Point(200, 107);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(218, 27);
            this.txtAuthor.TabIndex = 33;
            // 
            // txtVersion
            // 
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Location = new System.Drawing.Point(200, 74);
            this.txtVersion.MaxLength = 8;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(218, 27);
            this.txtVersion.TabIndex = 31;
            // 
            // grpProgDesc
            // 
            this.grpProgDesc.Controls.Add(this.txtDescription);
            this.grpProgDesc.Location = new System.Drawing.Point(26, 181);
            this.grpProgDesc.Name = "grpProgDesc";
            this.grpProgDesc.Size = new System.Drawing.Size(982, 208);
            this.grpProgDesc.TabIndex = 35;
            this.grpProgDesc.TabStop = false;
            this.grpProgDesc.Text = "Program Description";
            // 
            // tabInputFiles
            // 
            this.tabInputFiles.Controls.Add(this.btnDeleteInputFile);
            this.tabInputFiles.Controls.Add(this.btnModifyInputFile);
            this.tabInputFiles.Controls.Add(this.comboAccessType);
            this.tabInputFiles.Controls.Add(this.radioBtnSeq);
            this.tabInputFiles.Controls.Add(this.radioBtnInd);
            this.tabInputFiles.Controls.Add(this.btnAddFile);
            this.tabInputFiles.Controls.Add(this.txtFileLayout);
            this.tabInputFiles.Controls.Add(this.label2);
            this.tabInputFiles.Controls.Add(this.btnAddCopybook);
            this.tabInputFiles.Controls.Add(this.comboCopybooks);
            this.tabInputFiles.Controls.Add(this.lblCopybook);
            this.tabInputFiles.Controls.Add(this.btnManualInputLayout);
            this.tabInputFiles.Controls.Add(this.lblInputFileLayout);
            this.tabInputFiles.Controls.Add(this.txtInputFileDesc);
            this.tabInputFiles.Controls.Add(this.lblInputFileDesc);
            this.tabInputFiles.Controls.Add(this.txtInputFile);
            this.tabInputFiles.Controls.Add(this.lblInputFile);
            this.tabInputFiles.Controls.Add(this.button6);
            this.tabInputFiles.Controls.Add(this.grpInputFiles);
            this.tabInputFiles.Location = new System.Drawing.Point(4, 28);
            this.tabInputFiles.Name = "tabInputFiles";
            this.tabInputFiles.Size = new System.Drawing.Size(1361, 666);
            this.tabInputFiles.TabIndex = 4;
            this.tabInputFiles.Text = "Input File Details";
            this.tabInputFiles.UseVisualStyleBackColor = true;
            // 
            // btnDeleteInputFile
            // 
            this.btnDeleteInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteInputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteInputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeleteInputFile.Location = new System.Drawing.Point(1193, 492);
            this.btnDeleteInputFile.Name = "btnDeleteInputFile";
            this.btnDeleteInputFile.Size = new System.Drawing.Size(106, 30);
            this.btnDeleteInputFile.TabIndex = 43;
            this.btnDeleteInputFile.Text = "Delete File";
            this.btnDeleteInputFile.UseVisualStyleBackColor = true;
            this.btnDeleteInputFile.Click += new System.EventHandler(this.btnDeleteInputFile1_Click);
            // 
            // btnModifyInputFile
            // 
            this.btnModifyInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyInputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModifyInputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnModifyInputFile.Location = new System.Drawing.Point(1023, 492);
            this.btnModifyInputFile.Name = "btnModifyInputFile";
            this.btnModifyInputFile.Size = new System.Drawing.Size(106, 30);
            this.btnModifyInputFile.TabIndex = 42;
            this.btnModifyInputFile.Text = "Modify File";
            this.btnModifyInputFile.UseVisualStyleBackColor = true;
            this.btnModifyInputFile.Click += new System.EventHandler(this.btnModifyInputFile_Click);
            // 
            // comboAccessType
            // 
            this.comboAccessType.FormattingEnabled = true;
            this.comboAccessType.Items.AddRange(new object[] {
            "Dynamic",
            "Random"});
            this.comboAccessType.Location = new System.Drawing.Point(1172, 31);
            this.comboAccessType.Name = "comboAccessType";
            this.comboAccessType.Size = new System.Drawing.Size(90, 27);
            this.comboAccessType.TabIndex = 41;
            this.comboAccessType.Visible = false;
            // 
            // radioBtnSeq
            // 
            this.radioBtnSeq.AutoSize = true;
            this.radioBtnSeq.Checked = true;
            this.radioBtnSeq.Location = new System.Drawing.Point(910, 31);
            this.radioBtnSeq.Name = "radioBtnSeq";
            this.radioBtnSeq.Size = new System.Drawing.Size(95, 23);
            this.radioBtnSeq.TabIndex = 40;
            this.radioBtnSeq.TabStop = true;
            this.radioBtnSeq.Text = "Sequential";
            this.radioBtnSeq.UseVisualStyleBackColor = true;
            this.radioBtnSeq.CheckedChanged += new System.EventHandler(this.radioBtnSeq_CheckedChanged);
            // 
            // radioBtnInd
            // 
            this.radioBtnInd.AutoSize = true;
            this.radioBtnInd.Location = new System.Drawing.Point(1051, 31);
            this.radioBtnInd.Name = "radioBtnInd";
            this.radioBtnInd.Size = new System.Drawing.Size(78, 23);
            this.radioBtnInd.TabIndex = 39;
            this.radioBtnInd.Text = "Indexed";
            this.radioBtnInd.UseVisualStyleBackColor = true;
            this.radioBtnInd.Click += new System.EventHandler(this.radioBtnInd_CheckedChanged);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddFile.Location = new System.Drawing.Point(883, 492);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(88, 30);
            this.btnAddFile.TabIndex = 37;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtFileLayout
            // 
            this.txtFileLayout.Enabled = false;
            this.txtFileLayout.Location = new System.Drawing.Point(1011, 128);
            this.txtFileLayout.Multiline = true;
            this.txtFileLayout.Name = "txtFileLayout";
            this.txtFileLayout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileLayout.Size = new System.Drawing.Size(251, 249);
            this.txtFileLayout.TabIndex = 36;
            this.txtFileLayout.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "Click below button if user defined layout is required";
            // 
            // btnAddCopybook
            // 
            this.btnAddCopybook.Location = new System.Drawing.Point(699, 239);
            this.btnAddCopybook.Name = "btnAddCopybook";
            this.btnAddCopybook.Size = new System.Drawing.Size(127, 27);
            this.btnAddCopybook.TabIndex = 34;
            this.btnAddCopybook.Text = "Add Copybook";
            this.btnAddCopybook.UseVisualStyleBackColor = true;
            this.btnAddCopybook.Click += new System.EventHandler(this.btnAddCopybook_Click);
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
            this.comboCopybooks.Location = new System.Drawing.Point(544, 239);
            this.comboCopybooks.Name = "comboCopybooks";
            this.comboCopybooks.Size = new System.Drawing.Size(121, 27);
            this.comboCopybooks.TabIndex = 33;
            // 
            // lblCopybook
            // 
            this.lblCopybook.AutoSize = true;
            this.lblCopybook.Location = new System.Drawing.Point(539, 217);
            this.lblCopybook.Name = "lblCopybook";
            this.lblCopybook.Size = new System.Drawing.Size(324, 19);
            this.lblCopybook.TabIndex = 32;
            this.lblCopybook.Text = "Select Copybook if any and click \"Add Copybook\"";
            // 
            // btnManualInputLayout
            // 
            this.btnManualInputLayout.Location = new System.Drawing.Point(544, 332);
            this.btnManualInputLayout.Name = "btnManualInputLayout";
            this.btnManualInputLayout.Size = new System.Drawing.Size(166, 32);
            this.btnManualInputLayout.TabIndex = 31;
            this.btnManualInputLayout.Text = "User Defined Layout";
            this.btnManualInputLayout.UseVisualStyleBackColor = true;
            this.btnManualInputLayout.Click += new System.EventHandler(this.btnManualInputLayout_Click);
            // 
            // lblInputFileLayout
            // 
            this.lblInputFileLayout.AutoSize = true;
            this.lblInputFileLayout.Location = new System.Drawing.Point(534, 193);
            this.lblInputFileLayout.Name = "lblInputFileLayout";
            this.lblInputFileLayout.Size = new System.Drawing.Size(116, 19);
            this.lblInputFileLayout.TabIndex = 30;
            this.lblInputFileLayout.Text = "Input File Layout";
            // 
            // txtInputFileDesc
            // 
            this.txtInputFileDesc.Location = new System.Drawing.Point(544, 93);
            this.txtInputFileDesc.Multiline = true;
            this.txtInputFileDesc.Name = "txtInputFileDesc";
            this.txtInputFileDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputFileDesc.Size = new System.Drawing.Size(260, 88);
            this.txtInputFileDesc.TabIndex = 27;
            this.txtInputFileDesc.WordWrap = false;
            // 
            // lblInputFileDesc
            // 
            this.lblInputFileDesc.AutoSize = true;
            this.lblInputFileDesc.Location = new System.Drawing.Point(540, 71);
            this.lblInputFileDesc.Name = "lblInputFileDesc";
            this.lblInputFileDesc.Size = new System.Drawing.Size(147, 19);
            this.lblInputFileDesc.TabIndex = 26;
            this.lblInputFileDesc.Text = "Input File Description";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(666, 28);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(138, 27);
            this.txtInputFile.TabIndex = 25;
            this.txtInputFile.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(540, 31);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(111, 19);
            this.lblInputFile.TabIndex = 24;
            this.lblInputFile.Text = "Input File Name";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button6.Location = new System.Drawing.Point(1193, 588);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 30);
            this.button6.TabIndex = 16;
            this.button6.Text = "Next";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // grpInputFiles
            // 
            this.grpInputFiles.Controls.Add(this.gridViewInputFiles);
            this.grpInputFiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInputFiles.Location = new System.Drawing.Point(8, 18);
            this.grpInputFiles.Name = "grpInputFiles";
            this.grpInputFiles.Size = new System.Drawing.Size(520, 532);
            this.grpInputFiles.TabIndex = 23;
            this.grpInputFiles.TabStop = false;
            this.grpInputFiles.Text = "Input Files";
            // 
            // gridViewInputFiles
            // 
            this.gridViewInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewInputFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewInputFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridViewInputFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewInputFiles.Location = new System.Drawing.Point(6, 75);
            this.gridViewInputFiles.Name = "gridViewInputFiles";
            this.gridViewInputFiles.ReadOnly = true;
            this.gridViewInputFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewInputFiles.Size = new System.Drawing.Size(503, 399);
            this.gridViewInputFiles.TabIndex = 24;
            this.gridViewInputFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewInputFiles_CellClick);
            // 
            // tabDBRecords
            // 
            this.tabDBRecords.Controls.Add(this.grpDBRecords);
            this.tabDBRecords.Location = new System.Drawing.Point(4, 28);
            this.tabDBRecords.Name = "tabDBRecords";
            this.tabDBRecords.Size = new System.Drawing.Size(1361, 666);
            this.tabDBRecords.TabIndex = 5;
            this.tabDBRecords.Text = "Database Records";
            this.tabDBRecords.UseVisualStyleBackColor = true;
            // 
            // grpDBRecords
            // 
            this.grpDBRecords.Controls.Add(this.btnDeleteDBRecord);
            this.grpDBRecords.Controls.Add(this.btnAddDBRecord);
            this.grpDBRecords.Location = new System.Drawing.Point(61, 39);
            this.grpDBRecords.Name = "grpDBRecords";
            this.grpDBRecords.Size = new System.Drawing.Size(624, 386);
            this.grpDBRecords.TabIndex = 0;
            this.grpDBRecords.TabStop = false;
            this.grpDBRecords.Text = "Database Records";
            // 
            // btnDeleteDBRecord
            // 
            this.btnDeleteDBRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDBRecord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteDBRecord.BackgroundImage")));
            this.btnDeleteDBRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteDBRecord.Location = new System.Drawing.Point(565, 14);
            this.btnDeleteDBRecord.Name = "btnDeleteDBRecord";
            this.btnDeleteDBRecord.Size = new System.Drawing.Size(53, 51);
            this.btnDeleteDBRecord.TabIndex = 24;
            this.btnDeleteDBRecord.UseVisualStyleBackColor = true;
            this.btnDeleteDBRecord.Click += new System.EventHandler(this.btnDeleteDBRecord_Click);
            // 
            // btnAddDBRecord
            // 
            this.btnAddDBRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDBRecord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDBRecord.BackgroundImage")));
            this.btnAddDBRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDBRecord.Location = new System.Drawing.Point(506, 14);
            this.btnAddDBRecord.Name = "btnAddDBRecord";
            this.btnAddDBRecord.Size = new System.Drawing.Size(54, 51);
            this.btnAddDBRecord.TabIndex = 23;
            this.btnAddDBRecord.UseVisualStyleBackColor = true;
            this.btnAddDBRecord.Click += new System.EventHandler(this.btnAddDBRecord_Click);
            // 
            // tabCopyCodes
            // 
            this.tabCopyCodes.Location = new System.Drawing.Point(4, 28);
            this.tabCopyCodes.Name = "tabCopyCodes";
            this.tabCopyCodes.Size = new System.Drawing.Size(1361, 666);
            this.tabCopyCodes.TabIndex = 6;
            this.tabCopyCodes.Text = "Copy Codes";
            this.tabCopyCodes.UseVisualStyleBackColor = true;
            // 
            // tabInitialProcessing
            // 
            this.tabInitialProcessing.Location = new System.Drawing.Point(4, 28);
            this.tabInitialProcessing.Name = "tabInitialProcessing";
            this.tabInitialProcessing.Size = new System.Drawing.Size(1361, 666);
            this.tabInitialProcessing.TabIndex = 7;
            this.tabInitialProcessing.Text = "Initial Processing";
            this.tabInitialProcessing.UseVisualStyleBackColor = true;
            // 
            // tabMainProcessing
            // 
            this.tabMainProcessing.Location = new System.Drawing.Point(4, 28);
            this.tabMainProcessing.Name = "tabMainProcessing";
            this.tabMainProcessing.Size = new System.Drawing.Size(1361, 666);
            this.tabMainProcessing.TabIndex = 8;
            this.tabMainProcessing.Text = "Main Processing";
            this.tabMainProcessing.UseVisualStyleBackColor = true;
            // 
            // tabEndProcessing
            // 
            this.tabEndProcessing.Location = new System.Drawing.Point(4, 28);
            this.tabEndProcessing.Name = "tabEndProcessing";
            this.tabEndProcessing.Size = new System.Drawing.Size(1361, 666);
            this.tabEndProcessing.TabIndex = 9;
            this.tabEndProcessing.Text = "End Processing";
            this.tabEndProcessing.UseVisualStyleBackColor = true;
            // 
            // tabCodeGeneration
            // 
            this.tabCodeGeneration.Controls.Add(this.btnCodeGenerate);
            this.tabCodeGeneration.Location = new System.Drawing.Point(4, 28);
            this.tabCodeGeneration.Name = "tabCodeGeneration";
            this.tabCodeGeneration.Size = new System.Drawing.Size(1361, 666);
            this.tabCodeGeneration.TabIndex = 10;
            this.tabCodeGeneration.Text = "Code Generation";
            this.tabCodeGeneration.UseVisualStyleBackColor = true;
            // 
            // btnCodeGenerate
            // 
            this.btnCodeGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodeGenerate.Location = new System.Drawing.Point(843, 397);
            this.btnCodeGenerate.Name = "btnCodeGenerate";
            this.btnCodeGenerate.Size = new System.Drawing.Size(133, 30);
            this.btnCodeGenerate.TabIndex = 17;
            this.btnCodeGenerate.Text = "Generate Code";
            this.btnCodeGenerate.UseVisualStyleBackColor = true;
            this.btnCodeGenerate.Click += new System.EventHandler(this.btnCodeGenerate_Click);
            // 
            // tabOutputFiles
            // 
            this.tabOutputFiles.Controls.Add(this.grpOutputFiles);
            this.tabOutputFiles.Location = new System.Drawing.Point(4, 28);
            this.tabOutputFiles.Name = "tabOutputFiles";
            this.tabOutputFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutputFiles.Size = new System.Drawing.Size(1361, 666);
            this.tabOutputFiles.TabIndex = 11;
            this.tabOutputFiles.Text = "Output File Details";
            this.tabOutputFiles.UseVisualStyleBackColor = true;
            // 
            // grpOutputFiles
            // 
            this.grpOutputFiles.Controls.Add(this.btnAddOutputFile);
            this.grpOutputFiles.Controls.Add(this.btnDeleteOutputFile);
            this.grpOutputFiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOutputFiles.Location = new System.Drawing.Point(59, 25);
            this.grpOutputFiles.Name = "grpOutputFiles";
            this.grpOutputFiles.Size = new System.Drawing.Size(527, 409);
            this.grpOutputFiles.TabIndex = 25;
            this.grpOutputFiles.TabStop = false;
            this.grpOutputFiles.Text = "Output Files";
            // 
            // btnAddOutputFile
            // 
            this.btnAddOutputFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOutputFile.BackgroundImage")));
            this.btnAddOutputFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddOutputFile.Location = new System.Drawing.Point(433, 10);
            this.btnAddOutputFile.Name = "btnAddOutputFile";
            this.btnAddOutputFile.Size = new System.Drawing.Size(39, 39);
            this.btnAddOutputFile.TabIndex = 23;
            this.btnAddOutputFile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOutputFile
            // 
            this.btnDeleteOutputFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteOutputFile.BackgroundImage")));
            this.btnDeleteOutputFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteOutputFile.Location = new System.Drawing.Point(480, 10);
            this.btnDeleteOutputFile.Name = "btnDeleteOutputFile";
            this.btnDeleteOutputFile.Size = new System.Drawing.Size(39, 39);
            this.btnDeleteOutputFile.TabIndex = 24;
            this.btnDeleteOutputFile.UseVisualStyleBackColor = true;
            // 
            // CobolStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.Header);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "CobolStudio";
            this.Text = "CobolStudio - Template Generator";
            this.tab.ResumeLayout(false);
            this.tabCodeGenerate.ResumeLayout(false);
            this.tabCodeGenerate.PerformLayout();
            this.grpProgDetails.ResumeLayout(false);
            this.grpProgDetails.PerformLayout();
            this.grpProgDesc.ResumeLayout(false);
            this.grpProgDesc.PerformLayout();
            this.tabInputFiles.ResumeLayout(false);
            this.tabInputFiles.PerformLayout();
            this.grpInputFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputFiles)).EndInit();
            this.tabDBRecords.ResumeLayout(false);
            this.grpDBRecords.ResumeLayout(false);
            this.tabCodeGeneration.ResumeLayout(false);
            this.tabOutputFiles.ResumeLayout(false);
            this.grpOutputFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Text Boxes
        private System.Windows.Forms.TextBox Header;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;

        // Tab Processing
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabInputFiles;
        private System.Windows.Forms.TabPage tabCodeGenerate;
        private System.Windows.Forms.TabPage tabDBRecords;
        private System.Windows.Forms.TabPage tabCopyCodes;
        private System.Windows.Forms.TabPage tabInitialProcessing;
        private System.Windows.Forms.TabPage tabMainProcessing;
        private System.Windows.Forms.TabPage tabEndProcessing;
        private System.Windows.Forms.TabPage tabCodeGeneration;

        // Labels
        private System.Windows.Forms.Label lblProgName;
        
        // Buttons
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnCodeGenerate;
        private System.Windows.Forms.GroupBox grpInputFiles;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.GroupBox grpDBRecords;
        private System.Windows.Forms.Button btnDeleteDBRecord;
        private System.Windows.Forms.Button btnAddDBRecord;
        private System.Windows.Forms.GroupBox grpProgDetails;
        private System.Windows.Forms.GroupBox grpProgDesc;
        private System.Windows.Forms.RadioButton radioNonRestart;
        private System.Windows.Forms.RadioButton radioRestart;

        // User definded Text Boxes
        //private System.Windows.Forms.TextBox[] inputFileArray;
        //private System.Windows.Forms.TextBox[] inputFileDescArray;
        private System.Windows.Forms.TextBox[] outputFileArray;
        private System.Windows.Forms.TextBox[] outputFileDescArray;
        private System.Windows.Forms.TextBox[] DBRecordArray;

        // User defined Combo box
        //private System.Windows.Forms.ComboBox[] inputFileType;
        private System.Windows.Forms.ComboBox[] outputFileType;
        private System.Windows.Forms.ComboBox comboRestart;
        private System.Windows.Forms.DataGridView gridViewInputFiles;
        private System.Windows.Forms.TabPage tabOutputFiles;
        private System.Windows.Forms.GroupBox grpOutputFiles;
        private System.Windows.Forms.Button btnAddOutputFile;
        private System.Windows.Forms.Button btnDeleteOutputFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.TextBox txtFileLayout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddCopybook;
        private System.Windows.Forms.ComboBox comboCopybooks;
        private System.Windows.Forms.Label lblCopybook;
        private System.Windows.Forms.Button btnManualInputLayout;
        private System.Windows.Forms.Label lblInputFileLayout;
        private System.Windows.Forms.TextBox txtInputFileDesc;
        private System.Windows.Forms.Label lblInputFileDesc;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.ComboBox comboAccessType;
        private System.Windows.Forms.RadioButton radioBtnSeq;
        private System.Windows.Forms.RadioButton radioBtnInd;
        private System.Windows.Forms.Button btnDeleteInputFile;
        private System.Windows.Forms.Button btnModifyInputFile; 

    }
}