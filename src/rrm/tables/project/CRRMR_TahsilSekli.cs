using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_TahsilSekli : CRRMR_KodNoVeAdiYapi {
        #region Accessors
        [XmlElement( "tip" )]
        public string Tip { get; set; }

        [XmlElement( "ahalttip" )]
        public string AHAltTip { get; set; }
        #endregion
    }
}
