using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    [Obsolete( "Bu sınıf kullanımdan kaldırılmıştır", true )]
    public class CRRM_GYTicFaturaBilgiVerResponse : CRRMSingleMasterResponse {
        #region Accessors
        //[XmlArray( "Faturalar" )]
        [XmlArrayItem( "Firma" )]
        public CRRMR_GYTicFaturaBilgi[] Firmalar { get; set; }
        #endregion
    }
}
