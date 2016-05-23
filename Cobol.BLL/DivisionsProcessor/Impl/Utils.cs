using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Cobol.BLL.BusinessModel;

namespace Cobol.BLL.DivisionsProcessor.Impl
{
    public static class Utils
    {
        private const char CommentChar = '*';
        private const int StartPos = 7;
        private const int MaxCharInLine = 66;
        private const int AreaAStartPos = 8;
        private const int AreaBStartPos = 12;
        private const int AreaCStartPos = 41;
        public static string BuildCommentHeader()
        {
            StringBuilder sb =new StringBuilder();
            for (int cntr = 1; cntr < StartPos; cntr++)
            {
                sb.Append(' ');
            }
            for(int cntr=0;cntr<MaxCharInLine;cntr++)
            {
                sb.Append(CommentChar);
            }
            sb.AppendLine();
            return sb.ToString();
        }

        public static string BuildCommentLine(string inputLine,bool isCenter=false)
        {
            StringBuilder sb1 = new StringBuilder();
            StringReader sr=new StringReader(inputLine);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] inputLineArr = line.Split(' ');
                string curtempLine = string.Empty;
                string prevtempLine = string.Empty;
                bool isProcessComplete = false;
                foreach (string word in inputLineArr)
                {
                    isProcessComplete = false;
                    curtempLine = curtempLine + " " + word;
                    curtempLine = curtempLine.Trim();
                    if (curtempLine.Length + 4 > MaxCharInLine)
                    {
                        isProcessComplete = true;
                        sb1.Append(AppendStringChars(prevtempLine, isCenter));
                        curtempLine = word;
                    }
                    prevtempLine = curtempLine;
                }
                if (!isProcessComplete)
                {
                    sb1.Append(AppendStringChars(prevtempLine, isCenter));
                }
                line = sr.ReadLine();
            }
            return sb1.ToString();
        }

        private static string AppendStringChars(string inputLine,bool isCenter)
        {
            StringBuilder sb2 = new StringBuilder();
            for (int cntr = 1; cntr < StartPos; cntr++)
            {
                sb2.Append(' ');
            }
            sb2.Append(CommentChar).Append(" ");
            //wite logic to calculate how much space is appened if center flag is true
            int spaceCount = 0;
            if (isCenter)
            {
                spaceCount = (MaxCharInLine - 4 - inputLine.ToCharArray().Length)/2;
                for (int i = 0; i < spaceCount; i++)
                {
                    sb2.Append(' ');
                }
            }
            sb2.Append(inputLine);
            int spaceLength = MaxCharInLine - 4 - inputLine.Length-spaceCount;
            for (int i = 0; i < spaceLength; i++)
            {
                sb2.Append(' ');
            }
            sb2.Append(" ").Append(CommentChar);
            sb2.AppendLine();
            return sb2.ToString();
        }

        public static string BuildAreaA(string inputLine)
        {
            StringBuilder sb3 = new StringBuilder();

            for (int cntr = 1; cntr < AreaAStartPos; cntr++)
            {
                sb3.Append(' ');
            }
            sb3.Append(inputLine);

            return sb3.ToString();
        }
        public static string BuildAreaB(string inputLine)
        {
            StringBuilder sb4 = new StringBuilder();

            for (int cntr = 1; cntr < AreaBStartPos; cntr++)
            {
                sb4.Append(' ');
            }
            sb4.Append(inputLine);

            return sb4.ToString();
        }

        public static string BuildNameString(string name)
        {
            StringBuilder sb5 = new StringBuilder();

            for (int cntr = 1; cntr < StartPos; cntr++)
            {
                sb5.Append(' ');
            }

            sb5.Append(CommentChar).Append(" ");
            sb5.Append(Constants.IdentificationDivision.AuthorColon);
            sb5.Append(name.Trim());

            for (int cntr = 0; cntr < 24 - name.Length; cntr++)
            {
                sb5.Append(' ');
            }
            sb5.Append(Constants.IdentificationDivision.Reviewer);

            for (int cntr = 0; cntr < 18; cntr++)
            {
                sb5.Append(' ');
            }
            sb5.Append(CommentChar);
            sb5.AppendLine();
            return sb5.ToString();
        }

        public static string BuildCompleteLine(string areaA, string areaB, string areaC)
        {
            StringBuilder sb6 = new StringBuilder();

                if (areaA.Length > 0)
                {
                    for (int cntr = 1; cntr < AreaAStartPos; cntr++)
                    {
                        sb6.Append(' ');
                    }

                    sb6.Append(areaA);

                    for (int cntr = 1; cntr < AreaCStartPos - AreaAStartPos- areaA.Length; cntr++)
                    {
                        sb6.Append(' ');
                    }
                    sb6.Append(areaC);
                }
                else
                {
                    if (areaB.Length > 0)
                    {
                        for (int cntr = 1; cntr < AreaBStartPos; cntr++)
                        {
                            sb6.Append(' ');
                        }

                        sb6.Append(areaB);

                        for (int cntr = 1; cntr < (AreaCStartPos - AreaBStartPos - areaB.Length); cntr++)
                        {
                            sb6.Append(' ');
                        }
                        sb6.Append(areaC);
                    }
                }

            sb6.AppendLine();
            return sb6.ToString();
        }

        internal static string LogicalFileName(string i)
        {
            return ("CFL0" + i);
        }

        internal static string CreateWorkingStorage(int level, string workingStorage, string picClause,
            string value = "")
        {
            StringBuilder sb7 = new StringBuilder();
            sb7.Append(level.ToString("D2")).Append("  ").Append(workingStorage);

            if (picClause == "")
            {
                return BuildAreaA(sb7.AppendLine(Constants.CommonUseItem.Dot).ToString());
            }
            if (level == 01)
            {
                for (int cntr = 1; cntr < (AreaCStartPos - AreaAStartPos - workingStorage.Length - 4); cntr++)
                {
                    sb7.Append(' ');
                }
            }
            sb7.Append("PIC " + picClause + " ");

            if (value != "")
            {
                sb7.Append("VALUE " + value);
            }

            sb7.Append(Constants.CommonUseItem.Dot);
            sb7.AppendLine();

            return BuildAreaA(sb7.ToString());
        }

        internal static string WsName(int wsNumber, string wsName)
        {
            return ("WS" + wsNumber.ToString("D2") + "-" + wsName);
        }
    }
}