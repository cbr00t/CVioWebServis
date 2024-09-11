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
    [Serializable()]
    public class CRRMDownloadResponse : CRRMBinaryResponse {
        #region Accessors
        [XmlElement( "downloadID" )]
        public string DownloadID { get; set; }
        [XmlElement( "contentType" )]
        public string ContentType { get; set; }
        [XmlElement( "dosyaAdi" )]
        public string DosyaAdi { get; set; }
        [XmlElement( "dosyaExt" )]
        public string DosyaExt { get; set; }
        #endregion

        public CRRMDownloadResponse()
            : base() {
            init();
        }
        public CRRMDownloadResponse( byte[] content )
            : base( content ) {
            init();
        }
        public CRRMDownloadResponse( string base64Data )
            : base( base64Data ) {
            init();
        }

        protected void init() {
        }

        #region Getter
        public virtual CRRMDownloadRequest newRequest( CRRMDownloadRequest request ) {
            //newRequest = (CRRMDownloadRequest)Activator.CreateInstance( ( requestClass ?? typeof( CRRMRequest ) ) );
            var newRequest = (CRRMDownloadRequest)request.Clone();
            newRequest.DosyaAdi = newRequest.DosyaExt = null;
            newRequest.Content = null;
            newRequest.DownloadID = this.DownloadID;
            newRequest.skipXMLAutoLoad();
            return newRequest;
        }
        #endregion
    }
}
