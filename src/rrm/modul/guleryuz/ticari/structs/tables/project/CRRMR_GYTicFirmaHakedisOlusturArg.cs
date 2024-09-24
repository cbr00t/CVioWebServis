using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicFirmaHakedisOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "donemID" )]
        public Guid DonemID { get; set; }

        [XmlElement( "gorevID" )]
        public Guid GorevID { get; set; }

        [XmlElement( "hizmetTipi" ), DefaultValue( 0 )]
        // [SoapIgnore()]
        public int HizmetTipKod { get; set; }

        public CRRM_GYTicHizmetTipi HizmetTipi {
            get {
                if (HizmetTipKod.bosDegilmi()) {
                    switch (HizmetTipKod) {
                        case 1: return CRRM_GYTicHizmetTipi.Su;
                        case 2: return CRRM_GYTicHizmetTipi.Yemek;
                        case 3: return CRRM_GYTicHizmetTipi.Servis;
                        case 4: return CRRM_GYTicHizmetTipi.Hizmet;
                        case 5: return CRRM_GYTicHizmetTipi.FazlaMesai;
                    }
                }

                return CRRM_GYTicHizmetTipi.Yok;
            }
            set {
                switch (value) {
                    case CRRM_GYTicHizmetTipi.Su: HizmetTipKod = 1; break;
                    case CRRM_GYTicHizmetTipi.Yemek: HizmetTipKod = 2; break;
                    case CRRM_GYTicHizmetTipi.Servis: HizmetTipKod = 3; break;
                    case CRRM_GYTicHizmetTipi.Hizmet: HizmetTipKod = 4; break;
                    case CRRM_GYTicHizmetTipi.FazlaMesai: HizmetTipKod = 5; break;
                    default: HizmetTipKod = 0; break;
                }
            }
        }

        [XmlElement( "cinsiyetKod" )]
        // [SoapIgnore()]
        public string CinsiyetKod { get; set; }

        public CRRM_GYTicCinsiyet Cinsiyet {
            get {
                if (CinsiyetKod != null) {
                    switch (CinsiyetKod) {
                        case "E": return CRRM_GYTicCinsiyet.Erkek;
                        case "K": return CRRM_GYTicCinsiyet.Kadin;
                    }
                }

                return CRRM_GYTicCinsiyet.Belirsiz;
            }
            set {
                switch (value) {
                    case CRRM_GYTicCinsiyet.Erkek: CinsiyetKod = "E"; break;
                    case CRRM_GYTicCinsiyet.Kadin: CinsiyetKod = "K"; break;
                    default: CinsiyetKod = ""; break;
                }
            }
        }

        [XmlElement( "hakedis" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Hakedis { get; set; }

        [XmlElement( "miktar" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Miktar { get; set; }

        [XmlElement( "fiyat" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Fiyat { get; set; }

        [XmlElement( "maliyet" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Maliyet { get; set; }
        #endregion
    }
}
