using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliTotalPuantajOlusturResult : CRRMResponseRecord {
        #region Accessors
        [XmlElement( "yilAy" ), DefaultValue( 0 )]
        public int YilAy { get; set; }

        [XmlElement( "yil" ), DefaultValue( 0 )]
        public int Yil { get; set; }

        [XmlElement( "ay" ), DefaultValue( 0 )]
        public int Ay { get; set; }

        [XmlElement( "goPerID" )]
        public Guid? GoPerID { get; set; }

        [XmlElement( "perSayac" ), DefaultValue( 0 )]
        public int PerSayac { get; set; }

        [XmlElement( "perKod" )]
        public string PerKod { get; set; }

        /*[XmlElement( "perIsim" )]
        public string PerIsim { get; set; }*/

        [XmlElement( "calismaID" ), DefaultValue( 0 )]
        public int CalismaID { get; set; }

        [XmlElement( "eksikNedenKod" )]
        public string EksikNedenKod { get; set; }

        [XmlElement( "eksikGun" ), DefaultValue( 0 )]
        public int EksikGun { get; set; }
        #endregion
    }
}
