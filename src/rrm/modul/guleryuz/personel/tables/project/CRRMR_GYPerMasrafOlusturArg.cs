using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerMasrafOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "masrafKod" )]
        public string MasrafKod { get; set; }

        [XmlElement( "masrafAdi" )]
        public string MasrafAdi { get; set; }
        #endregion
    }
}
