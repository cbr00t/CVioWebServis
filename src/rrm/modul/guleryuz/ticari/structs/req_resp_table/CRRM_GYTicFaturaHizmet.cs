using System;
using System.Xml;
using System.Xml.Serialization;

namespace CVioWebServis {
	public class CRRM_GYTicFaturaHizmetRequest : CRRMMasterListRequest<CRRMR_GYTicFaturaHizmetArg, CRRMR_GYTicFaturaHizmetResult> {
        public override string DefaultWSIslem { get => "ticFaturaHizmet"; }
        public override Type ResponseClass { get => typeof(CRRM_GYTicFaturaHizmetResponse); }
    }
    [Serializable()] public class CRRM_GYTicFaturaHizmetResponse : CRRMMasterResponse<CRRMR_GYTicFaturaHizmetResult> { }
	[Serializable()] public class CRRMR_GYTicFaturaHizmetArg : CRRMRequestRecord {
		#region Accessors
		[XmlElement("Tarih")] public DateTime Tarih { get; set; }
		[XmlElement("FisNox")] public string FisNox { get; set; }
		[XmlElement("TakipNo")] public string TakipNo { get; set; }
		[XmlElement("FirmaID")] public Guid FirmaID { get; set; }
		[XmlElement("FirmaAdi")] public string FirmaAdi { get; set; }
		[XmlArray("EkHizmetler"), XmlArrayItem("EkHizmet")]
		public CRRMR_GYTicFaturaHizmet_EkHizmet[] EkHizmetler { get; set; }
		#endregion
	}
	[Serializable()] public class CRRMR_GYTicFaturaHizmetResult : CRRMR_GYBasicResult { }
	#region Ek Sınıflar
	[Serializable()] public class CRRMR_GYTicFaturaHizmet_EkHizmet : CRRMRecord {
		#region Accessors
		[XmlElement("HizmetTipi")] public string HizmetTipi { get; set; }
		[XmlElement("Bedel")] public decimal Bedel { get; set; }
		#endregion
	}
	#endregion
}
