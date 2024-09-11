using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYTicHizmetleriEslestirArg : CRRMR_GYBasicArgWithID {
        #region Accessors
        [XmlElement( "hizmetKod" )]
        public string HizmetKod { get; set; }
        #endregion
    }
}
