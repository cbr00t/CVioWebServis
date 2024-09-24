using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerPersonel : CRRMR_KodVeAdiYapi {
        #region Accessors
        [XmlElement( "perid" )]
        public Guid? ID { get; set; }

        [XmlElement( "adi" )]
        public string Adi { get; set; }

        [XmlElement( "soyadi" )]
        public string Soyadi { get; set; }

        [XmlElement( "tckimlikno" )]
        public string TCKimlikNo { get; set; }

        [SoapIgnore()]
        [XmlElement( "cinsiyet" )]
        public string CinsiyetKod { get; set; }

        public CRRM_Cinsiyet Cinsiyet {
            get {
                if (CinsiyetKod != null) {
                    switch (CinsiyetKod.ToUpper()) {
                        case "K": return CRRM_Cinsiyet.Kadin;
                    }
                }

                return CRRM_Cinsiyet.Erkek;
            }
            set {
                switch (value) {
                    case CRRM_Cinsiyet.Kadin: CinsiyetKod = "K"; break;
                    default: CinsiyetKod = "E"; break;
                }
            }
        }

        [SoapIgnore()]
        [XmlElement( "medeni" )]
        public string MedeniDurumKod { get; set; }

        public CRRM_MedeniDurum MedeniDurum {
            get {
                if (MedeniDurumKod != null) {
                    switch (MedeniDurumKod.ToUpper()) {
                        case "E": return CRRM_MedeniDurum.Evli;
                        case "D": return CRRM_MedeniDurum.Dul;
                    }
                }

                return CRRM_MedeniDurum.Bekar;
            }
            set {
                switch (value) {
                    case CRRM_MedeniDurum.Evli: MedeniDurumKod = "E"; break;
                    case CRRM_MedeniDurum.Dul: MedeniDurumKod = "D"; break;
                    default: MedeniDurumKod = "B"; break;
                }
            }
        }

        [SoapIgnore()]
        [XmlElement( "ogrenimDurumu" )]
        public string OgrenimDurumuKod { get; set; }

        public CRRM_GYPerOgrenimDurumu OgrenimDurumu {
            get {
                if (OgrenimDurumuKod != null) {
                    switch (OgrenimDurumuKod.ToUpper().Trim()) {
                        case "U": return CRRM_GYPerOgrenimDurumu.Ilkokul;
                        case "I": return CRRM_GYPerOgrenimDurumu.Ortaokul;
                        case "L": return CRRM_GYPerOgrenimDurumu.Lise;
                        case "Y": return CRRM_GYPerOgrenimDurumu.Lisans;
                        case "S": return CRRM_GYPerOgrenimDurumu.YuksekLisans;
                        case "D": return CRRM_GYPerOgrenimDurumu.Doktora;
                    }
                }

                return CRRM_GYPerOgrenimDurumu.OkurYazarDegil;
            }
            set {
                switch (value) {
                    case CRRM_GYPerOgrenimDurumu.Ilkokul: OgrenimDurumuKod = "U"; break;
                    case CRRM_GYPerOgrenimDurumu.Ortaokul: OgrenimDurumuKod = "I"; break;
                    case CRRM_GYPerOgrenimDurumu.Lise: OgrenimDurumuKod = "L"; break;
                    case CRRM_GYPerOgrenimDurumu.Lisans: OgrenimDurumuKod = "Y"; break;
                    case CRRM_GYPerOgrenimDurumu.YuksekLisans: OgrenimDurumuKod = "S"; break;
                    case CRRM_GYPerOgrenimDurumu.Doktora: OgrenimDurumuKod = "D"; break;
                    default: OgrenimDurumuKod = ""; break;
                }
            }
        }

        [XmlElement( "kimdogumyeri" )]
        public string DogumYeri { get; set; }

        [XmlElement( "kimdogumtarihi" )]
        public DateTime? DogumTarihi { get; set; }

        [XmlElement( "cepTel" )]
        public string CepTel { get; set; }

        [XmlElement( "ibanNo" )]
        public string IBANNo { get; set; }

        [SoapIgnore()]
        [XmlElement( "sskdurum" )]
        public string SSKDurumKod { get; set; }

        public CRRM_SSKDurum SSKDurum {
            get {
                if (SSKDurumKod != null) {
                    switch (SSKDurumKod.ToUpper()) {
                        case "E": return CRRM_SSKDurum.Emekli;
                        case "C": return CRRM_SSKDurum.Cirak;
                        case "S": return CRRM_SSKDurum.Stajyer;
                        case "Y": return CRRM_SSKDurum.Yabanci_AnlasmaliUlke;
                        case "Z": return CRRM_SSKDurum.Yabanci_DigerUlke;
                        case "D": return CRRM_SSKDurum.YurtDisindaCalisan;
                        case "F6": return CRRM_SSKDurum.FiiliHizmetZammi_60Gun;
                        case "F9": return CRRM_SSKDurum.FiiliHizmetZammi_90Gun;
                        case "F8": return CRRM_SSKDurum.FiiliHizmetZammi_180Gun;
                        case "H": return CRRM_SSKDurum.HakkiHuzur;
                        case "HM": return CRRM_SSKDurum.HarpMalulu;
                        case "KM": return CRRM_SSKDurum.KamuIhaleKanunuIstihdami;
                        case "R": return CRRM_SSKDurum.Diger;
                    }
                }

                return CRRM_SSKDurum.Normal;
            }
            set {
                switch (value) {
                    case CRRM_SSKDurum.Emekli: SSKDurumKod = "E"; break;
                    case CRRM_SSKDurum.Cirak: SSKDurumKod = "C"; break;
                    case CRRM_SSKDurum.Stajyer: SSKDurumKod = "S"; break;
                    case CRRM_SSKDurum.Yabanci_AnlasmaliUlke: SSKDurumKod = "Y"; break;
                    case CRRM_SSKDurum.Yabanci_DigerUlke: SSKDurumKod = "Z"; break;
                    case CRRM_SSKDurum.YurtDisindaCalisan: SSKDurumKod = "D"; break;
                    case CRRM_SSKDurum.FiiliHizmetZammi_60Gun: SSKDurumKod = "F6"; break;
                    case CRRM_SSKDurum.FiiliHizmetZammi_90Gun: SSKDurumKod = "F9"; break;
                    case CRRM_SSKDurum.FiiliHizmetZammi_180Gun: SSKDurumKod = "F8"; break;
                    case CRRM_SSKDurum.HakkiHuzur: SSKDurumKod = "H"; break;
                    case CRRM_SSKDurum.HarpMalulu: SSKDurumKod = "HM"; break;
                    case CRRM_SSKDurum.KamuIhaleKanunuIstihdami: SSKDurumKod = "KM"; break;
                    case CRRM_SSKDurum.Diger: SSKDurumKod = "R"; break;
                    default: SSKDurumKod = ""; break;
                }
            }
        }

        [XmlElement( "depkod" )]
        public string DepKod { get; set; }

        [XmlElement( "depadi" )]
        public string DepAdi { get; set; }

        /*[XmlElement( "isyeriid" )]
        public Guid? IsyeriID { get; set; }*/

        [XmlElement( "sgkisyerikod" )]
        public string IsyeriKod { get; set; }

        [XmlElement( "isyeriunvan" )]
        public string IsyeriUnvan { get; set; }

        [XmlElement( "isyeriilkod" )]
        public string IsyeriIlKod { get; set; }

        [XmlElement( "isyeriiladi" )]
        public string IsyeriIlAdi { get; set; }

        [XmlElement( "isyeriilceadi" )]
        public string IsyeriIlceAdi { get; set; }

        [XmlElement( "isegiristarihi" )]
        public DateTime? IseGirisTarihi { get; set; }

        [XmlElement( "istencikistarihi" )]
        public DateTime? IstenCikisTarihi { get; set; }

        [XmlElement( "sskisyintgirbiltrh" )]
        [SoapIgnore()]
        public DateTime? _SSKIseGirisBildirimTarihi { get; set; }

        public DateTime? SSKIseGirisBildirimTarihi {
            get { return _SSKIseGirisBildirimTarihi; }
            set { _SSKIseGirisBildirimTarihi = value; }
        }

        [XmlElement( "sskisyintcikbiltrh" )]
        [SoapIgnore()]
        public DateTime? _SSKIstenCikisBildirimTarihi { get; set; }

        public DateTime? SSKIstenCikisBildirimTarihi {
            get { return _SSKIstenCikisBildirimTarihi; }
            set { _SSKIstenCikisBildirimTarihi = value; }
        }

        [XmlElement( "firmacalismaalanid" )]
        public Guid? FirmaCalismaAlanID { get; set; }
        #endregion
    }
}
