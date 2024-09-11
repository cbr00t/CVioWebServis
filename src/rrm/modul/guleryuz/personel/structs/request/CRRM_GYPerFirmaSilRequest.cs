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
    public class CRRM_GYPerFirmaSilRequest : CRRMMasterListRequest<CRRMR_GYDeleteArg, CRRMR_GYDeleteResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perFirmaSil"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerFirmaSilResponse ); }
        }
        #endregion
    }
}
