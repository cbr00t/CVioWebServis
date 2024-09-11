using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_Cari : CRRMR_KodVeAdiYapi {
        #region Data Accessors
        [XmlElement( "kayittipi" )]
        public string KayitTipi { get; set; }

        [XmlElement( "unvan1" )]
        public string Unvan1 { get; set; }

        [XmlElement( "unvan2" )]
        public string Unvan2 { get; set; }

        [XmlElement( "yore" )]
        public string Yore { get; set; }
        
        [XmlElement( "ilkod" )]
        public string IlKod { get; set; }

        [XmlElement( "iladi" )]
        public string IlAdi { get; set; }

        [XmlElement( "ulkekod" )]
        public string UlkeKod { get; set; }

        [XmlElement( "sahismi" )]
        [SoapIgnore()]
        public string _SahismiText { get; set; }

        public bool Sahismi {
            get {
                return _SahismiText.bosDegilmi() && _SahismiText.ToUpper() != "H" && _SahismiText.ToUpper() != "FALSE";
            }
            set {
                _SahismiText = value.ToString();
            }
        }

        [XmlElement( "vdaire" )]
        public string VergiDairesi { get; set; }

        [XmlElement( "vnumara" )]
        public string VergiNo { get; set; }

        [XmlElement( "tckimlikno" )]
        public string TCKimlikNo { get; set; }

        public string VKN {
            get { return Sahismi ? TCKimlikNo : VergiNo; }
            set { }
        }
        #endregion
    }
}
