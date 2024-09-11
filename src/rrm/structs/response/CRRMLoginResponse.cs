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
    [Serializable()]
    public class CRRMLoginResponse : CRRMSingleMasterResponse {
        #region Accessors
        [XmlElement( "sessionID" )]
        public string SessionID { get; set; }

        [XmlElement( "ozelTipKod" )]
        public string OzelTipKod { get; set; }

        [XmlElement( "ozelTipAdi" )]
        public string OzelTipAdi { get; set; }
        #endregion


        #region Parser
        /*protected override void parseResponseInternal( CRRMCallArgs args, XmlNode xnode, string name, string value ) {
            base.parseResponseInternal( args, xnode, name, value );

            if (xnode.NodeType != XmlNodeType.Text)
                return;

            switch (name) {
                case "sessionID":
                    SessionID = ( value.bosmu() ? null : value ); ;
                    break;
                case "ozelTipKod":
                    OzelTipKod = ( value.bosmu() ? null : value ); ;
                    break;
                case "ozelTipAdi":
                    OzelTipAdi = ( value.bosmu() ? null : value ); ;
                    break;
            }
        }*/
        #endregion
    }
}
