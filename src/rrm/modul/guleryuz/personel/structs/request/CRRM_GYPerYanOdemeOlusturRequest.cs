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
    public class CRRM_GYPerYanOdemeOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerYanOdemeOlusturArg, CRRMR_GYPerYanOdemeOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perYanOdemeOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerYanOdemeOlusturResponse ); }
        }
        #endregion
    }
}
