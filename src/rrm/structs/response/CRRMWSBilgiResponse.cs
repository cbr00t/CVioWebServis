using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMWSBilgiResponse : CRRMSingleMasterResponse {
        #region Accessors
        [XmlElement( "adi" )]
        public string Adi { get; set; }

        [XmlElement( "aciklama" )]
        public string Aciklama { get; set; }

        [XmlElement( "serverAdi" )]
        public string ServerAdi { get; set; }

        [XmlElement( "serverSurum" )]
        public string ServerSurum { get; set; }
        #endregion


        #region Parser
        /*protected override void parseResponseInternal( CRRMCallArgs args, XmlNode xnode, string name, string value ) {
            base.parseResponseInternal( args, xnode, name, value );

            if (xnode.NodeType != XmlNodeType.Text)
                return;

            switch (name) {
                case "adi":
                    Adi = ( value.bosmu() ? null : value ); ;
                    break;
                case "aciklama":
                    Aciklama = ( value.bosmu() ? null : value ); ;
                    break;
                case "serveradi":
                case "serverAdi":
                    ServerAdi = ( value.bosmu() ? null : value ); ;
                    break;
                case "serversurum":
                case "serverSurum":
                    ServerSurum = ( value.bosmu() ? null : value );
                    break;
            }
        }*/
        #endregion

        #region Not Categorized
        public override string ToString() {
            return string.Format( "{0} (Server Surum: [{1} (v{2})"
                , Adi
                , ServerAdi
                , ServerSurum
                );

        }
        #endregion
    }
}
