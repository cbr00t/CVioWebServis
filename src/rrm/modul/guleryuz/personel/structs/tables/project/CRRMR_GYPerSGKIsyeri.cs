using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSGKIsyeri : CRRMR_KodVeAdiYapi {
        #region Accessors
        [XmlElement( "isygrupkod" )]
        public string SGKIsyeriGrupKod { get; set; }

        [XmlElement( "isygrupadi" )]
        public string SGKIsyeriGrupAdi { get; set; }

        [XmlElement( "yore" )]
        public string Yore { get; set; }

        [XmlElement( "ilkod" )]
        public string IlKod { get; set; }

        [XmlElement( "iladi" )]
        public string IlAdi { get; set; }

        [XmlElement( "ilceadi" )]
        public string IlceAdi { get; set; }

        [XmlElement( "sgkno" )]
        public string SGKNo { get; set; }
        #endregion
    }
}
