namespace Cobol.BLL.BusinessModel
{
    public class Constants
    {
        public class IdentificationDivision
        {
            public const string IdDivision = "IDENTIFICATION DIVISION.";
            public const string ProgramId = "PROGRAM-ID.     ";
            public const string DateWritten = "DATA-WRITTEN.   ";
            public const string Author = "AUTHOR.         ";
            public const string Overview = "Overview";
            public const string OverHeader = "========";
            public const string ProcessingFiles = "Processing Files";
            public const string Underline = "================";
            public const string InputFiles = "Input Files:-";
            public const string OutputFiles = "Output Files:-";
            public const string Version = "VERSION : ";
            public const string AuthorColon = "AUTHOR  : ";
            public const string Reviewer = "REVIEWER : ";
            public const string Date = "DATE    :";
            public const string Date2 = "             DATE     :                   *";
            public const string FirstVersion = "DETAILS : 1st version of program.";
        }

        public class EnvironmentDivision
        {
            public const string EnvDivision = "ENVIRONMENT DIVISION.";
            public const string ConfigSection = "CONFIGURATION SECTION.";
            public const string SourceComputer = "SOURCE-COMPUTER.";
            public const string ObjectComputer = "OBJECT-COMPUTER.";
            public const string ComputerName = "ICL VME.";
            public const string SpecialNames = "SPECIAL-NAMES.";
            public const string RunNo = "SYSRUNNO                    IS SCLRUNNO";
            public const string JobJournal = "STDAD                       IS JOBJOURNAL";
            public const string CallPoints = "SYSCALPOINTS                IS SCLCALPOINTS";
            public const string UName = "SYSUNAME                    IS SCLUNAME";
            public const string InoutOutputSection = "INPIT-OUTPUT SECTION.";
            public const string FileControl = "FILE-CONTROL.";
            public const string Select = "SELECT ";
            public const string Assign = "ASSIGN ";
            public const string Organization = "       ORGANIZATION         IS INDEXED";
            public const string Access = "       ACCESS               IS ";
            public const string RecordKey = "       RECORD KEY           IS ";
            public const string Key = "-KEY";
            public const string FileStatus = "       FILE STATUS          IS ";
            public const string Status = "-STATUS";
            public const string IdmsControlSec = "IDMS-CONTROL SECTION.";
            public const string ProtocolMode = "PROTOCOL. MODE IS BATCH DEBUG.";
            public const string IdmsRecord = "IDMS-RECORD MANUAL.";
        }

        public class DataDivision
        {
            public const string DatDivision = "DATA DIVISION.";
            public const string SchemaSection = "SCHEMA SECTION.";
            public const string SchemaName = "DB {0} WITHIN ABSDB1.";
            public const string FileSection = "FILE SECTION.";
            public const string WorkingStorage = "WORKING-STORAGE SECTION.";
            public const string ProgramName = "AA-PROGRAM-NAME";
            public const string VersionNumber = "AA-VERSION-NUMBER";
            public const string CheckPointHdr = "Area used to store File Checkpointing Details";
            public const string CheckPointField = "CHECKPOINTING-FIELDS";
        }

        public class CommonUseItem
        {
            public const string Space = " ";
            public const string Dot = ".";
            public const char Quote = '"';
            public const string SingleComment = "*";
            public const string PageBreak = "/";
            public const string InputFile = "Input File";
            public const string OutputFile = "Output File";
            public const string Description = " Description";
            public const string DBRecord = "Database Record";
        }
    }
}
