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

namespace CobolStudio.Main.Forms
{
    public partial class CobolStudio : Form
    {

        #region Fields required for Input Files Text Box Creation

        private int _nInputFiles;
        private int _xInputPos = 10;
        private int _yInputPos = 55;
        private int _xInputDescPos = 235;
        private int _yInputDescPos = 55;

        #endregion

        #region Fields required for OutPut Files Text Box Creation

        private int _nOutputFiles;
        private int _xOutputPos = 10;
        private int _yOutputPos = 55;
        private int _xOutputDescPos = 235;
        private int _yOutputDescPos = 55;

        #endregion

        private int _nDbRecord;
        private int _xDbRecPos = 20;
        private int _yDbRecPos = 40;
        private int _inputtxtIndex;
        private string[] _inputFileNames = new string[10];
        private int _outputtxtIndex;
        private string[] _outputFileNames = new string[10];
        //InputFileData inputData = new InputFileData();
        StringBuilder inputFileLayout = new StringBuilder();
        private bool rowSelected;

        public CobolStudio()
        {
            InitializeComponent();
        }

        private void btnCodeGenerate_Click(object sender, EventArgs e)
        {
            ProcessAllDivisions();
            //MessageBox.Show(
            //    Resources.Code_Generation_Message,
            //    Resources.Code_Generation_Message_Title,
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information); 
        }

        private void ProcessAllDivisions()
        {
            DivisonProcessorService servieObj = new DivisonProcessorService();
            DivisionInputItems inputItemObj = new DivisionInputItems();
            inputItemObj.ProgramId = txtName.Text.ToUpper();
            inputItemObj.VersionNumber = txtVersion.Text.ToUpper();
            inputItemObj.AuthorName = txtAuthor.Text.ToLower();
            inputItemObj.CreationDate = DateTime.Now;
            inputItemObj.CodeDescription = txtDescription.Text;

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

            inputItemObj.NoOfOutputFIles = _nOutputFiles;
            if (_nOutputFiles > 0)
            {
                inputItemObj.OutputFileNames = outputFileArray.Where(p => p != null).Select(p => p.Text).ToList();
                inputItemObj.OutputFileTypes = outputFileType.Where(p => p != null).Select(p => p.SelectedItem.ToString()).ToList();
                inputItemObj.OutputFileDescriptions =
                    outputFileDescArray.Where(p => p != null).Select(p => p.Text).ToList();
            }

            inputItemObj.NoOfDbRecords = _nDbRecord;
            if (_nDbRecord > 0)
            {
                inputItemObj.DbRecordNames = DBRecordArray.Where(p => p != null).Select(p => p.Text).ToList();
            }

            inputItemObj.RestartInd = radioRestart.Checked;
            if (inputItemObj.RestartInd)
            {
                inputItemObj.RestartType = comboRestart.SelectedText;
            }
            System.IO.File.WriteAllText(@"C:\File\Cobol.cob", servieObj.WriteAllDivision(inputItemObj));
        }

        private void ClearTextBox(object sender, EventArgs e)
        {
            ((System.Windows.Forms.TextBox)sender).Clear();
        }

        //public void EnterInputTextBox(object sender, System.EventArgs e)
        //{
        //    _inputtxtIndex = (int)((System.Windows.Forms.TextBox)sender).Tag; // number of the TextBox
        //    _inputFileNames[_inputtxtIndex] = "";
        //_inputFileNames[_inputtxtIndex] = inputFileArray[_inputtxtIndex].Text;
        //}

        //public void InputTextChange(object sender, System.EventArgs e)
        //{
        //    _inputFileNames[_inputtxtIndex] = inputFileArray[_inputtxtIndex].Text;
        //}

        private void btnAddOutputFile_Click(object sender, EventArgs e)
        {
            _nOutputFiles++;
            if (_nOutputFiles > 10)
            {
                MessageBox.Show(
                    Resources.File_Limit_Message,
                    Resources.File_Limit_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _nOutputFiles--;
            }
            else
            {
                // Create array for Output Files Text Box
                if (_nOutputFiles == 1)
                {
                    outputFileArray = new System.Windows.Forms.TextBox[11];
                    outputFileType = new System.Windows.Forms.ComboBox[11];
                    outputFileDescArray = new System.Windows.Forms.TextBox[11];
                }
                outputFileArray[_nOutputFiles] = new System.Windows.Forms.TextBox
                {
                    Tag = _nOutputFiles,
                    AutoSize = false,
                    Width = 115,
                    Height = 24,
                    BackColor = System.Drawing.SystemColors.Info
                };
                outputFileArray[_nOutputFiles].Text = Constants.CommonUseItem.OutputFile +
                                                      outputFileArray[_nOutputFiles].Tag;
                outputFileArray[_nOutputFiles].Left = _xOutputPos;
                outputFileArray[_nOutputFiles].Top = _yOutputPos;
                // Create ComboBox for dropdownmenu
                outputFileType[_nOutputFiles] = new System.Windows.Forms.ComboBox
                {
                    DroppedDown = true,
                    AutoSize = false,
                    Width = 90,
                    Height = 24
                };
                outputFileType[_nOutputFiles].Items.AddRange(new object[] { "Sequential", "Indexed" });
                outputFileType[_nOutputFiles].SelectedItem = "Sequential";
                outputFileType[_nOutputFiles].Left = _xOutputPos + 125;
                outputFileType[_nOutputFiles].Top = _yOutputPos;
                grpOutputFiles.Controls.Add(outputFileType[_nOutputFiles]);
                // ComboBox has been created
                _yOutputPos = _yOutputPos + outputFileArray[_nOutputFiles].Height + 12;
                grpOutputFiles.Controls.Add(outputFileArray[_nOutputFiles]);
                // the Event of Click on Text Box
                outputFileArray[_nOutputFiles].Click += new System.EventHandler(ClearTextBox);
                // the Event of Enter (TextBox)
                outputFileArray[_nOutputFiles].Enter += new System.EventHandler(EnterOutputTextBox);
                // the Event of TextChanged (TextBox) 
                outputFileArray[_nOutputFiles].TextChanged += new System.EventHandler(OutputTextChange);

                // Create array for Input Files Description Text Box
                outputFileDescArray[_nOutputFiles] = new System.Windows.Forms.TextBox
                {
                    Tag = _nOutputFiles,
                    AutoSize = false,
                    Width = 260,
                    Height = 24,
                    BackColor = System.Drawing.SystemColors.Info
                };
                //textInput.Visible = !textInput.Visible;
                outputFileDescArray[_nOutputFiles].Text = Constants.CommonUseItem.OutputFile +
                                                          outputFileDescArray[_nOutputFiles].Tag +
                                                          Constants.CommonUseItem.Description;
                outputFileDescArray[_nOutputFiles].Left = _xOutputDescPos;
                outputFileDescArray[_nOutputFiles].Top = _yOutputDescPos;
                _yOutputDescPos = _yOutputDescPos + outputFileDescArray[_nOutputFiles].Height + 12;
                grpOutputFiles.Controls.Add(outputFileDescArray[_nOutputFiles]);
                // the Event of Click on Text Box
                outputFileDescArray[_nOutputFiles].Click += new System.EventHandler(ClearTextBox);
                // the Event of Enter (TextBox)
                outputFileDescArray[_nOutputFiles].Enter += new System.EventHandler(EnterOutputTextBox);
                // the Event of TextChanged (TextBox) 
                outputFileDescArray[_nOutputFiles].TextChanged += new System.EventHandler(OutputTextChange);

            }
        }

        public void EnterOutputTextBox(object sender, System.EventArgs e)
        {
            _outputtxtIndex = (int)((System.Windows.Forms.TextBox)sender).Tag; // number of the TextBox
            _outputFileNames[_outputtxtIndex] = "";
            _outputFileNames[_outputtxtIndex] = outputFileArray[_outputtxtIndex].Text;
        }

        public void OutputTextChange(object sender, System.EventArgs e)
        {
            _outputFileNames[_outputtxtIndex] = outputFileArray[_outputtxtIndex].Text;
        }

        private void btnDeleteInputFile_Click(object sender, EventArgs e)
        {
            if (_nInputFiles != 0)
            {
                //inputFileArray[_nInputFiles].Visible = false;
                //inputFileType[_nInputFiles].Visible = false;
                //inputFileDescArray[_nInputFiles].Visible = false;
                //_yInputPos = _yInputPos - inputFileArray[_nInputFiles].Height - 12;
                //_yInputDescPos = _yInputDescPos - inputFileArray[_nInputFiles].Height - 12;
                _nInputFiles--;
            }
            else
            {
                _yInputPos = 65;
                _yInputDescPos = 65;
            }
        }

        private void btnDeleteOutputFile_Click(object sender, EventArgs e)
        {
            if (_nOutputFiles != 0)
            {
                outputFileArray[_nOutputFiles].Visible = false;
                outputFileType[_nOutputFiles].Visible = false;
                outputFileDescArray[_nOutputFiles].Visible = false;
                _yOutputPos = _yOutputPos - outputFileArray[_nOutputFiles].Height - 12;
                _yOutputDescPos = _yOutputDescPos - outputFileArray[_nOutputFiles].Height - 12;
                _nOutputFiles--;
            }
            else
            {
                _yOutputPos = 65;
                _yOutputDescPos = 65;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabCodeGenerate;
        }
        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDBRecord_Click(object sender, EventArgs e)
        {
            _nDbRecord++;
            if (_nDbRecord > 20)
            {
                MessageBox.Show(
                    Resources.DB_Rec_Limit_Message,
                    Resources.DB_Rec_Limit_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _nDbRecord--;
            }
            else
            {
                // Create array for Database Records Text Box
                if (_nDbRecord == 1)
                {
                    DBRecordArray = new System.Windows.Forms.TextBox[21];
                }
                DBRecordArray[_nDbRecord] = new System.Windows.Forms.TextBox
                {
                    Tag = _nDbRecord,
                    AutoSize = false,
                    Width = 160,
                    Height = 24,
                    BackColor = System.Drawing.SystemColors.Info
                };
                if (_yDbRecPos > 350)
                {
                    _yDbRecPos = 40;
                    _xDbRecPos = 260;
                }
                DBRecordArray[_nDbRecord].Text = Constants.CommonUseItem.DBRecord +
                                                 DBRecordArray[_nDbRecord].Tag;
                DBRecordArray[_nDbRecord].Left = _xDbRecPos;
                DBRecordArray[_nDbRecord].Top = _yDbRecPos;
                _yDbRecPos = _yDbRecPos + DBRecordArray[_nDbRecord].Height + 10;
                grpDBRecords.Controls.Add(DBRecordArray[_nDbRecord]);
                // the Event of Click on Text Box
                DBRecordArray[_nDbRecord].Click += new System.EventHandler(ClearTextBox);
                // the Event of Enter (TextBox)
                //DBRecordArray[_nDBRecord].Enter += new System.EventHandler(EnterOutputTextBox);
                // the Event of TextChanged (TextBox) 
                //DBRecordArray[_nDBRecord].TextChanged += new System.EventHandler(OutputTextChange);
            }
        }

        private void btnDeleteDBRecord_Click(object sender, EventArgs e)
        {
            if (_nDbRecord != 0)
            {
                DBRecordArray[_nDbRecord].Visible = false;
                _yDbRecPos = _yDbRecPos - DBRecordArray[_nDbRecord].Height - 10;
                if (_nDbRecord > 10)
                    _xDbRecPos = 260;
                else
                    _xDbRecPos = 20;
                _nDbRecord--;
            }
            else
            {
                _yDbRecPos = 40;
            }

        }

        private void radioRestart_CheckedChanged(object sender, EventArgs e)
        {
            comboRestart.Visible = true;
            comboRestart.SelectedItem = "Database";
        }

        private void radioNonRestart_CheckedChanged(object sender, EventArgs e)
        {
            comboRestart.Visible = false;
            comboRestart.SelectedItem = string.Empty;
        }

        private void btnAddInputFile_Click(object sender, EventArgs e)
        {
            using (InputFiles form2 = new InputFiles())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    _nInputFiles++;
                    if (_nInputFiles > 10)
                    {
                        MessageBox.Show(
                            Resources.File_Limit_Message,
                            Resources.File_Limit_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        _nInputFiles--;
                    }
                    else
                    {
                        //InputFileRepository.obj.Add(new InputFileData(txtInputFile.Text.ToUpper(), txtInputFileDesc.Text, comboInputFileType.Text));
                        txtInputFile.Text = "";
                        txtInputFileDesc.Text = "";
                        //comboInputFileType.Text = "";
                        comboCopybooks.SelectedItem = null;
                        txtFileLayout.Text = "";
                    }
                }
            }
            var bindingList = new BindingList<InputFileData>(InputFileRepository.obj);
            var bindingSource = new BindingSource(bindingList, null);
            this.gridViewInputFiles.DataSource = bindingSource;
            this.gridViewInputFiles.Refresh();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (txtInputFile.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.Input_Filed_Empty_Message,
                    Resources.Input_Filed_Empty_Title,
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
                List<InputFileData> result = 
                    InputFileRepository.obj.Where(p=>String.Compare(p.fileName,txtInputFile.Text.Trim(),true)==0).ToList();
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
                    if (radioBtnSeq.Checked)
                    {
                        _fileType = "Sequential";
                        _accessType = " ";
                    }
                    else
                    {
                        _fileType = "Indexed";
                        _accessType = comboAccessType.SelectedItem.ToString();
                    }

                    InputFileRepository.obj.Add(new InputFileData(txtInputFile.Text.ToUpper(), txtInputFileDesc.Text,
                                                                  _fileType, txtFileLayout.Text, _accessType));
                    txtInputFile.Text = string.Empty;
                    txtInputFileDesc.Text = string.Empty;
                    radioBtnSeq.Checked = true;
                    comboCopybooks.SelectedItem = null;
                    comboAccessType.SelectedItem = null;
                    txtFileLayout.Text = string.Empty;
                    inputFileLayout = new StringBuilder();
                }
            }
            gridViewInputFiles.Visible = true;
            var bindingList = new BindingList<InputFileData>(InputFileRepository.obj);
            var bindingSource = new BindingSource(bindingList, null);
            this.gridViewInputFiles.DataSource = bindingSource;
            gridViewInputFiles.Columns[3].Visible = false;
            gridViewInputFiles.Columns[4].Visible = false;
            this.gridViewInputFiles.Refresh();
        }

        private void gridViewInputFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelected = true;
            txtInputFile.Text = gridViewInputFiles.SelectedRows[0].Cells[0].Value.ToString();
            txtInputFileDesc.Text = gridViewInputFiles.SelectedRows[0].Cells[1].Value.ToString();
            if (gridViewInputFiles.SelectedRows[0].Cells[2].Value.ToString() == "Sequential")
            {
                radioBtnSeq.Checked = true;
            }
            else
            {
                radioBtnInd.Checked = true;
                comboAccessType.Visible = true;
                comboAccessType.SelectedItem =
                    InputFileRepository.obj.ElementAt(gridViewInputFiles.SelectedRows[0].Index).accessType.ToString();
            }

            txtFileLayout.Text = InputFileRepository.obj.ElementAt(gridViewInputFiles.SelectedRows[0].Index).fileLayout.ToString();
        }

        private void btnAddCopybook_Click(object sender, EventArgs e)
        {
            if (comboCopybooks.SelectedItem == null)
            {
                MessageBox.Show(
                    Resources.Code_Generation_Message,
                    Resources.Code_Generation_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if (txtFileLayout.Text != "")
                {
                    inputFileLayout = new StringBuilder(txtFileLayout.Text);
                }
                inputFileLayout.Append(Environment.NewLine);
                inputFileLayout.Append(Utils.BuildAreaA(String.Format("COPY " + comboCopybooks.SelectedItem.ToString() + ".")));
                txtFileLayout.Text = inputFileLayout.ToString();
            }
        }

        private void btnManualInputLayout_Click(object sender, EventArgs e)
        {
            txtFileLayout.Enabled = true;
        }

        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {
            if (txtInputFile.Text != "" & txtFileLayout.Text == "")
            {
                inputFileLayout.Append(Utils.BuildAreaA(string.Format("FD " + txtInputFile.Text.ToString().ToUpper() + ".")));
                txtFileLayout.Text = inputFileLayout.ToString();
            }
            else if (txtFileLayout.Text.Trim().StartsWith("FD"))
            {
                inputFileLayout = new StringBuilder(txtFileLayout.Text);
                StringReader sr = new StringReader(inputFileLayout.ToString());
                inputFileLayout.Remove(0, sr.ReadLine().Length);
                inputFileLayout.Insert(0, Utils.BuildAreaA(string.Format("FD " + txtInputFile.Text.ToString().ToUpper() + ".")));
                if (inputFileLayout.ToString().Trim() == "FD .")
                {
                    inputFileLayout = new StringBuilder();
                }
                txtFileLayout.Text = inputFileLayout.ToString();
            }
        }

        private void radioBtnInd_CheckedChanged(object sender, EventArgs e)
        {
            comboAccessType.Visible = true;
            comboAccessType.SelectedItem = "Dynamic";
        }

        private void radioBtnSeq_CheckedChanged(object sender, EventArgs e)
        {
            comboAccessType.Visible = false;
            comboAccessType.SelectedItem = null;
        }

        private void btnModifyInputFile_Click(object sender, EventArgs e)
        {
            if (!rowSelected && txtInputFile.Text.Trim() != "")
            {
                MessageBox.Show(
                    Resources.Add_The_File_Message,
                    Resources.Add_The_File_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtInputFile.Text.Trim() == "")
            {
                MessageBox.Show(
                    Resources.No_Row_Selected_Message,
                    Resources.No_Row_Selected_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                List<InputFileData> result =
                    InputFileRepository.obj.Where(p => String.Compare(p.fileName.Trim(), txtInputFile.Text.Trim(), true) == 0).ToList();
                if (result.Count > 0 &&
                    gridViewInputFiles.SelectedRows[0].Cells[0].Value.ToString().Trim() != txtInputFile.Text.Trim())
                {
                    MessageBox.Show(
                   Resources.Already_Exists_Message,
                   Resources.Already_Exists_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                    txtInputFile.Text = string.Empty;
                    txtInputFileDesc.Text = string.Empty;
                    radioBtnSeq.Checked = true;
                    comboCopybooks.SelectedItem = null;
                    comboAccessType.SelectedItem = null;
                    txtFileLayout.Text = string.Empty;
                    inputFileLayout = new StringBuilder();
                }
                else
                {
                    string _fileType;
                    string _accessType;
                    if (radioBtnSeq.Checked)
                    {
                        _fileType = "Sequential";
                        _accessType = " ";
                    }
                    else
                    {
                        _fileType = "Indexed";
                        _accessType = comboAccessType.SelectedItem.ToString();
                    }

                    InputFileRepository.obj.RemoveAt(gridViewInputFiles.SelectedRows[0].Index);
                    InputFileRepository.obj.Insert(gridViewInputFiles.SelectedRows[0].Index,
                                            new InputFileData(txtInputFile.Text.ToUpper(), txtInputFileDesc.Text,
                                                             _fileType, txtFileLayout.Text, _accessType));
                    txtInputFile.Text = string.Empty;
                    txtInputFileDesc.Text = string.Empty;
                    radioBtnSeq.Checked = true;
                    comboCopybooks.SelectedItem = null;
                    comboAccessType.SelectedItem = null;
                    txtFileLayout.Text = string.Empty;
                    inputFileLayout = new StringBuilder();
                }
            }
            if (_nInputFiles != 0)
            {
                var bindingList = new BindingList<InputFileData>(InputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewInputFiles.DataSource = bindingSource;
                gridViewInputFiles.Columns[3].Visible = false;
                gridViewInputFiles.Columns[4].Visible = false;
                this.gridViewInputFiles.Refresh();
                rowSelected = false;
            }
        }

        private void btnDeleteInputFile1_Click(object sender, EventArgs e)
        {
            if (!rowSelected && txtInputFile.Text.Trim() != "")
            {
                MessageBox.Show(
                    Resources.Add_The_File_Message,
                    Resources.Add_The_File_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (txtInputFile.Text.Trim() == "")
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
                txtInputFile.Text = string.Empty;
                txtInputFileDesc.Text = string.Empty;
                radioBtnSeq.Checked = true;
                comboCopybooks.SelectedItem = null;
                comboAccessType.SelectedItem = null;
                txtFileLayout.Text = string.Empty;
                inputFileLayout = new StringBuilder();
                _nInputFiles--;
            }
            if (_nInputFiles != 0)
            {
                var bindingList = new BindingList<InputFileData>(InputFileRepository.obj);
                var bindingSource = new BindingSource(bindingList, null);
                this.gridViewInputFiles.DataSource = bindingSource;
                gridViewInputFiles.Columns[3].Visible = false;
                gridViewInputFiles.Columns[4].Visible = false;
                this.gridViewInputFiles.Refresh();
                rowSelected = false;
            }
            else
            {
                gridViewInputFiles.Visible = false;
            }
        }
    }
}

