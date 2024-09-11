using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace CVioWebServis {
    public class CRRMXmlRequest : CRRMRequest {
        [XmlIgnore()] internal bool SkipXMLAutoLoadFlag { get; set; }
        public override CIOType? DefaultOutputType { get { return CIOType.xml; } }
        public override Type ResponseClass { get { return typeof( CRRMXmlResponse ); } }

        public CRRMXmlRequest() : base() { this.SkipXMLAutoLoadFlag = false; }
		#region WS Iletisim
		protected override CRRMResponse wsCallInternal( CWSComm wsComm, CRRMCallArgs args ) {
            CRRMResponse response = null;
            if (SkipXMLAutoLoadFlag) {
                wsComm.sendWebRequest(args, responseBlock: ( resp, aStream, req ) => { args.Resp = resp; args.RespSrm = aStream; response = getResponse( args ); });
            }
            else {
                wsComm.sendWebRequestWithXMLReader(args,
                    postResponseBlock: ( resp, xr, aStream, req ) => {
                        try {
                            /* [Response] */ xr.ReadToDescendant( CRRMSingleMasterResponse.ParentRootNodeName );
                            /* [Response] > [Result] xr.ReadToDescendant( CRRMSingleMasterResponse.RootNodeName ); */ args.UserData = (XmlReader)xr;
                        }
                        catch (XmlException) { }
                        response = getResponse( args );
                    } );
            }

            return response;
        }
		#endregion
		internal void skipXMLAutoLoad() { SkipXMLAutoLoadFlag = true; }
	}
}
