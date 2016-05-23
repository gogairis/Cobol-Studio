using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobol.BLL.BusinessModel
{
    public class InputFileData
    {
        public InputFileData(string fileName, string fileDescription, string fileType, string fileLayout, string accessType)
        {
            _fileName = fileName;
            _fileDescription = fileDescription;
            _fileType = fileType;
            _fileLayout = fileLayout;
            _accessType = accessType;
        }
        private string _fileName;
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        private string _fileDescription;
        public string fileDescription
        {
            get { return _fileDescription; }
            set { _fileDescription = value; }
        }
        private string _fileType;
        public string fileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }
        private string _fileLayout;
        public string fileLayout
        {
            get { return _fileLayout; }
            set { _fileLayout = value; }
        }
        private string _accessType;
        public string accessType
        {
            get { return _accessType; }
            set { _accessType = value; }
        }
    }
}
