using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_KayitDegistiKontrolu : CRRMRecord {
        #region Accessors
        [XmlElement( "change_id" )]
        public string ChangeID { get; set; }

        [XmlElement( "islem" )]
        public string IslemKod { get; set; }

        [DefaultValue( typeof( CRRM_KayitDegistiTuru ), "Unknown" )]
        public CRRM_KayitDegistiTuru Islem {
            get {
                if (IslemKod.bosDegilmi()) {
                    switch (IslemKod.ToUpper()) {
                        case "I": return CRRM_KayitDegistiTuru.Insert;
                        case "U": return CRRM_KayitDegistiTuru.Update;
                        case "D": return CRRM_KayitDegistiTuru.Delete;
                    }
                }
                return CRRM_KayitDegistiTuru.Unknown;
            }
            set {
                switch (value) {
                    case CRRM_KayitDegistiTuru.Insert: IslemKod = "I"; break;
                    case CRRM_KayitDegistiTuru.Update: IslemKod = "U"; break;
                    case CRRM_KayitDegistiTuru.Delete: IslemKod = "D"; break;
                    default: IslemKod = ""; break;
                }
            }
        }

        [XmlElement( "kod" )]
        [DefaultValue( null )]
        public string Kod { get; set; }
        #endregion
    }
}
