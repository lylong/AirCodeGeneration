using Air.Currency.Frame.Library;
using Air.Currency.Frame.Library.Extension;
using Air.T4.Common;
using Air.T4.Common.Host;
using Air.T4.Common.Model.DatabaseTableInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirCodeGeneration
{
    public partial class FrmClassDetailInfo : Form
    {
        private DataTable _dtClassInfo = null;

        ComboBox cmb = new ComboBox();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">数据库表名</param>
        /// <param name="dt"></param>
        public FrmClassDetailInfo(string dbName, string tableName, DataTable dt)
        {
            InitializeComponent();
            this._dtClassInfo = dt;
            this.txtDbName.Text = dbName;
            this.txtTableName.Text = tableName;
            this.txt_Output.Text = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Output");
            this.dgvClassInfo.AutoGenerateColumns = false;
            DataTable tb = _dtClassInfo.Copy();
            dgvClassInfo.DataSource = tb;
        }

        /// <summary>
        /// 修改网格的CheckBox选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClassInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 验证
            if (dgvClassInfo.DataSource==null || dgvClassInfo.Rows.Count <= 0)
                return;
            DataTable tb = (DataTable)dgvClassInfo.DataSource;
            if (e.RowIndex < 0 || e.RowIndex >= tb.Rows.Count)
                return;
            if (tb.Columns[e.ColumnIndex].ColumnName != cSel.DataPropertyName)
                return;
            #endregion

            tb.Rows[e.RowIndex][e.ColumnIndex] = 1 - (int)tb.Rows[e.RowIndex][e.ColumnIndex];
        }

        /// <summary>
        /// 修改表结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            #region 验证
            if (dgvClassInfo.Rows.Count <= 0)
                return;
            if (dgvClassInfo.DataSource == null)
                return;
            #endregion 
            try
            {
                List<AlterTableModel> lstModels = new List<AlterTableModel>();
                foreach (DataGridViewRow dgvr in dgvClassInfo.Rows)
                {
                    if (Convert.ToInt32(dgvr.Cells[cSel.Name].Value) == 1)
                    {
                        if(string.IsNullOrEmpty(dgvr.Cells[cOperateType.Name].Value.ToString().Trim()))
                        {
                            throw new Exception($"请为字段[{dgvr.Cells[cName.Name].Value.ToString()}]选择操作类型");
                        }
                        AlterTableModel model = new AlterTableModel();
                        model.Name = dgvr.Cells[cName.Name].Value.ToString();
                        model.IsPramaryKey = Convert.ToInt32(dgvr.Cells[cIsPramaryKey.Name].Value) == 1 ? true : false;
                        model.IdentityValue = dgvr.Cells[cIdentityValue.Name].Value.ToString();
                        model.DataType = dgvr.Cells[cDataType.Name].Value.ToString();
                        model.DefaultValue = dgvr.Cells[cDefaultValue.Name].Value.ToString();
                        model.Constraint = dgvr.Cells[cConstraint.Name].Value.ToString();
                        model.OperateType = dgvr.Cells[cOperateType.Name].Value.ToString().Trim();
                        lstModels.Add(model);
                    }
                }
                if (lstModels.Count <= 0)
                    throw new Exception($"请选择要修改的字段");
                string t4FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, T4Consts.FILE_Folder, T4Consts.DB_TABLE_ALTER_FILE_NAME);
                Air.T4.Common.Model.Database.HostDatabase hostDatabase = new Air.T4.Common.Model.Database.HostDatabase();
                hostDatabase.Name = this.txtDbName.Text.Trim();
                DataBaseCoreHost host = new DataBaseCoreHost(hostDatabase,txtTableName.Text.Trim(), lstModels);
                string output = Path.Combine(txt_Output.Text, "Alter"+this.txtTableName.Text.Trim() + ".sql");
                this.rtbScripts.Text = T4EngineHelper.ProcessTemplate(t4FilePath, host, output, LogWrite);
                MessageBox.Show("修改表结构的脚本生成完毕");
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
                return;
            }
        }

        private void LogWrite(string logValue)
        {
            this.Invoke(new Action(() =>
            {
                this.rtbScripts.Text = string.Concat(Environment.NewLine,logValue);
            }));
        }

        /// <summary>
        /// 打开输出目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenFileDir_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(this.txt_Output.Text.Trim()))
            {
                Directory.CreateDirectory(this.txt_Output.Text.Trim());
            }
            System.Diagnostics.Process.Start("Explorer", $"{this.txt_Output.Text.Trim()}");
        }

        private void FrmClassDetailInfo_Load(object sender, EventArgs e)
        {
            InitCmb();
            cmb.Visible = false;
            this.dgvClassInfo.Controls.Add(cmb);
            this.dgvClassInfo.CurrentCellChanged += new System.EventHandler(this.dgv1_CurrentCellChanged);
        }

        private void InitCmb()
        {
            this.cmb.Items.Add("添加");
            this.cmb.Items.Add("删除");
            this.cmb.Items.Add("修改类型");
            this.cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvClassInfo.CurrentCell.Value = cmb.Text;
        }

        private void dgv1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvClassInfo.DataSource == null)
                return;
            DataTable tb = (DataTable)dgvClassInfo.DataSource;
            DataGridViewCell currentCell = dgvClassInfo.CurrentCell;
            if (currentCell != null && currentCell.RowIndex < tb.Rows.Count && currentCell.OwningColumn.Name == "cOperateType")
            {
                Rectangle rect = dgvClassInfo.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, true);
                cmb.Text = currentCell.Value.ToString();
                cmb.Size = rect.Size;
                cmb.Top = rect.Top;
                cmb.Left = rect.Left;
                cmb.Visible = true;
            }
            else
            {
                cmb.Visible = false;
            }
        }
    }
}
