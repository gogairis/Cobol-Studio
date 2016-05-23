using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobol.BLL.BusinessModel
{
    public class DivisionInputItems
    {
        public string AuthorName { get; set; }
        public string ProgramId { get; set; }
        public string VersionNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string CodeDescription { get; set; }
        public List<string> InputFileNames { get; set; }
        public List<string> OutputFileNames { get; set; }
        public List<string> InputFileTypes { get; set; }
        public List<string> OutputFileTypes { get; set; }
        public List<string> InputFileDescriptions { get; set; }
        public List<string> OutputFileDescriptions { get; set; }
        public List<string> InputFieLayout { get; set; }
        public List<string> InputFileAccessType { get; set; }
        public List<string> OutputFieLayout { get; set; }
        public List<string> OutputFileAccessType { get; set; }
        public int NoOfInputFiles { get; set; }
        public int NoOfOutputFIles { get; set; }
        public int NoOfDbRecords { get; set; }
        public List<string> DbRecordNames { get; set; }
        public string SchemaName { get; set; }
        public int VariableSize { get; set; }
        public bool RestartInd { get; set; }
        public string RestartType { get; set; }
    }
}
