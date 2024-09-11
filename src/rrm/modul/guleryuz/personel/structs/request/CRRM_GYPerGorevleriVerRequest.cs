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
    public class CRRM_GYPerGorevleriVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYPerGorev> {
        #region Getter
        public override string DefaultWSIslem { get { return "perGorevleriVer"; } }
        public override Type ResponseClass { get { return typeof( CRRM_GYPerGorevleriVerResponse ); } }
        #endregion
    }
}
