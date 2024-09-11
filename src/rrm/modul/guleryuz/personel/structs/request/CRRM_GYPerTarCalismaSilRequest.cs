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
    public class CRRM_GYPerTarCalismaSilRequest : CRRMMasterListRequest<CRRMR_GYPerTarCalismaSilArg, CRRMR_GYPerTarCalismaSilResult> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "perTarCalismaSil"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerTarCalismaSilResponse ); }
        }
        #endregion
    }
}
