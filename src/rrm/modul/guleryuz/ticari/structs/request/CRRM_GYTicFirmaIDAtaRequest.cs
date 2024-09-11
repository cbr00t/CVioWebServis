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
    public class CRRM_GYTicFirmaIDAtaRequest : CRRMMasterListRequest<CRRMR_GYTicFirmaIDAtaArg, CRRMR_GYTicFirmaIDAtaResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "ticFirmaIDAta"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicFirmaIDAtaResponse ); }
        }
        #endregion
    }
}
