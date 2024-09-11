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
    public class CRRM_GYTicKategorileriVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYTicKategori> {
        public override string DefaultWSIslem { get { return "ticKategorileriVer"; } }
        public override Type ResponseClass { get { return typeof( CRRM_GYTicKategorileriVerResponse ); } }
    }
}
