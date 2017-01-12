using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobol.BLL.BusinessModel;

namespace Cobol.BLL.DivisionsProcessor.Impl
{
    class ProcedureDivision:IDivisionProcessor
    {
        public string Write(DivisionInputItems inputItemObj)
        {
            StringBuilder sb = new StringBuilder();

            // Procedure Devision
            sb.Append(Utils.BuildAreaA(Constants.ProcedureDevision.procedureDivision)).Append(Environment.NewLine);

            // write Main control section (AA-CONTROL) where we perform all sections.
            sb.Append(Utils.BuildAreaA(Constants.ProcedureDevision.aaControlSection + Constants.ProcedureDevision.sectionText));
            sb.AppendLine();
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.mainSectionHdr, true));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());

            sb.Append(Utils.BuildAreaA("AA-010.")).Append(Environment.NewLine);

            sb.Append(Utils.BuildAreaB(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.baInitialise 
                                                  + Constants.CommonUseItem.Dot)).Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(Utils.BuildAreaB(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.caMainProcessing));
            sb.Append(Environment.NewLine);

            for (int i = 1; i < 20; i++)
            {
                sb.Append(' ');
            }
            sb.Append(Constants.ProcedureDevision.untilText + Constants.DataDivision.anErrorDetected);
            sb.Append(Constants.CommonUseItem.Dot);

            //if ((inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles) > 0)
            //{
            //    sb.Append(" OR " + Constants.ProcedureDevision.endOfFile + Constants.CommonUseItem.Dot);
            //}
            //else
            //{
            //    sb.Append(Constants.CommonUseItem.Dot);
            //}
            sb.Append(Environment.NewLine).Append(Environment.NewLine);

            sb.Append(Utils.BuildAreaB(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.daEndProcessing
                                                  + Constants.CommonUseItem.Dot)).Append(Environment.NewLine);

            sb.Append(Utils.BuildAreaA("AA-999.")).Append(Environment.NewLine);
            sb.Append(Utils.BuildAreaB(Constants.ProcedureDevision.stopRunText)).Append(Environment.NewLine);
            // Main control section (AA-CONTROL) ended here.

            // write BA-INITIALISE section
            sb.AppendLine();
            sb.Append(Utils.BuildAreaA(Constants.ProcedureDevision.baInitialise + Constants.ProcedureDevision.sectionText));
            sb.AppendLine();
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.baSectionHdr));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());

            sb.Append(Utils.BuildAreaA("BA-010.")).AppendLine();

            sb.Append(Utils.BuildCompleteLine("", Constants.CommonUseItem.moveText + Constants.CommonUseItem.spaceText, 
                Constants.CommonUseItem.toText + Constants.ProcedureDevision.cc57MessageText + Constants.CommonUseItem.Dot));

            sb.AppendLine();
            
            sb.Append(Utils.BuildCompleteLine("", Constants.CommonUseItem.ifText + Constants.DataDivision.VersionNumber + 
                      Constants.CommonUseItem.notText + Constants.CommonUseItem.equalSign + Constants.CommonUseItem.spaceText, ""));

            List<string> strList = new List<string>();
            
            strList.Add(Constants.DataDivision.ProgramName);
            strList.Add(Constants.CommonUseItem.versionText);
            strList.Add(Constants.DataDivision.VersionNumber);
            sb.Append(Utils.BuildCC57Syntax(16, strList));
            strList.Clear();
            sb.Append(Utils.BuildCompleteLine(16, Constants.CommonUseItem.moveText + Constants.CommonUseItem.spaceText + 
                      Constants.CommonUseItem.toText + Constants.DataDivision.VersionNumber + Constants.CommonUseItem.Dot));
            sb.AppendLine();

            bool firstTime = true;
            foreach (string wStorage in WorkingStorage.groupLevelWorking)
            {
                if (firstTime)
                {
                    firstTime = false;
                    sb.Append(Utils.BuildAreaB(Constants.CommonUseItem.initialiseText));
                    for (int i = 0; i < 21; i++)
                    {
                        sb.Append(' ');
                    }
                    sb.AppendLine(wStorage);
                }
                else
                {
                    sb.Append(Utils.BuildCompleteLine(43, wStorage));
                }
            }
            sb.Length -= 2;
            sb.AppendLine(Constants.CommonUseItem.Dot).AppendLine();

            sb.AppendLine(Utils.CreateMoveStatement(Constants.ProcedureDevision.text89997, Constants.ProcedureDevision.cProgEnd));

            // If restart indicator is set then accept RunNo and read RUS Size from SCL
            if (inputItemObj.RestartInd)
            {
                string wsName = string.Empty;
                if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                {
                    wsName = WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.CommonUseItem.runnoText));
                    sb.AppendLine(Utils.BuildCompleteLine("", Constants.CommonUseItem.acceptText + wsName,
                        Constants.CommonUseItem.fromText + Constants.CommonUseItem.sclRunNoText));
                }
                wsName = WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RUSParameter));
                sb.AppendLine(Utils.BuildCompleteLine("", Constants.CommonUseItem.callText + Constants.CommonUseItem.readSCLIntText,
                     Constants.CommonUseItem.usingText + wsName));

                wsName = WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RUSSize));
                sb.Length -= 2;
                sb.AppendLine(Utils.BuildCompleteLine(46, wsName));

                wsName = WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RUSReply));
                sb.Length -= 2;
                sb.AppendLine(Utils.BuildCompleteLine(46, wsName + Constants.CommonUseItem.Dot));
                sb.Append(Utils.BuildCompleteLine("", Constants.CommonUseItem.ifText + wsName +
                          Constants.CommonUseItem.notText + Constants.CommonUseItem.equalSign + Constants.CommonUseItem.zeroText, ""));

                sb.Append(Utils.BuildCompleteLine(16, Constants.CommonUseItem.moveText + wsName + Constants.CommonUseItem.Space +
                          Constants.CommonUseItem.toText + WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount))));
                strList.Add(Constants.ProcedureDevision.readRusFailed1);
                strList.Add(WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount)));
                strList.Add(Constants.ProcedureDevision.readRusFailed2);
                sb.Append(Utils.BuildCC57Syntax(16, strList));
                strList.Clear();
                sb.AppendLine(Utils.BuildCompleteLine(16, Constants.CommonUseItem.moveText + Constants.ProcedureDevision.rusSizeValue +
                          Constants.CommonUseItem.toText + WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RUSSize)) +
                          Constants.CommonUseItem.Dot));
            }

            // Perform database bind and ready on database records/area if there is any database record added
            if (inputItemObj.NoOfDbRecords > 0)
            {
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.bindText + Constants.CommonUseItem.runUnitText));
                sb.Append(Utils.BuildnotDBStatusSyntax("BA-010", Constants.ProcedureDevision.bindFailedText + 
                                                                 Constants.CommonUseItem.runUnitText, "BA-999"));

                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.xaBindSection +
                                               Constants.CommonUseItem.Dot));
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.anErrorDetected));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.gotoText + "BA-999.")).AppendLine();
            }
            if (inputItemObj.NoOfDbAreas > 0)
            {
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.xbReadySection +
                                               Constants.CommonUseItem.Dot));
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.anErrorDetected));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.gotoText + "BA-999.")).AppendLine();
            }
            // Performing Bind and Ready ended here

            if (inputItemObj.RestartInd)
            {
                // Check restart and perform NEW-START and RESTART sections conditionaly
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.restartCheckHdr, true));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildSingleComment());

                if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                {
                    sb.Append(Utils.CreateMoveStatement("\"N\"",
                        WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RestartFlagText))));

                    sb.AppendLine(Utils.CreateMoveStatement(WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.CommonUseItem.runnoText)),
                        Constants.ProcedureDevision.D736RunNo));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.obtainText + Constants.CommonUseItem.anyText + 
                        Constants.ProcedureDevision.r736RecName + Constants.CommonUseItem.Dot));
                    sb.Append(Utils.BuildnotDBStatusSyntax("BA-010",
                        Constants.ProcedureDevision.obtainFailedText + Constants.ProcedureDevision.r736RecName.Split('-')[0], "BA-999"));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.obtainText + Constants.CommonUseItem.firstText +
                        Constants.ProcedureDevision.r746RecName + Constants.CommonUseItem.withinText + Constants.ProcedureDevision.s737SetName));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.CommonUseItem.dbEndOfSetText));
                    sb.AppendLine(Utils.BuildAreaB2(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.baaFreshStart));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.elseText));
                    sb.AppendLine(Utils.BuildAreaB2(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.babRestart +
                        Constants.CommonUseItem.Dot)).AppendLine();
                }
                else
                    if (inputItemObj.RestartType == Constants.RestartType.File.ToString())
                    {
                        sb.Append(Utils.CreateMoveStatement("\"Y\"",
                            WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RestartFlagText))));

                        sb.AppendLine();
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.openText + Constants.ProcedureDevision.inputText + 
                            Constants.DataDivision.restartFileText + Constants.CommonUseItem.Dot)).AppendLine();
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.readText + Constants.DataDivision.restartFileText));
                        sb.Append(Utils.BuildCompleteLine(17, Constants.ProcedureDevision.atEndText + Constants.CommonUseItem.initialiseText +
                             Constants.CommonUseItem.Space + Constants.DataDivision.restartRecText));
                        sb.AppendLine(Utils.BuildCompleteLine(17, Constants.CommonUseItem.moveText + "\"N\" " + Constants.CommonUseItem.toText +
                            WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RestartFlagText)) +
                            Constants.CommonUseItem.Dot));
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.closeText + Constants.DataDivision.restartFileText +
                            Constants.CommonUseItem.Dot)).AppendLine();
                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText +
                            WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RestartFlagText)) +
                            Constants.CommonUseItem.equalSign + "\"N\""));
                        sb.AppendLine(Utils.BuildAreaB2(Constants.ProcedureDevision.nextSentenceText));
                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.elseText));
                        sb.Append(Utils.BuildAreaB2(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.baaRestart));
                        sb.AppendLine(Constants.CommonUseItem.Dot).AppendLine();
                    }
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.anErrorDetected));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.gotoText + "BA-999.")).AppendLine();
            }

            if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles > 0)
            {
                for (int i = 0; i < inputItemObj.NoOfInputFiles; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(Utils.BuildAreaB(Constants.ProcedureDevision.openText + Constants.ProcedureDevision.inputText + " " +
                            inputItemObj.InputFileNames[i]));
                    }
                    else
                    {
                        sb.AppendLine();
                        sb.Append(Utils.BuildCompleteLine(24, inputItemObj.InputFileNames[i]));
                        sb.Length -= 2;
                    }
                }
                for (int i = 0; i < inputItemObj.NoOfOutputFiles; i++)
                {
                    if (i == 0)
                    {
                        if (inputItemObj.NoOfInputFiles > 0)
                        {
                            sb.AppendLine();
                            sb.Append(Utils.BuildCompleteLine(17, Constants.ProcedureDevision.outputText + inputItemObj.OutputFileNames[i]));
                            sb.Length -= 2;
                        }
                        else
                        {
                            sb.Append(Utils.BuildAreaB(Constants.ProcedureDevision.openText + Constants.ProcedureDevision.outputText +
                                inputItemObj.OutputFileNames[i]));
                        }
                    }
                    else
                    {
                        sb.AppendLine();
                        sb.Append(Utils.BuildCompleteLine(24, inputItemObj.OutputFileNames[i]));
                        sb.Length -= 2;
                    }
                }
                sb.AppendLine(Constants.CommonUseItem.Dot).AppendLine();
                sb.AppendLine(Utils.CreateMoveStatement("\"Y\"",
                    WorkingStorage.otherWorkingStorage.Find(s=>s.Contains(Constants.DataDivision.filesOpenText))));
            }
            sb.AppendLine(Utils.BuildAreaA("BA-999."));
            sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();

            // Main control section (BA-INITIALISE) ended here.

            // BAA-FRESH-START Section to prepare records for restart processing.
            if (inputItemObj.RestartInd && inputItemObj.RestartType == Constants.RestartType.Database.ToString())
            {
                sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.baaFreshStart + Constants.ProcedureDevision.sectionText));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.baaSectionHdr, true));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildSingleComment());
                sb.AppendLine(Utils.BuildAreaA("BAA-010."));

                List<string> restartData = WorkingStorage.restartFields.FindAll(s => s.Contains(Constants.DataDivision.RestartData)).ToList();

                for (int i = 1; i <= restartData.Count; i++)
                {
                    string restartDataOccurnce = restartData[i - 1];
                    sb.AppendLine(Utils.CreateMoveStatement(restartDataOccurnce, Constants.ProcedureDevision.r746RecName));

                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.storeText + Constants.ProcedureDevision.r746RecName + 
                        Constants.CommonUseItem.Dot));

                    if (restartData.Count > 1)
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("BAA-010",
                            Constants.ProcedureDevision.storeFailedText + Utils.CreateOrdinal(i) +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "BAA-999"));
                    }
                    else
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("BAA-010",
                         Constants.ProcedureDevision.storeFailedText + Constants.ProcedureDevision.r746RecName.Split('-')[0], "BAA-999"));
                    }
                }
                sb.Length -= 2;
                sb.AppendLine(Utils.BuildAreaA("BAA-999."));
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
            }
            // BAA-FRESH-START ended here

            if (inputItemObj.RestartInd)
            {
                // BAB-RESTART Section to peform file checkpointing and count restore after reading data from database reccords.
                if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                {
                    sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.babRestart + Constants.ProcedureDevision.sectionText));
                    sb.Append(Utils.BuildCommentHeader());
                    sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.babSectionHdr, true));
                    sb.Append(Utils.BuildCommentHeader());
                    sb.Append(Utils.BuildSingleComment());
                    sb.AppendLine(Utils.BuildAreaA("BAB-010."));

                    List<string> restartData = WorkingStorage.restartFields.FindAll(s => s.Contains(Constants.DataDivision.RestartData)).ToList();

                    if (restartData.Count > 1)
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("BAB-010", Constants.ProcedureDevision.obtainFailedText +
                         Utils.CreateOrdinal(1) + Constants.ProcedureDevision.r746RecName.Split('-')[0], "BAB-999"));
                    }
                    else
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("BAB-010", Constants.ProcedureDevision.obtainFailedText +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "BAB-999"));
                    }
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.displayText + Constants.ProcedureDevision.restartModeText));

                    sb.Append(Utils.CreateMoveStatement("\"Y\"",
                        WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RestartFlagText)))).AppendLine();


                    sb.Append(Utils.CreateMoveStatement(Constants.ProcedureDevision.r746RecName, restartData[0]));

                    for (int i = 1; i < restartData.Count; i++)
                    {
                        sb.AppendLine();
                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.obtainText + Constants.CommonUseItem.nextText +
                            Constants.ProcedureDevision.r746RecName + Constants.CommonUseItem.withinText +
                            Constants.ProcedureDevision.s737SetName));

                        sb.Append(Utils.BuildnotDBStatusSyntax("BAB-010",
                            Constants.ProcedureDevision.obtainFailedText + Utils.CreateOrdinal(i + 1) +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "BAB-999"));

                        sb.Append(Utils.CreateMoveStatement(Constants.ProcedureDevision.r746RecName, restartData[i]));
                    }

                    sb.AppendLine();
                    sb.Append(Utils.CreateMoveStatement(WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.accumulatorText)).ToString(),
                        WorkingStorage.groupLevelWorking.Find(s => s.Contains(Constants.DataDivision.progCountText)).ToString()));

                    if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles > 0)
                    {
                        sb.AppendLine(Utils.CreateMoveStatement(WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.qdataText)).ToString(),
                            WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.qdataText)).ToString()));

                        sb.AppendLine(Utils.BuildAreaA("BAB-020."));
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.setFileCheckpointText));
                        sb.Append(Utils.BuildCompleteLine(43, 
                            WorkingStorage.checkpointingFields.Find(s=>s.Contains(Constants.DataDivision.lnameText)).ToString()));
                        sb.Append(Utils.BuildCompleteLine(43,
                            WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.qdataText)).ToString()));
                        sb.Append(Utils.BuildCompleteLine(43,
                            WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.notUsedText)).ToString()));
                        sb.Append(Utils.BuildCompleteLine(43,
                            WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() +
                            Constants.ProcedureDevision.forResponseText)).AppendLine();

                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText +
                            WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() +
                            Constants.CommonUseItem.notText + Constants.CommonUseItem.equalSign + Constants.CommonUseItem.zeroText));

                        sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText + Constants.ProcedureDevision.text89934 + 
                            Constants.CommonUseItem.toText + Constants.ProcedureDevision.cProgEnd));
                        sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText +
                            WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() + 
                            Constants.CommonUseItem.Space + Constants.CommonUseItem.toText + 
                            WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount))));
                        strList.Add("\"BAB-020: ");
                        strList.Add(Constants.ProcedureDevision.setFileCheckpointFailedText);
                        strList.Add(WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount)));
                        sb.Append(Utils.BuildCC57Syntax(16, strList));
                        strList.Clear();
                        sb.Length -= 2;
                        sb.AppendLine(Constants.CommonUseItem.Dot);
                   }

                    sb.AppendLine(Utils.BuildAreaA("BAB-999."));
                    sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
                    // BAB-RESTART ended here
                }
                else
                    // BAA-RESTART Section to peform file checkpointing and count restore after reading data from resart file.
                    if (inputItemObj.RestartType == Constants.RestartType.File.ToString())
                    {
                        sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.baaRestart + Constants.ProcedureDevision.sectionText));
                        sb.Append(Utils.BuildCommentHeader());
                        sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.baaRestartSectionHdr, true));
                        sb.Append(Utils.BuildCommentHeader());
                        sb.Append(Utils.BuildSingleComment());
                        sb.AppendLine(Utils.BuildAreaA("BAA-010."));

                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.displayText + Constants.ProcedureDevision.restartModeText));

                        sb.Append(Utils.CreateMoveStatement("\"Y\"",
                            WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RestartFlagText)))).AppendLine();

                        sb.Append(Utils.CreateMoveStatement(
                            WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.restRecCountText)).ToString(),
                            WorkingStorage.groupLevelWorking.Find(s => s.Contains(Constants.DataDivision.progCountText)).ToString()));

                        if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles > 0)
                        {
                            sb.AppendLine(Utils.CreateMoveStatement(
                                WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.dataText)).ToString(),
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.qdataText)).ToString()));

                            sb.AppendLine(Utils.BuildAreaA("BAA-020."));
                            sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.setFileCheckpointText));
                            sb.Append(Utils.BuildCompleteLine(43,
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.lnameText)).ToString()));
                            sb.Append(Utils.BuildCompleteLine(43,
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.qdataText)).ToString()));
                            sb.Append(Utils.BuildCompleteLine(43,
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.notUsedText)).ToString()));
                            sb.Append(Utils.BuildCompleteLine(43,
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() +
                                Constants.ProcedureDevision.forResponseText)).AppendLine();

                            sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText +
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() +
                                Constants.CommonUseItem.notText + Constants.CommonUseItem.equalSign + Constants.CommonUseItem.zeroText));

                            sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText + Constants.ProcedureDevision.text89934 +
                                Constants.CommonUseItem.toText + Constants.ProcedureDevision.cProgEnd));
                            sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText +
                                WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() +
                                Constants.CommonUseItem.Space + Constants.CommonUseItem.toText +
                                WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount))));
                            strList.Add("\"BAA-020: ");
                            strList.Add(Constants.ProcedureDevision.setFileCheckpointFailedText);
                            strList.Add(WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount)));
                            sb.Append(Utils.BuildCC57Syntax(16, strList));
                            strList.Clear();
                            sb.Length -= 2;
                            sb.AppendLine(Constants.CommonUseItem.Dot);
                        }

                        sb.AppendLine(Utils.BuildAreaA("BAA-999."));
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
                        // BAA-RESTART ended here
                    }
            }

            // CA-MAIN-PROCESSING section starts here
            sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.caMainProcessing + Constants.ProcedureDevision.sectionText));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.caSectionHdr, true));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());
            sb.AppendLine(Utils.BuildAreaA("CA-010."));
            string tempString = WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.readCountText));
            sb.Append(Utils.AddOne(tempString));
            if (inputItemObj.RestartInd)
            {
                sb.Length -= 3;
                sb.AppendLine();
                tempString = WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.rusCountText));
                sb.AppendLine(Utils.BuildCompleteLine(42, tempString + Constants.CommonUseItem.Dot));

                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + tempString + " > " +
                    WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.RUSSize))));
                sb.AppendLine(Utils.BuildAreaB2(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.caaSuccessUnit));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.ifText + Constants.DataDivision.anErrorDetected));
                sb.Append(Utils.BuildCompleteLine(20, Constants.CommonUseItem.gotoText + "CA-999."));
            }
            sb.AppendLine(Utils.BuildAreaA("CA-999."));
            sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
            // CA-MAIN-PROCESSING ended here

            if (inputItemObj.RestartInd)
            {
                // CAA-SUCCESS-UNIT section starts here
                sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.caaSuccessUnit + Constants.ProcedureDevision.sectionText));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.caaSectionHdr));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildSingleComment());
                sb.AppendLine(Utils.BuildAreaA("CAA-010."));

                if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles > 0)
                {
                    sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.giveFileCheckpointText));
                    sb.Append(Utils.BuildCompleteLine(43,
                        WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.lnameText)).ToString()));
                    sb.Append(Utils.BuildCompleteLine(43,
                        WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.qdataText)).ToString()));
                    sb.Append(Utils.BuildCompleteLine(43,
                        WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.notUsedText)).ToString()));
                    sb.Append(Utils.BuildCompleteLine(43,
                        WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.resultText)).ToString() +
                        Constants.ProcedureDevision.forResponseText)).AppendLine();
                    tempString = WorkingStorage.checkpointingFields.Find(s => s.Contains(Constants.DataDivision.qdataText));
                    if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                    {
                        sb.Append(Utils.CreateMoveStatement(tempString,
                            WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.qdataText))));
                    }
                    else
                        if (inputItemObj.RestartType == Constants.RestartType.File.ToString())
                        {
                            sb.Append(Utils.CreateMoveStatement(tempString,
                             WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.dataText))));
                        }
                }

                if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                {
                    tempString = WorkingStorage.groupLevelWorking.Find(s => s.Contains(Constants.DataDivision.progCountText));
                    sb.AppendLine(Utils.CreateMoveStatement(tempString,
                        WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.accumulatorText))));

                    sb.AppendLine(Utils.CreateMoveStatement(
                        WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.CommonUseItem.runnoText)),
                        Constants.ProcedureDevision.D736RunNo));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.findText + Constants.CommonUseItem.anyText +
                        Constants.ProcedureDevision.r736RecName + Constants.CommonUseItem.Dot));
                    sb.Append(Utils.BuildnotDBStatusSyntax("CAA-010",
                        Constants.ProcedureDevision.findFailedText + Constants.ProcedureDevision.r736RecName.Split('-')[0], "CAA-999"));

                    List<string> restartData = WorkingStorage.restartFields.FindAll(s => s.Contains(Constants.DataDivision.RestartData)).ToList();

                    for (int i = 0; i < restartData.Count; i++)
                    {
                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.obtainText + Constants.CommonUseItem.nextText +
                            Constants.ProcedureDevision.r746RecName + Constants.CommonUseItem.withinText +
                            Constants.ProcedureDevision.s737SetName));

                        if (restartData.Count > 1)
                        {
                            sb.Append(Utils.BuildnotDBStatusSyntax("CAA-010",
                                Constants.ProcedureDevision.obtainFailedText + Utils.CreateOrdinal(i + 1) +
                                Constants.ProcedureDevision.r746RecName.Split('-')[0], "CAA-999"));
                        }
                        else
                        {
                            sb.Append(Utils.BuildnotDBStatusSyntax("CAA-010", Constants.ProcedureDevision.obtainFailedText +
                                Constants.ProcedureDevision.r746RecName.Split('-')[0], "CAA-999"));
                        }
                        sb.AppendLine(Utils.CreateMoveStatement(restartData[i], Constants.ProcedureDevision.r746RecName));
                        sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.modifyText + Constants.ProcedureDevision.r746RecName +
                            Constants.CommonUseItem.Dot));

                        if (restartData.Count > 1)
                        {
                            sb.Append(Utils.BuildnotDBStatusSyntax("CAA-010",
                                Constants.ProcedureDevision.modifyFailedText + Utils.CreateOrdinal(i + 1) +
                                Constants.ProcedureDevision.r746RecName.Split('-')[0], "CAA-999"));
                        }
                        else
                        {
                            sb.Append(Utils.BuildnotDBStatusSyntax("CAA-010", Constants.ProcedureDevision.modifyFailedText +
                                Constants.ProcedureDevision.r746RecName.Split('-')[0], "CAA-999"));
                        }
                    }
                    sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.commitText));
                    sb.Append(Utils.BuildnotDBStatusSyntax("CAA-010", Constants.ProcedureDevision.commitFailedText, "CAA-999"));
                }
                else
                    if (inputItemObj.RestartType == Constants.RestartType.File.ToString())
                    {
                        tempString = WorkingStorage.groupLevelWorking.Find(s => s.Contains(Constants.DataDivision.progCountText));
                        sb.AppendLine(Utils.CreateMoveStatement(tempString,
                            WorkingStorage.restartFields.Find(s => s.Contains(Constants.DataDivision.restRecCountText))));
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.openText +
                            Constants.ProcedureDevision.outputText + Constants.DataDivision.restartFileText +
                            Constants.CommonUseItem.Dot)).AppendLine();

                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.writeText + Constants.DataDivision.restartRecText +
                            Constants.CommonUseItem.Dot)).AppendLine();
                    }
                sb.Append(Utils.CreateMoveStatement(Constants.CommonUseItem.zeroText,
                    WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.rusCountText))));
                sb.AppendLine(Utils.BuildAreaA("CAA-999."));
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
                // CAA-SUCCESS-UNIT ended here
            }

            // DA-END-PROCESSING starts here
            sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.daEndProcessing + Constants.ProcedureDevision.sectionText));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.daSectionHdr));
            sb.Append(Utils.BuildCommentHeader());
            sb.Append(Utils.BuildSingleComment());
            sb.AppendLine(Utils.BuildAreaA("DA-010."));
            if (inputItemObj.NoOfDbRecords > 0)
            {
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.ProcedureDevision.dbDeadlockText +
                    Constants.ProcedureDevision.orText + Constants.ProcedureDevision.dualUpdateText));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.displayText + Constants.ProcedureDevision.deadlockMessageText));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText + Constants.ProcedureDevision.text89993 +
                    Constants.CommonUseItem.toText + Constants.DataDivision.cProgEnd + Constants.CommonUseItem.Dot)).AppendLine();
            }
            sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.anErrorDetected));
            sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.gotoText + "DA-020.")).AppendLine();
            if (inputItemObj.RestartInd && inputItemObj.RestartType == Constants.RestartType.Database.ToString())
            {
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.performText + Constants.ProcedureDevision.daaEraseR746 +
                    Constants.CommonUseItem.Dot));
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.anErrorDetected));
                sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.gotoText + "DA-020.")).AppendLine();
            }
            sb.Append(Utils.BuildAreaB(Constants.CommonUseItem.displayText + "\"************* "));
            sb.Append(inputItemObj.ProgramId + Constants.CommonUseItem.Space + Constants.ProcedureDevision.statisticsText);
            sb.AppendLine("*************\".");
            sb.Append(Utils.CreateMoveStatement(
                WorkingStorage.otherWorkingStorage.Find(s=>s.Contains(Constants.DataDivision.readCountText)),
                WorkingStorage.otherWorkingStorage.Find(s=>s.Contains(Constants.DataDivision.DispCount))));
            sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.displayText + Constants.ProcedureDevision.totalReadCountText +
                WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.DataDivision.DispCount)) + "."));
            sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.displayText + "\"*************************************************\"."));
            sb.AppendLine();

            sb.AppendLine(Utils.BuildAreaA("DA-020.")).AppendLine();

            if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles > 0)
            {
                sb.Append(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.filesOpenText));
                for (int i = 0; i < inputItemObj.NoOfInputFiles; i++)
                {
                    sb.AppendLine();
                    if (i == 0)
                    {
                        sb.Append(Utils.BuildAreaB2(Constants.ProcedureDevision.closeText + inputItemObj.InputFileNames[i]));
                    }
                    else
                    {
                        sb.Append(Utils.BuildCompleteLine(22, inputItemObj.InputFileNames[i]));
                        sb.Length -= 2;
                    }
                }
                for (int i = 0; i < inputItemObj.NoOfOutputFiles; i++)
                {
                    sb.AppendLine();
                    if (inputItemObj.NoOfInputFiles == 0)
                    {
                        sb.Append(Utils.BuildAreaB2(Constants.ProcedureDevision.closeText + inputItemObj.OutputFileNames[i]));
                    }
                    else
                    {
                        sb.Append(Utils.BuildCompleteLine(22, inputItemObj.OutputFileNames[i]));
                        sb.Length -= 2;
                    }
                }
                sb.AppendLine(Constants.CommonUseItem.Dot).AppendLine();
            }
            if (inputItemObj.NoOfDbRecords > 0)
            {
                if (inputItemObj.NoOfDbAreas > 0 && inputItemObj.DbAreaUsage.Find(s => s.Contains("Update")) != null)
                {
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.allOK));
                    sb.AppendLine(Utils.BuildAreaB2(Constants.ProcedureDevision.finishText));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.elseText));
                    sb.AppendLine(Utils.BuildAreaB2(Constants.ProcedureDevision.finishAfterRollbackText)).AppendLine();
                }
                else
                {
                    sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.finishText + Constants.CommonUseItem.Dot));
                }
                sb.Append(Utils.BuildnotDBStatusSyntax("DA-020", Constants.ProcedureDevision.finishFailedText, "DA-999"));
            }
            sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.DataDivision.allOK));
            sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.moveText + Constants.ProcedureDevision.text80000 +
                Constants.CommonUseItem.toText + Constants.DataDivision.cProgEnd + Constants.CommonUseItem.Dot));
            sb.AppendLine(Utils.BuildAreaA("DA-999."));
            sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
            // DA-END-PROCESSING ended here

            if (inputItemObj.RestartInd && inputItemObj.RestartType == Constants.RestartType.Database.ToString())
            {
                //DAA-ERASE-R746 section starts here
                sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.daaEraseR746 + Constants.ProcedureDevision.sectionText));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildCommentLine(Constants.ProcedureDevision.daaSectionHdr, true));
                sb.Append(Utils.BuildCommentHeader());
                sb.Append(Utils.BuildSingleComment());
                sb.AppendLine(Utils.BuildAreaA("DAA-010."));

                sb.AppendLine(Utils.CreateMoveStatement(
                    WorkingStorage.otherWorkingStorage.Find(s => s.Contains(Constants.CommonUseItem.runnoText)),
                    Constants.ProcedureDevision.D736RunNo));
                sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.findText + Constants.CommonUseItem.anyText +
                    Constants.ProcedureDevision.r736RecName + Constants.CommonUseItem.Dot));
                sb.Append(Utils.BuildnotDBStatusSyntax("DAA-010",
                    Constants.ProcedureDevision.findFailedText + Constants.ProcedureDevision.r736RecName.Split('-')[0], "DAA-999"));

                List<string> restartData = WorkingStorage.restartFields.FindAll(s => s.Contains(Constants.DataDivision.RestartData)).ToList();

                sb.AppendLine(Utils.BuildAreaA("DAA-020.")).AppendLine();

                //for (int i = 0; i < restartData.Count; i++)
                //{
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.obtainText + Constants.CommonUseItem.nextText +
                        Constants.ProcedureDevision.r746RecName + Constants.CommonUseItem.withinText +
                        Constants.ProcedureDevision.s737SetName));
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.ifText + Constants.CommonUseItem.dbEndOfSetText));
                    sb.AppendLine(Utils.BuildAreaB2(Constants.CommonUseItem.gotoText + "DAA-999.")).AppendLine();

                    if (restartData.Count > 1)
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("DAA-020",
                            Constants.ProcedureDevision.obtainFailedText + //Utils.CreateOrdinal(i + 1) +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "DAA-999"));
                    }
                    else
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("DAA-020", Constants.ProcedureDevision.obtainFailedText +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "DAA-999"));
                    }
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.eraseText + Constants.ProcedureDevision.r746RecName +
                        Constants.CommonUseItem.Dot));

                    if (restartData.Count > 1)
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("DAA-020",
                            Constants.ProcedureDevision.eraseFailedText + //Utils.CreateOrdinal(i + 1) +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "DAA-999"));
                    }
                    else
                    {
                        sb.Append(Utils.BuildnotDBStatusSyntax("DAA-020", Constants.ProcedureDevision.eraseFailedText +
                            Constants.ProcedureDevision.r746RecName.Split('-')[0], "DAA-999"));
                    }

                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.gotoText + "DAA-020.")).AppendLine();
                //}

                sb.AppendLine(Utils.BuildAreaA("DAA-999."));
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
                // DAA-ERASE-R746 ended here
            }

            // XA-BINDS Section to bind all database records.
            if (inputItemObj.NoOfDbRecords > 0)
            {
                sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.xaBindSection + Constants.ProcedureDevision.sectionText));
                sb.AppendLine(Utils.BuildAreaA("XA-010."));

                foreach (string dbRec in inputItemObj.DbRecordNames)
                {
                    sb.AppendLine(Utils.BuildAreaB(Constants.CommonUseItem.bindText + dbRec + Constants.CommonUseItem.Dot));
                    sb.Append(Utils.BuildnotDBStatusSyntax("XA-010", Constants.ProcedureDevision.bindFailedText + dbRec.Split('-')[0], "XA-999"));
                }
                sb.Length -= 2;
                sb.AppendLine(Utils.BuildAreaA("XA-999."));
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
            }
            // XA-BINDS ended here

            // XB-READY Section to ready all database area added
            if (inputItemObj.NoOfDbAreas > 0)
            {
                sb.AppendLine(Utils.BuildAreaA(Constants.ProcedureDevision.xbReadySection + Constants.ProcedureDevision.sectionText));
                sb.AppendLine(Utils.BuildAreaA("XB-010."));

                foreach (string dbArea in inputItemObj.DbAreaNames)
                {
                    if (inputItemObj.DbAreaUsage[inputItemObj.DbAreaNames.IndexOf(dbArea)] == "Retrieval")
                    {
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.readyText + dbArea + Constants.CommonUseItem.Space +
                                                       Constants.ProcedureDevision.usageModeText + Constants.ProcedureDevision.retrievalText));
                    }
                    else
                    {
                        sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.readyText + dbArea + Constants.CommonUseItem.Space +
                                                   Constants.ProcedureDevision.usageModeText + Constants.ProcedureDevision.updateText));
                    }
                    sb.Append(Utils.BuildnotDBStatusSyntax("XB-010", Constants.ProcedureDevision.readyFailedText + dbArea, "XB-999"));
                }
                sb.Length -= 2;
                sb.AppendLine(Utils.BuildAreaA("XB-999."));
                sb.AppendLine(Utils.BuildAreaB(Constants.ProcedureDevision.exitText)).AppendLine();
            }
            // XB-READY ended here

            // Copy all required copycodes here
            sb.AppendLine(Utils.BuildAreaA(Constants.DataDivision.copyText + Constants.ProcedureDevision.cc57CodeText));
            
            return sb.ToString();
        }
    }
}
