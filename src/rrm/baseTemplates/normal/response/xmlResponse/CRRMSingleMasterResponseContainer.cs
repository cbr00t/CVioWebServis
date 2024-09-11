using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMSingleMasterResponseContainer {
        #region Accessors
        [XmlElement( CRRMSingleMasterResponse.RootNodeName )]
        public CRRMSingleMasterResponse Record { get; set; }
        #endregion


        #region Not Categorized
        public CRRMSingleMasterResponseContainer() {
        }
        #endregion
    }
}
