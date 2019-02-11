using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Air.T4.Common.Host;
using Air.T4.Common.Model.Database;
using Air.T4.Common.Model.DatabaseTableInfo;

namespace Air.T4.Common.Host
{
    /// <summary>
    /// 数据库T4模板服务Host
    /// </summary>
    [Serializable]
    public class DataBaseCoreHost : BaseHost
    {
        /// <summary>
        /// 数据库信息
        /// </summary>
        public readonly HostDatabase Database;

        public readonly List<AlterTableModel> lstModels;

        /// <summary>
        /// 数据库表名
        /// 用于修改表结构的模板
        /// </summary>
        public readonly string DatabaseTableName;

        public DataBaseCoreHost(HostDatabase database)
        {
            Database = database;

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="database">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <param name="lstModels">要修改的字段集合</param>
        public DataBaseCoreHost(HostDatabase database,string tableName, List<AlterTableModel> lstModels)
        {
            Database = database;
            this.lstModels = lstModels;
            this.DatabaseTableName = tableName;
        }


        public override object GetHostOption(string optionName)
        {
            object returnObject = null;
            //根据选项名称来获取数据
            switch (optionName)
            {
                case "CacheAssemblies":
                    returnObject = true;
                    break;
                default:
                    break;
            }
            return returnObject;
        }


        /// <summary>
        /// Gets the StandardImports
        /// 获取命名空间的列表。
        /// </summary>
        public override IList<string> StandardImports
        {
            get
            {
                return new string[]
                {
                    "System",
                    "System.IO",
                    "System.Linq",
                    "System.Text",
                    "System.Data",
                    "System.Collections.Generic",
                    "Air.T4.Common",
                    "Air.T4.Common.Host",
                    "Air.T4.Common.Model.Database",
                    "Air.T4.Common.Model.DatabaseTableInfo"

                };
            }
        }

        public override IList<string> StandardAssemblyReferences
        {
            get
            {
                return new string[]
                {
                    typeof(Uri).Assembly.Location,
                    typeof(BaseHost).Assembly.Location,
                    typeof(ParallelExecutionMode).Assembly.Location,
                    typeof(HostDatabase).Assembly.Location,
                    typeof(List<>).Assembly.Location,
                    typeof(System.Data.DataTable).Assembly.Location,
                };
            }
        }
    }
}
