using System.ComponentModel;

namespace Cobol.BLL.BusinessModel
{
    public class Constants
    {
        public enum RestartType
        {
            [Description("Database")]
            Database,
            [Description("File")]
            File
        }

        public class IdentificationDivision
        {
            public const string IdDivision = "IDENTIFICATION DIVISION.";
            public const string ProgramId = "PROGRAM-ID.     ";
            public const string DateWritten = "DATE-WRITTEN.   ";
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
            public const string InoutOutputSection = "INPUT-OUTPUT SECTION.";
            public const string FileControl = "FILE-CONTROL.";
            public const string Select = "SELECT ";
            public const string Assign = "ASSIGN ";
            public const string Organization = "       ORGANIZATION         IS INDEXED";
            public const string Access = "       ACCESS               IS ";
            public const string RecordKey = "       RECORD KEY           IS ";
            public const string Key = "-KEY";
            public const string FileStatus = "       FILE STATUS          IS ";
            public const string rsFileStatus = "RSFILE-STATUS";
            public const string Status = "-STATUS";
            public const string IdmsControlSec = "IDMS-CONTROL SECTION.";
            public const string ProtocolMode = "PROTOCOL.   MODE IS BATCH DEBUG.";
            public const string IdmsRecord = "IDMS-RECORDS MANUAL.";
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
            public const string RestartHdr = "Area used for RESTART Data";
            public const string CheckPointField = "CHECKPOINTING-FIELDS";
            public const string RestartField = "RESTART-FIELDS";
            public const string RestartData = "RESTART-DATA";
            public const string fillerRedefiles = "FILLER REDEFINES ";
            public const string SCLParameter = "SCL-PARAMETERS";
            public const string RUSParameter = "RUS-PARAM";
            public const string RestartFlagText = "RESTART-FLAG";
            public const string RUSSize = "RUS-SIZE";
            public const string RUSReply = "RUS-REPLY";
            public const string RUSHdr = "Area holds parameters for Restart Unit Size";
            public const string ProgProcessHdr = "Area used to store other work fields required for program processing";
            public const string WorkFields = "WORK-FIELDS";
            public const string FileStatus = "FILE-STATUS";
            public const string DispCount = "DISP-CT";
            public const string copyBookHdr = "Copy data from copybooks or function param files";
            public const string SysErrorRep = "SYSERRREP";
            public const string dbRecHdr = "Copy SUBSCHEMA details and record names used in program";
            public const string copyText = "COPY ";
            public const string idmsText = "IDMS ";
            public const string schemaCTRL = "SUBSCHEMACTRL EXTERNAL";
            public const string schemaNames = "SUBSCHEMANAMES";
            public const string linkageHdr = "Linkage details used in program";
            public const string linkageSection = "LINKAGE SECTION.";
            public const string cProgEnd = "C-PROG-END";
            public const string allOK = "ALL-OK";
            public const string anErrorDetected = "AN-ERROR-DETECTED";
            public const string progCountText = "PROG-COUNTS";
            public const string readCountText = "READ-COUNT";
            public const string ProgCountsHdr = "Area used to store all counts used in program processing";
            public const string accumulatorText = "ACCUMULATORS";
            public const string lnameText = "LNAME";
            public const string qdataText = "QDATA";
            public const string notUsedText = "NOT-USED";
            public const string resultText = "RESULT";
            public const string restRecCountText = "REC-COUNT";
            public const string restText = "REST";
            public const string restartFileText = "RESTARTFILE";
            public const string restartRecText = "RESTART-REC";
            public const string dataText = "DATA";
            public const string lengthText = "LENGTH";
            public const string filesOpenText = "FILES-OPEN";
            public const string cc57DataText = "CC57DATA.";
            public const string rusCountText = "RUS-COUNT";
        }

        public class ProcedureDevision
        {
            public const string procedureDivision = "PROCEDURE DIVISION USING C-PROG-END.";
            public const string mainSectionHdr = "Main Control Section";
            public const string sectionText = " SECTION.";
            public const string aaControlSection = "AA-CONTROL";
            public const string baInitialise = "BA-INITIALISE";
            public const string caMainProcessing = "CA-MAIN-PROCESSING";
            public const string daEndProcessing = "DA-END-PROCESSING";
            public const string endOfFile = "END-OF-FILE";
            public const string untilText = "UNTIL ";
            public const string performText = "PERFORM ";
            public const string stopRunText = "STOP RUN.";
            public const string baSectionHdr = "This section prepares the working storage sections, carries out the binds, generally prepares the program ready for processing of data";
            public const string cc57MessageText = "CC57-SEND-MESSAGE-TEXT";
            public const string cc57MessageSection = "CC57-ERROR-DISPLAY-NOW";
            public const string exitText = "EXIT.";
            public const string text89997 = "89997";
            public const string text89996 = "89996 ";
            public const string text89934 = "89934 ";
            public const string text89993 = "89993 ";
            public const string text80000 = "-80000 ";
            public const string rusSizeValue = "100 ";
            public const string cProgEnd = "C-PROG-END";
            public const string xaBindSection = "XA-BINDS";
            public const string xbReadySection = "XB-READY";
            public const string readRusFailed1 = "\"BA-010: Read SCL RUS failed: \"";
            public const string readRusFailed2 = "\",Defaulted to 100\"";
            public const string bindFailedText = "ERROR BINDING ";
            public const string readyFailedText = "ERROR READYING ";
            public const string obtainFailedText = "ERROR OBTAINING ";
            public const string findFailedText = "ERROR FINDING ";
            public const string storeFailedText = "ERROR STORING ";
            public const string modifyFailedText = "ERROR MODIFYING ";
            public const string eraseFailedText = "ERROR ERASING ";
            public const string finishFailedText = "ERROR IN FINISH DATABASE";
            public const string commitFailedText = "ERROR IN COMMIT DATABASE";
            public const string freeFailedText = "ERROR IN FREE DATABASE";
            public const string readyText = "READY ";
            public const string usageModeText = "USAGE-MODE IS ";
            public const string retrievalText = "RETRIEVAL.";
            public const string updateText = "UPDATE.";
            public const string restartCheckHdr = "Check for Restart";
            public const string D736RunNo = "D736-RUN-NO";
            public const string r736RecName = "R736-UPDATE-CTRL";
            public const string r746RecName = "R746-CF-RESTART";
            public const string s737SetName = "S737.";
            public const string baaFreshStart = "BAA-FRESH-START";
            public const string babRestart = "BAB-RESTART";
            public const string baaRestart = "BAA-RESTART";
            public const string baaSectionHdr = "This section stores the R746 records for later restart processing";
            public const string babSectionHdr = "This section restores the processing data from R746 records";
            public const string baaRestartSectionHdr = "This section restores the processing data from restart file";
            public const string restartModeText = "\" ***PROGRAM IS RUNNING IN RESTART MODE ***\".";
            public const string setFileCheckpointText = "CALL SYSLIB \"(ICLCTM).SETFILECHECKPOINTDATA\" USING";
            public const string giveFileCheckpointText = "CALL SYSLIB \"(ICLCTM).GIVEFILECHECKPOINTDATA\" USING";
            public const string setFileCheckpointFailedText = "SETFILECHECKPOINTDATA FAILED: \"";
            public const string forResponseText = " FOR RESPONSE.";
            public const string readText = "READ ";
            public const string atEndText = "AT END ";
            public const string closeText = "CLOSE ";
            public const string openText = "OPEN ";
            public const string inputText = "INPUT ";
            public const string outputText = "OUTPUT ";
            public const string writeText = "WRITE ";
            public const string cc57CodeText = "CC57CODE.";
            public const string nextSentenceText = "NEXT SENTENCE";
            public const string caSectionHdr = "This section will perfom the main processing of the code";
            public const string daSectionHdr = "This section will close all database resources/input files and this will display the program stats";
            public const string dbDeadlockText = "DB-DEADLOCK ";
            public const string dualUpdateText = "DB-DUAL-UPDATE";
            public const string orText = "OR ";
            public const string statisticsText = "STATISTICS ";
            public const string totalReadCountText = "\"Total Read Count:               \" ";
            public const string commitText = "COMMIT.";
            public const string freeText = "FREE.";
            public const string finishText = "FINISH";
            public const string finishAfterRollbackText = "FINISH AFTER ROLLBACK.";
            public const string deadlockMessageText = "\"DEADLOCK OCCURED, PLEASE RESTART THE JOB\"";
            public const string caaSuccessUnit = "CAA-SUCCESS-UNIT";
            public const string caaSectionHdr = "This section will store the checkpointing/count data when success unit is reached";
            public const string daaEraseR746 = "DAA-ERASE-R746";
            public const string daaSectionHdr = "This section will erase all R746 records";

        }
        public class CommonUseItem
        {
            public const string Space = " ";
            public const string Dot = ".";
            public const char Quote = '"';
            public const string  colonSign = ": ";
            public const string SingleComment = "*";
            public const string PageBreak = "/";
            public const string InputFile = "Input File";
            public const string OutputFile = "Output File";
            public const string Description = " Description";
            public const string DBRecord = "Database Record";
            public const string moveText = "MOVE ";
            public const string addText = "ADD ";
            public const string spaceText = "SPACES ";
            public const string toText = "TO ";
            public const string ifText = "IF  ";
            public const string elseText = "ELSE";
            public const string notText = " NOT";
            public const string stringText = "STRING ";
            public const string equalSign = " = ";
            public const string delimitedText = "DELIMITED BY SIZE INTO ";
            public const string versionText = "\" - VERSION NUMBER \"";
            public const string initialiseText = "INITIALISE";
            public const string runnoText = "RUNNO";
            public const string acceptText = "ACCEPT ";
            public const string sclRunNoText = "SCLRUNNO.";
            public const string fromText = "FROM ";
            public const string callText = "CALL ";
            public const string usingText = "USING ";
            public const string zeroText = "ZERO";
            public const string readSCLIntText = "\"READSCLINT\"";
            public const string bindText = "BIND ";
            public const string runUnitText = "RUN-UNIT.";
            public const string gotoText = "GO TO ";
            public const string errorStatusText = " ERROR-STATUS";
            public const string obtainText = "OBTAIN ";
            public const string findText = "FIND ";
            public const string storeText = "STORE ";
            public const string modifyText = "MODIFY ";
            public const string eraseText = "ERASE ";
            public const string anyText = "ANY ";
            public const string firstText = "FIRST ";
            public const string nextText = "NEXT ";
            public const string displayText = "DISPLAY ";
            public const string withinText = " WITHIN ";
            public const string notDBStatusOKText = "NOT DB-STATUS-OK";
            public const string dbEndOfSetText = "DB-END-OF-SET";
            public const string schemaName = "SSOAI86B";
        }
    }
}
