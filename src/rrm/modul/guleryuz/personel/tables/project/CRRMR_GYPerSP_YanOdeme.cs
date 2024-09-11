using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSP_YanOdeme : CRRMRecord {
        #region Accessors
        [XmlElement( "odemeKod" )]
        public string OdemeKod { get; set; }

        [XmlElement( "bedel" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Bedel { get; set; }
        #endregion
    }
}
