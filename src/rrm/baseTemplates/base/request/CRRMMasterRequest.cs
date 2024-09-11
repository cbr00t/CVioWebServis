using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMMasterRequest<T> : CRRMBasicMasterRequest where T : CRRMRecord {
        public override CIOType? DefaultOutputType { get { return CIOType.xml; } }
        public override Type ResponseClass { get { return typeof( CRRMMasterResponse<T> ); } }

        public CRRMMasterRequest() : base() { SkipXMLAutoLoadFlag = false; }
    }
}
