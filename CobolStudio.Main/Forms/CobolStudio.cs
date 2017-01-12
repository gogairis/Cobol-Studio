using System;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Cobol.BLL;
using Cobol.BLL.BusinessModel;
using CobolStudio.Main.Properties;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Cobol.BLL.DivisionsProcessor.Impl;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace CobolStudio.Main.Forms
{
    public partial class CobolStudio : Form
    {
        private int _nInputFiles;
        private int _nOutputFiles;
        private int _nDbRecord;
        private int _nAreaNames;
        private bool _inputRowSelected;
        private bool _outputRowSelected;
        private string _completeCode;
        StringBuilder inputFileLayout = new StringBuilder();
        StringBuilder outputFileLayout = new StringBuilder();

        List<string> dbRecNameList = new List<string>();
        List<string> dbAreaNamesList = new List<string>();
        List<string> schemaNameList = new List<string>();
        List<string> copyBookList = new List<string>();

        List<string> newDBRecNameList = new List<string>();
        List<string> newDBAreaNamesList = new List<string>();
        List<string> newSchemaNameList = new List<string>();
        List<string> newCopyBookList = new List<string>();

        AutoCompleteStringCollection CopyBookCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DBRecCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DBAreaCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection SchemaNameCollection = new AutoCompleteStringCollection();

        public CobolStudio()
        {
            InitializeComponent();

            StreamReader sr = null;

            // Create autocomplete source data for DB records
            if (File.Exists(@"Files" + Path.AltDirectorySeparatorChar + "DBRecords.txt"))
            {
                sr = File.OpenText(@"Files" + Path.AltDirectorySeparatorChar + "DBRecords.txt");

                while (!sr.EndOfStream)
                {
                    dbRecNameList.Add(sr.ReadLine());
                }
                sr.Close();
            }

            DBRecCollection.AddRange(dbRecNameList.ToArray());

            txtDBRecName.AutoCompleteCustomSource = DBRecCollection;
            txtDBRecName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDBRecName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            // Create autocomplete source data for Area fields
            sr = null;

            if (File.Exists(@"Files" + Path.AltDirectorySeparatorChar + "AreaNames.txt"))
            {
                sr = File.OpenText(@"Files" + Path.AltDirectorySeparatorChar + "AreaNames.txt");

                while (!sr.EndOfStream)
                {
                    dbAreaNamesList.Add(sr.ReadLine());
                }
                sr.Close();
            }

            DBAreaCollection.AddRange(dbAreaNamesList.ToArray());

            txtAreaName.AutoCompleteCustomSource = DBAreaCollection;
            txtAreaName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAreaName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Create autocomplete source data for subschema names
            sr = null;

            if (File.Exists(@"Files" + Path.AltDirectorySeparatorChar + "SubSchemaName.txt"))
            {
                sr = File.OpenText(@"Files" + Path.AltDirectorySeparatorChar + "SubSchemaName.txt");

                while (!sr.EndOfStream)
                {
                    schemaNameList.Add(sr.ReadLine());
                }
                sr.Close();
            }

            SchemaNameCollection.AddRange(schemaNameList.ToArray());

            txtSubSchemaName.AutoCompleteCustomSource = SchemaNameCollection;
            txtSubSchemaName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSubSchemaName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            // Create autocomplete source data for CopyBooks in input/output files section
            sr = null;

            if (File.Exists(@"Files" + Path.DirectorySeparatorChar + "CopyBooks.txt"))
            {
                sr = File.OpenText(@"Files" + Path.DirectorySeparatorChar + "CopyBooks.txt");

                while (!sr.EndOfStream)
                {
                    copyBookList.Add(sr.ReadLine());
                }
                sr.Close();
            }

            CopyBookCollection.AddRange(copyBookList.ToArray());

            txtBoxInpCopybook.AutoCompleteCustomSource = CopyBookCollection;
            txtBoxInpCopybook.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBoxInpCopybook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtBoxOutCopybook.AutoCompleteCustomSource = CopyBookCollection;
            txtBoxOutCopybook.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBoxOutCopybook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

        }

        /// <summary>
        /// When any tab is selected from the form, this event will be called. This will update the preview textbox to show
        /// a preview of code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab_Selected(object sender, TabControlEventArgs e)
        {
            // If no Author name entered by the user then this will pick the name from windows user currently logged in.
            if (txtAuthor.Text.Trim() == "")
            {
                txtAuthor.Text = Environment.UserName;
            }

            // If no version number entered by the user then this will default the version to C0123456.
            if (txtVersion.Text.Trim() == "")
            {
                txtVersion.Text = "C0123456";
            }

            // If no program name entered by user then this will default the name to "SAMPLECODE".
            if (txtName.Text.Trim() == "")
            {
                txtName.Text = "SAMPLECODE";
            }

            _completeCode = ProcessAllDivisions();
            txtCompleteCode.Text = _completeCode;
        }

        private void btnCodeGenerate_Click(object sender, EventArgs e)
        {
            if ((_nDbRecord > 0 || _nAreaNames > 0) && txtSubSchemaName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.No_Schema_Message,
                    Resources.No_Schema_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (!schemaNameList.Contains(txtSubSchemaName.Text.Trim().ToUpper()))
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show(
                    Resources.New_CopyBook_Message,
                    Resources.New_Schema_Title,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    goto AB010;
                }
            }
            else
            {
                System.IO.File.WriteAllText(@"C:\File\Cobol.cob", _completeCode);
                //sendemail();
                StreamWriter sw = new StreamWriter(@"Files" + Path.DirectorySeparatorChar + "CopyBooks.txt", true);

                foreach (string copyBook in copyBookList)
                {
                    sw.WriteLine(copyBook);
                }
            }
        AB010:
            { }
            //MessageBox.Show(
            //    Resources.Code_Generation_Message,
            //    Resources.Code_Generation_Message_Title,
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information); 
        }

        private string ProcessAllDivisions()
        {
            WorkingStorage.inputIndexedFile.Clear();
            WorkingStorage.outputIndexedFile.Clear();
            WorkingStorage.groupLevelWorking.Clear();
            WorkingStorage.otherWorkingStorage.Clear();
            WorkingStorage.checkpointingFields.Clear();
            WorkingStorage.restartFields.Clear();

            DivisonProcessorService servieObj = new DivisonProcessorService();
            DivisionInputItems inputItemObj = new DivisionInputItems();
            inputItemObj.ProgramId = txtName.Text.ToUpper();
            inputItemObj.VersionNumber = txtVersion.Text.ToUpper();
            inputItemObj.AuthorName = txtAuthor.Text.ToLower();
            inputItemObj.CreationDate = DateTime.Now;
            inputItemObj.CodeDescription = txtDescription.Text;

            // Create input file table
            inputItemObj.NoOfInputFiles = _nInputFiles;
            if (_nInputFiles > 0)
            {
                inputItemObj.InputFileNames =
                    InputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileName.ToString()).ToList();
                inputItemObj.InputFileTypes =
                    InputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileType.ToString()).ToList();
                inputItemObj.InputFileDescriptions =
                    InputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileDescription.ToString()).ToList();
                inputItemObj.InputFieLayout =
                    InputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileLayout.ToString().ToUpper()).ToList();
                inputItemObj.InputFileAccessType =
                    InputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.accessType.ToString().ToUpper()).ToList();
            }

            // Create output file table
            inputItemObj.NoOfOutputFiles = _nOutputFiles;
            if (_nOutputFiles > 0)
            {
                inputItemObj.OutputFileNames =
                    OutputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileName.ToString()).ToList();
                inputItemObj.OutputFileTypes =
                    OutputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileType.ToString()).ToList();
                inputItemObj.OutputFileDescriptions =
                    OutputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileDescription.ToString()).ToList();
                inputItemObj.OutputFieLayout =
                    OutputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.fileLayout.ToString().ToUpper()).ToList();
                inputItemObj.OutputFileAccessType =
                    OutputFileRepository.obj.Where(p => p.fileName != null).Select(p => p.accessType.ToString().ToUpper()).ToList();
            }

            // Create database records and area table
            inputItemObj.NoOfDbRecords = _nDbRecord;
            inputItemObj.NoOfDbAreas = _nAreaNames;
            inputItemObj.SchemaName = txtSubSchemaName.Text.ToUpper().Trim();
            if (_nDbRecord > 0)
            {
                inputItemObj.DbRecordNames = DatabaseRepository.dbRepository.Select(p => p.DBRecName).ToList();
            }
            if (_nAreaNames > 0)
            {
                inputItemObj.DbAreaNames = AreaRepository.areaRepository.Select(p => p.AreaNames).ToList();
                inputItemObj.DbAreaUsage = AreaRepository.areaRepository.Select(p => p.UsageMode).ToList();
            }

            inputItemObj.RestartInd = radioRestart.Checked;
            if (inputItemObj.RestartInd)
            {
                inputItemObj.RestartType = comboRestart.SelectedItem.ToString();
            }

            if (inputItemObj.NoOfDbRecords > 0)
            {

            }

            if (inputItemObj.RestartInd && inputItemObj.RestartType == Constants.RestartType.Database.ToString())
            {
                if (inputItemObj.NoOfDbRecords > 0)
                {
                    if (inputItemObj.DbRecordNames.Find(s => s.Contains(Constants.ProcedureDevision.r736RecName.Split('-')[0])) == null)
                    {
                        inputItemObj.DbRecordNames.Add(Constants.ProcedureDevision.r736RecName);
                        inputItemObj.NoOfDbRecords++;
                    }

                    if (inputItemObj.DbRecordNames.Find(s => s.Contains(Constants.ProcedureDevision.r746RecName.Split('-')[0])) == null)
                    {
                        inputItemObj.DbRecordNames.Add(Constants.ProcedureDevision.r746RecName);
                        inputItemObj.NoOfDbRecords++;
                    }
                }
                else
                {
                    inputItemObj.DbRecordNames = new List<string>();
                    inputItemObj.DbRecordNames.Add(Constants.ProcedureDevision.r736RecName);
                    inputItemObj.DbRecordNames.Add(Constants.ProcedureDevision.r746RecName);
                    inputItemObj.NoOfDbRecords += 2;
                }

                if (inputItemObj.NoOfDbAreas > 0)
                {
                    if (inputItemObj.DbAreaNames.Find(s => s.Contains("A741")) == null)
                    {
                        inputItemObj.DbAreaNames.Add("A741");
                        inputItemObj.DbAreaUsage.Add("Update");
                        inputItemObj.NoOfDbAreas++;
                    }
                }
                else
                {
                    inputItemObj.DbAreaNames = new List<string>();
                    inputItemObj.DbAreaUsage = new List<string>();
                    inputItemObj.DbAreaNames.Add("A741");
                    inputItemObj.DbAreaUsage.Add("Update");
                    inputItemObj.NoOfDbAreas++;
                }
                if (inputItemObj.SchemaName == string.Empty)
                {
                    inputItemObj.SchemaName = Constants.CommonUseItem.schemaName;
                }
            }

            return servieObj.WriteAllDivision(inputItemObj);
        }

        private void sendemail()
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("goganadeepak@gmail.com");
                message.To.Add(new MailAddress("deepakgogana@gmail.com"));
                message.Subject = "Test";
                message.Body = "Content";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("goganadeepak@gmail.com", "Chotu@4131");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        #region Basic Details Tab
        
        /// <summary>
        /// This will be called when Restart radion button is checked
        /// This will enable the combo box to select database/file restart type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioRestart_CheckedChanged(object sender, EventArgs e)
        {
            comboRestart.Visible = true;
            comboRestart.SelectedItem = Constants.RestartType.Database.ToString();
        }

        /// <summary>
        /// This will be called when NonRestart radion button is checked
        /// This will disable the combo box which select database/file restart type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioNonRestart_CheckedChanged(object sender, EventArgs e)
        {
            comboRestart.Visible = false;
            comboRestart.SelectedItem = string.Empty;
        }
        #endregion

        #region Input File processing
        
        /// <summary>
        /// Will be called when user clicks on Add button on Input Files Tab
        /// This will add a new file in InputFileRepository list and also show the file details on gridViewInputFiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInputFile_Click(object sender, EventArgs e)
        {
            if (txtInputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.File_Name_Filed_Empty_Message,
                    Resources.File_Name_Empty_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (_nInputFiles == 10)
            {
                MessageBox.Show(
                    Resources.File_Limit_Message,
                    Resources.File_Limit_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                List<FileData> result =
                    InputFileRepository.obj.Where(p => String.Compare(p.fileName, txtInputFileName.Text.Trim(), true) == 0).ToList();
                if (result.Count > 0)
                {
                    MessageBox.Show(
                   Resources.Already_Exists_Message,
                   Resources.Already_Exists_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
                else
                {
                    _nInputFiles++;
                    string _fileType;
                    string _accessType;
                    if (radioBtnInpSeqn.Checked)
                    {
                        _fileType = "Sequential";
                        _accessType = " ";
                    }
                    else
                    {
                        _fileType = "Indexed";
                        _accessType = comboInpAccType.SelectedItem.ToString();
                    }

                    txtInputFileLayout.Text = Utils.ReformatFileLayout(txtInputFileLayout.Text);
                    InputFileRepository.obj.Add(new FileData(txtInputFileName.Text.ToUpper(), txtInputFileDesc.Text,
                                                                  _fileType, txtInputFileLayout.Text, _accessType));
                    txtInputFileName.Text = string.Empty;
                    txtInputFileDesc.Text = string.Empty;
                    radioBtnInpSeqn.Checked = true;
                    txtBoxInpCopybook.Text = string.Empty;
                    comboInpAccType.SelectedItem = null;
                    txtInputFileLayout.Text = string.Empty;
                    inputFileLayout = new StringBuilder();
                }
                gridViewInputFiles.Visible = true;
                var bindingList = new BindingList<FileData>(InputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewInputFiles.DataSource = bindingSource;
                gridViewInputFiles.Columns[3].Visible = false;
                gridViewInputFiles.Columns[4].Visible = false;
                this.gridViewInputFiles.Refresh();
            }
        }

        /// <summary>
        /// Will be called when user clicks on AddCopyBook button on Input Files Tab
        /// this will add the copybook selected to the file layout and also show it to txtInputFileLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCopybook_Click(object sender, EventArgs e)
        {
            if (txtBoxInpCopybook.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.Enter_CopyBook_Message,
                    Resources.Enter_CopyBook_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtInputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.File_Name_Filed_Empty_Message,
                    Resources.File_Name_Empty_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if (!copyBookList.Contains(txtBoxInpCopybook.Text.Trim().ToUpper()))
                {
                    System.Windows.Forms.DialogResult result = MessageBox.Show(
                        Resources.New_CopyBook_Message,
                        Resources.New_CopyBook_Title,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        goto AB010;
                    }
                    newCopyBookList.Add(txtBoxInpCopybook.Text.Trim().ToUpper());
                    copyBookList.Add(txtBoxInpCopybook.Text.Trim().ToUpper());
                    CopyBookCollection.Add(txtBoxInpCopybook.Text.Trim().ToUpper());
                }
                if (txtInputFileLayout.Text != "")
                {
                    txtInputFileLayout.Text = Utils.ReformatFileLayout(txtInputFileLayout.Text);
                    inputFileLayout = new StringBuilder(txtInputFileLayout.Text);
                }
                inputFileLayout.Append(Environment.NewLine);
                inputFileLayout.Append(Utils.BuildAreaA(String.Format("COPY " + txtBoxInpCopybook.Text.Trim().ToUpper() + ".")));
                txtInputFileLayout.Text = inputFileLayout.ToString();
                txtBoxInpCopybook.Text = string.Empty;
            }
        AB010:
            { }
        }

        /// <summary>
        /// Will be called when user text on txtInputFileName textbox has been changed
        /// this will append the text entered on text box to a string and also show it to txtInputFileLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {
            if (txtInputFileName.Text != "" & txtInputFileLayout.Text == "")
            {
                inputFileLayout.Append(Utils.BuildAreaA(string.Format("FD " + txtInputFileName.Text.ToString().ToUpper() + ".")));
                txtInputFileLayout.Text = inputFileLayout.ToString();
            }
            else if (txtInputFileLayout.Text.Trim().StartsWith("FD"))
            {
                inputFileLayout = new StringBuilder(txtInputFileLayout.Text);
                StringReader sr = new StringReader(inputFileLayout.ToString());
                inputFileLayout.Remove(0, sr.ReadLine().Length);
                inputFileLayout.Insert(0, Utils.BuildAreaA(string.Format("FD " + txtInputFileName.Text.ToString().ToUpper() + ".")));
                if (inputFileLayout.ToString().Trim() == "FD .")
                {
                    inputFileLayout = new StringBuilder();
                }
                txtInputFileLayout.Text = inputFileLayout.ToString();
            }
        }

        /// <summary>
        /// Will be called when Sequential file radio button is checked on Input File Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnSeq_CheckedChanged(object sender, EventArgs e)
        {
            comboInpAccType.Visible = false;
            comboInpAccType.SelectedItem = null;
        }

        /// <summary>
        /// Will be called when Indexed file radio button is checked on Input File Tab
        /// This will enable the access type comboBox to be visile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnInd_CheckedChanged(object sender, EventArgs e)
        {
            comboInpAccType.Visible = true;
            comboInpAccType.SelectedItem = "Dynamic";
        }

        /// <summary>
        /// Will be called when CopyBook Layout radio button is checked on Input File Tab
        /// this will disable the TextFile Layout text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtnInpCopyBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInputFileLayout.Text != "")
                {
                    txtInputFileLayout.Text = Utils.ReformatFileLayout(txtInputFileLayout.Text);
                    txtInputFileLayout.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    Resources.System_Error_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Will be called when CopyBook Layout radio button is checked on Input File Tab
        /// this will enable the TextFile Layout text box to edit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtnInpUserDefined_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInputFileLayout.Text == "")
                {
                    MessageBox.Show(Resources.File_Name_Filed_Empty_Message,
                        Resources.File_Name_Empty_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    txtInputFileLayout.Text = Utils.ReformatFileLayout(txtInputFileLayout.Text);
                    txtInputFileLayout.Enabled = true;
                    txtInputFileLayout.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    Resources.System_Error_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This will be called when any cell is clicked on gridViewInputFiles
        /// This will show all details saved on that row to the textboxes for user to modify/delete the row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewInputFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _inputRowSelected = true;
            txtInputFileName.Text = gridViewInputFiles.SelectedRows[0].Cells[0].Value.ToString();
            txtInputFileDesc.Text = gridViewInputFiles.SelectedRows[0].Cells[1].Value.ToString();
            if (gridViewInputFiles.SelectedRows[0].Cells[2].Value.ToString() == "Sequential")
            {
                radioBtnInpSeqn.Checked = true;
            }
            else
            {
                radioBtnInpIndex.Checked = true;
                comboInpAccType.Visible = true;
                comboInpAccType.SelectedItem =
                    InputFileRepository.obj.ElementAt(gridViewInputFiles.SelectedRows[0].Index).accessType.ToString();
            }

            txtInputFileLayout.Text = InputFileRepository.obj.ElementAt(gridViewInputFiles.SelectedRows[0].Index).fileLayout.ToString();
        }

        /// <summary>
        /// Will be called when user clicks on Modify button on Input Files Tab
        /// This will modify the file selected from gridViewInputFiles and save updated data in InputFileRepository list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyInputFile_Click(object sender, EventArgs e)
        {
            if (!_inputRowSelected && txtInputFileName.Text.Trim() != "")
            {
                MessageBox.Show(
                    Resources.Add_The_File_Message,
                    Resources.Add_The_File_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtInputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.No_Row_Selected_Message,
                    Resources.No_Row_Selected_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                List<FileData> result =
                    InputFileRepository.obj.Where(p => String.Compare(p.fileName.Trim(), txtInputFileName.Text.Trim(), true) == 0).ToList();
                if (result.Count > 0 &&
                    gridViewInputFiles.SelectedRows[0].Cells[0].Value.ToString().Trim() != txtInputFileName.Text.Trim())
                {
                    MessageBox.Show(
                   Resources.Already_Exists_Message,
                   Resources.Already_Exists_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                    txtInputFileName.Text = string.Empty;
                    txtInputFileDesc.Text = string.Empty;
                    radioBtnInpSeqn.Checked = true;
                    txtBoxInpCopybook.Text = string.Empty;
                    comboInpAccType.SelectedItem = null;
                    txtInputFileLayout.Text = string.Empty;
                    inputFileLayout = new StringBuilder();
                }
                else
                {
                    string _fileType;
                    string _accessType;
                    if (radioBtnInpSeqn.Checked)
                    {
                        _fileType = "Sequential";
                        _accessType = " ";
                    }
                    else
                    {
                        _fileType = "Indexed";
                        _accessType = comboInpAccType.SelectedItem.ToString();
                    }

                    txtInputFileLayout.Text = Utils.ReformatFileLayout(txtInputFileLayout.Text);
                    InputFileRepository.obj.RemoveAt(gridViewInputFiles.SelectedRows[0].Index);
                    InputFileRepository.obj.Insert(gridViewInputFiles.SelectedRows[0].Index,
                                            new FileData(txtInputFileName.Text.ToUpper(), txtInputFileDesc.Text,
                                                             _fileType, txtInputFileLayout.Text, _accessType));
                    txtInputFileName.Text = string.Empty;
                    txtInputFileDesc.Text = string.Empty;
                    radioBtnInpSeqn.Checked = true;
                    txtBoxInpCopybook.Text = string.Empty;
                    comboInpAccType.SelectedItem = null;
                    txtInputFileLayout.Text = string.Empty;
                    inputFileLayout = new StringBuilder();
                }
            }
            if (_nInputFiles != 0)
            {
                var bindingList = new BindingList<FileData>(InputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewInputFiles.DataSource = bindingSource;
                gridViewInputFiles.Columns[3].Visible = false;
                gridViewInputFiles.Columns[4].Visible = false;
                this.gridViewInputFiles.Refresh();
                _inputRowSelected = false;
            }
        }

        /// <summary>
        /// Will be called when user clicks on Delete button on Input Files Tab
        /// This will delete the file selected from gridViewInputFiles and remove its entry from InputFileRepository list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteInputFile_Click(object sender, EventArgs e)
        {
            if (!_inputRowSelected && txtInputFileName.Text.Trim() != "")
            {
                MessageBox.Show(
                    Resources.Add_The_File_Message,
                    Resources.Add_The_File_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtInputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.No_Row_Selected_Message,
                    Resources.No_Row_Selected_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                InputFileRepository.obj.RemoveAt(gridViewInputFiles.SelectedRows[0].Index);
                txtInputFileName.Text = string.Empty;
                txtInputFileDesc.Text = string.Empty;
                radioBtnInpSeqn.Checked = true;
                txtBoxInpCopybook.Text = string.Empty;
                comboInpAccType.SelectedItem = null;
                txtInputFileLayout.Text = string.Empty;
                inputFileLayout = new StringBuilder();
                _nInputFiles--;
            }
            if (_nInputFiles != 0)
            {
                var bindingList = new BindingList<FileData>(InputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewInputFiles.DataSource = bindingSource;
                gridViewInputFiles.Columns[3].Visible = false;
                gridViewInputFiles.Columns[4].Visible = false;
                this.gridViewInputFiles.Refresh();
                _inputRowSelected = false;
            }
            else
            {
                gridViewInputFiles.Visible = false;
            }
        }

        #endregion

        #region Output File processing

        /// <summary>
        /// Will be called when user clicks on Add button on Output Files Tab
        /// This will add a new file in OutputFileRepository list and also show the file details on gridViewOutputFiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOutputFile_Click(object sender, EventArgs e)
        {
            if (txtOutputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.File_Name_Filed_Empty_Message,
                    Resources.File_Name_Empty_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (_nOutputFiles == 10)
            {
                MessageBox.Show(
                    Resources.File_Limit_Message,
                    Resources.File_Limit_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                List<FileData> result =
                    OutputFileRepository.obj.Where(p => String.Compare(p.fileName, txtOutputFileName.Text.Trim(), true) == 0).ToList();
                if (result.Count > 0)
                {
                    MessageBox.Show(
                   Resources.Already_Exists_Message,
                   Resources.Already_Exists_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
                else
                {
                    _nOutputFiles++;
                    string _fileType;
                    string _accessType;
                    if (radioBtnOutSeqn.Checked)
                    {
                        _fileType = "Sequential";
                        _accessType = " ";
                    }
                    else
                    {
                        _fileType = "Indexed";
                        _accessType = comboOutAccType.SelectedItem.ToString();
                    }

                    txtOutputFileLayout.Text = Utils.ReformatFileLayout(txtOutputFileLayout.Text);
                    OutputFileRepository.obj.Add(new FileData(txtOutputFileName.Text.ToUpper(), txtOutputFileDesc.Text,
                                                                  _fileType, txtOutputFileLayout.Text, _accessType));
                    txtOutputFileName.Text = string.Empty;
                    txtOutputFileDesc.Text = string.Empty;
                    radioBtnOutSeqn.Checked = true;
                    txtBoxOutCopybook.Text = string.Empty;
                    comboOutAccType.SelectedItem = null;
                    txtOutputFileLayout.Text = string.Empty;
                    outputFileLayout = new StringBuilder();
                }
            }
            gridViewOutputFiles.Visible = true;
            var bindingList = new BindingList<FileData>(OutputFileRepository.obj);
            var bindingSource = new BindingSource(bindingList, null);
            this.gridViewOutputFiles.DataSource = bindingSource;
            gridViewOutputFiles.Columns[3].Visible = false;
            gridViewOutputFiles.Columns[4].Visible = false;
            this.gridViewOutputFiles.Refresh();

        }

        /// <summary>
        /// Will be called when user clicks on AddCopyBook button on Output Files Tab
        /// this will add the copybook selected to the file layput and also show it to txtOutputFileLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOutCopybook_Click(object sender, EventArgs e)
        {
            if (txtBoxOutCopybook.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.Enter_CopyBook_Message,
                    Resources.Enter_CopyBook_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtOutputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.File_Name_Filed_Empty_Message,
                    Resources.File_Name_Empty_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else 
            {
                if (!copyBookList.Contains(txtBoxOutCopybook.Text.Trim().ToUpper()))
                {
                    System.Windows.Forms.DialogResult result  = MessageBox.Show(
                        Resources.New_CopyBook_Message,
                        Resources.New_CopyBook_Title,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning); 
                    if (result == System.Windows.Forms.DialogResult.Cancel )
                    {
                        goto AB010;
                    }
                    newCopyBookList.Add(txtBoxOutCopybook.Text.Trim().ToUpper());
                    copyBookList.Add(txtBoxOutCopybook.Text.Trim().ToUpper());
                    CopyBookCollection.Add(txtBoxOutCopybook.Text.Trim().ToUpper());
                }
                if (txtOutputFileLayout.Text != "")
                {
                    txtOutputFileLayout.Text = Utils.ReformatFileLayout(txtOutputFileLayout.Text);
                    outputFileLayout = new StringBuilder(txtOutputFileLayout.Text);
                }
                outputFileLayout.Append(Environment.NewLine);
                outputFileLayout.Append(Utils.BuildAreaA(String.Format("COPY " + txtBoxOutCopybook.Text.Trim().ToUpper() + ".")));
                txtOutputFileLayout.Text = outputFileLayout.ToString();
                txtBoxOutCopybook.Text = string.Empty;
            }
        AB010:
            { }
        }

        /// <summary>
        /// Will be called when user text on txtOutputFileName textbox has been changed
        /// this will append the text entered on text box to a string and also show it to outputFileLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtOutputFileName.Text != "" & txtOutputFileLayout.Text == "")
            {
                outputFileLayout.Append(Utils.BuildAreaA(string.Format("FD " + txtOutputFileName.Text.ToString().ToUpper() + ".")));
                txtOutputFileLayout.Text = outputFileLayout.ToString();
            }
            else if (txtOutputFileLayout.Text.Trim().StartsWith("FD"))
            {
                outputFileLayout = new StringBuilder(txtOutputFileLayout.Text);
                StringReader sr = new StringReader(outputFileLayout.ToString());
                outputFileLayout.Remove(0, sr.ReadLine().Length);
                outputFileLayout.Insert(0, Utils.BuildAreaA(string.Format("FD " + txtOutputFileName.Text.ToString().ToUpper() + ".")));
                if (outputFileLayout.ToString().Trim() == "FD .")
                {
                    outputFileLayout = new StringBuilder();
                }
                txtOutputFileLayout.Text = outputFileLayout.ToString();
            }
        }

        /// <summary>
        /// Will be called when Sequential file radio button is checked on Output File Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnOutSeqn_CheckedChanged(object sender, EventArgs e)
        {
            comboOutAccType.Visible = false;
            comboOutAccType.SelectedItem = null;
        }

        /// <summary>
        /// Will be called when Indexed file radio button is checked on Output File Tab
        /// This will enable the access type comboBox to be visile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnOutIndex_CheckedChanged(object sender, EventArgs e)
        {
            comboOutAccType.Visible = true;
            comboOutAccType.SelectedItem = "Dynamic";
        }

        /// <summary>
        /// Will be called when CopyBook Layout radio button is checked on Output File Tab
        /// this will disable the TextFile Layout text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtnOutCopyBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOutputFileLayout.Text != "")
                {
                    txtOutputFileLayout.Text = Utils.ReformatFileLayout(txtOutputFileLayout.Text);
                    txtOutputFileLayout.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Resources.System_Error_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Will be called when CopyBook Layout radio button is checked on Output File Tab
        /// this will enable the TextFile Layout text box to edit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radiobtnOutUserDefined_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOutputFileLayout.Text == "")
                {
                    MessageBox.Show(Resources.File_Name_Filed_Empty_Message,
                        Resources.File_Name_Empty_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    txtOutputFileLayout.Text = Utils.ReformatFileLayout(txtOutputFileLayout.Text);
                    txtOutputFileLayout.Enabled = true;
                    txtOutputFileLayout.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Resources.System_Error_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This will be called when any cell is clicked on gridViewOutputFile
        /// This will show all details saved on that row to the textboxes for user to modify/delete the row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewOutputFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _outputRowSelected = true;
            txtOutputFileName.Text = gridViewOutputFiles.SelectedRows[0].Cells[0].Value.ToString();
            txtOutputFileDesc.Text = gridViewOutputFiles.SelectedRows[0].Cells[1].Value.ToString();
            if (gridViewOutputFiles.SelectedRows[0].Cells[2].Value.ToString() == "Sequential")
            {
                radioBtnOutSeqn.Checked = true;
            }
            else
            {
                radioBtnOutIndex.Checked = true;
                comboOutAccType.Visible = true;
                comboOutAccType.SelectedItem =
                    OutputFileRepository.obj.ElementAt(gridViewOutputFiles.SelectedRows[0].Index).accessType.ToString();
            }

            txtOutputFileLayout.Text = OutputFileRepository.obj.ElementAt(gridViewOutputFiles.SelectedRows[0].Index).fileLayout.ToString();
        }

        /// <summary>
        /// Will be called when user clicks on Modify button on Output Files Tab
        /// This will modify the file selected from gridViewOutputFiles and save updated data in OutputFileRepository list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyOutputFile_Click(object sender, EventArgs e)
        {
            if (!_outputRowSelected &&  txtOutputFileName.Text.Trim() != "")
            {
                MessageBox.Show(
                    Resources.Add_The_File_Message,
                    Resources.Add_The_File_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtOutputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.No_Row_Selected_Message,
                    Resources.No_Row_Selected_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                List<FileData> result =
                    OutputFileRepository.obj.Where(p => String.Compare(p.fileName.Trim(), txtOutputFileName.Text.Trim(), true) == 0).ToList();
                if (result.Count > 0 &&
                    gridViewOutputFiles.SelectedRows[0].Cells[0].Value.ToString().Trim() != txtOutputFileName.Text.Trim())
                {
                    MessageBox.Show(
                   Resources.Already_Exists_Message,
                   Resources.Already_Exists_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                    txtOutputFileName.Text = string.Empty;
                    txtOutputFileDesc.Text = string.Empty;
                    radioBtnOutSeqn.Checked = true;
                    txtBoxOutCopybook.Text = string.Empty;
                    comboOutAccType.SelectedItem = null;
                    txtOutputFileLayout.Text = string.Empty;
                    outputFileLayout = new StringBuilder();
                }
                else
                {
                    string _fileType;
                    string _accessType;
                    if (radioBtnOutSeqn.Checked)
                    {
                        _fileType = "Sequential";
                        _accessType = " ";
                    }
                    else
                    {
                        _fileType = "Indexed";
                        _accessType = comboOutAccType.SelectedItem.ToString();
                    }

                    txtOutputFileLayout.Text = Utils.ReformatFileLayout(txtOutputFileLayout.Text);
                    OutputFileRepository.obj.RemoveAt(gridViewOutputFiles.SelectedRows[0].Index);
                    OutputFileRepository.obj.Insert(gridViewOutputFiles.SelectedRows[0].Index,
                                            new FileData(txtOutputFileName.Text.ToUpper(), txtOutputFileDesc.Text,
                                                             _fileType, txtOutputFileLayout.Text, _accessType));
                    txtOutputFileName.Text = string.Empty;
                    txtOutputFileDesc.Text = string.Empty;
                    radioBtnOutSeqn.Checked = true;
                    txtBoxOutCopybook.Text = string.Empty;
                    comboOutAccType.SelectedItem = null;
                    txtOutputFileLayout.Text = string.Empty;
                    outputFileLayout = new StringBuilder();
                }
            }
            if (_nOutputFiles != 0)
            {
                var bindingList = new BindingList<FileData>(OutputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewOutputFiles.DataSource = bindingSource;
                gridViewOutputFiles.Columns[3].Visible = false;
                gridViewOutputFiles.Columns[4].Visible = false;
                this.gridViewOutputFiles.Refresh();
                _outputRowSelected = false;
            }
        }

        /// <summary>
        /// Will be called when user clicks on Delete button on Output Files Tab
        /// This will delete the file selected from gridViewOutputFiles and remove its entry from OutputFileRepository list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteOutputFile_Click(object sender, EventArgs e)
        {
            if (!_outputRowSelected && txtOutputFileName.Text.Trim() != "")
            {
                MessageBox.Show(
                    Resources.Add_The_File_Message,
                    Resources.Add_The_File_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtOutputFileName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.No_Row_Selected_Message,
                    Resources.No_Row_Selected_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                OutputFileRepository.obj.RemoveAt(gridViewOutputFiles.SelectedRows[0].Index);
                txtOutputFileName.Text = string.Empty;
                txtOutputFileDesc.Text = string.Empty;
                radioBtnOutSeqn.Checked = true;
                txtBoxOutCopybook.Text = string.Empty;
                comboOutAccType.SelectedItem = null;
                txtOutputFileLayout.Text = string.Empty;
                outputFileLayout = new StringBuilder();
                _nOutputFiles--;
            }
            if (_nOutputFiles != 0)
            {
                var bindingList = new BindingList<FileData>(OutputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewOutputFiles.DataSource = bindingSource;
                gridViewOutputFiles.Columns[3].Visible = false;
                gridViewOutputFiles.Columns[4].Visible = false;
                this.gridViewOutputFiles.Refresh();
                _outputRowSelected = false;
            }
            else
            {
                gridViewOutputFiles.Visible = false;
            }
        }

        #endregion

        #region Database Records processing

        /// <summary>
        /// This will be called when user clicks on "Add" butotn in Database section, it will add the database record in 
        /// List collection DatabaseRepository also it will show this list of records in gridview gridViewDBRecords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDBRec_Click(object sender, EventArgs e)
        {
            if (DatabaseRepository.dbRepository.Exists(p => p.DBRecName == txtDBRecName.Text.ToUpper().Trim()))
            {
                MessageBox.Show(
                    Resources.DBRec_Already_Exists_Message,
                    Resources.DBRec_Already_Exists_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtDBRecName.Text = string.Empty;
            }
            else if (txtDBRecName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.Enter_DBRec_Message,
                    Resources.Enter_DBRec_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                _nDbRecord++;
                DatabaseRepository.dbRepository.Add(new DatabaseName(txtDBRecName.Text.ToUpper().Trim()));
                gridViewDBRecords.Visible = true;
                txtDBRecName.Text = string.Empty;
                var bindingList = new BindingList<DatabaseName>(DatabaseRepository.dbRepository);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewDBRecords.DataSource = bindingSource;
                this.gridViewDBRecords.Refresh();
            }
        }

        /// <summary>
        /// This will be calles when user clicks on any cell of gridViewDBRecords. It will check if user has right clicked on
        /// cell then it will show a "Delete" button on the cell to give an option to delete the database record added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDBRecords_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedRow = gridViewDBRecords.HitTest(e.X, e.Y);
                if (selectedRow.RowIndex != -1)
                {
                    this.gridViewDBRecords.ClearSelection();
                    this.gridViewDBRecords.Rows[selectedRow.RowIndex].Selected = true;
                    DeleteDBRecord.Show(gridViewDBRecords, new Point(e.X, e.Y));
                }
            }
        }

        /// <summary>
        /// This will be called when used has clicked on "Delete" button created from above method and it will delete the
        /// cell selected and also remove that entry from list collection DatabaseRepository
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDBRecord_Click(object sender, System.EventArgs e)
        {
            if (_nDbRecord != 0)
            {
                _nDbRecord--;
                DatabaseRepository.dbRepository.RemoveAt(gridViewDBRecords.SelectedRows[0].Index);
                var bindingList = new BindingList<DatabaseName>(DatabaseRepository.dbRepository);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewDBRecords.DataSource = bindingSource;
                this.gridViewDBRecords.Refresh();
                this.gridViewDBRecords.ClearSelection();
                if (_nDbRecord == 0)
                {
                    gridViewDBRecords.Visible = false;
                }
            }
        }

        /// <summary>
        /// This will be called when user clicks on "Add" butotn in Area section, it will add the Area name in 
        /// List collection AreaRepository also it will show this list of records in gridview gridViewAreaNames
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddArea_Click(object sender, EventArgs e)
        {
            if (AreaRepository.areaRepository.Exists(p => p.AreaNames == txtAreaName.Text.ToUpper().Trim()))
            {
                MessageBox.Show(
                    Resources.Area_Already_Exists_Message,
                    Resources.Area_Already_Exists_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtAreaName.Text = string.Empty;
            }
            else if (txtAreaName.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.Enter_AreaName_Message,
                    Resources.Enter_AreaName_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                _nAreaNames++;
                AreaRepository.areaRepository.Add(new DBAreaData(txtAreaName.Text.ToUpper().Trim(), 
                    comboUsageMode.SelectedItem.ToString().Trim()));
                gridViewAreaNames.Visible = true;
                txtAreaName.Text = string.Empty;
                comboUsageMode.SelectedIndex = 0;
                var bindingList = new BindingList<DBAreaData>(AreaRepository.areaRepository);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewAreaNames.DataSource = bindingSource;
                this.gridViewAreaNames.Refresh();
            }

        }

        /// <summary>
        /// This will be calles when user clicks on any cell of gridViewAreaNames. It will check if user has right clicked on
        /// cell then it will show a "Delete" button on the cell to give an option to delete the database record added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewAreaNames_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedRow = gridViewAreaNames.HitTest(e.X, e.Y);
                if (selectedRow.RowIndex != -1)
                {
                    this.gridViewAreaNames.ClearSelection();
                    this.gridViewAreaNames.Rows[selectedRow.RowIndex].Selected = true;
                    DeleteArea.Show(gridViewAreaNames, new Point(e.X, e.Y));
                }
            }
        }

        /// <summary>
        /// This will be called when used has clicked on "Delete" button created from above method and it will delete the
        /// cell selected and also remove that entry from list collection AreaRepository
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteArea_Click(object sender, System.EventArgs e)
        {
            if (_nAreaNames != 0)
            {
                _nAreaNames--;
                AreaRepository.areaRepository.RemoveAt(gridViewAreaNames.SelectedRows[0].Index);
                var bindingList = new BindingList<DBAreaData>(AreaRepository.areaRepository);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewAreaNames.DataSource = bindingSource;
                this.gridViewAreaNames.Refresh();
                this.gridViewAreaNames.ClearSelection();
                if (_nAreaNames == 0)
                {
                    gridViewAreaNames.Visible = false;
                }
            }
        }
        #endregion

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                Resources.System_Error_Message + ex.Message, 
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        //private void ClearTextBox(object sender, EventArgs e)
        //{
        //    ((System.Windows.Forms.TextBox)sender).Clear();
        //}

    }
}

