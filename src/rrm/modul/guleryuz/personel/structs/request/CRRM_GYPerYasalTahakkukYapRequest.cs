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
    public class CRRM_GYPerYasalTahakkukYapRequest : CRRMMasterListRequest<CRRMR_GYPerYasalTahakkukYapArg, CRRMR_GYPerTarTahakkukYapResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perYasalTahakkukYap"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerYasalTahakkukYapResponse ); }
        }
        #endregion
    }
}
