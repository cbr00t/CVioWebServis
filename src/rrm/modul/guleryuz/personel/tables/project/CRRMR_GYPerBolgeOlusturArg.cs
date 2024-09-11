using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerBolgeOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "bolgeID" )] public Guid BolgeID { get; set; }
        [XmlElement( "bolgeAdi" )] public string BolgeAdi { get; set; }
        #endregion
    }
}
