using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliPersonelOlusturResult : CRRMR_GYPerPersonelOlusturResult {
        #region Accessors
        [XmlElement( "firmaCalismaAlanID" )]
        public Guid? FirmaCalismaAlanID { get; set; }
        #endregion
    }
}
