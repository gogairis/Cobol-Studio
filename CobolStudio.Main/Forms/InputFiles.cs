using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobol.BLL;
using Cobol.BLL.BusinessModel;
using Cobol.BLL.DivisionsProcessor.Impl;
using CobolStudio.Main.Properties;
using System.IO;

namespace CobolStudio.Main.Forms
{
    public partial class InputFiles : Form
    {
        StringBuilder sb = new StringBuilder();
        public InputFiles()
        {
            InitializeComponent();
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
                    sb = new StringBuilder(txtFileLayout.Text);
                sb.Append(Environment.NewLine);
                sb.Append(Utils.BuildAreaA(String.Format("COPY " + comboCopybooks.SelectedItem.ToString() + ".")));
                txtFileLayout.Text = sb.ToString();
            }

        }

        public InputFileData returnInputFile()
        {
            InputFileData dt = null; //new InputFileData(txtInputFile.Text.ToUpper(), txtInputFileDesc.Text, comboInputFileType.Text);
            //dt.fileName = txtInputFile.Text.ToUpper();
            //dt.fileDescription = txtInputFileDesc.Text;
            //dt.fileType = comboInputFileType.Text;
            
            return dt;
        }

        private void btnManualInputLayout_Click(object sender, EventArgs e)
        {
            txtFileLayout.Enabled = true;
        }

        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {
            if (txtInputFile.Text != "" & txtFileLayout.Text == "")
            {
                sb.Append(Utils.BuildAreaA(string.Format("FD " + txtInputFile.Text.ToString().ToUpper() + ".")));
                txtFileLayout.Text = sb.ToString();
            }
            else if (txtFileLayout.Text.Trim().StartsWith("FD"))
            {
                sb = new StringBuilder(txtFileLayout.Text);
                StringReader sr = new StringReader(sb.ToString());
                sb.Remove(0, sr.ReadLine().Length);
                sb.Insert(0,Utils.BuildAreaA(string.Format("FD " + txtInputFile.Text.ToString().ToUpper() + ".")));
                txtFileLayout.Text = sb.ToString();
            }
        }


    }
}
