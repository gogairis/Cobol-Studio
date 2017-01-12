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
        private const int AreaB2StartPos = 16;
        private const int AreaB3StartPos = 20;
        private const int AreaB4StartPos = 24;
        private const int AreaCStartPos = 41;
        private static List<int> lastLevel;

        /// <summary>
        /// Create a line of all "*" as a comment header
        /// </summary>
        /// <returns>string line of *s</returns>
        public static string BuildCommentHeader()
        {
            StringBuilder sb =new StringBuilder();
            for (int cntr = 1; cntr < StartPos; cntr++)
            {
                sb.Append(' ');
            }
            for (int cntr = 0; cntr < MaxCharInLine; cntr++)
            {
                sb.Append(CommentChar);
            }
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// Returns a single "*" at 7th position of the line
        /// </summary>
        /// <returns>string with a "*" at 7th position</returns>
        public static string BuildSingleComment()
        {
            return (string.Format("{0,-5} {1,-1}", " ", CommentChar) + Environment.NewLine);
        }

        /// <summary>
        /// Returns a line of comment with the line of information provided as input,
        /// It can also append the line in center if the input param is true.
        /// </summary>
        /// <param name="inputLine">Input message to be appended in the comment line</param>
        /// <param name="isCenter">Optional, set to true if want the input line at center</param>
        /// <returns>returns a string with the comment line starting from 7th position with lien data provided in input</returns>
        public static string BuildCommentLine(string inputLine, bool isCenter = false)
        {
            StringBuilder sb1 = new StringBuilder();
            StringReader sr = new StringReader(inputLine);
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
            sr.Close();
            return sb1.ToString();
        }

        /// <summary>
        /// This is a private method and called from BuildCommentLine method to append Chars in string
        /// </summary>
        /// <param name="inputLine"></param>
        /// <param name="isCenter"></param>
        /// <returns></returns>
        private static string AppendStringChars(string inputLine, bool isCenter)
        {
            StringBuilder sb2 = new StringBuilder();
            for (int cntr = 1; cntr < StartPos; cntr++)
            {
                sb2.Append(' ');
            }
            sb2.Append(CommentChar).Append(" ");
            //wite logic to calculate how much space is appended if center flag is true
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

        /// <summary>
        /// Creates a line starting from 8th position with input line data
        /// "Note: It does not append a new line so append new line wherever required."
        /// </summary>
        /// <param name="inputLine">Data to be written from 8th position</param>
        /// <returns>String of input data starting from 8th column</returns>
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

        /// <summary>
        /// Creates a line starting from 12th position with input line data
        /// "Note: It does not append a new line so append new line wherever required."
        /// </summary>
        /// <param name="inputLine">Data to be written from 12th position</param>
        /// <returns>String of input data starting from 12th column</returns>
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

        /// <summary>
        /// Creates a line starting from 16th position with input line data
        /// "Note: It does not append a new line so append new line wherever required."
        /// </summary>
        /// <param name="inputLine">Data to be written from 16th position</param>
        /// <returns>String of input data starting from 16th column</returns>
        public static string BuildAreaB2(string inputLine)
        {
            StringBuilder sb4 = new StringBuilder();

            for (int cntr = 1; cntr < AreaB2StartPos; cntr++)
            {
                sb4.Append(' ');
            }
            sb4.Append(inputLine);

            return sb4.ToString();
        }

        /// <summary>
        /// Creates a line starting from 20th position with input line data
        /// "Note: It does not append a new line so append new line wherever required."
        /// </summary>
        /// <param name="inputLine">Data to be written from 16th position</param>
        /// <returns>String of input data starting from 16th column</returns>
        public static string BuildAreaB3(string inputLine)
        {
            StringBuilder sb5 = new StringBuilder();

            for (int cntr = 1; cntr < AreaB3StartPos; cntr++)
            {
                sb5.Append(' ');
            }
            sb5.Append(inputLine);

            return sb5.ToString();
        }

        /// <summary>
        /// Creates a line starting from 24th position with input line data
        /// "Note: It does not append a new line so append new line wherever required."
        /// </summary>
        /// <param name="inputLine">Data to be written from 16th position</param>
        /// <returns>String of input data starting from 16th column</returns>
        private static string BuildAreaB4(string inputLine)
        {
            StringBuilder sb6 = new StringBuilder();

            for (int cntr = 1; cntr < AreaB4StartPos; cntr++)
            {
                sb6.Append(' ');
            }
            sb6.Append(inputLine);

            return sb6.ToString();
        }

        /// <summary>
        /// This method is called from IdentificationDivision.cs class to create a name string in amendment history
        /// </summary>
        /// <param name="name">Author name in Title case</param>
        /// <returns>String with author name and reviewer tag in line</returns>
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

        /// <summary>
        /// This will create a complete line with data in its respective area.
        /// If no data required in any of the area then pass "" in parameter
        /// </summary>
        /// <param name="areaA">Data starting from 8th Position</param>
        /// <param name="areaB">Data starting from 12th Position</param>
        /// <param name="areaC">Data starting from 40th Position</param>
        /// <returns></returns>
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

        /// <summary>
        /// This will create a line of data provided as input starting from the startPosition inputed
        /// </summary>
        /// <param name="startPosition">Position from where input line to be started</param>
        /// <param name="lineText">Data to be appended in line</param>
        /// <returns>line starting from the startPosition parameter with lineText data</returns>
        public static string BuildCompleteLine(int startPosition, string lineText)
        {
            StringBuilder sb6 = new StringBuilder();

            for (int cntr = 1; cntr < startPosition; cntr++)
            {
                sb6.Append(' ');
            }

            sb6.Append(lineText).AppendLine();

            return sb6.ToString();
        }

        /// <summary>
        /// Used to create syntax of CC57 in program
        /// </summary>
        /// <param name="startPosition">position from where the syntax to be started</param>
        /// <param name="stringVariables">The list of variabled to be appened in STRING syntax</param>
        /// <returns>a complete syntax of CC57</returns>
        public static string BuildCC57Syntax(int startPosition, List<string> stringVariables)
        {
            StringBuilder sb6 = new StringBuilder();

            sb6.Append(Constants.CommonUseItem.stringText);

            foreach (string str in stringVariables)
            {
                sb6.Append(str + Constants.CommonUseItem.Space);
            }

            string dataLine = sb6.ToString().Trim();
            sb6.Clear();
            sb6.Append(BuildCC57Text(startPosition,dataLine));

            dataLine = Constants.CommonUseItem.delimitedText + Constants.ProcedureDevision.cc57MessageText;
            sb6.Append(BuildCC57Text(startPosition, dataLine));

            dataLine = Constants.ProcedureDevision.performText + Constants.ProcedureDevision.cc57MessageSection;
            sb6.Append(BuildCC57Text(startPosition, dataLine));

            return sb6.ToString();
        }

        /// <summary>
        /// Its a private method which is called from BuildCC57Syntax to append the text in proper format
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="inputLine"></param>
        /// <returns></returns>
        private static string BuildCC57Text(int startPos, string inputLine)
        {
            StringBuilder sb1 = new StringBuilder();
            string[] inputLineArr = inputLine.Split(' ');
            string curtempLine = string.Empty;
            string prevtempLine = string.Empty;
            bool isProcessComplete = false;
            foreach (string word in inputLineArr)
            {
                curtempLine = curtempLine + " " + word;
                curtempLine = curtempLine.Trim();
                if (curtempLine.Length > 57)
                {
                    isProcessComplete = true;
                    sb1.Append(BuildCompleteLine(startPos, prevtempLine));
                    curtempLine = word;
                }
                prevtempLine = curtempLine;
            }
            if (isProcessComplete)
            {
                sb1.Append(BuildCompleteLine(startPos + 7, prevtempLine));
            }
            else
            {
                sb1.Append(BuildCompleteLine(startPos, prevtempLine));
            }
            return sb1.ToString();
        }

        /// <summary>
        /// Used to create a move statement starting from 12th column
        /// </summary>
        /// <param name="moveString">Value to be moved</param>
        /// <param name="moveToString">in which value is moving</param>
        /// <returns>complete move statement starting from 12th column</returns>
        public static string CreateMoveStatement(string moveString, string moveToString)
        {
            StringBuilder sb6 = new StringBuilder();

            for (int cntr = 1; cntr < AreaBStartPos; cntr++)
            {
                sb6.Append(' ');
            }

            sb6.Append(Constants.CommonUseItem.moveText + moveString);

            for (int cntr = 1; cntr < (AreaCStartPos - AreaBStartPos - moveString.Length - 5); cntr++)
            {
                sb6.Append(' ');
            }
            sb6.AppendLine(Constants.CommonUseItem.toText + moveToString + Constants.CommonUseItem.Dot);

            return sb6.ToString();
        }

        /// <summary>
        /// Used to create logical file name for given sequence number (Ex. CFL01, CFL02)
        /// </summary>
        /// <param name="i">Sequence number</param>
        /// <returns>Logical File name</returns>
        internal static string LogicalFileName(string i)
        {
            return ("CFL0" + i);
        }

        /// <summary>
        /// Creata a line of working storage variable on basis of data input
        /// </summary>
        /// <param name="level">Working storage level</param>
        /// <param name="workingStorage">Working Storage variable name</param>
        /// <param name="picClause">Picture clause</param>
        /// <param name="value">Value if has to be supplied</param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string CreateWorkingStorage(int level, string workingStorage, string picClause,
            string value = "", string area = "A")
        {
            StringBuilder sb7 = new StringBuilder();
            StringBuilder finalString = new StringBuilder();
            bool needSecondLine = false;
            sb7.Append(level.ToString("D2")).Append("  ").Append(workingStorage);

            if (picClause == "" && value == "")
            {
                switch (area)
                {
                    case "A":
                        return BuildAreaA(sb7.AppendLine(Constants.CommonUseItem.Dot).ToString());
                    case "B":
                        return BuildAreaB(sb7.AppendLine(Constants.CommonUseItem.Dot).ToString());
                    case "B2":
                        return BuildAreaB2(sb7.AppendLine(Constants.CommonUseItem.Dot).ToString());
                    case "B3":
                        return BuildAreaB3(sb7.AppendLine(Constants.CommonUseItem.Dot).ToString());
                    default:
                        return BuildAreaB4(sb7.AppendLine(Constants.CommonUseItem.Dot).ToString());
                }
            }

            switch(area)
            {
                case "A":
                    if (AreaAStartPos + workingStorage.Length + 6 > AreaCStartPos)
                    {
                        finalString.AppendLine(BuildAreaA(sb7.ToString()));
                        needSecondLine = true;
                        sb7 = new StringBuilder();
                    }
                    else
                    {
                        for (int cntr = 1; cntr < (AreaCStartPos - AreaAStartPos - workingStorage.Length - 4); cntr++)
                        {
                            sb7.Append(' ');
                        }
                    }
                    break;

                case "B":
                    if (AreaBStartPos + workingStorage.Length + 6 > AreaCStartPos)
                    {
                        finalString.AppendLine(BuildAreaB(sb7.ToString()));
                        needSecondLine = true;
                        sb7 = new StringBuilder();
                    }
                    else
                    {
                        for (int cntr = 1; cntr < (AreaCStartPos - AreaBStartPos - workingStorage.Length - 4); cntr++)
                        {
                            sb7.Append(' ');
                        }
                    }
                    break;

                case "B2":
                    if (AreaB2StartPos + workingStorage.Length + 6 > AreaCStartPos)
                    {
                        finalString.AppendLine(BuildAreaB2(sb7.ToString()));
                        needSecondLine = true;
                        sb7 = new StringBuilder();
                    }
                    else
                    {
                        for (int cntr = 1; cntr < (AreaCStartPos - AreaB2StartPos - workingStorage.Length - 4); cntr++)
                        {
                            sb7.Append(' ');
                        }
                    }
                    break;

                case "B3":
                    if (AreaB3StartPos + workingStorage.Length + 6 > AreaCStartPos)
                    {
                        finalString.AppendLine(BuildAreaB3(sb7.ToString()));
                        needSecondLine = true;
                        sb7 = new StringBuilder();
                    }
                    else
                    {
                        for (int cntr = 1; cntr < (AreaCStartPos - AreaB3StartPos - workingStorage.Length - 4); cntr++)
                        {
                            sb7.Append(' ');
                        }
                    }
                    break;

                default:
                    if (AreaB4StartPos + workingStorage.Length + 6 > AreaCStartPos)
                    {
                        finalString.AppendLine(BuildAreaB4(sb7.ToString()));
                        needSecondLine = true;
                        sb7 = new StringBuilder();
                    }
                    else
                    {
                        for (int cntr = 1; cntr < (AreaCStartPos - AreaB4StartPos - workingStorage.Length - 4); cntr++)
                        {
                            sb7.Append(' ');
                        }
                    }
                    break;
            }

            if (picClause != "")
            {
                if (needSecondLine)
                {
                    for (int i = 1; i < 40; i++)
                    {
                        sb7.Append(' ');
                    }
                }
                sb7.Append("PIC " + picClause);
            }

            if (value != "")
            {
                if (level == 88)
                {
                    if (needSecondLine)
                    {
                        for (int i = 1; i < 40; i++)
                        {
                            sb7.Append(' ');
                        }
                    }
                    sb7.Append("VALUE " + value);
                }
                else
                {
                    sb7.Append(" VALUE " + value);
                }
            }

            sb7.Append(Constants.CommonUseItem.Dot);
            sb7.AppendLine();

            if (needSecondLine)
            {
                finalString.Append(sb7.ToString());
            }
            else
            {
                switch (area)
                {
                    case "A":
                        finalString.Append(BuildAreaA(sb7.ToString()));
                        break;
                    case "B":
                        finalString.Append(BuildAreaB(sb7.ToString()));
                        break;
                    case "B2":
                        finalString.Append(BuildAreaB2(sb7.ToString()));
                        break;
                    case "B3":
                        finalString.Append(BuildAreaB3(sb7.ToString()));
                        break;
                    default:
                        finalString.Append(BuildAreaB4(sb7.ToString()));
                        break;
                }
            }
            return finalString.ToString();
        }

        /// <summary>
        /// Returns a working storage name for working storage number and variable name
        /// </summary>
        /// <param name="wsNumber">working storage number</param>
        /// <param name="wsName">variable name</param>
        /// <returns>working storage name</returns>
        public static string WsName(int wsNumber, string wsName)
        {
            return ("WS" + wsNumber.ToString("D2") + "-" + wsName);
        }

        /// <summary>
        /// This will create NOT DB-STATUS-OK syntax for given input params
        /// </summary>
        /// <param name="errorInPara">para name in which error occured</param>
        /// <param name="errorMessage">error message to be displayed</param>
        /// <param name="gotoPara">go to this para for exit</param>
        /// <returns>NOT DB-STATUS-OK syntax</returns>
        public static string BuildnotDBStatusSyntax(string errorInPara, string errorMessage, string gotoPara)
        {
            StringBuilder sb5 = new StringBuilder();
            sb5.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.CommonUseItem.notDBStatusOKText));
            sb5.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText + Constants.ProcedureDevision.text89996 +
                           Constants.CommonUseItem.toText + Constants.ProcedureDevision.cProgEnd));

            StringBuilder sb6 = new StringBuilder();

            sb6.Append(Constants.CommonUseItem.stringText + Constants.CommonUseItem.Quote);
            sb6.Append(errorInPara + Constants.CommonUseItem.colonSign);
            sb6.Append(errorMessage + ": " + Constants.CommonUseItem.Quote + Constants.CommonUseItem.errorStatusText);
            
            sb5.Append(BuilddbStatusText(16, sb6.ToString().Trim()));
            sb5.Append(BuilddbStatusText(16, Constants.CommonUseItem.delimitedText + Constants.ProcedureDevision.cc57MessageText));
            sb5.Append(BuilddbStatusText(16, Constants.ProcedureDevision.performText + Constants.ProcedureDevision.cc57MessageSection));
            sb5.AppendLine(BuilddbStatusText(16, Constants.CommonUseItem.gotoText + gotoPara + Constants.CommonUseItem.Dot));

            return sb5.ToString();
        }

        /// <summary>
        /// This is a private method which will be called from BuildnotDBStatusSyntax method to apppend message lines
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="inputLine"></param>
        /// <returns></returns>
        private static string BuilddbStatusText(int startPos, string inputLine)
        {
            StringBuilder sb1 = new StringBuilder();
            string[] inputLineArr = inputLine.Split(' ');
            string curtempLine = string.Empty;
            string prevtempLine = string.Empty;
            bool isProcessComplete = false;
            foreach (string word in inputLineArr)
            {
                curtempLine = curtempLine + " " + word;
                curtempLine = curtempLine.Trim();
                if (curtempLine.Length > 57)
                {
                    isProcessComplete = true;
                    sb1.Append(BuildCompleteLine(startPos, prevtempLine));
                    curtempLine = word;
                }
                prevtempLine = curtempLine;
            }
            if (isProcessComplete)
            {
                sb1.Append(BuildCompleteLine(startPos + 7, prevtempLine));
            }
            else
            {
                sb1.Append(BuildCompleteLine(startPos, prevtempLine));
            }
            return sb1.ToString();
        }

        internal static string CreateOrdinal(int num)
        {
            switch (num % 10)
            {
                case 1:
                    return " " + num + "st ";
                case 2:
                    return " " + num + "nd ";
                case 3:
                    return " " + num + "rd ";
                default:
                    return " " + num + "th ";
            }

        }

        internal static string AddOne(string addToText)
        {
            StringBuilder sb6 = new StringBuilder();

            for (int cntr = 1; cntr < AreaBStartPos; cntr++)
            {
                sb6.Append(' ');
            }

            sb6.Append(Constants.CommonUseItem.addText + "1");

            for (int cntr = 1; cntr < (AreaCStartPos - AreaBStartPos - 6); cntr++)
            {
                sb6.Append(' ');
            }
            sb6.AppendLine(Constants.CommonUseItem.toText + addToText + Constants.CommonUseItem.Dot);

            return sb6.ToString();
        }

        public static string ReformatFileLayout(string fileLayout)
        {
            try
            {
                StringBuilder returnLayout = new StringBuilder();
                lastLevel = new List<int>();

                foreach (string myString in fileLayout.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    returnLayout.Append(RepositionFileLayout(myString) + Environment.NewLine);
                }

                returnLayout.Remove(returnLayout.Length - 2, 2);
                return returnLayout.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private static string RepositionFileLayout(string myString)
        {
            try
            {
                string variableName = string.Empty;
                string value = string.Empty;
                string picClause = string.Empty;
                string[] checkVariable;
                StringBuilder returnString = new StringBuilder();

                string[] values = myString.ToUpper().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length > 1)
                {
                    variableName = values[1];
                    if (values[0] == "88")
                    {
                        if (values.Length > 3)
                        {
                            value = values[3];
                            if (value[value.Length - 1].ToString() == ".")
                            {
                                value = value.Remove(value.Length - 1);
                            }
                        }
                        else
                        {
                            return myString.ToUpper();
                        }
                    }
                    else
                    {
                        if (values.Length > 3)
                        {
                            picClause = values[3];
                            for (int i = 4; i < values.Length; i++)
                            {
                                picClause = picClause + " " + values[i];

                            }

                            if (picClause[picClause.Length - 1].ToString() == ".")
                            {
                                picClause = picClause.Remove(picClause.Length - 1);
                            }
                        }
                        else
                        {
                            if (variableName[variableName.Length - 1].ToString() == ".")
                            {
                                variableName = variableName.Remove(variableName.Length - 1);
                            }
                        }
                    }

                    switch (values[0])
                    {
                        case "01":
                        case "1":
                            lastLevel.Add(01);
                            returnString.Append(CreateWorkingStorage(01, variableName, picClause, "", "A"));
                            returnString.Remove(returnString.Length - 2, 2);
                            break;
                        case "02":
                        case "2":
                            if (!lastLevel.Contains(01) && !lastLevel.Contains(02))
                            {
                                throw new Exception("Please use 01 level for starting a layout.");
                            }
                            else
                            {
                                lastLevel.Add(02);
                                returnString.Append(CreateWorkingStorage(02, variableName, picClause, "", "B"));
                                returnString.Remove(returnString.Length - 2, 2);
                            }
                            break;
                        case "03":
                        case "3":
                            if (!lastLevel.Contains(01) && !lastLevel.Contains(02) && !lastLevel.Contains(03))
                            {
                                throw new Exception("Please use 01/02 level before using 03.");
                            }
                            else
                            {
                                lastLevel.Add(03);
                                if (lastLevel.Contains(02))
                                {
                                    returnString.Append(CreateWorkingStorage(03, variableName, picClause, "", "B2"));
                                }
                                else
                                {
                                    returnString.Append(CreateWorkingStorage(03, variableName, picClause, "", "B"));
                                }
                                returnString.Remove(returnString.Length - 2, 2);
                            }
                            break;
                        case "04":
                        case "4":
                            if (!lastLevel.Contains(01) && !lastLevel.Contains(02) && !lastLevel.Contains(03) && !lastLevel.Contains(04))
                            {
                                throw new Exception("Please use 01/02/03 level before using 04.");
                            }
                            else
                            {
                                if (lastLevel.Contains(02) || lastLevel.Contains(03))
                                {
                                    if (lastLevel.Contains(02) && lastLevel.Contains(03))
                                    {
                                        returnString.Append(CreateWorkingStorage(04, variableName, picClause, "", "B3"));
                                    }
                                    else
                                    {
                                        returnString.Append(CreateWorkingStorage(04, variableName, picClause, "", "B2"));
                                    }
                                }
                                else
                                {
                                    returnString.Append(CreateWorkingStorage(04, variableName, picClause, "", "B"));
                                }
                                returnString.Remove(returnString.Length - 2, 2);
                                lastLevel.Add(04);
                            }
                            break;
                        case "05":
                        case "5":
                            if (!lastLevel.Contains(01) && !lastLevel.Contains(02) && !lastLevel.Contains(03) &&
                                !lastLevel.Contains(04) && !lastLevel.Contains(05))
                            {
                                throw new Exception("Please use 01/02/03/04 level before using 05.");
                            }
                            else
                            {
                                if (lastLevel.Contains(02) || lastLevel.Contains(03) || lastLevel.Contains(04))
                                {
                                    if (lastLevel.Contains(02) && lastLevel.Contains(03) && lastLevel.Contains(04))
                                    {
                                        returnString.Append(CreateWorkingStorage(05, variableName, picClause, "", "B4"));
                                    }
                                    else if ((lastLevel.Contains(02) && lastLevel.Contains(03)) ||
                                        (lastLevel.Contains(02) && lastLevel.Contains(04)) ||
                                        (lastLevel.Contains(03) && lastLevel.Contains(04)))
                                    {
                                        returnString.Append(CreateWorkingStorage(05, variableName, picClause, "", "B3"));
                                    }
                                    else
                                    {
                                        returnString.Append(CreateWorkingStorage(05, variableName, picClause, "", "B2"));
                                    }
                                }
                                else
                                {
                                    returnString.Append(CreateWorkingStorage(05, variableName, picClause, "", "B"));
                                }
                                returnString.Remove(returnString.Length - 2, 2);
                                lastLevel.Add(05);
                            }
                            break;

                        case "88":
                            if (!lastLevel.Contains(01) && !lastLevel.Contains(02))
                            {
                                throw new Exception("Please use 02/03/05 level before using 88.");
                            }
                            else
                            {
                                if (lastLevel.Contains(02) || lastLevel.Contains(03) || lastLevel.Contains(05))
                                {
                                    if (lastLevel.Contains(02) && lastLevel.Contains(03) && lastLevel.Contains(05))
                                    {
                                        returnString.Append(CreateWorkingStorage(88, variableName, "", value, "B4"));
                                    }
                                    else if ((lastLevel.Contains(02) && lastLevel.Contains(03)) ||
                                        (lastLevel.Contains(02) && lastLevel.Contains(05)) ||
                                        (lastLevel.Contains(03) && lastLevel.Contains(05)))
                                    {
                                        returnString.Append(CreateWorkingStorage(88, variableName, "", value, "B3"));
                                    }
                                    else
                                    {
                                        returnString.Append(CreateWorkingStorage(88, variableName, "", value, "B2"));
                                    }
                                }
                                else
                                {
                                    returnString.Append(CreateWorkingStorage(88, variableName, "", value, "B2"));
                                }
                                returnString.Remove(returnString.Length - 2, 2);
                                lastLevel.Add(88);
                            }
                            break;
                        default:
                            returnString.Append(myString.ToUpper());
                            break;
                    }
                }
                else
                {
                    returnString.Append(myString.ToUpper());
                }

                if (!returnString.ToString().Contains(" PIC ") &&
                    !returnString.ToString().Contains(" VALUE "))
                {
                    checkVariable = returnString.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (checkVariable.Length == 2 &&
                        returnString.Length >= 40)
                    {
                        returnString = returnString.Remove(returnString.Length - 1, 1);
                    }
                }
                return returnString.ToString();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}