using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobol.BLL.BusinessModel;
using Cobol.BLL.DivisionsProcessor;

namespace Cobol.BLL
{
    public class DivisonProcessorService
    {
        public string WriteAllDivision(DivisionInputItems inputItemObj)
        {
            StringBuilder sb=new StringBuilder();
            IDivisionProcessor writerObj= DivisionProcessorFactory.CreateDivisionWriter("Identification");
            sb.Append(writerObj.Write(inputItemObj));
            writerObj = DivisionProcessorFactory.CreateDivisionWriter("Environment");
            sb.Append(writerObj.Write(inputItemObj));
            writerObj = DivisionProcessorFactory.CreateDivisionWriter("Data");
            sb.Append(writerObj.Write(inputItemObj));
            writerObj = DivisionProcessorFactory.CreateDivisionWriter("Procedure");
            sb.Append(writerObj.Write(inputItemObj));
            return sb.ToString();
        }
    }
}
