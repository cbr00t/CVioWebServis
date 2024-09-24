using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerTarCalismaSilArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid? PerID { get; set; }

        [XmlElement( "tarih" )]
        public DateTime? Tarih { get; set; }

        [XmlElement( "firmaCalismaAlanID" )]
        public Guid? FirmaCalismaAlanID { get; set; }
        #endregion
    }
}
