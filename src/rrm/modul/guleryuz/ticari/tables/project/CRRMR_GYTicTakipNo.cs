using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicTakipNo : CRRMR_KodVeAdiYapi {
		[XmlElement("grupKod")] public string GrupKod { get; set; }
		[XmlElement("osColor"), DefaultValue(0)] public int OSColor { get; set; }
		[XmlElement("colorHTML")] public string ColorHTML { get; set; }
	}
}
