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
    public class CRRM_FRRaporOlusturRequest : CRRMXmlRequest {
        #region Accessors
        [SoapIgnore()]
        public string reportOutput { get; set; }

        public CRRM_FRReportOutput ReportOutput {
            get {
                var result = CRRM_FRReportOutput.pdf;
                try { result = (CRRM_FRReportOutput)Enum.Parse( typeof( CRRM_FRReportOutput ), reportOutput, true ); }
                catch (Exception) { }
                return result;
            }
            set { reportOutput = value.ToString(); }
        }

        public string RaporSinif { get; set; }
        [DefaultValue( 0 )]
        public int RaporSayac { get; set; }
        public string RaporSecimler { get; set; }
        public override bool IsVioWebRequest { get { return true; } }
        #endregion

        #region Getter
        public override CIOType? DefaultInputType { get { return CIOType.xml; } }
        public override string DefaultWSIslem { get { return "frRaporOlustur"; } }
        public override Type ResponseClass { get { return typeof( CRRM_FRRaporOlusturResponse ); } }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            base.updateRequestArgs( args );
            var qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "reportOutput", reportOutput );
            qsArgs.bosDegilseAtPut( "raporSinif", RaporSinif );
            qsArgs.bosDegilseAtPut( "raporSayac", RaporSayac );
            qsArgs.bosDegilseAtPut( "raporSecimler", RaporSecimler );
        }
        protected override void afterResponse( CRRMCallArgs args, ref CRRMResponse pResponse ) {
            base.afterResponse( args, ref pResponse );
            var response = pResponse as CRRM_FRRaporOlusturResponse;
            var reportKey = response == null ? null : response.ReportKey;
            if (reportKey.bosDegilmi()) {
                #region block
                var newRequest = new CRRM_FRRaporGetStreamRequest().aktar( this );
                newRequest.Content = null;
                newRequest.ReportKey = reportKey;
                newRequest.skipXMLAutoLoad();
                pResponse = newRequest.wsCall( args.WSComm ) as CRRM_FRRaporOlusturResponse;
                #endregion
            }
        }
        #endregion
    }
}
