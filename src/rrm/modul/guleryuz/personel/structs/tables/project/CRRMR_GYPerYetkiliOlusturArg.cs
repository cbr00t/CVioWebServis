using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerYetkiliOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "yetkiliID" )]
        public Guid YetkiliID { get; set; }

        [XmlElement( "firmaID" )]
        public Guid FirmaID { get; set; }

        [XmlElement( "yetkiliAdi" )]
        public string YetkiliAdi { get; set; }

        /*[XmlElement( "tcKimlikNo" )]
        public string TCKimlikNo { get; set; }*/
        #endregion
    }
}
