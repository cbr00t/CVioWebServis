using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliPuantajOlusturArg : CRRMRequestRecord {
        [XmlElement("perID")] public Guid PerID { get; set; }
        [XmlElement("donemID")] public Guid DonemID { get; set; }
        [XmlElement("yilAy"), DefaultValue(0)] public int YilAy { get; set; }
        [XmlElement("yil"), DefaultValue(0)] public int Yil { get; set; }
        [XmlElement("ay"), DefaultValue(0)] public int Ay { get; set; }
        [XmlArray("gunler"), XmlArrayItem("gun")] public CRRMR_GYPerSP_Gun[] Gunler { get; set; }
        [XmlArray("yanOdemeler"), XmlArrayItem("yanOdeme")] public CRRMR_GYPerSP_YanOdeme[] YanOdemeler { get; set; }
        [XmlArray("kesintiler"), XmlArrayItem("kesinti")] public CRRMR_GYPerSP_Kesinti[] Kesintiler { get; set; }
    }
    [Serializable()] public class CRRMR_GYPerSP_Gun : CRRMRecord {
        [XmlElement("gunInd"), DefaultValue(0)] public int GunInd { get; set; }
        [XmlElement("saat"), DefaultValue(typeof(decimal), "0")] public decimal Saat { get; set; }
        [XmlElement("fmSaat"), DefaultValue(typeof(decimal), "0")] public decimal FMSaat { get; set; }
        [XmlElement("fmTipKod")] public string _FMTipKod { get; set; }
        public CRRM_GYPerFazlaMesaiTipi FMTipi {
            get {
                if (_FMTipKod != null) { switch (_FMTipKod.ToUpper()) { case "5": return CRRM_GYPerFazlaMesaiTipi.Yuzde50; case "1": return CRRM_GYPerFazlaMesaiTipi.Yuzde100; } }
                return CRRM_GYPerFazlaMesaiTipi.Normal;
            }
            set {
                switch (value) {
                    case CRRM_GYPerFazlaMesaiTipi.Yuzde50: _FMTipKod = "5"; break; case CRRM_GYPerFazlaMesaiTipi.Yuzde100: _FMTipKod = "1"; break; default: _FMTipKod = "N"; break; }
            }
        }
        [XmlElement("calistimi"), DefaultValue(false)] public bool Calistimi { get; set; }
        [XmlElement("gunTipKod")] public string _GunTipKod { get; set; }
        public CRRM_GYPerGunTipi GunTipi {
            get {
                if (_GunTipKod != null) { switch (_GunTipKod.ToUpper()) { case "HF": return CRRM_GYPerGunTipi.HaftaTatili; case "RS": return CRRM_GYPerGunTipi.ResmiTatil; } }
                return CRRM_GYPerGunTipi.Normal;
            }
            set {
                switch (value) { case CRRM_GYPerGunTipi.HaftaTatili: _GunTipKod = "HF"; break; case CRRM_GYPerGunTipi.ResmiTatil: _GunTipKod = "RS"; break; default: _GunTipKod = "CL"; break; }
            }
        }
        [XmlElement("gelmemeNedenKod")] public string GelmemeNedenKod { get; set; }
    }
	[Serializable()]
	public class CRRMR_GYPerSP_YanOdeme : CRRMRecord {
		[XmlElement("odemeKod")] public string OdemeKod { get; set; }
		[XmlElement("bedel"), DefaultValue(typeof(decimal), "0")] public decimal Bedel { get; set; }
	}
	[Serializable()] public class CRRMR_GYPerSP_Kesinti : CRRMR_GYPerSP_YanOdeme { }
}
