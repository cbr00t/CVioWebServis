using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMXmlResponse : CRRMBasicXmlResponse {
        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            CIOType? outputType;

            outputType = args.OutputType;
            if (!outputType.HasValue || outputType.Value == CIOType.xml) {
                XmlElement xresult;

                xresult = (XmlElement)args.UserData;
                foreach (XmlNode xnode in xresult.ChildNodes) {
                    if (xnode.NodeType != XmlNodeType.Text)
                        continue;

                    parseResponseInternal( args, xnode, xnode.Name, xnode.Value );
                }

                return;
            }
        }

        protected virtual void parseResponseInternal( CRRMCallArgs args, XmlNode xnode, string name, string value ) {
        }
        #endregion
    }
}
