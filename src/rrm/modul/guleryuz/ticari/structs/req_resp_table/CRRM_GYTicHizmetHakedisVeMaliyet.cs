using System;
using System.Xml;
using System.Xml.Serialization;

namespace CVioWebServis {
	public class CRRM_GYTicHizmetHakedisVeMaliyetRequest : CRRMMasterListRequest<CRRMR_GYTicHizmetHakedisVeMaliyetArg, CRRMR_GYTicHizmetHakedisVeMaliyetResult> {
        public override string DefaultWSIslem { get => "ticHizmetHakedisVeMaliyet"; }
        public override Type ResponseClass { get => typeof(CRRM_GYTicHizmetHakedisVeMaliyetResponse); }
    }
    [Serializable()] public class CRRM_GYTicHizmetHakedisVeMaliyetResponse : CRRMMasterResponse<CRRMR_GYTicHizmetHakedisVeMaliyetResult> { }
	[Serializable()] public class CRRMR_GYTicHizmetHakedisVeMaliyetArg : CRRMRequestRecord {
		#region Accessors
		[XmlElement("Tarih")] public DateTime Tarih { get; set; }
		[XmlElement("FisNox")] public string FisNox { get; set; }
		[XmlElement("TakipNo")] public string TakipNo { get; set; }
		[XmlElement("FirmaID")] public Guid FirmaID { get; set; }
		[XmlElement("FirmaAdi")] public string FirmaAdi { get; set; }
		[XmlElement("BolgeID")] public Guid BolgeID { get; set; }
		[XmlElement("BolgeAdi")] public string BolgeAdi { get; set; }
		[XmlElement("CalismaAlaniID")] public Guid CalismaAlaniID { get; set; }
		[XmlElement("CalismaAlaniAdi")] public string CalismaAlaniAdi { get; set; }
		[XmlElement("TemsilciID")] public Guid TemsilciID { get; set; }
		[XmlElement("TemsilciAdi")] public string TemsilciAdi { get; set; }
		[XmlElement("GorevID")] public Guid GorevID { get; set; }
		[XmlElement("GorevAdi")] public string GorevAdi { get; set; }
		[XmlElement("Cinsiyet")] public string Cinsiyet { get; set; }
		[XmlElement("CalisanSayisi")] public int CalisanSayisi { get; set; }
		[XmlElement("IscilikBirimUcret")] public decimal IscilikBirimUcret { get; set; }
		[XmlElement("FMSaat")] public decimal FMSaat { get; set; }
		[XmlElement("netmi")] public string netmi { get; set; }
		public bool Netmi { get => netmi.bosDegilmi(); set => netmi = value ? "*" : ""; }
		[XmlElement("XOdenen")] public decimal XOdenen { get; set; }
		[XmlElement("SGKVeVergi")] public decimal SGKVeVergi { get; set; }
		[XmlElement("FazlaMesai")] public decimal FazlaMesai { get; set; }
		[XmlElement("HizmetFazlaMesai")] public decimal HizmetFazlaMesai { get; set; }
		[XmlElement("Yemek")] public decimal Yemek { get; set; }
		[XmlElement("ElcilikUcreti")] public decimal ElcilikUcreti { get; set; }
		[XmlElement("ISG")] public decimal ISG { get; set; }
		[XmlElement("Hizmet")] public decimal Hizmet { get; set; }
		[XmlElement("HizmetFM")] public decimal HizmetFM { get; set; }
		[XmlElement("Yol")] public decimal Yol { get; set; }
		[XmlElement("Su")] public decimal Su { get; set; }
		[XmlElement("Servis")] public decimal Servis { get; set; }
		[XmlElement("DigerUcret")] public decimal DigerUcret { get; set; }
		[XmlArray("EkHizmetler"), XmlArrayItem("EkHizmet")] public CRRMR_GYTicHizmetHakedisVeMaliyet_EkHizmet[] EkHizmetler { get; set; }
		[XmlElement("EkMaliyet")] public decimal EkMaliyet { get; set; }
		#endregion
	}
	[Serializable()] public class CRRMR_GYTicHizmetHakedisVeMaliyetResult : CRRMR_GYBasicResult { }
	#region Ek Sınıflar
	[Serializable()] public class CRRMR_GYTicHizmetHakedisVeMaliyet_EkHizmet : CRRMRecord {
		#region Accessors
		[XmlElement("ID")] public Guid ID { get; set; }
		[XmlElement("Aciklama")] public string Aciklama { get; set; }
		[XmlElement("Bedel")] public decimal Bedel { get; set; }
		#endregion
	}
	#endregion
}
