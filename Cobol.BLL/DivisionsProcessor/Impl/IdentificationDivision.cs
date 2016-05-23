using System;
using System.Globalization;
using System.Text;
using Cobol.BLL.BusinessModel;

namespace Cobol.BLL.DivisionsProcessor.Impl
{
    class IdentificationDivision:IDivisionProcessor
    {
        public string Write(DivisionInputItems inputItemObj)
        {
            StringBuilder sb =new StringBuilder();

            // Identification Division
            sb.Append(Utils.BuildAreaA(Constants.IdentificationDivision.IdDivision)).Append(Environment.NewLine);

            // Program ID
            sb.Append(Utils.BuildAreaA(Constants.IdentificationDivision.ProgramId));
            sb.Append(inputItemObj.ProgramId.Trim()).Append(Constants.CommonUseItem.Dot).Append(Environment.NewLine);
            
            // Date Written
            sb.Append(Utils.BuildAreaA(Constants.IdentificationDivision.DateWritten));
            sb.Append(DateTime.Now.ToString("MMM yyyy").ToUpper()).Append(Constants.CommonUseItem.Dot).Append(Environment.NewLine);

            // Author Name
            sb.Append(Utils.BuildAreaA(Constants.IdentificationDivision.Author));
            sb.Append(inputItemObj.AuthorName.ToUpper().Trim()).Append(Constants.CommonUseItem.Dot).Append(Environment.NewLine);

            sb.Append(string.Format("{0,-5} {1,-1}", " ", Constants.CommonUseItem.SingleComment)).Append(Environment.NewLine);

            ///////////////////////////////////////////////////////////
            //            Build Program Descritpion Box              //
            ///////////////////////////////////////////////////////////
            sb.Append(Utils.BuildCommentHeader());

            // Write Program Desription
            if (inputItemObj.CodeDescription.Length > 0)
            {
                sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.Overview, true));
                sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.OverHeader, true));
                sb.Append(Utils.BuildCommentLine(inputItemObj.CodeDescription));
            }
            
            // Write Input/Output File details
            if (inputItemObj.NoOfInputFiles > 0 | inputItemObj.NoOfOutputFIles > 0)
            {
                sb.Append(Utils.BuildCommentLine(" "));
                sb.Append(Utils.BuildCommentHeader());

                sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.ProcessingFiles, true));
                sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.Underline, true));
                sb.Append(Utils.BuildCommentLine(" "));

                // Write Input File details
                if (inputItemObj.NoOfInputFiles > 0)
                {
                    sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.InputFiles));
                    for (int i = 0; i < inputItemObj.NoOfInputFiles; i++)
                    {
                        sb.Append(Utils.BuildCommentLine(inputItemObj.InputFileNames[i] + " - " + inputItemObj.InputFileDescriptions[i]));                        
                    }
                }

                // Write output file details
                if (inputItemObj.NoOfOutputFIles > 0)
                {
                    sb.Append(Utils.BuildCommentLine(" "));
                    sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.OutputFiles));
                    for (int i = 0; i < inputItemObj.NoOfOutputFIles; i++)
                    {
                        sb.Append(Utils.BuildCommentLine(inputItemObj.OutputFileNames[i] + " - " + inputItemObj.OutputFileDescriptions[i]));
                    }
                }

            }

            sb.Append(Utils.BuildCommentLine(" "));
            sb.Append(Utils.BuildCommentHeader());

            // Write Program History Details
            sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.Version + inputItemObj.VersionNumber));
            sb.Append(Utils.BuildNameString(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputItemObj.AuthorName)));
            sb.Append(string.Format("{0,-5} {1,-1} {2,-9} {3,10} {4,-43}", " ", Constants.CommonUseItem.SingleComment,
                Constants.IdentificationDivision.Date, DateTime.Now.ToString("dd/MM/yyyy"),
                Constants.IdentificationDivision.Date2)).Append(Environment.NewLine);

            sb.Append(Utils.BuildCommentLine(Constants.IdentificationDivision.FirstVersion));            
            sb.Append(Utils.BuildCommentLine(" "));

            sb.Append(Utils.BuildCommentHeader());
            ///////////////////////////////////////////////////////////
            //           Program Descritpion Box created             //
            ///////////////////////////////////////////////////////////
            sb.Append(string.Format("{0,-5} {1,-1}", " ", Constants.CommonUseItem.PageBreak)).Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
