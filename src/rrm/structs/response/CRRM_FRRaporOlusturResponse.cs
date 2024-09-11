using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Reflection;

namespace CVioWebServis {
    [Serializable()]
    public class CRRM_FRRaporOlusturResponse : CRRMBinaryResponse {
        #region Accessors
        [XmlElement( "contentType" )]
        public string ContentType { get; set; }
        [XmlElement( "reportKey" )]
        public string ReportKey { get; set; }
        #endregion

        #region Parser
        public override void afterResponse( CRRMCallArgs args ) {
            base.afterResponse( args );
        }
        #endregion
    }
}
