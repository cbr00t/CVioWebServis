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
    public class CRRMBinaryRequest : CRRMXmlRequest {
        #region Accessors
        [XmlIgnore()]
        protected bool? PassContentToQueryStringFlag { get; set; }

        public byte[] Content { get; set; }
        #endregion


        #region Getter
        public override CHttpMethod? HttpMethod {
            get {
                if (Content.bosDegilmi())
                    return CHttpMethod.Post;

                return base.HttpMethod;
            }
        }

        public override string HttpContentType {
            get {
                if (Content.bosDegilmi() && _PassContentToQueryStringFlag)
                    return HttpContentType_Form;

                return HttpContentType_Binary;
            }
        }

        public virtual bool DefaultPassContentToQueryStringFlag {
            get { return false; }
        }

        protected bool _PassContentToQueryStringFlag {
            get {
                return PassContentToQueryStringFlag.HasValue
                            ? PassContentToQueryStringFlag.Value
                            : DefaultPassContentToQueryStringFlag;
            }
        }

        public override Type ResponseClass {
            get { return typeof( CRRMBinaryResponse ); }
        }

        protected virtual string WSContentAttr {
            get { return "content"; }
        }
        #endregion

        #region Accessors: Ozel
        [XmlIgnore()]
        public string Base64Data {
            get {
                if (Content == null)
                    return null;
                else if (Content.bosmu())
                    return "";
                else
                    return Convert.ToBase64String( Content, Base64FormattingOptions.None );
            }
            set {
                if (value == null)
                    Content = null;
                else if (value.bosmu())
                    Content = new byte[0];
                else
                    Content = Convert.FromBase64String( value );
            }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            if (Content.bosDegilmi() && _PassContentToQueryStringFlag)
                qsArgs.atPut( WSContentAttr, Base64Data );
        }
        public override void preUpdateRequest( CRRMCallArgs args ) {
            base.preUpdateRequest( args );

            /*if (Content.bosDegilmi() && _PassContentToQueryStringFlag)
                args.qsArgsToPostData();*/
        }
        public override void updateRequest( CRRMCallArgs args ) {
            //StreamWriter sw;

            base.updateRequest( args );

            if (Content.bosDegilmi() && !_PassContentToQueryStringFlag) {
                /*if (( sw = args.PostDataWriter ) != null) {
                    sw.Flush();
                    sw.Dispose();
                    args.PostDataWriter = sw = null;
                }*/

                //args.RespSrm.Write( Content, 0, Content.Length );
                args.PostData = Content;
            }
        }
        #endregion

        #region Not Categorized
        public CRRMBinaryRequest()
                : base() {
        }

        public CRRMBinaryRequest( byte[] content )
                : base() {
            this.Content = content;
        }

        public CRRMBinaryRequest( string base64Data )
                : base() {
            this.Base64Data = base64Data;
        }
        #endregion
    }
}
