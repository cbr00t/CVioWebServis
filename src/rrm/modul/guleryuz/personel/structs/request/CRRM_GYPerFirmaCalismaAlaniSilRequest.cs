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
    public class CRRM_GYPerFirmaCalismaAlaniSilRequest : CRRMMasterListRequest<CRRMR_GYDeleteArg, CRRMR_GYDeleteResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perFirmaCalismaAlaniSil"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerFirmaCalismaAlaniSilResponse ); }
        }
        #endregion
    }
}
