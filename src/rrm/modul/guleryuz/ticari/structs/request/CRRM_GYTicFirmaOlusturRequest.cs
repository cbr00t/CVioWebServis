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
    public class CRRM_GYTicFirmaOlusturRequest : CRRMMasterListRequest<CRRMR_GYTicFirmaOlusturArg, CRRMR_GYTicFirmaOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "ticFirmaOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicFirmaOlusturResponse ); }
        }
        #endregion
    }
}
