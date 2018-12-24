using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thyt.TiPLM.DEL.Admin.DataModel;
using Thyt.TiPLM.DEL.Product;
using Thyt.TiPLM.PLL.Admin.DataModel;
using Thyt.TiPLM.PLL.Product2;
using Thyt.TiPLM.UIL.ArchivManage;
using Thyt.TiPLM.UIL.Common;
using Thyt.TiPLM.UIL.Controls;

namespace AttributesMatchPlugin {
    public partial class AttributeSelectorFrm : FormPLM {
        private static string IS_SELECTED = "IsSelected";
        private static string ID = "M.ID";
        private DEBusinessItem _currentItem;
        private object _sender;
        private PLMOperationArgs _args;
        private bool _isParent = true;
        private string _relatedClassName;
        private string _relationName;

        public AttributeSelectorFrm() {
            InitializeComponent();
        }

        public AttributeSelectorFrm(DEBusinessItem theItem, object sender, PLMOperationArgs args) {
            InitializeComponent();
            // TODO: Complete member initialization
            this._currentItem = theItem;
            this._sender = sender;
            this._args = args;
            InitData();
        }

        private void InitData() {
            //初始化当前属性
            InitCmboxCurrentAttributes(_currentItem);

            SetParentSelection();
        }

        /// <summary>
        /// 设置父类选择器
        /// </summary>
        private void SetParentSelection() {
            this.cmboxMatchType.SelectedIndex = 0;
            //InitRelations(true);
        }

        /// <summary>
        /// 设置关联关系类型列表
        /// </summary>
        /// <param name="isParent"></param>
        private void InitRelations(bool isParent) {
            this.cmboxRelations.DataSource = null;
            ArrayList list;
            if (isParent) {
                list = ModelContext.MetaModel.GetAllRelationsAsRight(_currentItem.ClassName);
                if (list == null || list.Count == 0) {
                    return;
                }
                this.cmboxRelations.ValueMember = "leftClassName";
                this.cmboxRelations.DisplayMember = "leftClassLabel";
                this.cmboxRelations.DataSource = list;
                return;
            } else {
                list = ModelContext.MetaModel.GetAllRelationsAsLeft(_currentItem.ClassName);
                if (list == null || list.Count == 0) {
                    return;
                }
                this.cmboxRelations.ValueMember = "rightClassName";
                this.cmboxRelations.DisplayMember = "rightClassLabel";
                this.cmboxRelations.DataSource = list;
            }
        }


        /// <summary>
        /// 初始化当前对象属性列表
        /// </summary>
        /// <param name="item"></param>
        private void InitCmboxCurrentAttributes(DEBusinessItem item) {
            this.cmboxCurrentAttributes.DataSource = null;
            if (item == null) {
                return;
            }
            SetAttributesIntoCmbox(item.ClassName, this.cmboxCurrentAttributes);
            //GenericAttribute[] attrs = ModelContext.MetaModel.GetAllAttributes(item.ClassName);
            //if (attrs == null || attrs.Length == 0) {
            //    return;
            //} 
            //this.cmboxCurrentAttributes.DataSource = attrs;
            //this.cmboxCurrentAttributes.ValueMember = "Key";
            //this.cmboxCurrentAttributes.DisplayMember = "Label";
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 改变匹配类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxMatchType_SelectedIndexChanged(object sender, EventArgs e) {
            var index = this.cmboxMatchType.SelectedIndex;
            _isParent = index == 0;
            InitRelations(_isParent);
        }

        /// <summary>
        /// 选择关联关系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxRelations_SelectedIndexChanged(object sender, EventArgs e) {
            this.cmboxRelationAttributes.DataSource = null;
            _relatedClassName = "";
            var selectedItem = this.cmboxRelations.SelectedValue;
            if (selectedItem==null) {
                return;
            }
            SetAttributesIntoCmbox(selectedItem.ToString(), this.cmboxRelationAttributes);
        }

        /// <summary>
        /// 将某个类型的所有属性添加到列表中,值类型名，默认“Key”，显示成员名，默认“Label”
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="cmbox">列表控件</param>
        private void SetAttributesIntoCmbox(string className, ComboBox cmbox) {
            SetAttributesIntoCmbox(className, cmbox, null,null);
        }

        /// <summary>
        /// 将某个类型的所有属性添加到列表中
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="cmbox">列表控件</param>
        /// <param name="valueMember">值类型名，默认“Key”</param>
        /// <param name="disPlayMember">显示成员名，默认“Label”</param>
        private void SetAttributesIntoCmbox(string className, ComboBox cmbox,string valueMember,string disPlayMember) {
            if (cmbox==null) {
                return;
            }
            cmbox.DataSource = null;
            if (string.IsNullOrEmpty(className)) {
                return;
            }
            var cuClass = ModelContext.MetaModel.GetAllAttributes(className);
            if (cuClass==null) {
                return;
            }
            cmbox.ValueMember = string.IsNullOrEmpty(valueMember) ? "Key" :valueMember;
            cmbox.DisplayMember = string.IsNullOrEmpty(disPlayMember) ? "Label" : disPlayMember;
            cmbox.DataSource = cuClass;
        }

        /// <summary>
        /// 开始匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartMatch_Click(object sender, EventArgs e) {
            this.dataGridView1.DataSource = null;
            if (!CheckSelected()) {
                MessageBoxPLM.Show("匹配选项不能为空！");
                return;
            }
            var currentAttr = this.cmboxCurrentAttributes.SelectedItem as GenericAttribute;
            var matchAttr = this.cmboxRelationAttributes.SelectedItem as GenericAttribute;
            var items =GetMatchItems(currentAttr, matchAttr);
            if (items==null||items.Length==0) {
                return;
            }
            var attrs = this.cmboxRelationAttributes.DataSource as GenericAttribute[];
            DEBusinessItemCus cusItem = new DEBusinessItemCus(items, attrs);
            var cusItems = cusItem.GetTableByItem();
            SetDataGridViewData(cusItems, this.dataGridView1);
            _relatedClassName = this.cmboxRelations.SelectedValue.ToString();
            _isParent = this.cmboxMatchType.SelectedIndex == 0;
            var rlt = this.cmboxRelations.SelectedItem as DEMetaRelation;
            _relationName = rlt == null ? "" : rlt.Name;
            //this.dataGridView1.DataSource = cusItems;
            //for (int i = 0; i < cusItems.Columns.Count; i++) {
            //    this.dataGridView1.Columns[i].HeaderText = cusItems.Columns[i].Caption;
            //}
        }

        /// <summary>
        /// 对表格的列做二次处理
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dataGridView"></param>
        private void SetDataGridViewData(DataTable dt,DataGridView dataGridView){
            if (dt==null||dt.Columns.Count==0) {
                return;
            }
            if (dataGridView==null) {
                return;
            }
            dataGridView.DataSource = null;
            dataGridView.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++) {
                dataGridView.Columns[i].HeaderText = dt.Columns[i].Caption;
                if (dt.Columns[i].DataType==typeof(Guid)) {
                    dataGridView.Columns[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 检查输入
        /// </summary>
        /// <returns></returns>
        private bool CheckSelected() {
            if (this.cmboxCurrentAttributes.DataSource==null||this.cmboxRelationAttributes.DataSource==null) {
                return false;
            }
            if (this.cmboxCurrentAttributes.SelectedItem==null||this.cmboxRelationAttributes.SelectedItem==null) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据属性获取对象
        /// </summary>
        /// <param name="currentAttr">当前属性</param>
        /// <param name="matchAttr">匹配的属性</param>
        private DEBusinessItem[] GetMatchItems(GenericAttribute currentAttr,GenericAttribute matchAttr) {
            if (currentAttr==null||matchAttr==null) {
                return null;
            }
            var currentValue = _currentItem.GetAttrValue(_currentItem.ClassName, currentAttr.Name);
            if (currentValue==null) {
                return null;
            }
            var attrName = string.Format("{0}.{1}",matchAttr.Category,matchAttr.Name);
            Hashtable hashTb = new Hashtable() { { attrName, currentValue } };
            var items = PLItem.Agent.GetBizItemsByAttr(matchAttr.ClassName, hashTb, ClientData.LogonUser.Oid);
            return items;
        
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (this.dataGridView1.DataSource==null||this.dataGridView1.Columns.Count==0) {
                this.Close();
            }
            var items = GetSelectedItems();
            if (items==null||items.Length==0) {
                this.Close();
            }
            AddLinks(items);
            this.Close();
        }

        private void AddLinks(DEBusinessItem[] items) {
            if (items == null || items.Length == 0) {
                return;
            }
            DEBusinessItem parentItem;
            DEBusinessItem childItem;
            for (int i = 0; i < items.Length; i++) {
                if (_isParent) {//如果是查找父类
                    parentItem = items[i];
                    childItem = _currentItem;
                } else {
                    parentItem = _currentItem;
                    childItem = items[i];
                }
                var rltList = PLItem.Agent.GetLinkRelationItems(parentItem.IterOid, parentItem.ClassName, _relationName, ClientData.LogonUser.Oid, ClientData.UserGlobalOption);
                var rltItem = ArchiveManageCommon.AddNewRelItem(childItem, _relationName, parentItem);
                if (rltList==null||rltItem==null) {
                    continue;
                }
                rltList.AddRelationItem(rltItem);
                PLItem.UpdateLinkRelations(parentItem,_relationName, ClientData.LogonUser.Oid, ClientData.UserGlobalOption);
            }
            
            #region 失效代码
            
            //DERelationBizItemList rltList;
            //if (_isParent) {//如果是查找父类
            //    for (int i = 0; i < items.Length; i++) {
            //        if (items[i] == null) {
            //            continue;
            //        }
            //        rltList = PLItem.Agent.GetLinkRelationItems(items[i].IterOid, _relatedClassName, _relationName, ClientData.LogonUser.Oid, ClientData.UserGlobalOption);
            //        if (rltList==null||rltList.Count==0) {
            //            continue;
            //        }
            //        var rltItem = ArchiveManageCommon.AddNewRelItem(_currentItem, _relationName, items[i]);
            //        PLItem.UpdateLinkRelations(items[i],_relationName, ClientData.LogonUser.Oid, ClientData.UserGlobalOption);
            //        //var rltItem = ArchiveManageCommon.AddNewRelItem(item, _currentRelationName, _parentItem);
            //    }
            //    //                rltList = PLItem.Agent.GetLinkRelationItems(_parentItem.IterOid, _parentItem.ClassName, _currentRelationName, ClientData.LogonUser.Oid, ClientData.UserGlobalOption);

            //} else {
            //    for (int i = 0; i < items.Length; i++) {
            //        if (items[i]==null) {
            //            continue;
            //        }
            //        rltList = PLItem.Agent.GetLinkRelationItems(_currentItem.IterOid, _relatedClassName, _relationName, ClientData.LogonUser.Oid, ClientData.UserGlobalOption);
            //        if (rltList==null||rltList.Count==0) {
            //            continue;
            //        }
            //            //var rltItem=ArchiveManageCommon.AddNewRelItem(items[i],
            //    }
            //}
            #endregion

        }

        /// <summary>
        /// 获取选择的对象
        /// </summary>
        /// <returns></returns>
        private DEBusinessItem[] GetSelectedItems() {
            if (this.dataGridView1.DataSource==null||this.dataGridView1.Columns.Count==0) {
                return null;
            }
            var data = this.dataGridView1.DataSource as DataTable;
            if (data==null||data.Columns.Count==0||data.Rows.Count==0) {
                return null;
            }
            var className = this.cmboxRelations.SelectedValue;
            if (className == null || string.IsNullOrEmpty(className.ToString())) {
                return null;
            }
            Hashtable hashTb = new Hashtable();
            foreach (DataRow row in data.Rows) {
                if (row==null) {
                    continue;
                }
                var isSelected = Convert.ToBoolean(row[IS_SELECTED]);
                if (!isSelected) {
                    continue;
                }
                if (row[ID]==null) {
                    continue;
                }
                var id = row[ID].ToString();
                hashTb.Add(ID, id);
            }
            if (hashTb.Count==0) {
                return null;
            }
            var list = PLItem.Agent.GetBizItemsByAttr(className.ToString(), hashTb, ClientData.LogonUser.Oid);
            return list;
        }
    }
}
