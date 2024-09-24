using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerIseGirisYapArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid PerID { get; set; }

        [XmlElement( "tarih" )]
        public DateTime? Tarih { get; set; }

        [XmlElement( "meslekKod" )]
        public string MeslekKod { get; set; }

        /*[XmlElement( "sgkIsyeriKod" )]
        public string SGKIsyeriKod { get; set; }*/
        
        [XmlElement( "asgariUcretmi" )]
        //[DefaultValue( true )]  <--  defaultValue=True verilince true icin xml serialize etmiyor (default value değerini)
        public bool AsgariUcretmi { get; set; }

        [XmlElement( "ucret" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Ucret { get; set; }
        #endregion
    }
}
