using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSGKIsyeriOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "sgkIsyeriID" )]
        public Guid SGKIsyeriID { get; set; }

        [XmlElement( "isyeriKod" )]
        public string IsyeriKod { get; set; }

        [XmlElement( "firmaUnvan" )]
        public string FirmaUnvan { get; set; }

        [XmlElement( "firmaAdres" )]
        public string FirmaAdres { get; set; }

        [XmlElement( "firmaIlceAdi" )]
        public string FirmaIlceAdi { get; set; }

        [XmlElement( "firmaAdresPosta" )]
        public string FirmaAdresPosta { get; set; }

        [XmlElement( "firmaIlKod" )]
        public string FirmaIlKod { get; set; }

        [XmlElement( "sgkNo" )]
        public string SGKNo { get; set; }
        #endregion
    }
}
