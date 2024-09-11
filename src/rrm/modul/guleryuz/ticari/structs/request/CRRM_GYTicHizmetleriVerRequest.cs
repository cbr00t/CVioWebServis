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
    public class CRRM_GYTicHizmetleriVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYTicHizmet> {
        #region Accessors
        public bool Hepsimi { get; set; }
        #endregion

        #region Getter
        public override string DefaultWSIslem {
            get { return "ticHizmetleriVer"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicHizmetleriVerResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.atPut( "hepsimi", Hepsimi );
        }
        #endregion
    }
}
