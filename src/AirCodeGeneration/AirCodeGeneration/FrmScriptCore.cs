using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Air.Currency.Frame.Library;
using System.Windows.Forms;
using Air.CodeGeneration.Common;
using Air.CodeGeneration.Data.Core.Attribute;
using Air.CodeGeneration.Data.Core.Dto;
using System.Reflection;
using Air.CodeGeneration.Data.Core.Model;
using Air.T4.Common;
using Air.T4.Common.Host;
using Air.T4.Common.Model.Database;
using AutoMapper;
using Air.Currency.Frame.Library.Extension;

namespace AirCodeGeneration
{
    public partial class FrmScriptCore : Form
    {
        private DataTable _dt_Models;
        private List<Type> _lst_Types = null;
        public FrmScriptCore()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string output = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Output");
            this.txt_Output.Text = output;
            SetCmbData();
        }

        private void SetCmbData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            DataRow dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Name"] = ".Net Standard";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Name"] = "Framework";
            dt.Rows.Add(dr);

            cmb_Platform.DataSource = dt;
            cmb_Platform.ValueMember = "Id";
            cmb_Platform.DisplayMember = "Name";
            cmb_Platform.SelectedIndex = 1;
            this.cmb_Platform.SelectedValueChanged += new System.EventHandler(this.cmb_Platform_SelectedValueChanged);
        }

        /// <summary>
        /// 选择dll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectDLL_Click(object sender, EventArgs e)
        {
            LoadDLL();
        }

        /// <summary>
        /// 生成脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Execute_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dt_Models?.Rows?.Count <= 0 || _lst_Types == null)
                {
                    MessageBox.Show("没有可生成脚本的DLL!");
                    return;
                }
                if (cmb_Platform.SelectedValue == null)
                {
                    MessageBox.Show("请选择DLL平台");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_DatabaseName.Text))
                {
                    if (MessageBox.Show("检测到您未填写数据库名称，是否继续生成脚本文件?", "询问", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }

                int platform = (int)(cmb_Platform.SelectedValue);
                WriteCreateDBTableScript(platform);
            }
            catch (Exception ex)
            {
                LogWrite(ex.Message);
            }
        }

        /// <summary>
        /// 写入脚本
        /// </summary>
        /// <param name="platform"></param>
        private void WriteCreateDBTableScript(int platform = 1)
        {
            string t4FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, T4Consts.FILE_Folder, T4Consts.DB_TABLE_CREATE_FILE_NAME);
            HostDatabase hostDatabase = new HostDatabase();
            hostDatabase.Name = txt_DatabaseName.Text;
            DataBaseCoreHost host = new DataBaseCoreHost(hostDatabase);
            string scriptFileName = string.Empty;

            switch (platform)
            {
                case 1: //.Net Standard
                    {
                        Air.CodeGeneration.Data.Core.Model.Database database = new Air.CodeGeneration.Data.Core.Model.Database()
                        {
                            Name = txt_DatabaseName.Text
                        };
                        database.TableItems = new List<DatabaseTable>();
                        foreach (DataGridViewRow row in dgv_Dll.Rows)
                        {
                            if (row.Cells["Col_Name"].Value.ToString() == "全选") continue;
                            if (row.Cells["Col_Sel"].Value.ToString() == "false") continue;
                            scriptFileName = row.Cells["Col_Name"].Value.ToString();
                            string tableName = row.Cells["Col_Name"].Value.ToString();
                            T4EngineHelper.SetCoreDataBaseTableItems(tableName, database, _lst_Types);
                        }
                        if (database.TableItems.Count <= 0) return;
                        // hostDatabase.TableItems = database.TableItems.MapTo(new List<HostDatabaseTable>());
                        // var mapper = new Mapper(Mapper.Configuration);
                        hostDatabase.TableItems = Mapper.Map<List<HostDatabaseTable>>(database.TableItems);
                        break;
                    }
                case 2:  //Framework
                    {
                        Air.CodeGeneration.Data.Model.Database database = new Air.CodeGeneration.Data.Model.Database()
                        {
                            Name = txt_DatabaseName.Text
                        };
                        database.TableItems = new List<Air.CodeGeneration.Data.Model.DatabaseTable>();
                        foreach (DataGridViewRow row in dgv_Dll.Rows)
                        {
                            if (row.Cells["Col_Name"].Value.ToString() == "全选") continue;
                            if (row.Cells["Col_Sel"].Value.ToString() == "false") continue;
                            scriptFileName = row.Cells["Col_Name"].Value.ToString();
                            string tableName = row.Cells["Col_Name"].Value.ToString();
                            T4EngineHelper.SetDataBaseTableItems(tableName, database, _lst_Types);
                        }
                        if (database.TableItems.Count <= 0) return;
                        //hostDatabase.TableItems = database.TableItems.MapTo(new List<HostDatabaseTable>());
                        hostDatabase.TableItems = Mapper.Map<List<HostDatabaseTable>>(database.TableItems);
                        break;
                    }
                default:
                    throw new Exception($"参数[{nameof(platform)}]值有误!");
            }
            string output = Path.Combine(txt_Output.Text, scriptFileName + ".sql");
            rtb_Script.Text = T4EngineHelper.ProcessTemplate(t4FilePath, host, output, LogWrite);
        }

        //private void WriteNetCoreScript()
        //{
        //    //需要选择T4模板进行导出脚本
        //    string t4FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, T4Consts.FILE_Folder, T4Consts.DB_TABLE_CREATE_FILE_NAME);
        //    Air.Data.Core.Model.Database database = new Air.Data.Core.Model.Database()
        //    {
        //        Name = txt_DatabaseName.Text
        //    };
        //    database.TableItems = new List<DatabaseTable>();
        //    string scriptFileName = string.Empty;
        //    foreach (DataGridViewRow row in dgv_Dll.Rows)
        //    {
        //        if (row.Cells["Col_Name"].Value.ToString() == "全选") continue;
        //        if (row.Cells["Col_Sel"].Value.ToString() == "false") continue;
        //        scriptFileName = row.Cells["Col_Name"].Value.ToString();
        //        string tableName = row.Cells["Col_Name"].Value.ToString();
        //        T4EngineHelper.SetCoreDataBaseTableItems(tableName, database, _lst_Types);
        //    }
        //    if (database.TableItems.Count <= 0) return;
        //    HostDatabase hostDatabase = new HostDatabase();
        //    hostDatabase.Name = txt_DatabaseName.Text;
        //    hostDatabase.TableItems = database.TableItems.MapTo(new List<HostDatabaseTable>());
        //    DataBaseCoreHost host = new DataBaseCoreHost(hostDatabase);
        //    string output = Path.Combine(txt_Output.Text, scriptFileName + ".sql");
        //    rtb_Script.Text = T4EngineHelper.ProcessTemplate(t4FilePath, host, output, LogWrite);
        //}

        //private void WriteFrameworkScript()
        //{
        //    //需要选择T4模板进行导出脚本
        //    string t4FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, T4Consts.FILE_Folder, T4Consts.DB_TABLE_CREATE_FILE_NAME);
        //    Air.Data.Model.Database database = new Air.Data.Model.Database()
        //    {
        //        Name = txt_DatabaseName.Text
        //    };
        //    database.TableItems = new List<Air.Data.Model.DatabaseTable>();
        //    string scriptFileName = string.Empty;
        //    foreach (DataGridViewRow row in dgv_Dll.Rows)
        //    {
        //        if (row.Cells["Col_Name"].Value.ToString() == "全选") continue;
        //        if (row.Cells["Col_Sel"].Value.ToString() == "false") continue;
        //        scriptFileName = row.Cells["Col_Name"].Value.ToString();
        //        string tableName = row.Cells["Col_Name"].Value.ToString();
        //        T4EngineHelper.SetDataBaseTableItems(tableName, database, _lst_Types);
        //    }
        //    if (database.TableItems.Count <= 0) return;
        //    HostDatabase hostDatabase = new HostDatabase();
        //    hostDatabase.Name = txt_DatabaseName.Text;
        //    hostDatabase.TableItems = database.TableItems.MapTo(new List<HostDatabaseTable>());
        //    DataBaseCoreHost host = new DataBaseCoreHost(hostDatabase);
        //    string output = Path.Combine(txt_Output.Text, scriptFileName + ".sql");
        //    rtb_Script.Text = T4EngineHelper.ProcessTemplate(t4FilePath, host, output, LogWrite);
        //}

        private void LogWrite(string logValue)
        {
            this.Invoke(new Action(() =>
            {
                this.rich_Txt_Logs.Text = string.Concat(Environment.NewLine, logValue);
            }));
        }

        private void cmb_Platform_SelectedValueChanged(object sender, EventArgs e)
        {
            //需要重新加载DLL
            if (string.IsNullOrWhiteSpace(txt_DllFilePath.Text)) return;
            _lst_Types = null;
            _dt_Models = T4EngineHelper.GetTypeDataTable(txt_DllFilePath.Text, ref _lst_Types, (int)cmb_Platform.SelectedValue);
            this.dgv_Dll.DataSource = _dt_Models;
        }

        private void LoadDLL()
        {
            if (cmb_Platform.SelectedValue == null)
            {
                MessageBox.Show("请选择DLL平台");
                return;
            }
            using (OpenFileDialog dlgText = new OpenFileDialog())
            {
                dlgText.Filter = "|*.dll";
                if (dlgText.ShowDialog() == DialogResult.OK)
                {
                    txt_DllFilePath.Text = dlgText.FileName;
                    _dt_Models = T4EngineHelper.GetTypeDataTable(dlgText.FileName, ref _lst_Types, (int)cmb_Platform.SelectedValue);
                    this.dgv_Dll.DataSource = _dt_Models;
                }
            }
        }

        private void btn_OpenFileDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", $"{this.txt_Output.Text.Trim()}");
        }

        private void txt_Output_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", $"{this.txt_Output.Text.Trim()}");
        }

        /// <summary>
        /// 双击网格的单元格,显示类的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Dll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 验证
            if (dgv_Dll.DataSource == null)
                return;
            DataTable tb = (DataTable)dgv_Dll.DataSource;
            if (tb == null || tb.Rows.Count <= 0)
                return;
            if (e.RowIndex < 0 || e.RowIndex > dgv_Dll.Rows.Count - 2)
                return;
            #endregion

            string className = dgv_Dll.Rows[e.RowIndex].Cells["Col_Name"].Value.ToString();
            GetClassDetail(className,(int)cmb_Platform.SelectedValue);
        }

        /// <summary>
        /// 获取类的详细信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="platForm">DLL平台</param>
        private void GetClassDetail(string className,int platForm=1)
        {
            #region 构建DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(Int32)));//序号
            dt.Columns.Add(new DataColumn("Sel",typeof(Int32)));//选择
            dt.Columns.Add(new DataColumn("Name", typeof(string)));//字段名
            dt.Columns.Add(new DataColumn("IsPramaryKey", typeof(string)));//是否主键
            dt.Columns.Add(new DataColumn("IdentityValue", typeof(string)));//自增值 
            dt.Columns.Add(new DataColumn("DataType", typeof(string)));//数据类型
            dt.Columns.Add(new DataColumn("DefaultValue", typeof(string)));//默认值
            dt.Columns.Add(new DataColumn("Constraint", typeof(string)));//约束
            dt.Columns.Add(new DataColumn("OperateType", typeof(string)));//操作类型(添加，删除，修改字段类型)
            #endregion

            #region 通过反射获取选指定类的信息，并且获取自定义特性
            Type t = _lst_Types.Find(p => p.Name == className);
            List<PropertyInfo> lstField = new List<PropertyInfo>();
            switch(platForm)
            {
                case 1://.Net Standard
                    lstField = t.GetProperties()
                            .Where(p => p.GetCustomAttribute<Air.CodeGeneration.Data.Core.Attribute.DataBaseFieldRuleAttribute>() != null)
                            .ToList();
                    break;
                case 2://Framework
                    lstField = t.GetProperties()
                            .Where(p => p.GetCustomAttribute<Air.CodeGeneration.Data.Attribute.DataBaseFieldRuleAttribute>() != null)
                            .ToList();
                    break;
            }
            #endregion

            #region 遍历属性，根据属性的自定义特性拼凑表数据
            int i = 0;
            DataRow dr = null;
            foreach (PropertyInfo field in lstField)
            {
                i++;
                switch(platForm)
                {
                    case 1://.Net Standard
                        #region 获取这个字段的自定义特性，拼凑DataTable的数据
                        List<Air.CodeGeneration.Data.Core.Attribute.DataBaseFieldRuleAttribute> lstCoreAttrs = new List<DataBaseFieldRuleAttribute>();
                        Air.CodeGeneration.Data.Core.Attribute.DataBaseFieldRuleAttribute coreAttribute = field.GetAttribute<Air.CodeGeneration.Data.Core.Attribute.DataBaseFieldRuleAttribute>();
                        dr = dt.NewRow();
                        dr["Id"] = i;
                        dr["Sel"] = 0;
                        dr["Name"] = Convertor.IsNull(coreAttribute.Name, field.Name);// 字段名
                        dr["IsPramaryKey"] = Convert.ToInt32(coreAttribute.IsPramaryKey);//是否是主键
                        dr["IdentityValue"] = Convertor.IsNull(coreAttribute.IdentityValue,"");// 自增值
                        dr["DataType"] = Convertor.IsNull(coreAttribute.DataType, "");//数据类型
                        dr["DefaultValue"] = Convertor.IsNull(coreAttribute.DefaultValue, "");//默认值
                        dr["Constraint"] = Convertor.IsNull(coreAttribute.Constraint, "");//约束
                        dr["OperateType"] = "";
                        dt.Rows.Add(dr);
                        #endregion 
                        break;
                    case 2://Framework
                        #region 获取这个字段的自定义特性，拼凑DataTable的数据
                        List < Air.CodeGeneration.Data.Attribute.DataBaseFieldRuleAttribute > lstAttrs = new List<Air.CodeGeneration.Data.Attribute.DataBaseFieldRuleAttribute>();
                        Air.CodeGeneration.Data.Attribute.DataBaseFieldRuleAttribute attribute = field.GetAttribute<Air.CodeGeneration.Data.Attribute.DataBaseFieldRuleAttribute>();
                        dr = dt.NewRow();
                        dr["Id"] = i;
                        dr["Sel"] = 0;
                        dr["Name"] = Convertor.IsNull(attribute.Name, field.Name);// 字段名
                        dr["IsPramaryKey"] = Convert.ToInt32(attribute.IsPramaryKey);//是否是主键
                        dr["IdentityValue"] = Convertor.IsNull(attribute.IdentityValue, "");// 自增值
                        dr["DataType"] = Convertor.IsNull(attribute.DataType, "");//数据类型
                        dr["DefaultValue"] = Convertor.IsNull(attribute.DefaultValue, "");//默认值
                        dr["Constraint"] = Convertor.IsNull(attribute.Constraint, "");//约束
                        dr["OperateType"] = "";
                        dt.Rows.Add(dr);
                        #endregion
                        break;
                }
            }

            #endregion
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.TableName = className;
                FrmClassDetailInfo frmClassInfo = new FrmClassDetailInfo(this.txt_DatabaseName.Text.Trim(), className, dt);
                frmClassInfo.ShowDialog();
            }



        }
    }
}
