using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYBasicResult : CRRMResponseRecord {
        #region Accessors
        [XmlElement( "isError" )]
        public bool IsError { get; set; }

        [XmlElement( "errorCode" )]
        public string ErrorCode { get; set; }

        [XmlElement( "errorText" )]
        public string ErrorText { get; set; }

        [XmlElement( "uyariText" )]
        public string UyariText { get; set; }

        public bool UyariVarmi {
            get { return UyariText.bosDegilmi(); }
            set { }
        }
        #endregion
    }
}
