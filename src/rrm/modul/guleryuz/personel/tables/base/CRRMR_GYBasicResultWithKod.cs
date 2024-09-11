using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYBasicResultWithKod : CRRMR_GYBasicResult {
        #region Accessors
        [XmlElement( "kod" )]
        public string Kod { get; set; }
        #endregion
    }
}
