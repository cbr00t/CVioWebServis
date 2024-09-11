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
    public class CRRM_GYTicFirmaHakedisOlusturRequest : CRRMMasterListRequest<CRRMR_GYTicFirmaHakedisOlusturArg, CRRMR_GYTicFirmaHakedisOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "ticFirmaHakedisOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicFirmaHakedisOlusturResponse ); }
        }
        #endregion
    }
}
