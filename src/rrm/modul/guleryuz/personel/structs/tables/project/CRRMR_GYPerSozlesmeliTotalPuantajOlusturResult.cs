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
        [XmlElement("eksik1NedenKod")] public string Eksik1NedenKod { get; set; }
        [XmlElement("eksik1Gun"), DefaultValue(0)] public int Eksik1Gun { get; set; }
		[XmlElement("eksik2NedenKod")] public string Eksik2NedenKod { get; set; }
		[XmlElement("eksik2Gun"), DefaultValue(0)] public int Eksik2Gun { get; set; }
		[XmlElement("eksik3NedenKod")] public string Eksik3NedenKod { get; set; }
		[XmlElement("eksik3Gun"), DefaultValue(0)] public int Eksik3Gun { get; set; }
		[XmlElement("eksik4NedenKod")] public string Eksik4NedenKod { get; set; }
		[XmlElement("eksik4Gun"), DefaultValue(0)] public int Eksik4Gun { get; set; }
	}
}
