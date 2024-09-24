using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerIstenCikisYapArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid PerID { get; set; }

        [XmlElement( "tarih" )]
        public DateTime? Tarih { get; set; }

        /*[XmlElement( "sgkIsyeriKod" )]
        public string SGKIsyeriKod { get; set; }*/
        
        [XmlElement( "nedenKod" )]
        public string NedenKod { get; set; }

        [XmlElement( "tarimmi" ), DefaultValue( false )]
        public bool Tarimmi { get; set; }
        #endregion
    }
}
