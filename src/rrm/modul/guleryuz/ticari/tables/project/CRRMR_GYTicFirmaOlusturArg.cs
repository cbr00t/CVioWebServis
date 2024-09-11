using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicFirmaOlusturArg : CRRMR_GYBasicArgWithID {
        #region Accessors
        [XmlElement( "kimlikSorgulamaYapilirmi" ), DefaultValue( false )]
        public bool KimlikSorgulamaYapilirmi { get; set; }

        [XmlElement( "unvan" )]
        public string Unvan { get; set; }

        [XmlElement( "yore" )]
        public string Yore { get; set; }

        [XmlElement( "ilKod" )]
        public string IlKod { get; set; }

        [XmlElement( "adres" )]
        public string Adres { get; set; }

        [XmlElement( "vergiDairesi" )]
        public string VergiDairesi { get; set; }
        
        [XmlElement( "vknTckn" )]
        public string VknTckn { get; set; }
        #endregion
    }
}
