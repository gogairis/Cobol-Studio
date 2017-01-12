using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CobolStudio.Desktop
{
    public class Constants
    {
        public const string IdDivision = "       IDENTIFICATION DIVISION.";
        public class IdentificationDivision
        {
            public const string IdDivision = "       IDENTIFICATION DIVISION.";
            public const string ProgramId = "       PROGRAM-ID.";

        }

        public class EnvironmentDivision
        {
            public const string EnvDivision = "       ENVIRONMENT DIVISION.";
        }

        public class DataDivision
        {
            public const string DatDivision = "       DATA DIVISION.";
        }

        public class CommonUseItem
        {
            public const string Space = " ";
            public const string Dot = ".";
            
            public const string CommentLine =
                "      ******************************************************************";

            public const string SingleComment = "*";
            public const string PageBreak = "/";
            public const string InputFile = "Input File";
            public const string OutputFile = "Output File";
            public const string Description = " Description";
            public const string ProcessingFiles = "Processing Files";
            public const string InputFiles = "Input Files:";
            public const string OutputFiles = "Output Files:";

        }
    }
}
