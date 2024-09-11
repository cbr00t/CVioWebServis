using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.IO.Compression;

namespace CVioWebServis {
    #region Delegates
    public delegate void HttpRequestProc( HttpWebRequest req, Stream srm );
    public delegate bool HttpPreRequestProc( HttpWebRequest req, Stream srm );
    public delegate void HttpWithXMLWriterPostRequestProc( HttpWebRequest req, XmlWriter xw, Stream srm );
    public delegate XmlDocument HttpWithXMLDocumentGetRequestXMLDocumentProc( HttpWebRequest req, Stream srm );
    public delegate void HttpWithXMLDocumentPostRequestProc( HttpWebRequest req, Stream srm );
    public delegate void HttpResponseProc( HttpWebResponse resp, Stream srm, HttpWebRequest req );
    public delegate bool HttpPreResponseProc( HttpWebResponse resp, Stream srm, HttpWebRequest req );
    public delegate void HttpWithXMLReaderPostResponseProc( HttpWebResponse resp, XmlReader xr, Stream srm, HttpWebRequest req );
    public delegate void HttpWithXMLDocumentPostResponseProc( HttpWebResponse resp, XmlDocument xdoc, Stream srm, HttpWebRequest req );
    public delegate void HttpWithDTPostResponseProc( HttpWebResponse resp, DataTable dt, Stream srm, HttpWebRequest req );
    public delegate void HttpWithDSPostResponseProc( HttpWebResponse resp, DataSet ds, Stream srm, HttpWebRequest req );
    #endregion

    public class CWSComm {
        public const string DefaultName_DataSet = "DataSet", DefaultName_TableName = "Data";
        protected string wsUrl;
        public string WSHostName { get; set; }
        public int WSPort { get; set; }
        public string WSUrlPrefix { get; set; }
        public string WSUrl { get { if (wsUrl == null) wsUrl = getModifiedWSUrl( WSHostName, WSPort, null ); return wsUrl; } }

		public CWSComm() { WSHostName = "localhost"; WSPort = 8081; WSUrlPrefix = "/ws/ticari"; }
        #region Web Call Methods
        protected HttpWebRequest createWebRequest( CRRMCallArgs args ) {
            args.WSComm = this; var request = args.RRMRequest;
            if (request != null) { request.updateRequestArgs( args ); request.preUpdateRequest( args ); }
            var newURL = ( request == null /* || ( request.RedirectWSHost.bosmu() && request.RedirectWSPort <= 0 && request.RedirectWSClass.bosmu() ) */ )
                    ? WSUrl
                    : getModifiedWSUrl( request.RedirectWSHost, request.RedirectWSPort, request.RedirectWSClass, args.Islem.emptyCoalesce(() => request.DefaultWSIslem ) );
            var sbQueryString = new StringBuilder( newURL ); if (!newURL.EndsWith( "/" )) sbQueryString.Append( '/' );
            var finalQueryString = args.FinalQueryString;
            if (( request.HttpContentType ?? args.HttpContentType ) != CRRMRequest.HttpContentType_Form && finalQueryString.bosDegilmi()) {
                if (finalQueryString[0] != '?') sbQueryString.Append( '?' ); /* if (finalQueryString[0] != '/') sbQueryString.Append( '/' ); */
                sbQueryString.Append(finalQueryString);
            }
            var req = args.Req = (HttpWebRequest)WebRequest.Create( sbQueryString.ToString() );
            try { req.Proxy = WebRequest.GetSystemWebProxy() ?? WebRequest.DefaultWebProxy; } catch (Exception) { }
            req.AutomaticDecompression = DecompressionMethods.GZip;
            req.ContentType = (request.HttpContentType.emptyCoalesce(() => args.HttpContentType)).emptyCoalesce(() => CRRMRequest.HttpContentType_XML);
            req.CookieContainer = new CookieContainer(); /* req.TransferEncoding = Encoding.UTF8.WebName; */
            req.Timeout = req.ReadWriteTimeout = ( Debugger.IsAttached ? Timeout.Infinite : Convert.ToInt32( TimeSpan.FromMinutes( 15 ).TotalMilliseconds ) );
            req.AllowAutoRedirect = req.KeepAlive = true; try { req.AllowWriteStreamBuffering = false; } catch (Exception) { }
            return req;
        }
        public void sendWebRequest( CRRMCallArgs args, HttpRequestProc requestBlock = null, HttpResponseProc responseBlock = null ) {
            var request = args.RRMRequest; var req = createWebRequest( args );
            if (request != null) request.updateRequest( args );
            var hasPostData = args.PostData.bosDegilmi(); var hasRequestBlock = ( requestBlock != null );
            switch (request.HttpMethod ?? args.HttpMethod) {
                case CHttpMethod.Get: req.Method = WebRequestMethods.Http.Get; break;
                case CHttpMethod.Post: req.Method = WebRequestMethods.Http.Post; break;
                case CHttpMethod.Auto: req.Method = ( hasPostData || hasRequestBlock ) ? WebRequestMethods.Http.Post : WebRequestMethods.Http.Get; break;
            }
            if (hasPostData || hasRequestBlock) {
                if (hasPostData) {
                    // if (hasRequestBlock) req.SendChunked = true;
                    var postData = args.PostData; byte[] buffer = null;
                    if (postData is MemoryStream) buffer = ( (MemoryStream)postData ).ToArray();
                    else if (postData is byte[]) buffer = (byte[])postData;
                    using (var mSrm = new MemoryStream( 512 * 1024 )) {
                        if (buffer != null)
                            mSrm.Write(buffer, 0, buffer.Length);
                        else {
                            if (postData is StringBuilder) postData = ((StringBuilder)postData).ToString();
                            else if (postData is TextReader) postData = ((TextReader)postData).ReadToEnd();
                            else if (postData is StringWriter) postData = ((StringWriter)postData).ToString();
                            if (postData != null)
                                using (var sw = new StreamWriter(mSrm, CGlobals.DefaultEncoding ) { AutoFlush = true }) sw.Write( postData );
                        }
                        if (hasRequestBlock) requestBlock( req, mSrm );
                        if (mSrm.Length != 0) {
                            mSrm.Position = 0; req.ContentLength = mSrm.Length;
                            using (var wSrm = req.GetRequestStream()) mSrm.CopyTo(wSrm, 512 * 1024);
                        }
                    }
                }
            }
            try {
                HttpWebResponse resp = null;
                try { resp = (HttpWebResponse)req.GetResponse(); }
                catch (ProtocolViolationException) { if (req.SendChunked) throw; req.SendChunked = false; resp = (HttpWebResponse)req.GetResponse(); }
                using (resp)
                using (var srm = resp.GetResponseStream()) { args.RespSrm = srm; if (responseBlock != null) responseBlock(resp, srm, req); }
            }
            finally { args.RespSrm = null; }
        }
        public void sendWebRequestWithXMLReader(CRRMCallArgs args,
                HttpPreRequestProc preRequestBlock = null,
                HttpWithXMLWriterPostRequestProc postRequestBlock = null,
                HttpPreResponseProc preResponseBlock = null,
                HttpWithXMLReaderPostResponseProc postResponseBlock = null) {
            HttpRequestProc internalRequestBlock = null; HttpResponseProc internalResponseBlock = null;
            if (!(preRequestBlock == null && postRequestBlock == null))
                internalRequestBlock = (req, srm) => sendWebRequestWithXMLReader_requestProc(req, srm, preRequestBlock, postRequestBlock);
            internalResponseBlock = ( resp, srm, req ) => sendWebRequestWithXMLReader_responseProc( resp, srm, req, preResponseBlock, postResponseBlock );
            sendWebRequest(args, internalRequestBlock, internalResponseBlock);
        }
        public XmlDocument sendWebRequestWithXMLDocument( CRRMCallArgs args,
                HttpPreRequestProc preRequestBlock = null , HttpWithXMLDocumentGetRequestXMLDocumentProc getRequestXMLDocumentBlock = null,
                HttpWithXMLDocumentPostRequestProc postRequestBlock = null , HttpPreResponseProc preResponseBlock = null , HttpWithXMLDocumentPostResponseProc postResponseBlock = null ) {
            XmlDocument result = null;
            HttpWithXMLWriterPostRequestProc internalPostRequestBlock = null;
            HttpWithXMLReaderPostResponseProc internalPostResponseBlock = (resp, xr, srm, req) => result = sendWebRequestWithXMLDocument_responseProc(resp, xr, srm, req, postResponseBlock);
			if (!(getRequestXMLDocumentBlock == null && postRequestBlock == null))
                internalPostRequestBlock = (req, xw, srm) => sendWebRequestWithXMLDocument_requestProc(req, xw, srm, getRequestXMLDocumentBlock, postRequestBlock);
            sendWebRequestWithXMLReader(args, preRequestBlock, internalPostRequestBlock, preResponseBlock, internalPostResponseBlock);
            return result;
        }
        public DataTable sendWebRequestAndGetDataTable(CRRMCallArgs args,
                HttpPreRequestProc preRequestBlock = null,
                HttpWithXMLWriterPostRequestProc postRequestBlock = null,
                HttpPreResponseProc preResponseBlock = null,
                HttpWithDTPostResponseProc postResponseBlock = null) {
            DataTable result = null;
            HttpWithXMLReaderPostResponseProc internalPostResponseBlock = (resp, xr, srm, req) => result = sendWebRequestAndGetDataTable_responseProc(resp, xr, srm, req, postResponseBlock);
			sendWebRequestWithXMLReader(args, preRequestBlock, postRequestBlock, preResponseBlock, internalPostResponseBlock);
			return result;
		}
        public DataSet sendWebRequestAndGetDataSet(CRRMCallArgs args,
				HttpPreRequestProc preRequestBlock = null,
				HttpWithXMLWriterPostRequestProc postRequestBlock = null,
				HttpPreResponseProc preResponseBlock = null,
				HttpWithDSPostResponseProc postResponseBlock = null) {
            DataSet result = null;
			HttpWithXMLReaderPostResponseProc internalPostResponseBlock = (resp, xr, srm, req) => result = sendWebRequestAndGetDataSet_responseProc(resp, xr, srm, req, postResponseBlock);
			sendWebRequestWithXMLReader(args, preRequestBlock, postRequestBlock, preResponseBlock, internalPostResponseBlock);
			return result;
		}

        #endregion
        #region Web Call Methods: Eventler
        internal void sendWebRequestWithXMLReader_requestProc( HttpWebRequest req, Stream aStream
                                                                    , HttpPreRequestProc preRequestBlock = null
                                                                    , HttpWithXMLWriterPostRequestProc postRequestBlock = null ) {
            XmlWriter xw;

            if (preRequestBlock != null && !preRequestBlock( req, aStream ))
                return;

            if (postRequestBlock == null)
                return;

            xw = XmlWriter.Create( aStream, new XmlWriterSettings() { Indent = true, IndentChars = "   ", NewLineHandling = NewLineHandling.None, OmitXmlDeclaration = false } );
            try {
                postRequestBlock( req, xw, aStream );
            }
            finally {
                xw.Close();
            }
        }

        internal void sendWebRequestWithXMLReader_responseProc( HttpWebResponse resp, Stream aStream, HttpWebRequest req
                                                                    , HttpPreResponseProc preResponseBlock = null
                                                                    , HttpWithXMLReaderPostResponseProc postResponseBlock = null ) {
            XmlReader xr;

            if (preResponseBlock != null && !preResponseBlock( resp, aStream, req ))
                return;
            
            xr = (XmlReader)XmlReader.Create( aStream
                        , new XmlReaderSettings() {
                            ValidationFlags = XmlSchemaValidationFlags.None
                            , ValidationType = ValidationType.None
                        } );
            try {
                if (postResponseBlock != null)
                    postResponseBlock( resp, xr, aStream, req );
            }
            finally {
                xr.Close();
            }
        }

        internal void sendWebRequestWithXMLDocument_requestProc( HttpWebRequest req, XmlWriter xw, Stream aStream
                                                                    , HttpWithXMLDocumentGetRequestXMLDocumentProc getRequestXMLDocumentBlock = null
                                                                    , HttpWithXMLDocumentPostRequestProc postRequestBlock = null ) {
            XmlDocument xdoc = null;

            if (getRequestXMLDocumentBlock != null)
                xdoc = getRequestXMLDocumentBlock( req, aStream );

            if (xdoc != null)
                xdoc.WriteTo( xw );

            if (postRequestBlock != null)
                postRequestBlock( req, aStream );
        }

        internal XmlDocument sendWebRequestWithXMLDocument_responseProc( HttpWebResponse resp, XmlReader xr, Stream aStream, HttpWebRequest req
                                                                            , HttpWithXMLDocumentPostResponseProc postResponseBlock = null ) {
            XmlDocument result;

            result = new XmlDocument();
            result.Load( xr );
            
            if (postResponseBlock != null)
                postResponseBlock( resp, result, aStream, req );

            return result;
        }

        internal DataTable sendWebRequestAndGetDataTable_responseProc( HttpWebResponse resp, XmlReader xr, Stream aStream, HttpWebRequest req
                                                                            , HttpWithDTPostResponseProc postResponseBlock = null ) {
            DataTable result = null;

            result = sendWebRequestAndGetDataTable_responseProc_devam( resp, xr, aStream, req );
            if (postResponseBlock != null)
                postResponseBlock( resp, result, aStream, req );

            return result;
        }

        internal DataTable sendWebRequestAndGetDataTable_responseProc_devam( HttpWebResponse resp, XmlReader xr, Stream srm, HttpWebRequest req ) {
            DataTable dt;

            while (!xr.EOF && xr.Read() && !( xr.NodeType == XmlNodeType.Element && xr.Name == DefaultName_DataSet ))
                ;
            
            if (xr.EOF)
                return null;

            dt = new DataTable( DefaultName_TableName );
            dt.ReadXml( xr );

            //try {
            //    dt.ReadXml( xr );
            //}
            //catch (Exception ex) {
            //    ( dt = new DataTable() )
            //        .ReadXml( xr );
            //}

            return dt;
        }

        internal DataSet sendWebRequestAndGetDataSet_responseProc( HttpWebResponse resp, XmlReader xr, Stream aStream, HttpWebRequest req
                                                                            , HttpWithDSPostResponseProc postResponseBlock = null ) {
            DataSet result = null;

            result = sendWebRequestAndGetDataSet_responseProc_devam( resp, xr, aStream, req );
            if (postResponseBlock != null)
                postResponseBlock( resp, result, aStream, req );

            return result;
        }

        internal DataSet sendWebRequestAndGetDataSet_responseProc_devam( HttpWebResponse resp, XmlReader xr, Stream srm, HttpWebRequest req ) {
            DataSet ds;
            int lastTableCount = 0;

            while (!xr.EOF && xr.Read() && !( xr.NodeType == XmlNodeType.Element && xr.Name == DefaultName_DataSet ))
                ;

            if (xr.EOF)
                return null;

            ds = new DataSet();
            while (!xr.EOF) {
                ds.ReadXml( xr );
                if (ds.Tables.Count == lastTableCount)
                    break;

                lastTableCount = ds.Tables.Count;
            }

            if (ds.DataSetName.bosDegilmi())
                ds.DataSetName = DefaultName_DataSet;

            return ds;
        }
		#endregion
		#region Tools
		public string getWSUrlPrefix(string hostName, int port) { return string.Format("http://{0}:{1}/", hostName.bosmu() ? WSHostName : hostName, port > 0 ? port : WSPort); }
		public string getWSUrl(string hostName, int port, string postfix = null, string wsIslem = null) {
			var sb = new StringBuilder(getWSUrlPrefix(hostName, port));
			if (postfix.bosDegilmi()) sb.AppendFormat(postfix.TrimStart('/'));
			if (wsIslem.bosDegilmi()) sb.AppendFormat("/{0}", wsIslem);
			return sb.ToString();
		}
		public string getModifiedWSUrl(string hostName, int port, string postfix = null, string wsIslem = null) {
			return getWSUrl(hostName, port, (postfix.bosmu() ? WSUrlPrefix : postfix), wsIslem);
		}
		#endregion
	}
}
