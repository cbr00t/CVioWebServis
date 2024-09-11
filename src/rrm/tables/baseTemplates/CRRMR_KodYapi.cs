using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_KodYapi : CRRMRecord {
        [XmlElement("kod")] public string Kod { get; set; }
    }
}
