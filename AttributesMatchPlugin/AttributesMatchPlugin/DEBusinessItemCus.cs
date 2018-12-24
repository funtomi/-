using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyt.TiPLM.DEL.Admin.DataModel;
using Thyt.TiPLM.DEL.Product;
using Thyt.TiPLM.UIL.Common;
using Thyt.TiPLM.UIL.Controls;

namespace AttributesMatchPlugin {
    class DEBusinessItemCus {
        public DEBusinessItemCus(DEBusinessItem[] items, GenericAttribute[] attributes) {
            if (items == null || items.Length == 0) {
                throw new ArgumentNullException("items");
            }
            if (attributes == null || attributes.Length == 0) {
                throw new ArgumentNullException("attributes");
            }
            _currentItems = items;
            _attrModels = attributes;
        }

        private static string IS_SELECTED = "IsSelected";
        private static string IS_SELECTED_CAPTION = "";

        /// <summary>
        /// 类型的属性结构
        /// </summary>
        public GenericAttribute[] AttrModels {
            get { return _attrModels; }
        }
        private GenericAttribute[] _attrModels;

        /// <summary>
        /// 所有对象
        /// </summary>
        public DEBusinessItem[] CurrentItems {
            get { return _currentItems; }
        }
        private DEBusinessItem[] _currentItems;

        public DataTable GetTableByItem() {
            DataTable dt = CreateNewTable(_attrModels);
            if (dt==null||dt.Columns==null||dt.Columns.Count==0) {
                return null;
            }
            dt = FillTable(dt, _currentItems);
            return dt;
        }

        /// <summary>
        /// 填充表格
        /// </summary>
        /// <param name="dt">数据表格</param>
        /// <param name="items">数据列表</param>
        /// <returns></returns>
        private DataTable FillTable(DataTable dt, DEBusinessItem[] items) {
            if (dt==null||dt.Columns.Count==0||items==null||items.Length==0) {
                return null;
            }
            foreach (DEBusinessItem item in items) {
                if (item==null) {
                    continue;
                }
                dt = AddNewRow(dt, item);
            }
            return dt;
        }

        /// <summary>
        /// 添加新行
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="item">当前对象</param>
        /// <returns></returns>
        private DataTable AddNewRow(DataTable dt, DEBusinessItem item) {
            if (dt==null||dt.Columns.Count==0||item==null) {
                return null;
            }
            var row = dt.NewRow();
            foreach (DataColumn col in dt.Columns) {
                if (col==null) {
                    continue;
                }
                if (string.IsNullOrEmpty(col.ColumnName)||col.ColumnName==IS_SELECTED) {
                    continue;
                }
                var sp = col.ColumnName.Split('.');
                if (sp==null||sp.Length<2) {
                    continue;
                }
                var category = sp[0];
                var attrName = sp[1];
                var val = GetAttrValue(category, attrName, item, col);
                row[col] = val;
            }
            dt.Rows.Add(row);
            return dt;
        }

        /// <summary>
        /// 获取实际属性值，主要用于处理属性数据类型不对应的空属性
        /// </summary>
        /// <param name="category">属性类型</param>
        /// <param name="attrName">属性名称</param>
        /// <param name="item">当前对象</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        private object GetAttrValue(string category, string attrName, DEBusinessItem item, DataColumn col) {
            if (string.IsNullOrEmpty(category)||string.IsNullOrEmpty(attrName)||item==null||col==null) {
                return DBNull.Value;
            }
            var originVal = item.GetAttrValue(category, attrName);
            if (originVal!=null&&!string.IsNullOrEmpty(originVal.ToString())) {
                return originVal;
            }
            return DBNull.Value;
        }

        /// <summary>
        /// 创建表格的列
        /// </summary>
        /// <param name="attributes">属性集合</param>
        /// <returns></returns>
        private DataTable CreateNewTable(GenericAttribute[] attributes) {
            if (attributes == null || attributes.Length == 0) {
                return null;
            }
            DataTable dt = new DataTable();
            try {
                var selectCol = new DataColumn(IS_SELECTED, typeof(bool)) {
                    ReadOnly = false, DefaultValue = false, Caption = IS_SELECTED_CAPTION
                };
                dt.Columns.Add(selectCol);
                foreach (GenericAttribute attr in attributes) {
                    if (attr == null) {
                        continue;
                    }
                    var type = DataModelUtil.GetTypeOfAttribute(attr);
                    var attrName = string.Format("{0}.{1}", attr.Category, attr.Name);
                    DataColumn col = new DataColumn(attrName, type) { 
                    Caption=attr.Label,ReadOnly=true
                    };
                    dt.Columns.Add(col);
                }
            } catch (Exception ex) {
                MessageBoxPLM.Show(ex.Message);
                return null;
            }
            return dt;
        }
    }
}
