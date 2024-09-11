using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMProgramVersionResponse : CRRMSingleMasterResponse {
        #region Accessors
        [XmlElement( "Kod" )]
        public string Kod { get; set; }

        [XmlElement( "Adi" )]
        public string Adi { get; set; }

        [XmlElement( "Version" )]
        public string Version { get; set; }

        [XmlElement( "DBName" )]
        public string DBName { get; set; }
        #endregion

        #region Parser
        /*protected override void parseResponseInternal( CRRMCallArgs args, XmlNode xnode, string name, string value ) {
            base.parseResponseInternal( args, xnode, name, value );

            if (xnode.NodeType != XmlNodeType.Text)
                return;

            switch (name) {
                case "kod":
                    Kod = ( value.bosmu() ? null : value ); ;
                    break;
                case "adi":
                    Adi = ( value.bosmu() ? null : value ); ;
                    break;
                case "version":
                    Version = ( value.bosmu() ? null : value ); ;
                    break;
                case "dbName":
                    DBName = ( value.bosmu() ? null : value ); ;
                    break;
            }
        }*/
        #endregion

        #region Not Categorized
        public override string ToString() {
            return string.Format( "{0}-{1} (v{2}) :: {3}"
                , Kod, Adi
                , Version
                , DBName
                );
        }
        #endregion
    }
}
