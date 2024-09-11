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
    public class CRRM_GYTicDonemOlusturRequest : CRRMMasterListRequest<CRRMR_GYTicDonemOlusturArg, CRRMR_GYTicDonemOlusturResult> {
        #region Getter
        public override string DefaultWSIslem { get { return "ticDonemOlustur"; } }
        public override Type ResponseClass { get { return typeof( CRRM_GYTicDonemOlusturResponse ); } }
        #endregion
    }
}
