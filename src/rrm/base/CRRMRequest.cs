using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Net.Sockets;

namespace CVioWebServis {
    public class CRRMRequest : CRRMParseable {
        public const string
            HttpContentType_Plain = "text/plain", HttpContentType_Form = "application/x-www-form-urlencoded",
            HttpContentType_Binary = "application/octet-stream", HttpContentType_XML = "text/xml";

        #region Accessors
        public string APIAuthKey { get; set; }
        public string SessionID { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string RedirectWSHost { get; set; }
        [DefaultValue(0)]
        public int RedirectWSPort { get; set; }
        public string RedirectWSClass { get; set; }
        
        public virtual string DefaultWSIslem { get { return null; } }
        public virtual CIOType? DefaultInputType { get { return null; } }
        public virtual CIOType? DefaultOutputType { get { return null; } }
        public virtual Type ResponseClass { get { return typeof( CRRMResponse ); } }
        public virtual CHttpMethod? HttpMethod { get { return null; } }
        public virtual string HttpContentType { get { return null; } }
        public virtual bool SessionMatchFlag { get { return SessionID.bosmu() && User.bosDegilmi(); } }
        public virtual bool IsVioWebRequest { get { return false; } }
        #endregion

        #region WS Iletisim
        public virtual void updateRequestArgs( CRRMCallArgs args ) {
            if (IsVioWebRequest) {
                args.OutputType = CIOType.xml;
                if (RedirectWSClass.bosmu()) RedirectWSClass = CRRMCallArgs.WSPath_VioWeb;
                if (APIAuthKey.bosmu()) APIAuthKey = CRRMCallArgs.WSAPIKey_VioWeb;
            }

            IDictionary<string, object> qsArgs;
            if (( qsArgs = args.QSArgs ) == null) args.QSArgs = qsArgs = new CDict<string, object>();
            if (args.Islem.bosmu() && DefaultWSIslem.bosDegilmi()) args.Islem = DefaultWSIslem;
            if (!args.InputType.HasValue && DefaultInputType.HasValue) args.InputType = DefaultInputType;
            if (!args.OutputType.HasValue && DefaultOutputType.HasValue) args.OutputType = DefaultOutputType;
            if (SessionID.bosDegilmi()) qsArgs.atPut( "sessionID", SessionID );
            if (User.bosDegilmi()) qsArgs.atIfAbsentPut( "user", () => User );
            if (Pass.bosDegilmi()) qsArgs.atIfAbsentPut( "pass", () => Pass );
            if (SessionMatchFlag) qsArgs.atPut( "sessionMatch", SessionMatchFlag );
            if (APIAuthKey.bosDegilmi()) qsArgs.atPut( "apiAuthKey", APIAuthKey );
        }
        public virtual void preUpdateRequest( CRRMCallArgs args ) { }
        public virtual void updateRequest( CRRMCallArgs args ) {
            if (( HttpMethod ?? args.HttpMethod ) != CHttpMethod.Get && (HttpContentType ?? args.HttpContentType) == CRRMRequest.HttpContentType_Form && args.PostData.bosmu())
                args.PostData = args.FinalQueryString;
        }

        public CRRMResponse wsCall(CWSComm wsComm) { return wsCall( wsComm, new CRRMCallArgs() ); }
        public CRRMResponse wsCall(CWSComm wsComm, CRRMCallArgs args) { return wsCallWithErrorHandler( args, () => wsCallInternal( wsComm, args ) ); }
        protected virtual CRRMResponse wsCallInternal( CWSComm wsComm, CRRMCallArgs args ) { return null; }
        public virtual CRRMResponse getResponse( CRRMCallArgs args ) {
            var response = createResponse( args );
            if (response != null) { updateResponse( args, ref response ); response.parseResponse( args ); }
            response.afterResponse( args ); afterResponse( args, ref response ); return response;
        }
        protected CRRMResponse createResponse( CRRMCallArgs args ) {
            var cls = ResponseClass; if (cls == null) return null;
            args.RRMResponse = (CRRMResponse)Activator.CreateInstance(cls); return args.RRMResponse;
        }
        protected virtual void updateResponse( CRRMCallArgs args, ref CRRMResponse pResponse ) { }
        protected virtual void afterResponse( CRRMCallArgs args, ref CRRMResponse pResponse ) { }
        #endregion
        #region Error Handler
        protected CRRMResponse wsCallWithErrorHandler( CRRMCallArgs args, CRRMWSCallProc islemBlock ) {
            try { args.RRMRequest = this; return islemBlock(); }
            catch (WebException ex) {
                CRRMResponse orjResponse; CRRMErrorResponse errorResponse;
                var resp = ex.Response as HttpWebResponse;
                if (( orjResponse = args.RRMResponse ) == null) {
                    if ((orjResponse = createResponse(args)) != null) updateResponse(args, ref orjResponse);
                }
                if (orjResponse != null) {
                    if (( errorResponse = CRRMResponse.getErrorResponse(resp) ) != null) { orjResponse.ErrorObject = errorResponse; return orjResponse; }
                    if (( errorResponse = CRRMResponse.getErrorResponse(ex) ) != null) { orjResponse.ErrorObject = errorResponse; return orjResponse; }
                }
                throw ex;
            }
        }
        #endregion
    }
}
