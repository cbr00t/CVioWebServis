using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMProgramVersionRequest : CRRMXmlRequest {
        #region Getter
        public override string DefaultWSIslem {
            get { return "programVersion"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRMProgramVersionResponse ); }
        }
        #endregion
    }
}
