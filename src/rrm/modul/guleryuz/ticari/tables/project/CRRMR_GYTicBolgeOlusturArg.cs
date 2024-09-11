using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicBolgeOlusturArg : CRRMR_GYBasicArgWithID {
        #region Accessors
        [XmlElement( "aciklama" )] public string Aciklama { get; set; }
        #endregion
    }
}
