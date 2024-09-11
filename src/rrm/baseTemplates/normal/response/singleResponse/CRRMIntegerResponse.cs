using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMIntegerResponse : CRRMSingleResponse<int> {
        #region Setter
        protected override void setValue( string value ) {
            Value = value.asInteger();
        }
        #endregion
    }
}
