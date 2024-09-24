using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerPersonelRef : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perkod" )]
        public string PerKod { get; set; }
        
        [XmlElement( "perrefid" )]
        public Guid? PerID { get; set; }
        #endregion
    }
}
