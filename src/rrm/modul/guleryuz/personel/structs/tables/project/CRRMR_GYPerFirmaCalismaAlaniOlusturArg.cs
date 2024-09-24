using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerFirmaCalismaAlaniOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "firmaCalismaID" )]
        public Guid FirmaCalismaID { get; set; }

        [XmlElement( "firmaID" )]
        public Guid FirmaID { get; set; }

        [XmlElement( "calismaAlanID" )]
        public Guid CalismaAlanID { get; set; }
        #endregion
    }
}
