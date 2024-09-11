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
    public class CRRM_GYPerYetkiliOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerYetkiliOlusturArg, CRRMR_GYPerYetkiliOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perYetkiliOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerYetkiliOlusturResponse ); }
        }
        #endregion
    }
}
