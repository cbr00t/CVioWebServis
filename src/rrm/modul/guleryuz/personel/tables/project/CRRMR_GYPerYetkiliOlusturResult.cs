using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerYetkiliOlusturResult : CRRMR_GYBasicResultWithID {
        #region Accessors
        /*[XmlElement( "webServisIslemHataKod" )]
        public string WebServisIslemHataKod { get; set; }

        [XmlElement( "webServisIslemHataAciklama" )]
        public string WebServisIslemHataAciklama { get; set; }*/

        [XmlElement( "firmaID" )]
        public Guid FirmaID { get; set; }

        /*[XmlElement( "tcKimlikNo" )]
        public string TCKimlikNo { get; set; }

        [XmlElement( "isim" )]
        public string Isim { get; set; }

        [XmlElement( "adi" )]
        public string Adi { get; set; }

        [XmlElement( "soyadi" )]
        public string Soyadi { get; set; }*/
        #endregion
    }
}
