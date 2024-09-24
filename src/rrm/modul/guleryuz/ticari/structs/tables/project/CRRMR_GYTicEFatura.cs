using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicEFatura : CRRMRecord {
        [XmlElement( "vioID" )]
        public int VioID { get; set; }

        [XmlElement( "islemKod" )]
        public string IslemKod { get; set; }

        [XmlElement( "faturaTarih" )]
        public DateTime FaturaTarih { get; set; }

        [XmlElement( "faturaSeri" )]
        public string FaturaSeri { get; set; }

        [XmlElement( "faturaNoYil" )]
        public int faturaNoYil { get; set; }

        [XmlElement( "faturaNo" )]
        public int FaturaNo { get; set; }

        [XmlElement( "faturaNox" )]
        public string FaturaNox { get; set; }

        [XmlElement( "mustKod" )]
        public string MustKod { get; set; }

        [XmlElement( "mustUnvan" )]
        public string MustUnvan { get; set; }

        [XmlElement( "efAyrimTipi" )]
        // [SoapIgnore()]
        public string EFAyrimTipiKod { get; set; }

        public CRRM_GYTicEFAyrimTipi EFAyrimTipi {
            get {
                if (EFAyrimTipiKod != null) {
                    switch (EFAyrimTipiKod) {
                        case "A": return CRRM_GYTicEFAyrimTipi.EArsiv;
                    }
                }

                return CRRM_GYTicEFAyrimTipi.EFatura;
            }
            set {
                switch (value) {
                    case CRRM_GYTicEFAyrimTipi.EArsiv: EFAyrimTipiKod = "A"; break;
                    default: EFAyrimTipiKod = "E"; break;
                }
            }
        }

        [XmlElement( "efaUUID" )]
        public Guid? efaUUID { get; set; }

        [XmlElement( "efatImzaZamani" )]
        public DateTime? EFatImzaZamani { get; set; }

        [XmlElement( "efatGonderimZamani" )]
        public DateTime? EFatGonderimZamani { get; set; }
        
        [XmlElement( "brut" )]
        public decimal Brut { get; set; }

        [XmlElement( "kdv" )]
        public decimal Kdv { get; set; }

        [XmlElement( "sonuc" )]
        public decimal Sonuc { get; set; }
    }
}
