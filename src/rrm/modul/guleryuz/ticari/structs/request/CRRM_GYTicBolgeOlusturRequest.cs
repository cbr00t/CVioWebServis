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
    public class CRRM_GYTicBolgeOlusturRequest : CRRMMasterListRequest<CRRMR_GYTicBolgeOlusturArg, CRRMR_GYTicBolgeOlusturResult> {
        public override string DefaultWSIslem { get => "ticBolgeOlustur"; }
        public override Type ResponseClass { get => typeof(CRRM_GYTicBolgeOlusturResponse); }
    }
}
