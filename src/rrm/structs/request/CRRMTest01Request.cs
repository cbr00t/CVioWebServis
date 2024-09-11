using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMTest01Request : CRRMDownloadRequest {
        #region Getter
        public override string DefaultWSIslem {
            get { return "test01"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRMTest01Response ); }
        }
        #endregion
    }
}
