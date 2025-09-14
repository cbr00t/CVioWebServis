using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMErrorResponse : CRRMResponseBase {
        #region Accessors
        [XmlIgnore()]
        public string _Category { get; set; }

        public CRRMErrorCategory Category {
            get {
                if (_Category.bosDegilmi()) {
                    switch (_Category.ToUpper()) {
                        case "P": return CRRMErrorCategory.Programci;
                        case "W": return CRRMErrorCategory.Webci;
                    }
                }
                return CRRMErrorCategory.Kullanici;
            }
            set {
                switch (value) {
                    case CRRMErrorCategory.Programci: _Category = "P"; break;
                    case CRRMErrorCategory.Webci: _Category = "W"; break;
                    default: _Category = ""; break;
                }
            }
        }

        public string Code { get; set; }
        public string SubCode { get; set; }
        public string ExtraArg { get; set; }
        public string Message { get; set; }
        #endregion

        #region Uygunluk
        [SoapIgnore()]
        public override bool _IsErrorObject {
            get { return true; }
        }
        #endregion
    }
}
