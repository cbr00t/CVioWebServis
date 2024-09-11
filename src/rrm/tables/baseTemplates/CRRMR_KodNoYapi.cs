using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_KodNoYapi : CRRMRecord {
        #region Data Accessors
        [XmlElement( "kodno" )]
        public int KodNo { get; set; }
        #endregion
    }
}
