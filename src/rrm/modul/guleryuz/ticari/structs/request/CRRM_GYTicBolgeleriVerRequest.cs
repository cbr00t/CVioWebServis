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
    public class CRRM_GYTicBolgeleriVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYTicBolge> {
        public override string DefaultWSIslem { get { return "ticBolgeleriVer"; } }
        public override Type ResponseClass { get { return typeof( CRRM_GYTicBolgeleriVerResponse ); } }
    }
}
