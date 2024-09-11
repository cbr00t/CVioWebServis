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
    public class CRRM_GYPerSozlesmeliPuantajOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerSozlesmeliPuantajOlusturArg, CRRMR_GYPerSozlesmeliPuantajOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perSozlesmeliPuantajOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerSozlesmeliPuantajOlusturResponse ); }
        }
        #endregion
    }
}
