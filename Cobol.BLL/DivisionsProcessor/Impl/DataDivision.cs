using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobol.BLL.BusinessModel;

namespace Cobol.BLL.DivisionsProcessor.Impl
{
    class DataDivision:IDivisionProcessor
    {
        string wsName = string.Empty;
        public string Write(DivisionInputItems inputItemObj)
        {
            string picClause = String.Empty;
            string value = String.Empty;
            StringBuilder sb = new StringBuilder();

            // Data Division
            sb.Append(Utils.BuildAreaA(Constants.DataDivision.DatDivision)).Append(Environment.NewLine);

            // Write Schema Details
            if (inputItemObj.NoOfDbRecords > 0 && inputItemObj.SchemaName.Trim() != "")
            {
                sb.Append(Utils.BuildAreaA(Constants.DataDivision.SchemaSection)).Append(Environment.NewLine);
                sb.Append(Utils.BuildAreaA(string.Format(Constants.DataDivision.SchemaName, inputItemObj.SchemaName)));
                sb.Append(Environment.NewLine).Append(Environment.NewLine);
            }

            // Write Files Details (FD)
            if (inputItemObj.NoOfInputFiles > 0 | inputItemObj.NoOfOutputFiles > 0)
            {
                sb.Append(Utils.BuildAreaA(Constants.DataDivision.FileSection)).Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // Write Input Files Details with Layout
                for (int i = 0; i < inputItemObj.NoOfInputFiles; i++)
                {
                    sb.Append(inputItemObj.InputFieLayout[i]).Append(Environment.NewLine).Append(Environment.NewLine);
                }

                // Write Output Files Details with Layout
                for (int i = 0; i < inputItemObj.NoOfOutputFiles; i++)
                {
                    sb.Append(inputItemObj.OutputFieLayout[i]).Append(Environment.NewLine).Append(Environment.NewLine);
                }
            }
            if (inputItemObj.RestartInd && inputItemObj.RestartType == Constants.RestartType.File.ToString())
            {
                sb.AppendLine(Utils.BuildAreaA("FD " + Constants.DataDivision.restartFileText));
                sb.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.restartRecText, ""));
                if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles > 0)
                {
                    wsName = Constants.DataDivision.restText + "-" + Constants.DataDivision.dataText;
                    WorkingStorage.restartFields.Add(wsName);
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, "X(" +
                        (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles) * 100 + ")", "", "B"));

                    wsName = Constants.DataDivision.restText + "-" + Constants.DataDivision.lengthText;
                    WorkingStorage.restartFields.Add(wsName);
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, "9(09) COMP SYNC",
                        Convert.ToString((inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles) * 100), "B"));
                }

                wsName = Constants.DataDivision.restText + "-" + Constants.DataDivision.restRecCountText;
                WorkingStorage.restartFields.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName, "", "", "B"));
                sb.Append(Utils.CreateWorkingStorage(05,
                    Constants.DataDivision.restText + "-" + Constants.DataDivision.readCountText, "S9(08) COMP SYNC", "", "B2"));
                sb.AppendLine();
            }

            ////////////////////////////////////////////////
            ////         Working Storage Section        ////
            /////////////////////////////////////////////// 

            int WsNumber = 1;
            int _nTotalFiles = inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles;

            sb.Append(Utils.BuildAreaA(Constants.DataDivision.WorkingStorage)).Append(Environment.NewLine).Append(Environment.NewLine);

            picClause = "X(08)";
            value = Constants.CommonUseItem.Quote + inputItemObj.VersionNumber +
                                   Constants.CommonUseItem.Quote;

            sb.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.VersionNumber, picClause, value));

            picClause = "X(10)";
            value = Constants.CommonUseItem.Quote + inputItemObj.ProgramId +
                                   Constants.CommonUseItem.Quote;

            sb.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.ProgramName, picClause, value));
            sb.Append(Environment.NewLine);

            if (inputItemObj.RestartInd)
            {
                if (_nTotalFiles > 0)
                {
                    // Create File Checkpointing details working storage
                    sb.Append(Utils.BuildCommentHeader());
                    sb.Append(Utils.BuildCommentLine(Constants.DataDivision.CheckPointHdr, true));
                    sb.Append(Utils.BuildCommentHeader());
                    sb.Append(Utils.BuildSingleComment());

                    wsName = Utils.WsName(WsNumber, Constants.DataDivision.CheckPointField);
                    WorkingStorage.groupLevelWorking.Add(wsName);
                    sb.Append(Utils.CreateWorkingStorage(01, wsName, ""));

                    wsName = Utils.WsName(WsNumber, Constants.DataDivision.lnameText);
                    WorkingStorage.checkpointingFields.Add(wsName);
                    picClause = "X(04)";
                    value = "SPACES";
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, value, "B"));

                    wsName = Utils.WsName(WsNumber, Constants.DataDivision.qdataText);
                    WorkingStorage.checkpointingFields.Add(wsName);
                    picClause = "X(" + _nTotalFiles * 100 + ")";
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, "", "B"));

                    picClause = "9(09) COMP SYNC";
                    value = (_nTotalFiles * 100).ToString();
                    sb.Append(Utils.CreateWorkingStorage(03, Utils.WsName(WsNumber, "QDATA-LENGTH"), picClause, value, "B"));

                    wsName = Utils.WsName(WsNumber, Constants.DataDivision.notUsedText);
                    WorkingStorage.checkpointingFields.Add(wsName);
                    picClause = "X(04)";
                    value = "SPACES";
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, value, "B"));

                    wsName = Utils.WsName(WsNumber, Constants.DataDivision.resultText);
                    WorkingStorage.checkpointingFields.Add(wsName);
                    picClause = "S9(09) COMP SYNC";
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, "", "B"));

                    sb.Append(Environment.NewLine);
                    ++WsNumber;
                }

                if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                {
                    // Create area for restart data in case of database restart
                    sb.Append(createRestartData(_nTotalFiles, WsNumber));
                    sb.Append(Environment.NewLine);
                    ++WsNumber;
                }

                // Create RUS paramters area
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildCommentLine(Constants.DataDivision.RUSHdr, true));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildSingleComment());

                wsName = Utils.WsName(WsNumber,Constants.DataDivision.SCLParameter);
                WorkingStorage.groupLevelWorking.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(01, wsName,""));
                picClause = "X(13)";
                value = '"' + inputItemObj.ProgramId + "RUS" + '"';

                wsName = Utils.WsName(WsNumber, Constants.DataDivision.RUSParameter);
                WorkingStorage.otherWorkingStorage.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName,picClause,value,"B"));
                picClause = "S9(17) COMP SYNC";

                wsName = Utils.WsName(WsNumber, Constants.DataDivision.RUSSize);
                WorkingStorage.otherWorkingStorage.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName,picClause,"", "B"));

                wsName = Utils.WsName(WsNumber, Constants.DataDivision.RUSReply);
                WorkingStorage.otherWorkingStorage.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, "", "B"));
                
                sb.Append(Environment.NewLine);
                ++WsNumber;
            }

            //// Build area for other work fields required for program processing ////
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.DataDivision.ProgProcessHdr));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());

            wsName = Utils.WsName(WsNumber, Constants.DataDivision.WorkFields);
            WorkingStorage.groupLevelWorking.Add(wsName);
            sb.Append(Utils.CreateWorkingStorage(01, wsName, ""));
            picClause = "ZZZ,ZZZ,ZZ9";

            wsName = Utils.WsName(WsNumber, Constants.DataDivision.DispCount);
            WorkingStorage.otherWorkingStorage.Add(wsName);
            sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause,"", "B"));

            if (_nTotalFiles > 0)
            {
                picClause = "X(02)";
                for (int i = 0; i < inputItemObj.NoOfInputFiles; i++)
                {
                    if (inputItemObj.InputFileTypes[i] == "Indexed")
                    {
                        sb.Append(Utils.CreateWorkingStorage(03, WorkingStorage.inputIndexedFile[i], picClause,"", "B"));
                    }
                }
                for (int i = 0; i < inputItemObj.NoOfOutputFiles; i++)
                {
                    if (inputItemObj.OutputFileTypes[i] == "Indexed")
                    {
                        sb.Append(Utils.CreateWorkingStorage(03, WorkingStorage.outputIndexedFile[i], picClause,"", "B"));
                    }
                }

                picClause = "X(01)";
                value = "\"N\"";
                wsName = Utils.WsName(WsNumber, Constants.DataDivision.filesOpenText);
                WorkingStorage.otherWorkingStorage.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, value, "B"));

                value = "\"Y\"";
                sb.Append(Utils.CreateWorkingStorage(88, Constants.DataDivision.filesOpenText, "", value, "B2"));
            }
            if (inputItemObj.RestartInd)
            {
                if (inputItemObj.RestartType == Constants.RestartType.File.ToString())
                {
                    picClause = "X(02)";
                    sb.Append(Utils.CreateWorkingStorage(03,
                        WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.EnvironmentDivision.rsFileStatus)).ToString(),
                        picClause, "", "B"));
                }
                else if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                {
                    picClause = "9(06)";
                    wsName = Utils.WsName(WsNumber, Constants.CommonUseItem.runnoText);

                    WorkingStorage.otherWorkingStorage.Add(wsName);
                    sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, "", "B"));
                }
                picClause = "X(01)";
                value = "\"N\"";
                wsName = Utils.WsName(WsNumber, Constants.DataDivision.RestartFlagText);

                WorkingStorage.otherWorkingStorage.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, value, "B"));

                picClause = "S9(08) COMP SYNC";
                wsName = Utils.WsName(WsNumber, Constants.DataDivision.rusCountText);

                WorkingStorage.otherWorkingStorage.Add(wsName);
                sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, "", "B"));
            }
            ++WsNumber;
            sb.AppendLine();

            ///// Work field ended here /////

            //// Build area for counts used in program processing ////
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.DataDivision.ProgCountsHdr, true));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());

            wsName = Utils.WsName(WsNumber, Constants.DataDivision.progCountText);
            WorkingStorage.groupLevelWorking.Add(wsName);
            sb.Append(Utils.CreateWorkingStorage(01, wsName, ""));

            picClause = "S9(08) COMP SYNC";

            wsName = Utils.WsName(WsNumber, Constants.DataDivision.readCountText);
            WorkingStorage.otherWorkingStorage.Add(wsName);
            sb.Append(Utils.CreateWorkingStorage(03, wsName, picClause, "", "B"));

            ++WsNumber;
            sb.AppendLine();

            ///// Counts Area ended here /////

            //// Build area for Copy data from copybooks or function param files ////

            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.DataDivision.copyBookHdr, true));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());

            sb.AppendLine(Utils.BuildAreaA(Constants.DataDivision.copyText + Constants.DataDivision.cc57DataText));
            sb.AppendLine();
            //// CopyBok area ended here ////

            //// Copy SUBSCHEMA details and record names used in program ////
            if (inputItemObj.NoOfDbRecords > 0)
            {
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildCommentLine(Constants.DataDivision.dbRecHdr, true));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildSingleComment());

                sb.Append(Utils.BuildAreaA(Constants.DataDivision.copyText + Constants.DataDivision.idmsText + 
                                                 Constants.DataDivision.schemaCTRL + Constants.CommonUseItem.Dot));
                sb.Append(Environment.NewLine);
                sb.Append(Utils.BuildAreaA(Constants.DataDivision.copyText + Constants.DataDivision.idmsText + 
                                                 Constants.DataDivision.schemaNames + Constants.CommonUseItem.Dot));
                sb.Append(Environment.NewLine);

                foreach (string dbRec in inputItemObj.DbRecordNames)
                {
                    sb.Append(Utils.BuildAreaA(Constants.DataDivision.copyText + Constants.DataDivision.idmsText +
                                                     dbRec + Constants.CommonUseItem.Dot));
                    sb.Append(Environment.NewLine);
                }
                sb.Append(Environment.NewLine);
            }
            //// DBRec area ended here ////

            ////////////////////////////////////////////////
            ////     Working Storage Section ended      ////
            /////////////////////////////////////////////// 

            //////////////////////////////////////////
            ////     Linkage Section starts      ////
            ///////////////////////////////////////// 

            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.DataDivision.linkageHdr, true));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());

            sb.Append(Utils.BuildAreaA(Constants.DataDivision.linkageSection)).Append(Environment.NewLine);
            picClause = "S9(17) COMP SYNC";
            sb.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.cProgEnd, picClause));
            value = "-80000 89997";
            sb.Append(Utils.CreateWorkingStorage(88, Constants.DataDivision.allOK, "", value, "B"));
            value = "1 THRU 89996";
            sb.Append(Utils.CreateWorkingStorage(88, Constants.DataDivision.anErrorDetected, "", value, "B"));

            ///////////////////////////////////////////
            ////      Linkage Section ended       ////
            ////////////////////////////////////////// 

            sb.Append(string.Format("{0,-5} {1,-1}", " ", Constants.CommonUseItem.PageBreak)).Append(Environment.NewLine);
            return sb.ToString();
        }

        private string createRestartData(int totalFiles, int wsNumber)
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.Append(Utils.BuildCommentHeader());
            returnValue.Append(Utils.BuildCommentLine(Constants.DataDivision.RestartHdr, true));
            returnValue.Append(Utils.BuildCommentHeader());
            returnValue.Append(Utils.BuildSingleComment());

            wsName = Utils.WsName(wsNumber, Constants.DataDivision.RestartField);
            WorkingStorage.groupLevelWorking.Add(wsName);

            returnValue.Append(Utils.CreateWorkingStorage(01,wsName,""));
            int restartDataCount = 0;

            for (int i = 1; i <= (totalFiles / 3) + 1; i++)
            {
                if (totalFiles > 2)
                {
                    wsName = Utils.WsName(wsNumber, Constants.DataDivision.RestartData + "-" + i);

                    WorkingStorage.restartFields.Add(wsName);
                    returnValue.Append(Utils.CreateWorkingStorage(03, wsName, "X(300)","", "B"));
                    restartDataCount++;
                }
                else
                {
                    wsName = Utils.WsName(wsNumber, Constants.DataDivision.RestartData);

                    WorkingStorage.restartFields.Add(wsName);
                    returnValue.Append(Utils.CreateWorkingStorage(03, wsName, "", "", "B"));
                    restartDataCount++;
                }
            }
            if (totalFiles > 2)
            {
                returnValue.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.fillerRedefiles + Utils.WsName(wsNumber, Constants.DataDivision.RestartField), ""));
                returnValue.Append(Utils.CreateWorkingStorage(03, Utils.WsName(wsNumber, "RESTART"), "","", "B"));
            }

            if (totalFiles > 0)
            {
                wsName = Utils.WsName(wsNumber, Constants.DataDivision.qdataText);

                WorkingStorage.restartFields.Add(wsName);
                returnValue.Append(Utils.CreateWorkingStorage(05, wsName, "X(" + totalFiles * 100 + ")","","B2"));
            }

            wsName = Utils.WsName(wsNumber, Constants.DataDivision.accumulatorText);

            WorkingStorage.restartFields.Add(wsName);
            returnValue.Append(Utils.CreateWorkingStorage(05, wsName, "X(32)","", "B2"));
            returnValue.Append(Utils.CreateWorkingStorage(05, Utils.WsName(wsNumber, "FILLERS"), "X(" + (restartDataCount * 300 - totalFiles * 100 - 32) + ")","", "B2"));
            return returnValue.ToString();
        }
    }
}
