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
    public class CRRM_GYTicGorevIDAtaRequest : CRRMMasterListRequest<CRRMR_GYTicGorevIDAtaArg, CRRMR_GYTicGorevIDAtaResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "ticGorevIDAta"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicGorevIDAtaResponse ); }
        }
        #endregion
    }
}
