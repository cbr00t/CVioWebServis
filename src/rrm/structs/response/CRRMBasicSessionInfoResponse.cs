using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMBasicSessionInfoResponse : CRRMSingleMasterResponse {
        #region Accessors
        [XmlElement( "hasSession" )]
        public bool HasSession { get; set; }

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
                case "hasSession":
                    HasSession = ( value.bosmu()
                                        ? false
                                        : Convert.ToBoolean( value ) );
                    break;
                case "sessionID":
                    SessionID = ( value.bosmu()
                                            ? null
                                            : value );
                    break;
                case "ozelTipKod":
                    OzelTipKod = value;
                    break;
                case "ozelTipAdi":
                    OzelTipAdi = value;
                    break;
            }
        }*/
        #endregion

        #region Not Categorized
        public override string ToString() {
            return string.Format( "{0} :: {1} :: {2}"
                , ( HasSession ? "HAS SESSION" : "NO SESSION" )
                , SessionID
                , string.IsNullOrEmpty( OzelTipKod )
                    ? string.Empty
                    : string.Format( "OZEL TIP: ({0}) {1}", OzelTipKod, OzelTipAdi )
                );

        }
        #endregion
    }
}
