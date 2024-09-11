using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Net.Sockets;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMResponse : CRRMResponseBase {
        #region Accessors
        public CRRMErrorResponse ErrorObject { get; set; }
        #endregion


        #region Uygunluk
        public bool HasError {
            get { return _HasError; }
            set { }
        }

        [SoapIgnore()]
        public virtual bool _HasError {
            get { return ErrorObject != null; }
        }
        #endregion

        #region Error Handler
        internal static CRRMErrorResponse getErrorResponse( HttpWebResponse resp ) {
            string text;

            if (resp == null || (int)resp.StatusCode < 400 || ( text = resp.StatusDescription ).bosmu() )
                return null;

            return getErrorResponse( text );
            
        }

        internal static CRRMErrorResponse getErrorResponse( string text ) {
            return getErrorResponse( text.Split( new char[] { '|' }, 5 ) );
        }

        internal static CRRMErrorResponse getErrorResponse( params string[] parts ) {
            return getErrorResponse(
                code: parts[0]
                , subCode: parts.Length > 1 ? parts[1] : null
                , extraArg: parts.Length > 2 ? parts[2] : null
                , message: parts.Length > 3 ? parts[3] : null
                , categoryStr: parts.Length > 4 ? parts[4] : null
                );
        }

        internal static CRRMErrorResponse getErrorResponse( string categoryStr = null, string code = null, string subCode = null, string message = null, string extraArg = null ) {
            return new CRRMErrorResponse() {
                Code = code ?? string.Empty
                , SubCode = subCode ?? string.Empty
                , ExtraArg = extraArg ??  string.Empty
                , Message = message ?? string.Empty
                , _Category = categoryStr ?? string.Empty
            };
        }

        internal static CRRMErrorResponse getErrorResponse( CRRMErrorCategory category, string code, string subCode = null, string message = null, string extraArg = null ) {
            CRRMErrorResponse resp;

            resp = getErrorResponse( categoryStr: null, code: code, subCode: subCode, message: message, extraArg: extraArg );
            if (resp != null)
                resp.Category = category;

            return resp;
        }

        internal static CRRMErrorResponse getErrorResponse( WebException ex ) {
            SocketException socketException;

            if (ex == null)
                return null;

            socketException = ex.InnerException as SocketException;

            return new CRRMErrorResponse() {
                Code = ex.Status.ToString()
                , SubCode = ( socketException == null ? string.Empty : socketException.SocketErrorCode.ToString() )
                , ExtraArg = ( socketException == null ? string.Empty : socketException.Message )
                , Message = ex.Message
                , Category = CRRMErrorCategory.Programci
            };
        }
        #endregion

        #region Not Categorized
        public CRRMResponse() : base() {
        }
        #endregion
                
    }
}
