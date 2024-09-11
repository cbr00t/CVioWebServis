using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    public class CRRM_GYPerKesintiOdemeOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerKesintiOdemeOlusturArg, CRRMR_GYPerKesintiOdemeOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perKesintiOdemeOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerKesintiOdemeOlusturResponse ); }
        }
        #endregion
    }
}
