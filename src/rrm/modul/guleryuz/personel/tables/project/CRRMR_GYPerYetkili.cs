using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerYetkili : CRRMRecord {
        #region Accessors
        [XmlElement( "webrefid" )]
        public Guid? WebRefID { get; set; }

        [XmlElement( "firmarefid" )]
        public Guid? FirmaRefID { get; set; }
        
        [XmlElement( "aciklama" )]
        public string Aciklama { get; set; }
        #endregion
    }
}
