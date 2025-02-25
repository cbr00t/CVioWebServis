using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerTarFirmaMaliyet : CRRMResponseRecord {
        [XmlElement("goPerID")] public Guid PerID { get; set; }
        [XmlElement("perIsim")] public string PerIsim { get; set; }
        [XmlElement("tckimlikno")] public string TCKimlikNo { get; set; }
        [XmlElement("goDonemID")] public Guid DonemID { get; set; }
        [XmlElement("goFirmaID")] public Guid FirmaID { get; set; }
        [XmlElement("goFirmaAdi")] public string FirmaAdi { get; set; }
        [XmlElement("goBolgeID")] public Guid BolgeID { get; set; }
        [XmlElement("goBolgeAdi")] public string BolgeAdi { get; set; }
		[XmlElement("brutUcret"), DefaultValue(typeof(decimal), "0")] public decimal BrutUcret { get; set; }
		[XmlElement("brutOdenen"), DefaultValue(typeof(decimal), "0")] public decimal BrutOdenen { get; set; }
        [XmlElement("normalOdeme"), DefaultValue(typeof(decimal), "0")] public decimal NormalOdeme { get; set; }
        [XmlElement("fazlaMesai"), DefaultValue(typeof(decimal), "0")] public decimal FazlaMesai { get; set; }
        [XmlElement("fazlaMesaiSaat"), DefaultValue(typeof(decimal), "0")] public decimal FazlaMesaiSaat { get; set; }
		[XmlElement("fazlaMesaiTumNet"), DefaultValue(typeof(decimal), "0")] public decimal FazlaMesaiTumNet { get; set; }
		[XmlElement("calismaGunu"), DefaultValue(typeof(decimal), "0")] public decimal CalismaGunu { get; set; }
        [XmlElement("yanOdeme"), DefaultValue(typeof(decimal), "0")] public decimal YanOdeme { get; set; }
        [XmlElement("ozelKesinti"), DefaultValue(typeof(decimal), "0")] public decimal OzelKesinti { get; set; }
        [XmlElement("isverenPrimi"), DefaultValue(typeof(decimal), "0")] public decimal IsverenPrimi { get; set; }
        [XmlElement("issizlikIsvPrimi"), DefaultValue(typeof(decimal), "0")] public decimal IssizlikIsvPrimi { get; set; }
        [XmlElement("besKesinti"), DefaultValue(typeof(decimal), "0")] public decimal BESKesinti { get; set; }
        [XmlElement("icraKesinti"), DefaultValue(typeof(decimal), "0")] public decimal IcraKesinti { get; set; }
        [XmlElement("nafakaKesinti"), DefaultValue(typeof(decimal), "0")] public decimal NafakaKesinti { get; set; }
        [XmlElement("netHakedis"), DefaultValue(typeof(decimal), "0")] public decimal NetHakedis { get; set; }
        [XmlElement("asgariGecim"), DefaultValue(typeof(decimal), "0")] public decimal AsgariGecim { get; set; }
        [XmlElement("sgk_sskMatrahi"), DefaultValue(typeof(decimal), "0")] public decimal SGK_SSKMatrahi { get; set; }
        [XmlElement("sgk_Indirim5Puan"), DefaultValue(typeof(decimal), "0")] public decimal SGK_Indirim5Puan { get; set; }
        [XmlElement("sgkTesvikKanunNo")] public string SGKTesvikKanunNo { get; set; }
        [XmlElement("sskDurum"), SoapIgnore()] public string SSKDurumKod { get; set; }
        public CRRM_SSKDurum SSKDurum {
            get {
                if (SSKDurumKod != null) {
                    switch (SSKDurumKod.ToUpper()) {
                        case "E": return CRRM_SSKDurum.Emekli; case "C": return CRRM_SSKDurum.Cirak; case "S": return CRRM_SSKDurum.Stajyer;
                        case "Y": return CRRM_SSKDurum.Yabanci_AnlasmaliUlke; case "Z": return CRRM_SSKDurum.Yabanci_DigerUlke; case "D": return CRRM_SSKDurum.YurtDisindaCalisan;
                        case "F6": return CRRM_SSKDurum.FiiliHizmetZammi_60Gun; case "F9": return CRRM_SSKDurum.FiiliHizmetZammi_90Gun; case "F8": return CRRM_SSKDurum.FiiliHizmetZammi_180Gun;
                        case "H": return CRRM_SSKDurum.HakkiHuzur; case "HM": return CRRM_SSKDurum.HarpMalulu; case "KM": return CRRM_SSKDurum.KamuIhaleKanunuIstihdami;
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
        [XmlElement("agiDahilNet"), DefaultValue(typeof(decimal), "0")] public decimal AgiDahilNet { get; set; }
        [XmlElement("firmaMaliyet"), DefaultValue(typeof(decimal), "0")] public decimal FirmaMaliyet { get; set; }
    }
}
