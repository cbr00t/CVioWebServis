using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicHizmet : CRRMResponseRecord {
        #region Accessors
        [XmlElement( "firmaID" )]
        public Guid firmaID { get; set; }

        [XmlElement( "kategoriKod" )]
        public string KategoriKod { get; set; }

        [XmlElement( "hizmetKod" )]
        public string HizmetKod { get; set; }

        [XmlElement( "hizmetAdi" )]
        public string HizmetAdi { get; set; }
        #endregion
    }
}
