using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicFirma : CRRMR_KodYapi {
        #region Accessors
        [XmlElement( "id" )]
        public Guid? ID { get; set; }

        [XmlElement( "unvan1" )]
        public string Unvan1 { get; set; }

        [XmlElement( "unvan2" )]
        public string Unvan2 { get; set; }

        [XmlElement( "birUnvan" )]
        public string BirUnvan { get; set; }

        [XmlElement( "yore" )]
        public string Yore { get; set; }

        [XmlElement( "ilKod" )]
        public string IlKod { get; set; }

        [XmlElement( "ilAdi" )]
        public string IlAdi { get; set; }

        [XmlElement( "adres1" )]
        public string Adres1 { get; set; }

        [XmlElement( "adres2" )]
        public string Adres2 { get; set; }

        [XmlElement( "birAdres" )]
        public string BirAdres { get; set; }

        [XmlElement( "sahismi" )]
        public string _SahismiText { get; set; }

        public bool Sahismi {
            get { return _SahismiText.asBool(); }
            set { _SahismiText = value.fileStr(); }
        }

        [XmlElement( "vergiDairesi" )]
        public string VergiDairesi { get; set; }

        [XmlElement( "vknTckn" )]
        public string VknTckn { get; set; }
        #endregion
    }
}
