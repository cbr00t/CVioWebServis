using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicHizmetleriEslestirResult : CRRMR_GYBasicResultWithID {
        #region Accessors
        [XmlElement( "hizmetKod" )]
        public string HizmetKod { get; set; }
        #endregion
    }
}
