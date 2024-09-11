using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_SayacYapi : CRRMRecord {
        #region Accessors
        [XmlElement( "sayac" ), DefaultValue( 0 )]
        public int Sayac { get; set; }
        #endregion
    }
}
