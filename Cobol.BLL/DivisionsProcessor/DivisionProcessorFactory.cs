using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Cobol.BLL.DivisionsProcessor.Impl;

namespace Cobol.BLL.DivisionsProcessor
{
    public class DivisionProcessorFactory
    {
        public static IDivisionProcessor CreateDivisionWriter(string divisionType)
        {
            switch (divisionType)
            {
                case "Identification":
                    return new IdentificationDivision();
                case "Environment":
                    return new EnvironmentDivision();
                case "Data":
                    return new DataDivision();
                case "Procedure":
                    return new ProcedureDivision();
                default:
                    return new IdentificationDivision();       
            }
        }
    }
}
