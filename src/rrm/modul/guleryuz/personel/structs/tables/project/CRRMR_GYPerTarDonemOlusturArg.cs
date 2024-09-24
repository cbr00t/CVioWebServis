using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerTarDonemOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "donemID" )]
        public Guid DonemID { get; set; }

        [XmlElement( "firmaID" )]
        public Guid FirmaID { get; set; }

        [XmlElement( "bolgeID" )]
        public Guid BolgeID { get; set; }

        [XmlElement( "yetkiliID" )]
        public Guid? YetkiliID { get; set; }

        [XmlElement( "donemBasi" )]
        public DateTime DonemBasi { get; set; }

        [XmlElement( "donemSonu" )]
        public DateTime DonemSonu { get; set; }
        #endregion
    }
}
