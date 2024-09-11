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
    public class CRRMDownloadRequest : CRRMBinaryRequest {
        #region Accessors
        public string DownloadID { get; set; }
        public string ContentType { get; set; }
        public string DosyaAdi { get; set; }
        public string DosyaExt { get; set; }
        #endregion


        #region Getter
        public override Type ResponseClass {
            get { return typeof( CRRMDownloadResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void preUpdateRequest( CRRMCallArgs args ) {
            base.preUpdateRequest( args );

            //args.SkipXMLAutoLoadFlag = SkipXMLAutoLoadFlag;
        }

        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );
            qsArgs = args.QSArgs;
            if (DownloadID.bosDegilmi())
                qsArgs.atIfAbsentPut( "downloadID", () => DownloadID );
            if (ContentType.bosDegilmi())
                qsArgs.atIfAbsentPut( "contentType", () => ContentType );
            if (DosyaAdi.bosDegilmi())
                qsArgs.atIfAbsentPut( "dosyaAdi", () => DosyaAdi );
            if (DosyaExt.bosDegilmi())
                qsArgs.atIfAbsentPut( "dosyaExt", () => DosyaExt );
        }

        protected override void afterResponse( CRRMCallArgs args, ref CRRMResponse pResponse ) {
            base.afterResponse( args, ref pResponse );
            var response = pResponse as CRRMDownloadResponse;
            if (response != null && response.Content.bosmu() && response.DownloadID.bosDegilmi()) {
                #region block
                var newRequest = response.newRequest( this );
                pResponse = newRequest.wsCall( args.WSComm );
                #endregion
            }
        }
        #endregion

        #region Not Categorized
        public CRRMDownloadRequest()
                : base() {
            init();
        }

        public CRRMDownloadRequest( byte[] content )
                : base( content ) {
            init();
        }

        public CRRMDownloadRequest( string base64Data )
                : base( base64Data ) {
            init();
        }
        protected void init() {
        }
        #endregion
    }
}
