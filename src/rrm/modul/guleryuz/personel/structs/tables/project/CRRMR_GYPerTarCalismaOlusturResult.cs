using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerTarCalismaOlusturResult : CRRMR_GYBasicResult {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid PerID { get; set; }

        [XmlElement( "firmaCalismaAlanID" )]
        public Guid FirmaCalismaAlanID { get; set; }
        #endregion
    }
}
