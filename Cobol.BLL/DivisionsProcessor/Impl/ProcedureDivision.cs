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
            //sb.Append(inputItemObj.Name).Append(" Procedure");
            return sb.ToString();
        }
    }
}
