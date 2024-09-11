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
    public class CRRM_GYPerTarCalismaOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerTarCalismaOlusturArg, CRRMR_GYPerTarCalismaOlusturResult> {
        #region Getter
        public override string DefaultWSIslem { get { return "perTarCalismaOlustur"; } }
        public override Type ResponseClass { get { return typeof( CRRM_GYPerTarCalismaOlusturResponse ); } }
        #endregion
    }
}
