using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_KodVeAdiYapi : CRRMR_KodYapi {
        [XmlElement("aciklama")] public string Aciklama { get; set; }
    }
}
