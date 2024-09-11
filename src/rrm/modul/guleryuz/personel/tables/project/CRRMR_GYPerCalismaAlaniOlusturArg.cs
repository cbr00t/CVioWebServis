using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerCalismaAlaniOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "calismaAlanID" )]
        public Guid CalismaAlanID { get; set; }

        [XmlElement( "calismaAlanAdi" )]
        public string CalismaAlanAdi { get; set; }

        [XmlElement( "bolgeID" )]
        public Guid BolgeID { get; set; }
        #endregion
    }
}
