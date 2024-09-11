using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYBasicArgWithID : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "id" )] public Guid ID { get; set; }
        #endregion
    }
}
