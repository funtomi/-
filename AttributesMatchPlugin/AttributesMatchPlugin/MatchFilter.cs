using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyt.TiPLM.DEL.Operation;
using Thyt.TiPLM.PLL.Admin.DataModel;
using Thyt.TiPLM.UIL.Common;
using Thyt.TiPLM.UIL.Common.Operation;

namespace AttributesMatchPlugin {
    class MatchFilter : IOperationFilter {
        private static string ROOT_CLASS = "ROOTBI";
        //菜单过滤器
        public bool Filter(PLMOperationArgs args, DEOperationItem item) {
            if (args.BizItems == null || args.BizItems.Length == 0) {
                return false;
            }
            var iItem = args.BizItems[0];
            return ModelContext.MetaModel.IsChild(ROOT_CLASS, iItem.ClassName);

        }
    }
}
