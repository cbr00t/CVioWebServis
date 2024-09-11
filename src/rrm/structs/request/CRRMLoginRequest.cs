using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMLoginRequest : CRRMXmlRequest {
        #region Getter
        public override bool SessionMatchFlag {
            get { return false; }
        }

        public override string DefaultWSIslem {
            get { return "login"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRMLoginResponse ); }
        }
        #endregion
    }
}
