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
    public class CRRM_GYPerGrupOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerGrupOlusturArg, CRRMR_GYPerGrupOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perGrupOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerGrupOlusturResponse ); }
        }
        #endregion
    }
}
