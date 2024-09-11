using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMCallArgs : EventArgs {
        public const string WSPath_VioWeb = "ws/ticari/vioweb";
        public const string WSAPIKey_VioWeb = "vioWeb";

        #region Accessors
        public CWSComm WSComm { get; set; }
        public CHttpMethod HttpMethod { get; set; }
        public HttpWebRequest Req { get; set; }
        public HttpWebResponse Resp { get; set; }
        public Stream RespSrm { get; set; }
        public string Islem { get; set; }
        public string HttpContentType { get; set; }
        public object PostData { get; set; }
        //public StreamWriter PostDataWriter { get; set; }
        public IDictionary<string, object> QSArgs { get; set; }
        public string FinalQueryString {
            get {
                var sb = new StringBuilder();
                // sb.AppendFormat( "islem={0}", Islem );
                if (OutputType.HasValue) {
                    if (sb.Length != 0)
                        sb.Append( '&' );
                    sb.AppendFormat( "output={0}", OutputType.ToString() );
                }
                if (InputType.HasValue) {
                    if (sb.Length != 0)
                        sb.Append( '&' );
                    sb.AppendFormat( "input={0}", InputType.ToString() );
                }
                if (QSArgs.bosDegilmi()) {
                    foreach (var kv in QSArgs) {
                        if (sb.Length != 0)
                            sb.Append( '&' );
                        sb.AppendFormat( "{0}={1}", kv.Key, kv.Value.asString() );
                    }
                }
                //args.FinalQueryString = sb.ToString();
                return sb.ToString();
            }
        }
        public CIOType? InputType { get; set; }
        public CIOType? OutputType { get; set; }
        public object UserData { get; set; }
        public CRRMRequest RRMRequest { get; set; }
        public CRRMResponse RRMResponse { get; set; }
        //public bool SkipXMLAutoLoadFlag { get; set; }
        #endregion


        #region Setter
        /*public void setCTForm() {
            ContentType = CRRMRequest.HttpContentType_Form;
        }

        public void setPlain() {
            ContentType = CRRMRequest.HttpContentType_Plain;
        }

        public void setCTXML() {
            ContentType = CRRMRequest.HttpContentType_XML;
        }

        public void setCTBinary() {
            ContentType = CRRMRequest.HttpContentType_Binary;
        }*/

        /*public void qsArgsToPostData() {
            if (FinalQueryString.bosDegilmi())
                PostData = FinalQueryString;
            FinalQueryString = null;
            ContentType = CRRMRequest.HttpContentType_Form;
        }*/
        #endregion

        #region Not Categorized
        public CRRMCallArgs()
                : base() {
        }

        public CRRMCallArgs( string islem = null, IDictionary<string, object> qsArgs = null, object userData = null )
                : this() {
            if (islem != null)
                this.Islem = islem;
            if (qsArgs != null)
                this.QSArgs = qsArgs;
            if (userData != null)
                this.UserData = userData;
            //this.SkipXMLAutoLoadFlag = false;
        }
        #endregion
                
    }
}
