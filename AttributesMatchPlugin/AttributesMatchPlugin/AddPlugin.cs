using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyt.TiPLM.Common.Interface.Addin;
using Thyt.TiPLM.DEL.Operation;
using Thyt.TiPLM.PLL.Admin.DataModel;
using Thyt.TiPLM.PLL.Operation;
using Thyt.TiPLM.UIL.Controls;

namespace AttributesMatchPlugin {
    class AddPlugin : IAddinClientEntry, IAutoExec {
        #region 初始化

        #region 插入操作内容

        private const string OPERATION_ID = "PLM32_AttributeMatch";
        private const string OPERATION_LABEL = "属性匹配关联";
        private const string OPERATION_TOOLTIP = "属性匹配关联";
        private const string OPERATION_FILTER = "AttributesMatchPlugin.dll,AttributesMatchPlugin.MatchFilter";
        private const string OPERATION_EVENTHANDLE = "AttributesMatchPlugin.dll,AttributesMatchPlugin.MatchHandlerHelper,OnMatch";
        private const string ROOT_BI = "ROOTBI";
        private const string SINGLE = "Single";
        //OPERATION_BINDING_COLLECTION
        private const string OBCOLLECTION_PRODUCT = "PLM";
        //private static List<string> OBCOLLECTION_CLASSNAME = new List<string>() { "PART", "BASEDOC", "GYGCK", "GXK" };
        private List<string> _classes;
        //private static List<string> OBCOLLECTION_CLASSNAME =ERPServiceHelper.Instance.ConfigDoc
        //private static List<string> OBCOLLECTION_SENCE = new List<string>() { "CheckOutFolder", "CheckOutRootFolder", "ItemList", "PPCardTemplateList", "PublicFolder", "PublicRootFolder","RelationTreeRoot"
//,"RelationTreeChild"};
        private static List<string> OBCOLLECTION_MODE = new List<string>() { "Single" };
        #endregion

        //public Delegate d_AfterCheckIn { get; set; }
        
        public void Init() { 
            //#region 绑定检入后事件
            //this.d_AfterCheckIn = new PLMBizItemDelegate(this.AfterCheckIn);
            //BizItemHandlerEvent.Instance.D_AfterCheckIn = (PLMBizItemDelegate)Delegate.Combine(BizItemHandlerEvent.Instance.D_AfterCheckIn,this.d_AfterCheckIn);
            //#endregion
            #region 添加右键菜单【导入到ERP】

            var list = PLOperationDef.Agent.GetAllOperationItems(Guid.NewGuid());
            if (list != null && list.Count != 0) {
                var opItem = list.Find(p => p.Id == OPERATION_ID);
                if (opItem == null) {
                    AddOperationItem();
                }
                AddOperationBinding();
            }
            #endregion
        }


        public void UnInit() {
            //BizItemHandlerEvent.Instance.D_AfterCheckIn = (PLMBizItemDelegate)Delegate.Remove(BizItemHandlerEvent.Instance.D_AfterCheckIn, this.d_AfterCheckIn);
        }

        /// <summary>
        /// 添加操作类
        /// </summary>
        private void AddOperationItem() {
            DEOperationItem operationItem = new DEOperationItem() {
                Id = OPERATION_ID, Label = OPERATION_LABEL, Tooltip = OPERATION_TOOLTIP, Filter = OPERATION_FILTER, EventHandler = OPERATION_EVENTHANDLE, Option = 0
            };
            PLOperationDef.Agent.CreateOperationItem(operationItem, Guid.NewGuid());
        }

        private void AddOperationBinding() {
            var cols = PLOperationDef.Agent.GetAllBindingCollection(new Guid());
            try {  
                //DEBindingOperationCollection col = new DEBindingOperationCollection() {
                //    Product = OBCOLLECTION_PRODUCT, Mode = OperModeType.Single.ToString(), ClassName = className, Scene = scene
                //};
                var oldCol = cols.FindAll(p =>ModelContext.MetaModel.IsChild(ROOT_BI,p.ClassName));
                if (oldCol == null || oldCol.Count == 0) {
                    return;
                }
                foreach (DEBindingOperationCollection curCol in oldCol) {
                    if (curCol == null) {
                        continue;
                    }
                    var currentCol = curCol.OperationInfos.Find(p => p.Id == OPERATION_ID);
                    if (currentCol != null) {
                        continue;
                    }
                    DEBindingOperationInfo info = new DEBindingOperationInfo() {
                        Id = OPERATION_ID, Order = 600
                    };
                    curCol.OperationInfos.Add(info);
                    PLOperationDef.Agent.SaveBindingCollection(curCol, Guid.NewGuid());

                }
                //if (oldCol != null && oldCol.OperationInfos != null && oldCol.OperationInfos.Count > 0) {
                //    col.OperationInfos.AddRange(oldCol.OperationInfos);
                //}
            } catch (Exception ex) {
                MessageBoxPLM.Show(ex.Message);
            }
        }
         

        #endregion
    }
}
