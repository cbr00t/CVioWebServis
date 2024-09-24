using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicDonemOlusturResult : CRRMR_GYBasicResultWithID {
        #region Accessors
        [XmlElement( "tarihBasi" )] public DateTime TarihBasi { get; set; }
        [XmlElement( "tarihSonu" )] public DateTime TarihSonu { get; set; }
        [XmlElement( "firmaID" )] public Guid FirmaID { get; set; }
        [XmlElement( "bolgeID" )] public Guid BolgeID { get; set; }
        #endregion
    }
}
