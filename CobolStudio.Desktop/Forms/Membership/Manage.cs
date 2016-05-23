// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

using System.Text;
using Cobol.BLL;
using Cobol.BLL.BusinessModel;

namespace CobolStudio.Desktop.Forms.Membership
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using CobolStudio.Desktop.Properties;

    /// <summary>
    /// Manage screen - To view, search, print, export club members information
    /// </summary>
    public partial class Manage : System.Windows.Forms.Form
    {

#region Fields required for Input Files Text Box Creation
        private int _nInputFiles = 0;
        private int _xInputPos = 50;
        private int _yInputPos = 95;
        private int _xInputDescPos = 245;
        private int _yInputDescPos = 95;
#endregion

#region Fields required for OutPut Files Text Box Creation
        private int _nOutputFiles = 0;
        private int _xOutputPos = 580;
        private int _yOutputPos = 95;
        private int _xOutputDescPos = 775;
        private int _yOutputDescPos = 95;
#endregion

        private int _txtIndex;

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

        /// <summary>
        /// Click event to handle registration
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void GoToFilesSection_Click(object sender, EventArgs e)
        {
            try
            {
                tab.SelectedTab = tabFiles;
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void ProcessAllDivisions()
        {
            DivisonProcessorService servieObj=new DivisonProcessorService();
            DivisionInputItems inputItemObj = new DivisionInputItems();
            inputItemObj.Name = txtName.Text;
            inputItemObj.CreationDate=DateTime.Now;
            inputItemObj.CodeDescription = txtDescription.Text;
            System.IO.File.WriteAllText(@"C:\File\Cobol.txt", servieObj.WriteAllDivision(inputItemObj));
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void GoToNextSection_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = CodeGenerate;
        }

        private void CodeGenrate_Click(object sender, EventArgs e)
        {
            ProcessAllDivisions();
            MessageBox.Show(
                Resources.Code_Generation_Message,
                Resources.Code_Generation_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information); 
        }

        private void btnAddInputFile_Click(object sender, EventArgs e)
        {
            _nInputFiles++;
            if (_nInputFiles > 5)
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
                // Create array for Input Files Text Box
                if (_nInputFiles == 1)
                {
                    inputFileArray = new System.Windows.Forms.TextBox[6];
                    inputFileDescArray = new System.Windows.Forms.TextBox[6];
                }
                inputFileArray[_nInputFiles] = new System.Windows.Forms.TextBox();
                //textInput.Visible = !textInput.Visible;
                inputFileArray[_nInputFiles].Tag = _nInputFiles;
                inputFileArray[_nInputFiles].Width = 115;
                inputFileArray[_nInputFiles].Height = 24;
                inputFileArray[_nInputFiles].BackColor = System.Drawing.SystemColors.Info;
                inputFileArray[_nInputFiles].Text = Constants.CommonUseItem.InputFile +
                                                    inputFileArray[_nInputFiles].Tag.ToString();
                inputFileArray[_nInputFiles].Left = _xInputPos;
                inputFileArray[_nInputFiles].Top = _yInputPos;
                _yInputPos = _yInputPos + inputFileArray[_nInputFiles].Height + 12;
                tabFiles.Controls.Add(inputFileArray[_nInputFiles]);
                // the Event of Enter (TextBox)
                inputFileArray[_nInputFiles].Enter += new System.EventHandler(EnterTextBox);
                // the Event of TextChanged (TextBox) 
                inputFileArray[_nInputFiles].TextChanged += new System.EventHandler(TextChange);

                // Create array for Input Files Description Text Box
                inputFileDescArray[_nInputFiles] = new System.Windows.Forms.TextBox();
                //textInput.Visible = !textInput.Visible;
                inputFileDescArray[_nInputFiles].Tag = _nInputFiles;
                inputFileDescArray[_nInputFiles].Width = 250;
                inputFileDescArray[_nInputFiles].Height = 24;
                inputFileDescArray[_nInputFiles].BackColor = System.Drawing.SystemColors.Info;
                inputFileDescArray[_nInputFiles].Text = Constants.CommonUseItem.InputFile +
                                                        inputFileDescArray[_nInputFiles].Tag.ToString() +
                                                        Constants.CommonUseItem.Description;
                inputFileDescArray[_nInputFiles].Left = _xInputDescPos;
                inputFileDescArray[_nInputFiles].Top = _yInputDescPos;
                inputFileDescArray[_nInputFiles].Multiline = true;
                _yInputDescPos = _yInputDescPos + inputFileArray[_nInputFiles].Height + 12;
                tabFiles.Controls.Add(inputFileDescArray[_nInputFiles]);
                // the Event of Enter (TextBox)
                inputFileArray[_nInputFiles].Click += new System.EventHandler(ClearTextBox);
                inputFileDescArray[_nInputFiles].Enter += new System.EventHandler(EnterTextBox);
                inputFileDescArray[_nInputFiles].Click += new System.EventHandler(ClearTextBox);
                // the Event of TextChanged (TextBox) 
                inputFileDescArray[_nInputFiles].TextChanged += new System.EventHandler(TextChange);
            }
        }

        private void ClearTextBox(object sender, EventArgs e)
        {
            ((System.Windows.Forms.TextBox)sender).Clear(); // number of the TextBox
        }

        public void EnterTextBox(Object sender, System.EventArgs e)
        {
            _txtIndex = (int)((System.Windows.Forms.TextBox)sender).Tag; // number of the TextBox
            label2.Text = _txtIndex.ToString();
            label3.Text = "";
            label3.Text = inputFileArray[_txtIndex].Text;
        }

        public void TextChange(Object sender, System.EventArgs e)
        {
            label3.Text = inputFileArray[_txtIndex].Text;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnAddOutputFile_Click(object sender, EventArgs e)
        {
            _nOutputFiles++;
            if (_nOutputFiles > 5)
            {
                MessageBox.Show(
                    Resources.File_Limit_Message,
                    Resources.File_Limit_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                goto EXIT;
            }
            // Create array for Input Files Text Box
            if (_nOutputFiles == 1)
            {
                outputFileArray = new System.Windows.Forms.TextBox[6];
                outputFileDescArray = new System.Windows.Forms.TextBox[6];
            }
            outputFileArray[_nOutputFiles] = new System.Windows.Forms.TextBox();
            //textInput.Visible = !textInput.Visible;
            outputFileArray[_nOutputFiles].Tag = _nOutputFiles;
            outputFileArray[_nOutputFiles].Width = 115;
            outputFileArray[_nOutputFiles].Height = 24;
            outputFileArray[_nOutputFiles].BackColor = System.Drawing.SystemColors.Info;
            outputFileArray[_nOutputFiles].Text = Constants.CommonUseItem.OutputFile + outputFileArray[_nOutputFiles].Tag.ToString();
            outputFileArray[_nOutputFiles].Left = _xOutputPos;
            outputFileArray[_nOutputFiles].Top = _yOutputPos;
            _yOutputPos = _yOutputPos + outputFileArray[_nOutputFiles].Height + 12;
            tabFiles.Controls.Add(outputFileArray[_nOutputFiles]);
            // the Event of Enter (TextBox)
            outputFileArray[_nOutputFiles].Enter += new System.EventHandler(EnterTextBox);
            // the Event of TextChanged (TextBox) 
            outputFileArray[_nOutputFiles].TextChanged += new System.EventHandler(TextChange);

            // Create array for Input Files Description Text Box
            outputFileDescArray[_nOutputFiles] = new System.Windows.Forms.TextBox();
            //textInput.Visible = !textInput.Visible;
            outputFileDescArray[_nOutputFiles].Tag = _nOutputFiles;
            outputFileDescArray[_nOutputFiles].Width = 250;
            outputFileDescArray[_nOutputFiles].Height = 24;
            outputFileDescArray[_nOutputFiles].BackColor = System.Drawing.SystemColors.Info;
            outputFileDescArray[_nOutputFiles].Text = Constants.CommonUseItem.OutputFile + outputFileDescArray[_nOutputFiles].Tag.ToString() + Constants.CommonUseItem.Description;
            outputFileDescArray[_nOutputFiles].Left = _xOutputDescPos;
            outputFileDescArray[_nOutputFiles].Top = _yOutputDescPos;
            outputFileDescArray[_nOutputFiles].Multiline = true;
            _yOutputDescPos = _yOutputDescPos + outputFileArray[_nOutputFiles].Height + 12;
            tabFiles.Controls.Add(outputFileDescArray[_nOutputFiles]);
            // the Event of Enter (TextBox)
            outputFileDescArray[_nOutputFiles].Enter += new System.EventHandler(EnterTextBox);
            // the Event of TextChanged (TextBox) 
            outputFileDescArray[_nOutputFiles].TextChanged += new System.EventHandler(TextChange);

        EXIT:
            if (_nOutputFiles > 5)
            {
                _nOutputFiles--;
            }
        }

        private void btnDeleteInputFile_Click(object sender, EventArgs e)
        {
            inputFileArray[_nInputFiles].Visible = false;
            inputFileDescArray[_nInputFiles].Visible = false;
            _yInputPos = _yInputPos - inputFileArray[_nInputFiles].Height - 12;
            _yInputDescPos = _yInputDescPos - inputFileArray[_nInputFiles].Height - 12;
            _nInputFiles--;

        }

        private void btnDeleteOutputFile_Click(object sender, EventArgs e)
        {
            outputFileArray[_nOutputFiles].Visible = false;
            outputFileDescArray[_nOutputFiles].Visible = false;
            _yOutputPos = _yOutputPos - outputFileArray[_nOutputFiles].Height - 12;
            _yOutputDescPos = _yOutputDescPos - outputFileArray[_nOutputFiles].Height - 12;
            _nOutputFiles--;

        }

                         
    }
}
