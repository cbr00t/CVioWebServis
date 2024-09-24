using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicKategori : CRRMResponseRecord {
        #region Accessors
        [XmlElement( "seq" )]
        public int Seq { get; set; }

        [XmlElement( "kategoriKod" )]
        public string KategoriKod { get; set; }

        [XmlElement( "kategoriDetaySayac" )]
        public int KategoriDetaySayac { get; set; }

        [XmlElement( "kategoriDetayAdi" )]
        public string KategoriDetayAdi { get; set; }
        #endregion
    }
}
