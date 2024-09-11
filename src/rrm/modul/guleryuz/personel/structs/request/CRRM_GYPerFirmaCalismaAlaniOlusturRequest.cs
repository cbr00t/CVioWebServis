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
    public class CRRM_GYPerFirmaCalismaAlaniOlusturRequest : CRRMMasterListRequest<CRRMR_GYPerFirmaCalismaAlaniOlusturArg, CRRMR_GYPerFirmaCalismaAlaniOlusturResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perFirmaCalismaAlaniOlustur"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerFirmaCalismaAlaniOlusturResponse ); }
        }
        #endregion
    }
}
