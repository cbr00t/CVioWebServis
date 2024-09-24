using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerPersonelOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )] public Guid PerID { get; set; }
        [XmlElement( "perKod" )] public string PerKod { get; set; }
        [XmlElement( "sgkIsyeriKod" )] public string SGKIsyeriKod { get; set; }
        [XmlElement( "tcKimlikNo" )] public string TCKimlikNo { get; set; }
        [XmlElement( "kimlikSorgulamaYapilirmi" ), DefaultValue( false )] public bool KimlikSorgulamaYapilirmi { get; set; }
        [XmlElement( "emeklimi" )]
        public bool Emeklimi { get; set; }
        [XmlElement( "masrafKod" )]
        public string MasrafKod { get; set; }
        [XmlElement( "grupKod" )] public string GrupKod { get; set; }
        [XmlElement( "gorevKod" )] public string GorevKod { get; set; }
        [XmlElement( "adi" )] public string Adi { get; set; }
        [XmlElement( "soyadi" )] public string Soyadi { get; set; }
        /* [SoapIgnore()] */ [XmlElement( "cinsiyet" )] public string CinsiyetKod { get; set; }
        public CRRM_Cinsiyet Cinsiyet {
            get {
                if (CinsiyetKod != null) { switch (CinsiyetKod.ToUpper()) { case "K": return CRRM_Cinsiyet.Kadin; } }
                return CRRM_Cinsiyet.Erkek;
            }
            set {
                switch (value) {
                    case CRRM_Cinsiyet.Kadin: CinsiyetKod = "K"; break;
                    default: CinsiyetKod = "E"; break;
                }
            }
        }
        [SoapIgnore(), XmlElement( "medeni" )] public string MedeniDurumKod { get; set; }
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
        [XmlElement( "ogrenimDurumu" )] public string OgrenimDurumuKod { get; set; }
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
        [XmlElement( "dogumTarihi" )] public DateTime? DogumTarihi { get; set; }
        [XmlElement( "babaAdi" )] public string BabaAdi { get; set; }
        [XmlElement( "anaAdi" )] public string AnaAdi { get; set; }
        [XmlElement( "hesKod" )] public string HESKod { get; set; }
        [XmlElement( "cepTel" )] public string CepTel { get; set; }
        [XmlElement( "ibanNo" )] public string IBANNo { get; set; }
        /*[XmlElement( "iseGirisTarihi" ), DefaultValue( null )] public DateTime? IseGirisTarihi { get; set; }
        [XmlElement( "meslekKod" )] public string MeslekKod { get; set; }*/
        #endregion
    }
}
