using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobol.BLL.BusinessModel
{
    public static class DatabaseRepository
    {
        public static List<DatabaseName> dbRepository = new List<DatabaseName>();
    }

    public static class AreaRepository
    {
        public static List<DBAreaData> areaRepository = new List<DBAreaData>();
    }

    public class DatabaseName
    {
        public DatabaseName(string dbName)
        {
            _dbName = dbName;
        }
        private string _dbName;

        public string DBRecName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }
    }

    public class DBAreaData
    {
        public DBAreaData(string areaName, string usageMode)
        {
            _areaName = areaName;
            _usageMode = usageMode;
        }
        private string _areaName;
        private string _usageMode;

        public string AreaNames
        {
            get { return _areaName; }
            set { _areaName = value; }
        }

        public string UsageMode
        {
            get { return _usageMode; }
            set { _usageMode = value; }
        }
    }

}
