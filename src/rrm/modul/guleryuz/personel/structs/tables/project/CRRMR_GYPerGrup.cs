using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerGrup : CRRMR_KodVeAdiYapi {
        #region Accessors
        [XmlElement( "anaGrupKod" )] public string AnaGrupKod { get; set; }
        [XmlElement( "anaGrupAdi" )] public string AnaGrupAdi { get; set; }
        #endregion
    }
}
