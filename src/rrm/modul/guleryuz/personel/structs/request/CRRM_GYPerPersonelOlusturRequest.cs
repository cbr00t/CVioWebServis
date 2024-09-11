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
    public class CRRM_GYPerPersonelOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerPersonelOlusturArg, CRRMR_GYPerPersonelOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perPersonelOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerPersonelOlusturResponse ); }
        }
        #endregion
    }
}
