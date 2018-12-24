namespace AttributesMatchPlugin {
    partial class AttributeSelectorFrm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSelectAttr = new System.Windows.Forms.TabPage();
            this.btnCancel = new Thyt.TiPLM.UIL.Controls.ButtonPLM();
            this.btnSave = new Thyt.TiPLM.UIL.Controls.ButtonPLM();
            this.btnStartMatch = new Thyt.TiPLM.UIL.Controls.ButtonPLM();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpBoxCondition = new System.Windows.Forms.GroupBox();
            this.cmboxMatchType = new System.Windows.Forms.ComboBox();
            this.label4 = new Thyt.TiPLM.UIL.Controls.LabelPLM();
            this.cmboxRelationAttributes = new System.Windows.Forms.ComboBox();
            this.lblRelation = new Thyt.TiPLM.UIL.Controls.LabelPLM();
            this.cmboxCurrentAttributes = new System.Windows.Forms.ComboBox();
            this.label2 = new Thyt.TiPLM.UIL.Controls.LabelPLM();
            this.cmboxRelations = new System.Windows.Forms.ComboBox();
            this.label1 = new Thyt.TiPLM.UIL.Controls.LabelPLM();
            this.tabControl1.SuspendLayout();
            this.tabPageSelectAttr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpBoxCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSelectAttr);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSelectAttr
            // 
            this.tabPageSelectAttr.Controls.Add(this.btnCancel);
            this.tabPageSelectAttr.Controls.Add(this.btnSave);
            this.tabPageSelectAttr.Controls.Add(this.btnStartMatch);
            this.tabPageSelectAttr.Controls.Add(this.dataGridView1);
            this.tabPageSelectAttr.Controls.Add(this.grpBoxCondition);
            this.tabPageSelectAttr.Location = new System.Drawing.Point(4, 25);
            this.tabPageSelectAttr.Name = "tabPageSelectAttr";
            this.tabPageSelectAttr.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelectAttr.Size = new System.Drawing.Size(833, 493);
            this.tabPageSelectAttr.TabIndex = 0;
            this.tabPageSelectAttr.Text = "属性匹配";
            this.tabPageSelectAttr.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(738, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(624, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStartMatch
            // 
            this.btnStartMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartMatch.Appearance.Options.UseBackColor = true;
            this.btnStartMatch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStartMatch.Location = new System.Drawing.Point(503, 458);
            this.btnStartMatch.Name = "btnStartMatch";
            this.btnStartMatch.Size = new System.Drawing.Size(87, 23);
            this.btnStartMatch.TabIndex = 3;
            this.btnStartMatch.Text = "开始匹配";
            this.btnStartMatch.Click += new System.EventHandler(this.btnStartMatch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(817, 307);
            this.dataGridView1.TabIndex = 2;
            // 
            // grpBoxCondition
            // 
            this.grpBoxCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCondition.Controls.Add(this.cmboxMatchType);
            this.grpBoxCondition.Controls.Add(this.label4);
            this.grpBoxCondition.Controls.Add(this.cmboxRelationAttributes);
            this.grpBoxCondition.Controls.Add(this.lblRelation);
            this.grpBoxCondition.Controls.Add(this.cmboxCurrentAttributes);
            this.grpBoxCondition.Controls.Add(this.label2);
            this.grpBoxCondition.Controls.Add(this.cmboxRelations);
            this.grpBoxCondition.Controls.Add(this.label1);
            this.grpBoxCondition.Location = new System.Drawing.Point(8, 6);
            this.grpBoxCondition.Name = "grpBoxCondition";
            this.grpBoxCondition.Size = new System.Drawing.Size(817, 132);
            this.grpBoxCondition.TabIndex = 1;
            this.grpBoxCondition.TabStop = false;
            this.grpBoxCondition.Text = "匹配条件";
            // 
            // cmboxMatchType
            // 
            this.cmboxMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxMatchType.FormattingEnabled = true;
            this.cmboxMatchType.Items.AddRange(new object[] {
            "匹配父类",
            "匹配子类"});
            this.cmboxMatchType.Location = new System.Drawing.Point(107, 32);
            this.cmboxMatchType.Name = "cmboxMatchType";
            this.cmboxMatchType.Size = new System.Drawing.Size(221, 23);
            this.cmboxMatchType.TabIndex = 7;
            this.cmboxMatchType.SelectedIndexChanged += new System.EventHandler(this.cmboxMatchType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "匹配类型";
            // 
            // cmboxRelationAttributes
            // 
            this.cmboxRelationAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxRelationAttributes.FormattingEnabled = true;
            this.cmboxRelationAttributes.Location = new System.Drawing.Point(510, 87);
            this.cmboxRelationAttributes.Name = "cmboxRelationAttributes";
            this.cmboxRelationAttributes.Size = new System.Drawing.Size(221, 23);
            this.cmboxRelationAttributes.TabIndex = 5;
            // 
            // lblRelation
            // 
            this.lblRelation.Location = new System.Drawing.Point(437, 91);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(60, 18);
            this.lblRelation.TabIndex = 4;
            this.lblRelation.Text = "关联属性";
            // 
            // cmboxCurrentAttributes
            // 
            this.cmboxCurrentAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxCurrentAttributes.FormattingEnabled = true;
            this.cmboxCurrentAttributes.Location = new System.Drawing.Point(107, 87);
            this.cmboxCurrentAttributes.Name = "cmboxCurrentAttributes";
            this.cmboxCurrentAttributes.Size = new System.Drawing.Size(221, 23);
            this.cmboxCurrentAttributes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前属性";
            // 
            // cmboxRelations
            // 
            this.cmboxRelations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxRelations.FormattingEnabled = true;
            this.cmboxRelations.Location = new System.Drawing.Point(510, 32);
            this.cmboxRelations.Name = "cmboxRelations";
            this.cmboxRelations.Size = new System.Drawing.Size(221, 23);
            this.cmboxRelations.TabIndex = 1;
            this.cmboxRelations.SelectedIndexChanged += new System.EventHandler(this.cmboxRelations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(437, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "关联关系";
            // 
            // AttributeSelectorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 522);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttributeSelectorFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "属性匹配";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSelectAttr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpBoxCondition.ResumeLayout(false);
            this.grpBoxCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSelectAttr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpBoxCondition;
        private System.Windows.Forms.ComboBox cmboxRelationAttributes;
        private Thyt.TiPLM.UIL.Controls.LabelPLM lblRelation;
        private System.Windows.Forms.ComboBox cmboxCurrentAttributes;
        private Thyt.TiPLM.UIL.Controls.LabelPLM label2;
        private System.Windows.Forms.ComboBox cmboxRelations;
        private Thyt.TiPLM.UIL.Controls.LabelPLM label1;
        private System.Windows.Forms.ComboBox cmboxMatchType;
        private Thyt.TiPLM.UIL.Controls.LabelPLM label4;
        private Thyt.TiPLM.UIL.Controls.ButtonPLM btnCancel;
        private Thyt.TiPLM.UIL.Controls.ButtonPLM btnSave;
        private Thyt.TiPLM.UIL.Controls.ButtonPLM btnStartMatch;
    }
}