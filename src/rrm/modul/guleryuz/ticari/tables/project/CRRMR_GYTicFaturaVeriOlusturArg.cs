using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicFaturaVeriOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "donemID" )]
        public Guid DonemID { get; set; }

        [XmlElement( "hizmetKod" )]
        public string HizmetKod { get; set; }

        [XmlElement( "poNo" )]
        public string PONo { get; set; }
        
        [XmlElement( "gruplama" )]
        public string Gruplama { get; set; }

        [XmlElement( "kategoriDetaySayac" ), DefaultValue( 0 )]
        public int KategoriDetaySayac { get; set; }

        [XmlElement( "hizmetBedeli" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal HizmetBedeli { get; set; }

        [XmlElement( "miktar" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Miktar { get; set; }

        [XmlElement( "fiyat" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Fiyat { get; set; }
        #endregion
    }
}
