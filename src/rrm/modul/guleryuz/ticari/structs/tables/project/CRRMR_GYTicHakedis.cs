using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicHakedis : CRRMRecord {
        #region Accessors
        [XmlElement( "Kod" )]
        public string Kod { get; set; }

        [XmlElement( "Bedel" )]
        public decimal Bedel { get; set; }
        #endregion
    }
}
