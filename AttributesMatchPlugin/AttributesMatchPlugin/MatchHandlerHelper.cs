using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyt.TiPLM.DEL.Product;
using Thyt.TiPLM.PLL.Product2;
using Thyt.TiPLM.UIL.Common;

namespace AttributesMatchPlugin {
    class MatchHandlerHelper {
        public void OnMatch(object sender, PLMOperationArgs args) {
            if (((args != null) && (args.BizItems != null)) && (args.BizItems.Length != 0)) {
                IBizItem item = args.BizItems[0];
                DEBusinessItem theItem = PSConvert.ToBizItem(item, args.Option.CurView, ClientData.LogonUser.Oid);
                AttributeSelectorFrm frm = new AttributeSelectorFrm(theItem, sender, args);
                frm.ShowDialog();
            }
        }
    }
}
