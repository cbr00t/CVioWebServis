using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicFirmaOlusturResult : CRRMR_GYBasicResultWithID {
        #region Accessors
        [XmlElement( "kimlikSorgulamaYapilirmi" ), DefaultValue( false )]
        public bool KimlikSorgulamaYapilirmi { get; set; }

        /*[XmlElement( "kod" )]
        public string Kod { get; set; }*/

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

        [XmlElement( "sahismi" ), DefaultValue( false )]
        public bool Sahismi { get; set; }

        [XmlElement( "vergiDairesi" )]
        public string VergiDairesi { get; set; }

        [XmlElement( "vknTckn" )]
        public string VknTckn { get; set; }
        #endregion
    }
}
