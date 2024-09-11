using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace CVioWebServis {
    public class CRRMMasterRequestNonFilterable<T> : CRRMMasterRequest<T> where T : CRRMRecord {
        [XmlIgnore()]
        public override Filtre[] Filtreler { get { return base.Filtreler; } set { base.Filtreler = value; } }
    }
}
