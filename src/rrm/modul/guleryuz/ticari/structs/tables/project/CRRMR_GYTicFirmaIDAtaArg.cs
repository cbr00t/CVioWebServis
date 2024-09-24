using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicFirmaIDAtaArg : CRRMR_GYBasicArgWithID {
        #region Accessors
        [XmlElement( "kod" )]
        public string Kod { get; set; }
        #endregion
    }
}
