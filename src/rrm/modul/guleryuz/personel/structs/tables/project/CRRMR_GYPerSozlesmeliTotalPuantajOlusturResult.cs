using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliTotalPuantajOlusturResult : CRRMResponseRecord {
        [XmlElement("yilAy"), DefaultValue(0)] public int YilAy { get; set; }
        [XmlElement("yil"), DefaultValue(0)] public int Yil { get; set; }
        [XmlElement("ay"), DefaultValue(0)] public int Ay { get; set; }
        [XmlElement("goPerID")] public Guid? GoPerID { get; set; }
        [XmlElement("perSayac"), DefaultValue(0)] public int PerSayac { get; set; }
        [XmlElement("perKod")] public string PerKod { get; set; }
        /*[XmlElement("perIsim")] public string PerIsim { get; set; }*/
        [XmlElement("calismaID"), DefaultValue(0)] public int CalismaID { get; set; }
		[XmlArray("eksikBilgileri"), XmlArrayItem("eksikBilgi")] public CRRMR_GYPer_EksikBilgi[] EksikBilgileri { get; set; }
    }
    [Serializable()] public class CRRMR_GYPer_EksikBilgi : CRRMRecord {
		[XmlElement("nedenKod")] public string NedenKod { get; set; }
		[XmlElement("gun"), DefaultValue(0)] public decimal Gun { get; set; }
	}
}
