using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerGrupOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "grupKod" )] public string GrupKod { get; set; }
        [XmlElement( "grupAdi" )] public string GrupAdi { get; set; }
        #endregion
    }
}
