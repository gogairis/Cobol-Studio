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
        public string Write(DivisionInputItems inputItemObj)
        {
            string picClause = String.Empty;
            string value = String.Empty;
            StringBuilder sb = new StringBuilder();

            // Data Division
            sb.Append(Utils.BuildAreaA(Constants.DataDivision.DatDivision)).Append(Environment.NewLine);

            // Write Schema Details
            if (inputItemObj.NoOfDbRecords > 0)
            {
                sb.Append(Utils.BuildAreaA(Constants.DataDivision.SchemaSection)).Append(Environment.NewLine);
                sb.Append(Utils.BuildAreaA(string.Format(Constants.DataDivision.SchemaName, inputItemObj.SchemaName)));
                sb.Append(Environment.NewLine).Append(Environment.NewLine);
            }

            // Write Files Details (FD)
            if (inputItemObj.NoOfInputFiles > 0 | inputItemObj.NoOfOutputFIles > 0)
            {
                sb.Append(Utils.BuildAreaA(Constants.DataDivision.FileSection)).Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // Write Input Files Details with Layout
                for (int i = 0; i < inputItemObj.NoOfInputFiles; i++)
                {
                    sb.Append(inputItemObj.InputFieLayout[i]).Append(Environment.NewLine).Append(Environment.NewLine);
                }                
            }

            ////////////////////////////////////////////////
            ////         Working Storage Section        ////
            /////////////////////////////////////////////// 

            int WsNumber = 1;

            sb.Append(Utils.BuildAreaA(Constants.DataDivision.WorkingStorage)).Append(Environment.NewLine).Append(Environment.NewLine);

            picClause = "X(8)";
            value = Constants.CommonUseItem.Quote + inputItemObj.VersionNumber +
                                   Constants.CommonUseItem.Quote;

            sb.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.VersionNumber, picClause, value));

            picClause = "X(10)";
            value = Constants.CommonUseItem.Quote + inputItemObj.ProgramId +
                                   Constants.CommonUseItem.Quote;

            sb.Append(Utils.CreateWorkingStorage(01, Constants.DataDivision.ProgramName, picClause, value));

            if (inputItemObj.RestartInd)
            {
                if (inputItemObj.NoOfInputFiles > 0 | inputItemObj.NoOfOutputFIles > 0)
                {
                    // Create File Checkpointing details working storage
                    sb.Append(Utils.BuildCommentHeader());
                    sb.Append(Utils.BuildCommentLine(Constants.DataDivision.CheckPointHdr, true));
                    sb.Append(Utils.BuildCommentHeader());
                    sb.Append(string.Format("{0,-5} {1,-1}", " ", Constants.CommonUseItem.SingleComment)).Append(Environment.NewLine);

                    sb.Append(Utils.CreateWorkingStorage(01, Utils.WsName(WsNumber, Constants.DataDivision.CheckPointField),
                        ""));

                }
            }

            ////////////////////////////////////////////////
            ////     Working Storage Section ended      ////
            /////////////////////////////////////////////// 

            sb.Append(string.Format("{0,-5} {1,-1}", " ", Constants.CommonUseItem.PageBreak)).Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
