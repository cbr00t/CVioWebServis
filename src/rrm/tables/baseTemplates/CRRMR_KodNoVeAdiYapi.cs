using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_KodNoVeAdiYapi : CRRMR_KodNoYapi {
        #region Data Accessors
        [XmlElement( "aciklama" )]
        public string Aciklama { get; set; }
        #endregion
    }
}
