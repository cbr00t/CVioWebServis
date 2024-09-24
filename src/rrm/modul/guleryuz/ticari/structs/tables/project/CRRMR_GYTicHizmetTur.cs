using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicHizmetTur : CRRMRecord {
        #region Accessors
        [XmlElement( "kategoriKod" )]
        public string KategoriKod { get; set; }

        [XmlElement( "turKod" )]
        public string TurKod { get; set; }
        #endregion
    }
}
