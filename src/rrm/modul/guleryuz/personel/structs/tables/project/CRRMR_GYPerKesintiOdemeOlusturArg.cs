using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerKesintiOdemeOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "odemeKod" )]
        public string OdemeKod { get; set; }

        [XmlElement( "odemeAdi" )]
        public string OdemeAdi { get; set; }
        #endregion
    }
}
