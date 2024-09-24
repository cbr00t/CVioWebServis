using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliPuantajSilResult : CRRMR_GYBasicResult {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid PerID { get; set; }

        [XmlElement( "yilAy" ), DefaultValue( 0 )]
        public int YilAy { get; set; }

        [XmlElement( "yil" ), DefaultValue( 0 )]
        public int Yil { get; set; }

        [XmlElement( "ay" ), DefaultValue( 0 )]
        public int Ay { get; set; }

        [XmlElement( "perSayac" )]
        public int? PerSayac { get; set; }

        [XmlElement( "perKod" )]
        public string PerKod { get; set; }

        [XmlElement( "perIsim" )]
        public string PerIsim { get; set; }
        #endregion
    }
}
