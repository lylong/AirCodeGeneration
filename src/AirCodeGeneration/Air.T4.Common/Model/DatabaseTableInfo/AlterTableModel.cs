using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air.T4.Common.Model.DatabaseTableInfo
{


    /// <summary>
    /// 修改数据库表模型
    /// </summary>
    [Serializable]
    public class AlterTableModel
    {

        /// <summary>
        /// 字段名(这里默认写属性名称)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 选择
        /// </summary>
        public int Sel { get; set; }

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsPramaryKey { get; set; }

        /// <summary>
        /// 自增值 
        /// 如:identity(1,1)
        /// </summary>
        public string IdentityValue { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 约束
        /// 如:Unique、NotNull
        /// </summary>
        public string Constraint { get; set; }

        /// <summary>
        /// 操作类型
        /// add-新增字段,modify-修改字段类型,del-删除字段
        /// </summary>
        public string OperateType { get; set; }
    }
}
