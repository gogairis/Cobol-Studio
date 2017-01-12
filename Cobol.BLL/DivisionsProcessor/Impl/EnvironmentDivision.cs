using System;
using System.Text;
using Cobol.BLL.BusinessModel;

namespace Cobol.BLL.DivisionsProcessor.Impl
{
    class EnvironmentDivision:IDivisionProcessor
    {
        public string Write(DivisionInputItems inputItemObj)
        {
            StringBuilder sb = new StringBuilder();

            // Environment Division
            sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.EnvDivision)).Append(Environment.NewLine);

            // Configuration Section
            sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.ConfigSection)).Append(Environment.NewLine);

            // Source/Object Computer names
            sb.Append(Environment.NewLine);
            sb.Append(Utils.BuildCompleteLine(Constants.EnvironmentDivision.SourceComputer, "", Constants.EnvironmentDivision.ComputerName));
            sb.Append(Utils.BuildCompleteLine(Constants.EnvironmentDivision.ObjectComputer, "", Constants.EnvironmentDivision.ComputerName));

            /////////////////////////////////
            //        Special Names        //
            /////////////////////////////////
            sb.Append(Environment.NewLine);
            sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.SpecialNames)).Append(Environment.NewLine);

            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.JobJournal));

            if (inputItemObj.RestartInd)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.RunNo));
            }
            sb.Append(Constants.CommonUseItem.Dot).Append(Environment.NewLine);
            /////////////////////////////////
            //    Special Names Ended      //
            /////////////////////////////////

            // Select Input/Output files
            sb.Append(Environment.NewLine);
            if (inputItemObj.NoOfInputFiles > 0 | inputItemObj.NoOfOutputFiles > 0 | 
                inputItemObj.RestartType == Constants.RestartType.File.ToString())
            {
                sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.InoutOutputSection)).Append(Environment.NewLine);
                sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.FileControl)).Append(Environment.NewLine);

                string wsLevel = string.Empty;
                if (!inputItemObj.RestartInd)
                {
                    wsLevel = "WS01-";
                }
                else
                    if (inputItemObj.RestartType == Constants.RestartType.Database.ToString())
                    {
                        wsLevel = "WS04-";
                    }
                    else
                        if (inputItemObj.NoOfInputFiles + inputItemObj.NoOfOutputFiles == 0
                            && inputItemObj.RestartType == Constants.RestartType.File.ToString())
                        {
                            wsLevel = "WS02-";
                        }
                        else
                        {
                            wsLevel = "WS03-";
                        }


                // Select Input Files
                if (inputItemObj.NoOfInputFiles > 0)
                {
                    sb.Append(Environment.NewLine);

                    for (int i = 1; i <= inputItemObj.NoOfInputFiles; i++)
                    {
                        if (inputItemObj.InputFileTypes[i - 1] == "Sequential")
                        {
                            // Sequential File
                            string areaB = Constants.EnvironmentDivision.Select + inputItemObj.InputFileNames[i - 1];
                            string areaC = Constants.EnvironmentDivision.Assign + Utils.LogicalFileName(i.ToString()) +
                                           Constants.CommonUseItem.Dot;
                            sb.Append(Utils.BuildCompleteLine("", areaB, areaC));
                            WorkingStorage.inputIndexedFile.Add("");
                        }
                        else
                        {
                            // Indexed File
                            string areaB = Constants.EnvironmentDivision.Select + inputItemObj.InputFileNames[i - 1];
                            string areaC = Constants.EnvironmentDivision.Assign + Utils.LogicalFileName(i.ToString());
                            sb.Append(Utils.BuildCompleteLine("", areaB, areaC));
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.Organization)).Append(Environment.NewLine);
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.Access));
                            sb.Append(inputItemObj.InputFileAccessType[i - 1]).Append(Environment.NewLine);
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.RecordKey));
                            sb.Append(Utils.LogicalFileName(i.ToString()) + Constants.EnvironmentDivision.Key).Append(Environment.NewLine);
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.FileStatus));
                            
                            WorkingStorage.inputIndexedFile.Add(wsLevel + Utils.LogicalFileName(i.ToString()) + Constants.EnvironmentDivision.Status);
                            sb.Append(WorkingStorage.inputIndexedFile[i-1] + Constants.CommonUseItem.Dot).Append(Environment.NewLine);
                        }
                    }
                }

                // Select Output files
                if (inputItemObj.NoOfOutputFiles > 0)
                {
                    sb.Append(Environment.NewLine);
                    for (int i = 1; i <= inputItemObj.NoOfOutputFiles; i++)
                    {
                        if (inputItemObj.OutputFileTypes[i - 1] == "Sequential")
                        {
                            // Sequential File
                            string areaB = Constants.EnvironmentDivision.Select + inputItemObj.OutputFileNames[i - 1];
                            string areaC = Constants.EnvironmentDivision.Assign +
                                           Utils.LogicalFileName((i + inputItemObj.NoOfInputFiles).ToString()) +
                                           Constants.CommonUseItem.Dot;
                            sb.Append(Utils.BuildCompleteLine("", areaB, areaC));
                            WorkingStorage.outputIndexedFile.Add("");
                        }
                        else
                        {
                            // Indexed File
                            string areaB = Constants.EnvironmentDivision.Select + inputItemObj.OutputFileNames[i - 1];
                            string areaC = Constants.EnvironmentDivision.Assign + Utils.LogicalFileName((i + inputItemObj.NoOfInputFiles).ToString());
                            sb.Append(Utils.BuildCompleteLine("", areaB, areaC));
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.Organization)).Append(Environment.NewLine);
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.Access));
                            sb.Append(inputItemObj.OutputFileAccessType[i - 1]).Append(Environment.NewLine);
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.RecordKey));
                            sb.Append(Utils.LogicalFileName((i + inputItemObj.NoOfInputFiles).ToString()) + Constants.EnvironmentDivision.Key).Append(Environment.NewLine);
                            sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.FileStatus));
                            WorkingStorage.outputIndexedFile.Add(wsLevel + Utils.LogicalFileName((i + inputItemObj.NoOfInputFiles).ToString()) + Constants.EnvironmentDivision.Status);
                            sb.Append(WorkingStorage.outputIndexedFile[i-1] + Constants.CommonUseItem.Dot).Append(Environment.NewLine);                         
                        }
                    }
                }

                if (inputItemObj.RestartInd && inputItemObj.RestartType == Constants.RestartType.File.ToString())
                {
                    sb.Append(Utils.BuildCompleteLine("",Constants.EnvironmentDivision.Select + Constants.DataDivision.restartFileText, 
                        Constants.EnvironmentDivision.Assign + Constants.DataDivision.restartFileText));
                    sb.Append(Utils.BuildAreaB(Constants.EnvironmentDivision.FileStatus));
                    WorkingStorage.otherWorkingStorage.Add(wsLevel + Constants.EnvironmentDivision.rsFileStatus);
                    sb.AppendLine(WorkingStorage.otherWorkingStorage[0] + Constants.CommonUseItem.Dot);
                }
                sb.AppendLine();
            }

            // IDMS Control Section
            if (inputItemObj.NoOfDbRecords > 0)
            {
                sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.IdmsControlSec)).Append(Environment.NewLine);

                // Protocol Mode
                sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.ProtocolMode)).Append(Environment.NewLine);

                sb.Append(Utils.BuildAreaA(Constants.EnvironmentDivision.IdmsRecord)).Append(Environment.NewLine);
            }
            sb.Append(string.Format("{0,-5} {1,-1}", " ", Constants.CommonUseItem.PageBreak)).Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
