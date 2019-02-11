namespace AirCodeGeneration
{
    partial class FrmClassDetailInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OpenFileDir = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpClassInfo = new System.Windows.Forms.TabPage();
            this.dgvClassInfo = new System.Windows.Forms.DataGridView();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.rtbScripts = new System.Windows.Forms.RichTextBox();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIsPramaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cIdentityValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cConstraint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOperateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpClassInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassInfo)).BeginInit();
            this.tpOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_OpenFileDir);
            this.panel1.Controls.Add(this.txt_Output);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTableName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDbName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 114);
            this.panel1.TabIndex = 0;
            // 
            // btn_OpenFileDir
            // 
            this.btn_OpenFileDir.Location = new System.Drawing.Point(1026, 13);
            this.btn_OpenFileDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_OpenFileDir.Name = "btn_OpenFileDir";
            this.btn_OpenFileDir.Size = new System.Drawing.Size(129, 28);
            this.btn_OpenFileDir.TabIndex = 14;
            this.btn_OpenFileDir.Text = "打开输出目录";
            this.btn_OpenFileDir.UseVisualStyleBackColor = true;
            this.btn_OpenFileDir.Click += new System.EventHandler(this.btn_OpenFileDir_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Enabled = false;
            this.txt_Output.Location = new System.Drawing.Point(148, 13);
            this.txt_Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(864, 28);
            this.txt_Output.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "脚本输出位置";
            // 
            // txtTableName
            // 
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(148, 77);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(191, 28);
            this.txtTableName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "表名";
            // 
            // txtDbName
            // 
            this.txtDbName.Enabled = false;
            this.txtDbName.Location = new System.Drawing.Point(148, 45);
            this.txtDbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(191, 28);
            this.txtDbName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据库名称";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(346, 48);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(159, 57);
            this.btnModify.TabIndex = 0;
            this.btnModify.Text = "修改表结构";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1169, 550);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpClassInfo);
            this.tabControl1.Controls.Add(this.tpOutput);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1169, 550);
            this.tabControl1.TabIndex = 0;
            // 
            // tpClassInfo
            // 
            this.tpClassInfo.Controls.Add(this.dgvClassInfo);
            this.tpClassInfo.Location = new System.Drawing.Point(4, 28);
            this.tpClassInfo.Name = "tpClassInfo";
            this.tpClassInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClassInfo.Size = new System.Drawing.Size(1161, 518);
            this.tpClassInfo.TabIndex = 0;
            this.tpClassInfo.Text = "表结构";
            this.tpClassInfo.UseVisualStyleBackColor = true;
            // 
            // dgvClassInfo
            // 
            this.dgvClassInfo.AllowUserToAddRows = false;
            this.dgvClassInfo.AllowUserToDeleteRows = false;
            this.dgvClassInfo.AllowUserToResizeColumns = false;
            this.dgvClassInfo.AllowUserToResizeRows = false;
            this.dgvClassInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClassInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClassInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClassInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cSel,
            this.cName,
            this.cDataType,
            this.cIsPramaryKey,
            this.cIdentityValue,
            this.cDefaultValue,
            this.cConstraint,
            this.cOperateType});
            this.dgvClassInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClassInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvClassInfo.Name = "dgvClassInfo";
            this.dgvClassInfo.RowHeadersVisible = false;
            this.dgvClassInfo.RowTemplate.Height = 30;
            this.dgvClassInfo.Size = new System.Drawing.Size(1155, 512);
            this.dgvClassInfo.TabIndex = 0;
            this.dgvClassInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassInfo_CellClick);
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.rtbScripts);
            this.tpOutput.Location = new System.Drawing.Point(4, 28);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutput.Size = new System.Drawing.Size(1161, 518);
            this.tpOutput.TabIndex = 1;
            this.tpOutput.Text = "输出";
            this.tpOutput.UseVisualStyleBackColor = true;
            // 
            // rtbScripts
            // 
            this.rtbScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbScripts.Location = new System.Drawing.Point(3, 3);
            this.rtbScripts.Name = "rtbScripts";
            this.rtbScripts.Size = new System.Drawing.Size(1155, 512);
            this.rtbScripts.TabIndex = 0;
            this.rtbScripts.Text = "";
            // 
            // cId
            // 
            this.cId.DataPropertyName = "Id";
            this.cId.HeaderText = "序号";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            this.cId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cId.Width = 60;
            // 
            // cSel
            // 
            this.cSel.DataPropertyName = "Sel";
            this.cSel.FalseValue = "0";
            this.cSel.HeaderText = "选择";
            this.cSel.Name = "cSel";
            this.cSel.ReadOnly = true;
            this.cSel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSel.TrueValue = "1";
            this.cSel.Width = 60;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "Name";
            this.cName.HeaderText = "字段名称";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cDataType
            // 
            this.cDataType.DataPropertyName = "DataType";
            this.cDataType.HeaderText = "字段类型";
            this.cDataType.Name = "cDataType";
            this.cDataType.ReadOnly = true;
            this.cDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cIsPramaryKey
            // 
            this.cIsPramaryKey.DataPropertyName = "IsPramaryKey";
            this.cIsPramaryKey.FalseValue = "0";
            this.cIsPramaryKey.HeaderText = "主键";
            this.cIsPramaryKey.Name = "cIsPramaryKey";
            this.cIsPramaryKey.ReadOnly = true;
            this.cIsPramaryKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cIsPramaryKey.TrueValue = "1";
            this.cIsPramaryKey.Width = 60;
            // 
            // cIdentityValue
            // 
            this.cIdentityValue.DataPropertyName = "IdentityValue";
            this.cIdentityValue.HeaderText = "自增值";
            this.cIdentityValue.Name = "cIdentityValue";
            this.cIdentityValue.ReadOnly = true;
            this.cIdentityValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cDefaultValue
            // 
            this.cDefaultValue.DataPropertyName = "DefaultValue";
            this.cDefaultValue.HeaderText = "默认值";
            this.cDefaultValue.Name = "cDefaultValue";
            this.cDefaultValue.ReadOnly = true;
            this.cDefaultValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cConstraint
            // 
            this.cConstraint.DataPropertyName = "Constraint";
            this.cConstraint.HeaderText = "约束";
            this.cConstraint.Name = "cConstraint";
            this.cConstraint.ReadOnly = true;
            this.cConstraint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cOperateType
            // 
            this.cOperateType.DataPropertyName = "OperateType";
            this.cOperateType.HeaderText = "操作";
            this.cOperateType.Name = "cOperateType";
            this.cOperateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cOperateType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmClassDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 664);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmClassDetailInfo";
            this.Text = "数据库表详细信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmClassDetailInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpClassInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassInfo)).EndInit();
            this.tpOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpClassInfo;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.DataGridView dgvClassInfo;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.RichTextBox rtbScripts;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_OpenFileDir;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDataType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsPramaryKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdentityValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cConstraint;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOperateType;
    }
}