using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMResponseBase : CRRMParseable {
        #region Uygunluk
        /*[SoapIgnore()]
        public bool IsErrorObject {
            get { return _IsErrorObject; }
            set { }
        }*/

        [SoapIgnore()]
        public virtual bool _IsErrorObject {
            get { return false; }
        }
        #endregion

        #region WS Iletisim
        public virtual void parseResponse( CRRMCallArgs args ) {
        }
        public virtual void afterResponse( CRRMCallArgs args ) {
        }
        #endregion

        #region Not Categorized
        public CRRMResponseBase() : base() {
        }
        #endregion
    }
}
