using Cobol.BLL.BusinessModel;

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
            this.components = new System.ComponentModel.Container();
            this.Header = new System.Windows.Forms.TextBox();
            this.DeleteDBRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Item_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.areaDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCodeGeneration = new System.Windows.Forms.TabPage();
            this.txtCompleteCode = new System.Windows.Forms.TextBox();
            this.btnCodeGenerate = new System.Windows.Forms.Button();
            this.tabDBRecords = new System.Windows.Forms.TabPage();
            this.grpAreaUsed = new System.Windows.Forms.GroupBox();
            this.comboUsageMode = new System.Windows.Forms.ComboBox();
            this.gridViewAreaNames = new System.Windows.Forms.DataGridView();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.btnAddArea = new System.Windows.Forms.Button();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.grpDBRecords = new System.Windows.Forms.GroupBox();
            this.gridViewDBRecords = new System.Windows.Forms.DataGridView();
            this.lblSubSchema = new System.Windows.Forms.Label();
            this.txtSubSchemaName = new System.Windows.Forms.TextBox();
            this.txtDBRecName = new System.Windows.Forms.TextBox();
            this.btnAddDBRec = new System.Windows.Forms.Button();
            this.lblDBRecName = new System.Windows.Forms.Label();
            this.tabOutputFiles = new System.Windows.Forms.TabPage();
            this.btnDeleteOutputFile = new System.Windows.Forms.Button();
            this.btnModifyOutputFile = new System.Windows.Forms.Button();
            this.btnAddOutputFile = new System.Windows.Forms.Button();
            this.txtOutputFileDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.grpboxOutputFileDetails = new System.Windows.Forms.GroupBox();
            this.radioBtnOutIndex = new System.Windows.Forms.RadioButton();
            this.radioBtnOutSeqn = new System.Windows.Forms.RadioButton();
            this.comboOutAccType = new System.Windows.Forms.ComboBox();
            this.txtOutputFileName = new System.Windows.Forms.TextBox();
            this.grpBoxOutputFileLayout = new System.Windows.Forms.GroupBox();
            this.txtBoxOutCopybook = new System.Windows.Forms.TextBox();
            this.radiobtnOutUserDefined = new System.Windows.Forms.RadioButton();
            this.radiobtnOutCopyBook = new System.Windows.Forms.RadioButton();
            this.txtOutputFileLayout = new System.Windows.Forms.TextBox();
            this.btnAddOutCopybook = new System.Windows.Forms.Button();
            this.grpOutputFiles = new System.Windows.Forms.GroupBox();
            this.gridViewOutputFiles = new System.Windows.Forms.DataGridView();
            this.tabInputFiles = new System.Windows.Forms.TabPage();
            this.grpInputFiles = new System.Windows.Forms.GroupBox();
            this.gridViewInputFiles = new System.Windows.Forms.DataGridView();
            this.btnDeleteInputFile = new System.Windows.Forms.Button();
            this.btnModifyInputFile = new System.Windows.Forms.Button();
            this.btnAddInputFile = new System.Windows.Forms.Button();
            this.txtInputFileDesc = new System.Windows.Forms.TextBox();
            this.lblInputFileDesc = new System.Windows.Forms.Label();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.grpboxInputFileDetails = new System.Windows.Forms.GroupBox();
            this.radioBtnInpIndex = new System.Windows.Forms.RadioButton();
            this.radioBtnInpSeqn = new System.Windows.Forms.RadioButton();
            this.comboInpAccType = new System.Windows.Forms.ComboBox();
            this.txtInputFileName = new System.Windows.Forms.TextBox();
            this.grpBoxInpFileLayout = new System.Windows.Forms.GroupBox();
            this.txtBoxInpCopybook = new System.Windows.Forms.TextBox();
            this.radiobtnInpUserDefined = new System.Windows.Forms.RadioButton();
            this.radiobtnInpCopyBook = new System.Windows.Forms.RadioButton();
            this.txtInputFileLayout = new System.Windows.Forms.TextBox();
            this.btnAddInpCopybook = new System.Windows.Forms.Button();
            this.tabCodeGenerate = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgName = new System.Windows.Forms.Label();
            this.grpProgDetails = new System.Windows.Forms.GroupBox();
            this.comboRestart = new System.Windows.Forms.ComboBox();
            this.radioNonRestart = new System.Windows.Forms.RadioButton();
            this.radioRestart = new System.Windows.Forms.RadioButton();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.grpProgDesc = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.grpBoxCodePreview = new System.Windows.Forms.GroupBox();
            this.DeleteDBRecord.SuspendLayout();
            this.DeleteArea.SuspendLayout();
            this.tabCodeGeneration.SuspendLayout();
            this.tabDBRecords.SuspendLayout();
            this.grpAreaUsed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAreaNames)).BeginInit();
            this.grpDBRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDBRecords)).BeginInit();
            this.tabOutputFiles.SuspendLayout();
            this.grpboxOutputFileDetails.SuspendLayout();
            this.grpBoxOutputFileLayout.SuspendLayout();
            this.grpOutputFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutputFiles)).BeginInit();
            this.tabInputFiles.SuspendLayout();
            this.grpInputFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputFiles)).BeginInit();
            this.grpboxInputFileDetails.SuspendLayout();
            this.grpBoxInpFileLayout.SuspendLayout();
            this.tabCodeGenerate.SuspendLayout();
            this.grpProgDetails.SuspendLayout();
            this.grpProgDesc.SuspendLayout();
            this.tab.SuspendLayout();
            this.grpBoxCodePreview.SuspendLayout();
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
            // DeleteDBRecord
            // 
            this.DeleteDBRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Item_Delete});
            this.DeleteDBRecord.Name = "DeleteDBRecord";
            this.DeleteDBRecord.Size = new System.Drawing.Size(108, 26);
            this.DeleteDBRecord.Click += new System.EventHandler(this.DeleteDBRecord_Click);
            // 
            // Item_Delete
            // 
            this.Item_Delete.Name = "Item_Delete";
            this.Item_Delete.Size = new System.Drawing.Size(107, 22);
            this.Item_Delete.Text = "Delete";
            // 
            // DeleteArea
            // 
            this.DeleteArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areaDeleteToolStripMenuItem});
            this.DeleteArea.Name = "DeleteArea";
            this.DeleteArea.Size = new System.Drawing.Size(108, 26);
            this.DeleteArea.Click += new System.EventHandler(this.DeleteArea_Click);
            // 
            // areaDeleteToolStripMenuItem
            // 
            this.areaDeleteToolStripMenuItem.Name = "areaDeleteToolStripMenuItem";
            this.areaDeleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.areaDeleteToolStripMenuItem.Text = "Delete";
            // 
            // tabCodeGeneration
            // 
            this.tabCodeGeneration.Controls.Add(this.btnCodeGenerate);
            this.tabCodeGeneration.Controls.Add(this.grpBoxCodePreview);
            this.tabCodeGeneration.Location = new System.Drawing.Point(4, 28);
            this.tabCodeGeneration.Name = "tabCodeGeneration";
            this.tabCodeGeneration.Size = new System.Drawing.Size(1361, 666);
            this.tabCodeGeneration.TabIndex = 10;
            this.tabCodeGeneration.Text = "Code Generation";
            this.tabCodeGeneration.UseVisualStyleBackColor = true;
            // 
            // txtCompleteCode
            // 
            this.txtCompleteCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompleteCode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompleteCode.Location = new System.Drawing.Point(19, 32);
            this.txtCompleteCode.MaxLength = 3276788;
            this.txtCompleteCode.Multiline = true;
            this.txtCompleteCode.Name = "txtCompleteCode";
            this.txtCompleteCode.ReadOnly = true;
            this.txtCompleteCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCompleteCode.Size = new System.Drawing.Size(745, 574);
            this.txtCompleteCode.TabIndex = 37;
            this.txtCompleteCode.WordWrap = false;
            // 
            // btnCodeGenerate
            // 
            this.btnCodeGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodeGenerate.Location = new System.Drawing.Point(1135, 582);
            this.btnCodeGenerate.Name = "btnCodeGenerate";
            this.btnCodeGenerate.Size = new System.Drawing.Size(133, 30);
            this.btnCodeGenerate.TabIndex = 17;
            this.btnCodeGenerate.Text = "Generate Code";
            this.btnCodeGenerate.UseVisualStyleBackColor = true;
            this.btnCodeGenerate.Click += new System.EventHandler(this.btnCodeGenerate_Click);
            // 
            // tabDBRecords
            // 
            this.tabDBRecords.Controls.Add(this.grpAreaUsed);
            this.tabDBRecords.Controls.Add(this.grpDBRecords);
            this.tabDBRecords.Location = new System.Drawing.Point(4, 28);
            this.tabDBRecords.Name = "tabDBRecords";
            this.tabDBRecords.Size = new System.Drawing.Size(1361, 666);
            this.tabDBRecords.TabIndex = 5;
            this.tabDBRecords.Text = "Database Records";
            this.tabDBRecords.UseVisualStyleBackColor = true;
            // 
            // grpAreaUsed
            // 
            this.grpAreaUsed.Controls.Add(this.comboUsageMode);
            this.grpAreaUsed.Controls.Add(this.gridViewAreaNames);
            this.grpAreaUsed.Controls.Add(this.txtAreaName);
            this.grpAreaUsed.Controls.Add(this.btnAddArea);
            this.grpAreaUsed.Controls.Add(this.lblAreaName);
            this.grpAreaUsed.Location = new System.Drawing.Point(683, 19);
            this.grpAreaUsed.Name = "grpAreaUsed";
            this.grpAreaUsed.Size = new System.Drawing.Size(627, 589);
            this.grpAreaUsed.TabIndex = 1;
            this.grpAreaUsed.TabStop = false;
            this.grpAreaUsed.Text = "Area used";
            // 
            // comboUsageMode
            // 
            this.comboUsageMode.BackColor = System.Drawing.SystemColors.Info;
            this.comboUsageMode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboUsageMode.FormattingEnabled = true;
            this.comboUsageMode.Items.AddRange(new object[] {
            "Retrieval",
            "Update"});
            this.comboUsageMode.Location = new System.Drawing.Point(375, 79);
            this.comboUsageMode.Name = "comboUsageMode";
            this.comboUsageMode.Size = new System.Drawing.Size(90, 27);
            this.comboUsageMode.TabIndex = 58;
            // 
            // gridViewAreaNames
            // 
            this.gridViewAreaNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewAreaNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewAreaNames.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridViewAreaNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewAreaNames.Location = new System.Drawing.Point(15, 134);
            this.gridViewAreaNames.Name = "gridViewAreaNames";
            this.gridViewAreaNames.ReadOnly = true;
            this.gridViewAreaNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewAreaNames.Size = new System.Drawing.Size(433, 441);
            this.gridViewAreaNames.TabIndex = 57;
            this.gridViewAreaNames.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridViewAreaNames_MouseClick);
            // 
            // txtAreaName
            // 
            this.txtAreaName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAreaName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAreaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaName.Location = new System.Drawing.Point(213, 80);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(125, 27);
            this.txtAreaName.TabIndex = 27;
            // 
            // btnAddArea
            // 
            this.btnAddArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddArea.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddArea.Location = new System.Drawing.Point(493, 76);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(88, 30);
            this.btnAddArea.TabIndex = 54;
            this.btnAddArea.Text = "Add";
            this.btnAddArea.UseVisualStyleBackColor = true;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(105, 83);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(81, 19);
            this.lblAreaName.TabIndex = 26;
            this.lblAreaName.Text = "Area Name";
            // 
            // grpDBRecords
            // 
            this.grpDBRecords.Controls.Add(this.gridViewDBRecords);
            this.grpDBRecords.Controls.Add(this.lblSubSchema);
            this.grpDBRecords.Controls.Add(this.txtSubSchemaName);
            this.grpDBRecords.Controls.Add(this.txtDBRecName);
            this.grpDBRecords.Controls.Add(this.btnAddDBRec);
            this.grpDBRecords.Controls.Add(this.lblDBRecName);
            this.grpDBRecords.Location = new System.Drawing.Point(29, 19);
            this.grpDBRecords.Name = "grpDBRecords";
            this.grpDBRecords.Size = new System.Drawing.Size(624, 589);
            this.grpDBRecords.TabIndex = 0;
            this.grpDBRecords.TabStop = false;
            this.grpDBRecords.Text = "Database Records";
            // 
            // gridViewDBRecords
            // 
            this.gridViewDBRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewDBRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewDBRecords.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridViewDBRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewDBRecords.Location = new System.Drawing.Point(10, 134);
            this.gridViewDBRecords.Name = "gridViewDBRecords";
            this.gridViewDBRecords.ReadOnly = true;
            this.gridViewDBRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewDBRecords.Size = new System.Drawing.Size(485, 441);
            this.gridViewDBRecords.TabIndex = 56;
            this.gridViewDBRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridViewDBRecords_MouseClick);
            // 
            // lblSubSchema
            // 
            this.lblSubSchema.AutoSize = true;
            this.lblSubSchema.Location = new System.Drawing.Point(375, 29);
            this.lblSubSchema.Name = "lblSubSchema";
            this.lblSubSchema.Size = new System.Drawing.Size(82, 19);
            this.lblSubSchema.TabIndex = 55;
            this.lblSubSchema.Text = "Subschema";
            // 
            // txtSubSchemaName
            // 
            this.txtSubSchemaName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSubSchemaName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSubSchemaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubSchemaName.Location = new System.Drawing.Point(474, 26);
            this.txtSubSchemaName.Name = "txtSubSchemaName";
            this.txtSubSchemaName.Size = new System.Drawing.Size(127, 27);
            this.txtSubSchemaName.TabIndex = 30;
            // 
            // txtDBRecName
            // 
            this.txtDBRecName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDBRecName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDBRecName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDBRecName.Location = new System.Drawing.Point(213, 80);
            this.txtDBRecName.Name = "txtDBRecName";
            this.txtDBRecName.Size = new System.Drawing.Size(282, 27);
            this.txtDBRecName.TabIndex = 27;
            // 
            // btnAddDBRec
            // 
            this.btnAddDBRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDBRec.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddDBRec.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddDBRec.Location = new System.Drawing.Point(513, 77);
            this.btnAddDBRec.Name = "btnAddDBRec";
            this.btnAddDBRec.Size = new System.Drawing.Size(88, 30);
            this.btnAddDBRec.TabIndex = 54;
            this.btnAddDBRec.Text = "Add";
            this.btnAddDBRec.UseVisualStyleBackColor = true;
            this.btnAddDBRec.Click += new System.EventHandler(this.btnAddDBRec_Click);
            // 
            // lblDBRecName
            // 
            this.lblDBRecName.AutoSize = true;
            this.lblDBRecName.Location = new System.Drawing.Point(6, 83);
            this.lblDBRecName.Name = "lblDBRecName";
            this.lblDBRecName.Size = new System.Drawing.Size(162, 19);
            this.lblDBRecName.TabIndex = 26;
            this.lblDBRecName.Text = "Database Record Name";
            // 
            // tabOutputFiles
            // 
            this.tabOutputFiles.Controls.Add(this.btnDeleteOutputFile);
            this.tabOutputFiles.Controls.Add(this.btnModifyOutputFile);
            this.tabOutputFiles.Controls.Add(this.btnAddOutputFile);
            this.tabOutputFiles.Controls.Add(this.txtOutputFileDesc);
            this.tabOutputFiles.Controls.Add(this.label2);
            this.tabOutputFiles.Controls.Add(this.lblOutputFile);
            this.tabOutputFiles.Controls.Add(this.grpboxOutputFileDetails);
            this.tabOutputFiles.Controls.Add(this.grpBoxOutputFileLayout);
            this.tabOutputFiles.Controls.Add(this.grpOutputFiles);
            this.tabOutputFiles.Location = new System.Drawing.Point(4, 28);
            this.tabOutputFiles.Name = "tabOutputFiles";
            this.tabOutputFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutputFiles.Size = new System.Drawing.Size(1361, 666);
            this.tabOutputFiles.TabIndex = 11;
            this.tabOutputFiles.Text = "Output File Details";
            this.tabOutputFiles.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOutputFile
            // 
            this.btnDeleteOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOutputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteOutputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeleteOutputFile.Location = new System.Drawing.Point(673, 580);
            this.btnDeleteOutputFile.Name = "btnDeleteOutputFile";
            this.btnDeleteOutputFile.Size = new System.Drawing.Size(88, 30);
            this.btnDeleteOutputFile.TabIndex = 53;
            this.btnDeleteOutputFile.Text = "Delete";
            this.btnDeleteOutputFile.UseVisualStyleBackColor = true;
            this.btnDeleteOutputFile.Click += new System.EventHandler(this.btnDeleteOutputFile_Click);
            // 
            // btnModifyOutputFile
            // 
            this.btnModifyOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyOutputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModifyOutputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnModifyOutputFile.Location = new System.Drawing.Point(568, 580);
            this.btnModifyOutputFile.Name = "btnModifyOutputFile";
            this.btnModifyOutputFile.Size = new System.Drawing.Size(88, 30);
            this.btnModifyOutputFile.TabIndex = 52;
            this.btnModifyOutputFile.Text = "Modify";
            this.btnModifyOutputFile.UseVisualStyleBackColor = true;
            this.btnModifyOutputFile.Click += new System.EventHandler(this.btnModifyOutputFile_Click);
            // 
            // btnAddOutputFile
            // 
            this.btnAddOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOutputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddOutputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddOutputFile.Location = new System.Drawing.Point(463, 580);
            this.btnAddOutputFile.Name = "btnAddOutputFile";
            this.btnAddOutputFile.Size = new System.Drawing.Size(88, 30);
            this.btnAddOutputFile.TabIndex = 51;
            this.btnAddOutputFile.Text = "Add";
            this.btnAddOutputFile.UseVisualStyleBackColor = true;
            this.btnAddOutputFile.Click += new System.EventHandler(this.btnAddOutputFile_Click);
            // 
            // txtOutputFileDesc
            // 
            this.txtOutputFileDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFileDesc.Location = new System.Drawing.Point(46, 95);
            this.txtOutputFileDesc.Multiline = true;
            this.txtOutputFileDesc.Name = "txtOutputFileDesc";
            this.txtOutputFileDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputFileDesc.Size = new System.Drawing.Size(698, 125);
            this.txtOutputFileDesc.TabIndex = 50;
            this.txtOutputFileDesc.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "File Description";
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(42, 33);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(74, 19);
            this.lblOutputFile.TabIndex = 47;
            this.lblOutputFile.Text = "File Name";
            // 
            // grpboxOutputFileDetails
            // 
            this.grpboxOutputFileDetails.Controls.Add(this.radioBtnOutIndex);
            this.grpboxOutputFileDetails.Controls.Add(this.radioBtnOutSeqn);
            this.grpboxOutputFileDetails.Controls.Add(this.comboOutAccType);
            this.grpboxOutputFileDetails.Controls.Add(this.txtOutputFileName);
            this.grpboxOutputFileDetails.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxOutputFileDetails.Location = new System.Drawing.Point(30, 6);
            this.grpboxOutputFileDetails.Name = "grpboxOutputFileDetails";
            this.grpboxOutputFileDetails.Size = new System.Drawing.Size(731, 235);
            this.grpboxOutputFileDetails.TabIndex = 55;
            this.grpboxOutputFileDetails.TabStop = false;
            this.grpboxOutputFileDetails.Text = "Output File Details";
            // 
            // radioBtnOutIndex
            // 
            this.radioBtnOutIndex.AutoSize = true;
            this.radioBtnOutIndex.Location = new System.Drawing.Point(473, 28);
            this.radioBtnOutIndex.Name = "radioBtnOutIndex";
            this.radioBtnOutIndex.Size = new System.Drawing.Size(78, 23);
            this.radioBtnOutIndex.TabIndex = 39;
            this.radioBtnOutIndex.Text = "Indexed";
            this.radioBtnOutIndex.UseVisualStyleBackColor = true;
            this.radioBtnOutIndex.CheckedChanged += new System.EventHandler(this.radioBtnOutIndex_CheckedChanged);
            // 
            // radioBtnOutSeqn
            // 
            this.radioBtnOutSeqn.AutoSize = true;
            this.radioBtnOutSeqn.Checked = true;
            this.radioBtnOutSeqn.Location = new System.Drawing.Point(332, 28);
            this.radioBtnOutSeqn.Name = "radioBtnOutSeqn";
            this.radioBtnOutSeqn.Size = new System.Drawing.Size(95, 23);
            this.radioBtnOutSeqn.TabIndex = 40;
            this.radioBtnOutSeqn.TabStop = true;
            this.radioBtnOutSeqn.Text = "Sequential";
            this.radioBtnOutSeqn.UseVisualStyleBackColor = true;
            this.radioBtnOutSeqn.CheckedChanged += new System.EventHandler(this.radioBtnOutSeqn_CheckedChanged);
            // 
            // comboOutAccType
            // 
            this.comboOutAccType.FormattingEnabled = true;
            this.comboOutAccType.Items.AddRange(new object[] {
            "Dynamic",
            "Random"});
            this.comboOutAccType.Location = new System.Drawing.Point(594, 28);
            this.comboOutAccType.Name = "comboOutAccType";
            this.comboOutAccType.Size = new System.Drawing.Size(120, 27);
            this.comboOutAccType.TabIndex = 41;
            this.comboOutAccType.Visible = false;
            // 
            // txtOutputFileName
            // 
            this.txtOutputFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFileName.Location = new System.Drawing.Point(111, 24);
            this.txtOutputFileName.Name = "txtOutputFileName";
            this.txtOutputFileName.Size = new System.Drawing.Size(138, 27);
            this.txtOutputFileName.TabIndex = 48;
            this.txtOutputFileName.TextChanged += new System.EventHandler(this.txtOutputFileName_TextChanged);
            // 
            // grpBoxOutputFileLayout
            // 
            this.grpBoxOutputFileLayout.Controls.Add(this.txtBoxOutCopybook);
            this.grpBoxOutputFileLayout.Controls.Add(this.radiobtnOutUserDefined);
            this.grpBoxOutputFileLayout.Controls.Add(this.radiobtnOutCopyBook);
            this.grpBoxOutputFileLayout.Controls.Add(this.txtOutputFileLayout);
            this.grpBoxOutputFileLayout.Controls.Add(this.btnAddOutCopybook);
            this.grpBoxOutputFileLayout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxOutputFileLayout.Location = new System.Drawing.Point(30, 257);
            this.grpBoxOutputFileLayout.Name = "grpBoxOutputFileLayout";
            this.grpBoxOutputFileLayout.Size = new System.Drawing.Size(731, 317);
            this.grpBoxOutputFileLayout.TabIndex = 56;
            this.grpBoxOutputFileLayout.TabStop = false;
            this.grpBoxOutputFileLayout.Text = "Output File Layout";
            // 
            // txtBoxOutCopybook
            // 
            this.txtBoxOutCopybook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxOutCopybook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxOutCopybook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxOutCopybook.Location = new System.Drawing.Point(33, 116);
            this.txtBoxOutCopybook.Name = "txtBoxOutCopybook";
            this.txtBoxOutCopybook.Size = new System.Drawing.Size(121, 27);
            this.txtBoxOutCopybook.TabIndex = 43;
            // 
            // radiobtnOutUserDefined
            // 
            this.radiobtnOutUserDefined.AutoSize = true;
            this.radiobtnOutUserDefined.Location = new System.Drawing.Point(188, 52);
            this.radiobtnOutUserDefined.Name = "radiobtnOutUserDefined";
            this.radiobtnOutUserDefined.Size = new System.Drawing.Size(158, 23);
            this.radiobtnOutUserDefined.TabIndex = 41;
            this.radiobtnOutUserDefined.Text = "User Defined Layout";
            this.radiobtnOutUserDefined.UseVisualStyleBackColor = true;
            this.radiobtnOutUserDefined.Click += new System.EventHandler(this.radiobtnOutUserDefined_Click);
            // 
            // radiobtnOutCopyBook
            // 
            this.radiobtnOutCopyBook.AutoSize = true;
            this.radiobtnOutCopyBook.Checked = true;
            this.radiobtnOutCopyBook.Location = new System.Drawing.Point(33, 52);
            this.radiobtnOutCopyBook.Name = "radiobtnOutCopyBook";
            this.radiobtnOutCopyBook.Size = new System.Drawing.Size(138, 23);
            this.radiobtnOutCopyBook.TabIndex = 42;
            this.radiobtnOutCopyBook.TabStop = true;
            this.radiobtnOutCopyBook.Text = "CopyBook Layout";
            this.radiobtnOutCopyBook.UseVisualStyleBackColor = true;
            this.radiobtnOutCopyBook.Click += new System.EventHandler(this.radiobtnOutCopyBook_Click);
            // 
            // txtOutputFileLayout
            // 
            this.txtOutputFileLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFileLayout.Enabled = false;
            this.txtOutputFileLayout.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFileLayout.Location = new System.Drawing.Point(433, 37);
            this.txtOutputFileLayout.Multiline = true;
            this.txtOutputFileLayout.Name = "txtOutputFileLayout";
            this.txtOutputFileLayout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputFileLayout.Size = new System.Drawing.Size(281, 254);
            this.txtOutputFileLayout.TabIndex = 36;
            this.txtOutputFileLayout.WordWrap = false;
            // 
            // btnAddOutCopybook
            // 
            this.btnAddOutCopybook.Location = new System.Drawing.Point(188, 115);
            this.btnAddOutCopybook.Name = "btnAddOutCopybook";
            this.btnAddOutCopybook.Size = new System.Drawing.Size(123, 27);
            this.btnAddOutCopybook.TabIndex = 34;
            this.btnAddOutCopybook.Text = "Add Copybook";
            this.btnAddOutCopybook.UseVisualStyleBackColor = true;
            this.btnAddOutCopybook.Click += new System.EventHandler(this.btnAddOutCopybook_Click);
            // 
            // grpOutputFiles
            // 
            this.grpOutputFiles.Controls.Add(this.gridViewOutputFiles);
            this.grpOutputFiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOutputFiles.Location = new System.Drawing.Point(802, 6);
            this.grpOutputFiles.Name = "grpOutputFiles";
            this.grpOutputFiles.Size = new System.Drawing.Size(520, 568);
            this.grpOutputFiles.TabIndex = 54;
            this.grpOutputFiles.TabStop = false;
            this.grpOutputFiles.Text = "Output Files";
            // 
            // gridViewOutputFiles
            // 
            this.gridViewOutputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewOutputFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewOutputFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridViewOutputFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewOutputFiles.Location = new System.Drawing.Point(6, 40);
            this.gridViewOutputFiles.Name = "gridViewOutputFiles";
            this.gridViewOutputFiles.ReadOnly = true;
            this.gridViewOutputFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewOutputFiles.Size = new System.Drawing.Size(503, 513);
            this.gridViewOutputFiles.TabIndex = 24;
            this.gridViewOutputFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewOutputFiles_CellClick);
            // 
            // tabInputFiles
            // 
            this.tabInputFiles.Controls.Add(this.grpInputFiles);
            this.tabInputFiles.Controls.Add(this.btnDeleteInputFile);
            this.tabInputFiles.Controls.Add(this.btnModifyInputFile);
            this.tabInputFiles.Controls.Add(this.btnAddInputFile);
            this.tabInputFiles.Controls.Add(this.txtInputFileDesc);
            this.tabInputFiles.Controls.Add(this.lblInputFileDesc);
            this.tabInputFiles.Controls.Add(this.lblInputFile);
            this.tabInputFiles.Controls.Add(this.grpboxInputFileDetails);
            this.tabInputFiles.Controls.Add(this.grpBoxInpFileLayout);
            this.tabInputFiles.Location = new System.Drawing.Point(4, 28);
            this.tabInputFiles.Name = "tabInputFiles";
            this.tabInputFiles.Size = new System.Drawing.Size(1361, 666);
            this.tabInputFiles.TabIndex = 4;
            this.tabInputFiles.Text = "Input File Details";
            this.tabInputFiles.UseVisualStyleBackColor = true;
            // 
            // grpInputFiles
            // 
            this.grpInputFiles.Controls.Add(this.gridViewInputFiles);
            this.grpInputFiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInputFiles.Location = new System.Drawing.Point(802, 6);
            this.grpInputFiles.Name = "grpInputFiles";
            this.grpInputFiles.Size = new System.Drawing.Size(520, 568);
            this.grpInputFiles.TabIndex = 44;
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
            this.gridViewInputFiles.Location = new System.Drawing.Point(6, 40);
            this.gridViewInputFiles.Name = "gridViewInputFiles";
            this.gridViewInputFiles.ReadOnly = true;
            this.gridViewInputFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewInputFiles.Size = new System.Drawing.Size(503, 513);
            this.gridViewInputFiles.TabIndex = 24;
            this.gridViewInputFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewInputFiles_CellClick);
            // 
            // btnDeleteInputFile
            // 
            this.btnDeleteInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteInputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteInputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeleteInputFile.Location = new System.Drawing.Point(673, 580);
            this.btnDeleteInputFile.Name = "btnDeleteInputFile";
            this.btnDeleteInputFile.Size = new System.Drawing.Size(88, 30);
            this.btnDeleteInputFile.TabIndex = 43;
            this.btnDeleteInputFile.Text = "Delete";
            this.btnDeleteInputFile.UseVisualStyleBackColor = true;
            this.btnDeleteInputFile.Click += new System.EventHandler(this.btnDeleteInputFile_Click);
            // 
            // btnModifyInputFile
            // 
            this.btnModifyInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyInputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModifyInputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnModifyInputFile.Location = new System.Drawing.Point(568, 580);
            this.btnModifyInputFile.Name = "btnModifyInputFile";
            this.btnModifyInputFile.Size = new System.Drawing.Size(88, 30);
            this.btnModifyInputFile.TabIndex = 42;
            this.btnModifyInputFile.Text = "Modify";
            this.btnModifyInputFile.UseVisualStyleBackColor = true;
            this.btnModifyInputFile.Click += new System.EventHandler(this.btnModifyInputFile_Click);
            // 
            // btnAddInputFile
            // 
            this.btnAddInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddInputFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddInputFile.Location = new System.Drawing.Point(463, 580);
            this.btnAddInputFile.Name = "btnAddInputFile";
            this.btnAddInputFile.Size = new System.Drawing.Size(88, 30);
            this.btnAddInputFile.TabIndex = 37;
            this.btnAddInputFile.Text = "Add";
            this.btnAddInputFile.UseVisualStyleBackColor = true;
            this.btnAddInputFile.Click += new System.EventHandler(this.btnAddInputFile_Click);
            // 
            // txtInputFileDesc
            // 
            this.txtInputFileDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputFileDesc.Location = new System.Drawing.Point(46, 95);
            this.txtInputFileDesc.Multiline = true;
            this.txtInputFileDesc.Name = "txtInputFileDesc";
            this.txtInputFileDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputFileDesc.Size = new System.Drawing.Size(698, 125);
            this.txtInputFileDesc.TabIndex = 27;
            this.txtInputFileDesc.WordWrap = false;
            // 
            // lblInputFileDesc
            // 
            this.lblInputFileDesc.AutoSize = true;
            this.lblInputFileDesc.Location = new System.Drawing.Point(42, 73);
            this.lblInputFileDesc.Name = "lblInputFileDesc";
            this.lblInputFileDesc.Size = new System.Drawing.Size(110, 19);
            this.lblInputFileDesc.TabIndex = 26;
            this.lblInputFileDesc.Text = "File Description";
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(42, 33);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(74, 19);
            this.lblInputFile.TabIndex = 24;
            this.lblInputFile.Text = "File Name";
            // 
            // grpboxInputFileDetails
            // 
            this.grpboxInputFileDetails.Controls.Add(this.radioBtnInpIndex);
            this.grpboxInputFileDetails.Controls.Add(this.radioBtnInpSeqn);
            this.grpboxInputFileDetails.Controls.Add(this.comboInpAccType);
            this.grpboxInputFileDetails.Controls.Add(this.txtInputFileName);
            this.grpboxInputFileDetails.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxInputFileDetails.Location = new System.Drawing.Point(30, 6);
            this.grpboxInputFileDetails.Name = "grpboxInputFileDetails";
            this.grpboxInputFileDetails.Size = new System.Drawing.Size(731, 235);
            this.grpboxInputFileDetails.TabIndex = 45;
            this.grpboxInputFileDetails.TabStop = false;
            this.grpboxInputFileDetails.Text = "Input File Details";
            // 
            // radioBtnInpIndex
            // 
            this.radioBtnInpIndex.AutoSize = true;
            this.radioBtnInpIndex.Location = new System.Drawing.Point(473, 28);
            this.radioBtnInpIndex.Name = "radioBtnInpIndex";
            this.radioBtnInpIndex.Size = new System.Drawing.Size(78, 23);
            this.radioBtnInpIndex.TabIndex = 39;
            this.radioBtnInpIndex.Text = "Indexed";
            this.radioBtnInpIndex.UseVisualStyleBackColor = true;
            this.radioBtnInpIndex.Click += new System.EventHandler(this.radioBtnInd_CheckedChanged);
            // 
            // radioBtnInpSeqn
            // 
            this.radioBtnInpSeqn.AutoSize = true;
            this.radioBtnInpSeqn.Checked = true;
            this.radioBtnInpSeqn.Location = new System.Drawing.Point(332, 28);
            this.radioBtnInpSeqn.Name = "radioBtnInpSeqn";
            this.radioBtnInpSeqn.Size = new System.Drawing.Size(95, 23);
            this.radioBtnInpSeqn.TabIndex = 40;
            this.radioBtnInpSeqn.TabStop = true;
            this.radioBtnInpSeqn.Text = "Sequential";
            this.radioBtnInpSeqn.UseVisualStyleBackColor = true;
            this.radioBtnInpSeqn.CheckedChanged += new System.EventHandler(this.radioBtnSeq_CheckedChanged);
            // 
            // comboInpAccType
            // 
            this.comboInpAccType.FormattingEnabled = true;
            this.comboInpAccType.Items.AddRange(new object[] {
            "Dynamic",
            "Random"});
            this.comboInpAccType.Location = new System.Drawing.Point(594, 28);
            this.comboInpAccType.Name = "comboInpAccType";
            this.comboInpAccType.Size = new System.Drawing.Size(120, 27);
            this.comboInpAccType.TabIndex = 41;
            this.comboInpAccType.Visible = false;
            // 
            // txtInputFileName
            // 
            this.txtInputFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputFileName.Location = new System.Drawing.Point(111, 24);
            this.txtInputFileName.Name = "txtInputFileName";
            this.txtInputFileName.Size = new System.Drawing.Size(138, 27);
            this.txtInputFileName.TabIndex = 25;
            this.txtInputFileName.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            // 
            // grpBoxInpFileLayout
            // 
            this.grpBoxInpFileLayout.Controls.Add(this.txtBoxInpCopybook);
            this.grpBoxInpFileLayout.Controls.Add(this.radiobtnInpUserDefined);
            this.grpBoxInpFileLayout.Controls.Add(this.radiobtnInpCopyBook);
            this.grpBoxInpFileLayout.Controls.Add(this.txtInputFileLayout);
            this.grpBoxInpFileLayout.Controls.Add(this.btnAddInpCopybook);
            this.grpBoxInpFileLayout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxInpFileLayout.Location = new System.Drawing.Point(30, 257);
            this.grpBoxInpFileLayout.Name = "grpBoxInpFileLayout";
            this.grpBoxInpFileLayout.Size = new System.Drawing.Size(731, 317);
            this.grpBoxInpFileLayout.TabIndex = 46;
            this.grpBoxInpFileLayout.TabStop = false;
            this.grpBoxInpFileLayout.Text = "Input File Layout";
            // 
            // txtBoxInpCopybook
            // 
            this.txtBoxInpCopybook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxInpCopybook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxInpCopybook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxInpCopybook.Location = new System.Drawing.Point(33, 116);
            this.txtBoxInpCopybook.Name = "txtBoxInpCopybook";
            this.txtBoxInpCopybook.Size = new System.Drawing.Size(121, 27);
            this.txtBoxInpCopybook.TabIndex = 43;
            // 
            // radiobtnInpUserDefined
            // 
            this.radiobtnInpUserDefined.AutoSize = true;
            this.radiobtnInpUserDefined.Location = new System.Drawing.Point(188, 52);
            this.radiobtnInpUserDefined.Name = "radiobtnInpUserDefined";
            this.radiobtnInpUserDefined.Size = new System.Drawing.Size(158, 23);
            this.radiobtnInpUserDefined.TabIndex = 41;
            this.radiobtnInpUserDefined.Text = "User Defined Layout";
            this.radiobtnInpUserDefined.UseVisualStyleBackColor = true;
            this.radiobtnInpUserDefined.Click += new System.EventHandler(this.radiobtnInpUserDefined_Click);
            // 
            // radiobtnInpCopyBook
            // 
            this.radiobtnInpCopyBook.AutoSize = true;
            this.radiobtnInpCopyBook.Checked = true;
            this.radiobtnInpCopyBook.Location = new System.Drawing.Point(33, 52);
            this.radiobtnInpCopyBook.Name = "radiobtnInpCopyBook";
            this.radiobtnInpCopyBook.Size = new System.Drawing.Size(138, 23);
            this.radiobtnInpCopyBook.TabIndex = 42;
            this.radiobtnInpCopyBook.TabStop = true;
            this.radiobtnInpCopyBook.Text = "CopyBook Layout";
            this.radiobtnInpCopyBook.UseVisualStyleBackColor = true;
            this.radiobtnInpCopyBook.Click += new System.EventHandler(this.radiobtnInpCopyBook_Click);
            // 
            // txtInputFileLayout
            // 
            this.txtInputFileLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputFileLayout.Enabled = false;
            this.txtInputFileLayout.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputFileLayout.Location = new System.Drawing.Point(433, 37);
            this.txtInputFileLayout.Multiline = true;
            this.txtInputFileLayout.Name = "txtInputFileLayout";
            this.txtInputFileLayout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputFileLayout.Size = new System.Drawing.Size(281, 254);
            this.txtInputFileLayout.TabIndex = 36;
            this.txtInputFileLayout.WordWrap = false;
            // 
            // btnAddInpCopybook
            // 
            this.btnAddInpCopybook.Location = new System.Drawing.Point(188, 115);
            this.btnAddInpCopybook.Name = "btnAddInpCopybook";
            this.btnAddInpCopybook.Size = new System.Drawing.Size(123, 27);
            this.btnAddInpCopybook.TabIndex = 34;
            this.btnAddInpCopybook.Text = "Add Copybook";
            this.btnAddInpCopybook.UseVisualStyleBackColor = true;
            this.btnAddInpCopybook.Click += new System.EventHandler(this.btnAddCopybook_Click);
            // 
            // tabCodeGenerate
            // 
            this.tabCodeGenerate.Controls.Add(this.label1);
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
            this.comboRestart.BackColor = System.Drawing.SystemColors.Info;
            this.comboRestart.ForeColor = System.Drawing.SystemColors.WindowText;
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
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(200, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 27);
            this.txtName.TabIndex = 26;
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
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabCodeGenerate);
            this.tab.Controls.Add(this.tabInputFiles);
            this.tab.Controls.Add(this.tabOutputFiles);
            this.tab.Controls.Add(this.tabDBRecords);
            this.tab.Controls.Add(this.tabCodeGeneration);
            this.tab.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(0, 32);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1369, 698);
            this.tab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tab.TabIndex = 3;
            this.tab.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_Selected);
            // 
            // grpBoxCodePreview
            // 
            this.grpBoxCodePreview.Controls.Add(this.txtCompleteCode);
            this.grpBoxCodePreview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCodePreview.Location = new System.Drawing.Point(25, 14);
            this.grpBoxCodePreview.Name = "grpBoxCodePreview";
            this.grpBoxCodePreview.Size = new System.Drawing.Size(787, 627);
            this.grpBoxCodePreview.TabIndex = 46;
            this.grpBoxCodePreview.TabStop = false;
            this.grpBoxCodePreview.Text = "Code Preview";
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
            this.DeleteDBRecord.ResumeLayout(false);
            this.DeleteArea.ResumeLayout(false);
            this.tabCodeGeneration.ResumeLayout(false);
            this.tabDBRecords.ResumeLayout(false);
            this.grpAreaUsed.ResumeLayout(false);
            this.grpAreaUsed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAreaNames)).EndInit();
            this.grpDBRecords.ResumeLayout(false);
            this.grpDBRecords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDBRecords)).EndInit();
            this.tabOutputFiles.ResumeLayout(false);
            this.tabOutputFiles.PerformLayout();
            this.grpboxOutputFileDetails.ResumeLayout(false);
            this.grpboxOutputFileDetails.PerformLayout();
            this.grpBoxOutputFileLayout.ResumeLayout(false);
            this.grpBoxOutputFileLayout.PerformLayout();
            this.grpOutputFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutputFiles)).EndInit();
            this.tabInputFiles.ResumeLayout(false);
            this.tabInputFiles.PerformLayout();
            this.grpInputFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputFiles)).EndInit();
            this.grpboxInputFileDetails.ResumeLayout(false);
            this.grpboxInputFileDetails.PerformLayout();
            this.grpBoxInpFileLayout.ResumeLayout(false);
            this.grpBoxInpFileLayout.PerformLayout();
            this.tabCodeGenerate.ResumeLayout(false);
            this.tabCodeGenerate.PerformLayout();
            this.grpProgDetails.ResumeLayout(false);
            this.grpProgDetails.PerformLayout();
            this.grpProgDesc.ResumeLayout(false);
            this.grpProgDesc.PerformLayout();
            this.tab.ResumeLayout(false);
            this.grpBoxCodePreview.ResumeLayout(false);
            this.grpBoxCodePreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Text Boxes
        private System.Windows.Forms.TextBox Header;

        private System.Windows.Forms.ContextMenuStrip DeleteDBRecord;
        private System.Windows.Forms.ContextMenuStrip DeleteArea;
        private System.Windows.Forms.ToolStripMenuItem Item_Delete;
        private System.Windows.Forms.ToolStripMenuItem areaDeleteToolStripMenuItem;
        private System.Windows.Forms.TabPage tabCodeGeneration;
        private System.Windows.Forms.Button btnCodeGenerate;
        private System.Windows.Forms.TabPage tabDBRecords;
        private System.Windows.Forms.GroupBox grpAreaUsed;
        private System.Windows.Forms.DataGridView gridViewAreaNames;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Button btnAddArea;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.GroupBox grpDBRecords;
        private System.Windows.Forms.DataGridView gridViewDBRecords;
        private System.Windows.Forms.Label lblSubSchema;
        private System.Windows.Forms.TextBox txtSubSchemaName;
        private System.Windows.Forms.TextBox txtDBRecName;
        private System.Windows.Forms.Button btnAddDBRec;
        private System.Windows.Forms.Label lblDBRecName;
        private System.Windows.Forms.TabPage tabOutputFiles;
        private System.Windows.Forms.Button btnDeleteOutputFile;
        private System.Windows.Forms.Button btnModifyOutputFile;
        private System.Windows.Forms.Button btnAddOutputFile;
        private System.Windows.Forms.TextBox txtOutputFileDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.GroupBox grpboxOutputFileDetails;
        private System.Windows.Forms.RadioButton radioBtnOutIndex;
        private System.Windows.Forms.RadioButton radioBtnOutSeqn;
        private System.Windows.Forms.ComboBox comboOutAccType;
        private System.Windows.Forms.TextBox txtOutputFileName;
        private System.Windows.Forms.GroupBox grpBoxOutputFileLayout;
        private System.Windows.Forms.TextBox txtBoxOutCopybook;
        private System.Windows.Forms.RadioButton radiobtnOutUserDefined;
        private System.Windows.Forms.RadioButton radiobtnOutCopyBook;
        private System.Windows.Forms.TextBox txtOutputFileLayout;
        private System.Windows.Forms.Button btnAddOutCopybook;
        private System.Windows.Forms.GroupBox grpOutputFiles;
        private System.Windows.Forms.DataGridView gridViewOutputFiles;
        private System.Windows.Forms.TabPage tabInputFiles;
        private System.Windows.Forms.GroupBox grpInputFiles;
        private System.Windows.Forms.DataGridView gridViewInputFiles;
        private System.Windows.Forms.Button btnDeleteInputFile;
        private System.Windows.Forms.Button btnModifyInputFile;
        private System.Windows.Forms.Button btnAddInputFile;
        private System.Windows.Forms.TextBox txtInputFileDesc;
        private System.Windows.Forms.Label lblInputFileDesc;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.GroupBox grpboxInputFileDetails;
        private System.Windows.Forms.RadioButton radioBtnInpIndex;
        private System.Windows.Forms.RadioButton radioBtnInpSeqn;
        private System.Windows.Forms.ComboBox comboInpAccType;
        private System.Windows.Forms.TextBox txtInputFileName;
        private System.Windows.Forms.GroupBox grpBoxInpFileLayout;
        private System.Windows.Forms.TextBox txtBoxInpCopybook;
        private System.Windows.Forms.RadioButton radiobtnInpUserDefined;
        private System.Windows.Forms.RadioButton radiobtnInpCopyBook;
        private System.Windows.Forms.TextBox txtInputFileLayout;
        private System.Windows.Forms.Button btnAddInpCopybook;
        private System.Windows.Forms.TabPage tabCodeGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProgName;
        private System.Windows.Forms.GroupBox grpProgDetails;
        private System.Windows.Forms.ComboBox comboRestart;
        private System.Windows.Forms.RadioButton radioNonRestart;
        private System.Windows.Forms.RadioButton radioRestart;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.GroupBox grpProgDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.ComboBox comboUsageMode;
        private System.Windows.Forms.TextBox txtCompleteCode;
        private System.Windows.Forms.GroupBox grpBoxCodePreview;

    }
}