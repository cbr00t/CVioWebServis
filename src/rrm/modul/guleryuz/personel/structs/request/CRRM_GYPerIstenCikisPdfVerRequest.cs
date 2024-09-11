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
    public class CRRM_GYPerIstenCikisPdfVerRequest : CRRMMasterListRequest<CRRMR_GYPerIstenCikisPdfVerArg, CRRMR_GYPerIstenCikisPdfVerResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perIstenCikisPDFVer"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerIstenCikisPdfVerResponse ); }
        }
        #endregion
    }
}
