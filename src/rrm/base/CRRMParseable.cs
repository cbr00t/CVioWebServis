using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMParseable : ICloneable {
        #region Not Categorized
        public object Clone() {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
