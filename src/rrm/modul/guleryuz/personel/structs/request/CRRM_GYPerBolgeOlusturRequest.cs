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
    public class CRRM_GYPerBolgeOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerBolgeOlusturArg, CRRMR_GYPerBolgeOlusturResult> {
        #region Getter
        public override string DefaultWSIslem { get { return "perBolgeOlustur"; } }
        public override Type ResponseClass { get { return typeof(CRRM_GYPerBolgeOlusturResponse); } }
        #endregion
    }
}
