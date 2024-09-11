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
    public class CRRM_GYPerMasrafOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerMasrafOlusturArg, CRRMR_GYPerMasrafOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perMasrafOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerMasrafOlusturResponse ); }
        }
        #endregion
    }
}
