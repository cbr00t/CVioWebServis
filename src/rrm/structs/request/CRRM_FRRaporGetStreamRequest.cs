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
    public class CRRM_FRRaporGetStreamRequest : CRRMBinaryRequest {
        #region Accessors
        public string ReportKey { get; set; }
        #endregion

        #region Getter
        public override string DefaultWSIslem { get { return "frRaporGetStream"; } }
        public override Type ResponseClass { get { return typeof( CRRM_FRRaporOlusturResponse ); } }
        public override bool IsVioWebRequest { get { return true; } }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            base.updateRequestArgs( args );
            var qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "reportKey", ReportKey );
        }
        protected override void afterResponse( CRRMCallArgs args, ref CRRMResponse pResponse ) {
            base.afterResponse( args, ref pResponse );
            var thisResponse = pResponse as CRRM_FRRaporOlusturResponse;
            if (args.Resp != null) {
                #region block
                var contentType = args.Resp.ContentType;
                if (contentType.bosDegilmi())
                    contentType = contentType.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ).FirstOrDefault().Trim();
                thisResponse.ContentType = contentType;
                #endregion
            }
            thisResponse.ReportKey = ReportKey;
        }
        #endregion
    }
}
