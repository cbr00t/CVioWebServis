using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    [Obsolete( "Bu sınıf kullanımdan kaldırılmıştır", true )]
    public class CRRMR_GYTicFaturaBilgi : CRRMRecord {
        #region Accessors
        [XmlAttribute( "DonemID" )]
        public string DonemID { get; set; }

        [XmlAttribute( "FirmaID" )]
        public string FirmaID { get; set; }

        [XmlArrayItem( "GrupFatura" )]
        public CRRMR_GYTicGrupFatura[] GrupFaturalar { get; set; }
        #endregion
    }
}
