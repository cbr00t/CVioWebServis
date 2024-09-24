using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerTarCalismaSilResult : CRRMR_GYBasicResult {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid PerID { get; set; }

        [XmlElement( "tarih" )]
        public DateTime Tarih { get; set; }

        [XmlElement( "firmaCalismaAlanID" )]
        public Guid FirmaCalismaAlanID { get; set; }

        [XmlElement( "perSayac" )]
        public int? PerSayac { get; set; }

        [XmlElement( "perKod" )]
        public string PerKod { get; set; }

        [XmlElement( "perIsim" )]
        public string PerIsim { get; set; }
        #endregion
    }
}
