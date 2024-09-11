using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerPersonelRefOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perKod" )]
        public string PerKod { get; set; }

        [XmlElement( "perID" )]
        public Guid PerID { get; set; }
        #endregion
    }
}
