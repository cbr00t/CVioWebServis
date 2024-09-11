using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerFirmaOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "firmaID" )]
        public Guid FirmaID { get; set; }

        [XmlElement( "firmaAdi" )]
        public string FirmaAdi { get; set; }
        #endregion
    }
}
