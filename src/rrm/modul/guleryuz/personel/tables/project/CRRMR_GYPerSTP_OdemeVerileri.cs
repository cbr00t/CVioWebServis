using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSTP_OdemeVerileri : CRRMRecord {
        #region Accessors
        [XmlElement( "odemeKod" )]
        public string OdemeKod { get; set; }

        [XmlElement( "veri" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Veri { get; set; }
        #endregion
    }
}
