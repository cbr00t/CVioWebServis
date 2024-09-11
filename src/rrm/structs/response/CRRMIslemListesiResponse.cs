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
    [Serializable()]
    public class CRRMIslemListesiResponse : CRRMStringListResponse {
        #region Accessors
        [XmlElement( "islem" )]
        public bool Islem { get; set; }
        #endregion
    }
}
