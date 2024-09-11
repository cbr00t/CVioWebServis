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
    public class CRRM_GYPerSozlesmeliTotalPuantajOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerSozlesmeliTotalPuantajOlusturArg, CRRMR_GYPerSozlesmeliTotalPuantajOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perSozlesmeliTotalPuantajOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerSozlesmeliTotalPuantajOlusturResponse ); }
        }
        #endregion
    }
}
