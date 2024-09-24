using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicBolge : CRRMR_KodVeAdiYapi {
        [XmlElement("id")] public Guid? ID { get; set; }
		[XmlElement("grupKod")] public string GrupKod { get; set; }
		[XmlElement("diibKod")] public string DIIBKod { get; set; }
	}
}
