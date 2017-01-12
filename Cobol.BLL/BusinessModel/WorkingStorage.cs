using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobol.BLL.BusinessModel
{
    public static class WorkingStorage
    {
        public static List<string> inputIndexedFile = new List<string>();
        public static List<string> outputIndexedFile = new List<string>();
        public static List<string> groupLevelWorking = new List<string>();
        public static List<string> otherWorkingStorage = new List<string>();
        public static List<string> checkpointingFields = new List<string>();
        public static List<string> restartFields = new List<string>();
    }
}
