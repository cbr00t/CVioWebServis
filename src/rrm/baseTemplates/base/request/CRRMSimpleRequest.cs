using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMSimpleRequest : CRRMRequest {
        public override CIOType? DefaultOutputType { get { return CIOType.tab; } }

        #region WS Iletisim
        protected override CRRMResponse wsCallInternal( CWSComm wsComm, CRRMCallArgs args ) {
            CRRMResponse response = null; wsComm.sendWebRequest(args, responseBlock: (resp, srm, req) => response = getResponse( args ));
            return response;
        }
        #endregion
    }
}
