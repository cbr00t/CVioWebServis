using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    [Obsolete( "Bu sınıf kullanımdan kaldırılmıştır", true )]
    public class CRRMR_GYTicFirmaGiderMasraf : CRRMR_KodYapi {
        #region Accessors
        [XmlElement( "firmaid" )]
        public string FirmaID { get; set; }

        [XmlElement( "masrafkod" )]
        public string MasrafKod { get; set; }
        #endregion
    }
}
