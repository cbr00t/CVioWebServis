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
    public class CRRMBinaryResponse : CRRMSingleMasterResponse {
        #region Accessors
        [XmlElement( "content" )]
        public byte[] Content { get; set; }

        protected virtual string WSContentAttr {
            get { return "content"; }
        }
        internal string Base64Data {
            set {
                if (value == null)
                    Content = null;
                else if (value.bosDegilmi())
                    Content = Convert.FromBase64String( value );
            }
        }
        #endregion

        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;
            Stream srm;

            base.parseResponse( args );

            if (Content == null && ( qsArgs = args.QSArgs ) != null)
                Base64Data = qsArgs.atIfAbsent( WSContentAttr ) as string;
            if (Content == null && ( srm = args.RespSrm ) != null && srm.CanRead) {
                #region block
                byte[] buffer, content = null;
                int offset = 0, bytes;

                buffer = new byte[500 * 1024];
                while (( bytes = srm.Read( buffer, 0, buffer.Length ) ) > 0) {
                    #region block
                    if (content == null)
                        content = new byte[buffer.Length];
                    if (content.Length < offset + bytes)
                        Array.Resize(ref content, ( offset + bytes ) * 2);
                    Buffer.BlockCopy( buffer, 0, content, offset, bytes );
                    offset += bytes;
                    #endregion
                }
                if (content != null && content.Length != offset)
                    Array.Resize( ref content, offset );

                Content = content;
                #endregion
            }
        }

        /*protected override void parseResponseInternal( CRRMCallArgs args, XmlNode xnode, string name, string value ) {
            base.parseResponseInternal( args, xnode, name, value );

            if (xnode.NodeType != XmlNodeType.Text)
                return;

            switch (name) {
                case "content":
                    Base64Data = value;
                    break;
            }
        }*/
        #endregion

        #region Not Categorized
        public CRRMBinaryResponse()
                : base() {
        }

        public CRRMBinaryResponse( byte[] content )
                : base() {
            this.Content = content;
        }

        public CRRMBinaryResponse( string base64Data )
                : base() {
            this.Base64Data = base64Data;
        }
        #endregion
    }
}
