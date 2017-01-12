using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobol.BLL.BusinessModel;

namespace Cobol.BLL.DivisionsProcessor
{
    public interface IDivisionProcessor
    {
        string Write(DivisionInputItems inputItemObj);
    }
}
