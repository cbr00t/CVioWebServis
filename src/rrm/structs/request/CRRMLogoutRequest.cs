using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMLogoutRequest : CRRMSimpleRequest {
        #region Getter
        public override bool SessionMatchFlag {
            get { return false; }
        }

        public override string DefaultWSIslem {
            get { return "logout"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRMLogoutResponse ); }
        }
        #endregion
    }
}
