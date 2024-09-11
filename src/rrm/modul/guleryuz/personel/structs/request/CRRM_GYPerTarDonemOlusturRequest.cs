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
    public class CRRM_GYPerTarDonemOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerTarDonemOlusturArg, CRRMR_GYPerTarDonemOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perTarDonemOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerTarDonemOlusturResponse ); }
        }
        #endregion
    }
}
