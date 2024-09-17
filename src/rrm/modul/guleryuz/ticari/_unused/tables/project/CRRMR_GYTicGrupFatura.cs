using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    [Obsolete( "Bu sınıf kullanımdan kaldırılmıştır", true )]
    public class CRRMR_GYTicGrupFatura : CRRMRecord {
        [XmlAttribute( "GiderGrupKod" )]
        public string GiderGrupKod { get; set; }

        [XmlAttribute( "FaturaNo" )]
        public string FaturaNo { get; set; }

        [XmlAttribute( "FaturaTarih" )]
        public DateTime FaturaTarih { get; set; }

        [XmlAttribute( "Brut" )]
        public decimal Brut { get; set; }

        [XmlAttribute( "Kdv" )]
        public decimal Kdv { get; set; }

        [XmlAttribute( "Sonuc" )]
        public decimal Sonuc { get; set; }

        [XmlArrayItem( "Hakedis" )]
        public CRRMR_GYTicHakedis[] Hakedisler { get; set; }
    }
}
