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
    public class CRRMSingleResponse<T> : CRRMResponse {
        #region Accessors
        public T Value { get; set; }
        #endregion

        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            CIOType? outputType;

            outputType = args.OutputType;
            if (outputType.HasValue) {
                #region block
                switch (outputType.Value) {
                    #region block
                    case CIOType.csv:
                    case CIOType.tab:
                    case CIOType.tcsv:
                    case CIOType.ttab:
                        #region block
                        StreamReader sr;
                        char[] delims;

                        delims = new char[] { ( outputType.Value == CIOType.tab ? '\t' : ';' ) };
                        sr = new StreamReader( args.RespSrm, CGlobals.DefaultEncoding );
                        sr.ReadLine();
                        if (outputType.Value == CIOType.tcsv || outputType.Value == CIOType.ttab)
                            sr.ReadLine();
                        setValue( sr.ReadLine().Split( delims, 1 )[0].Trim( '"' ).TrimEnd() );
                        return;
                        #endregion
                    #endregion
                }
                #endregion
            }

            if (!outputType.HasValue || outputType.Value == CIOType.xml) {
                #region block
                XmlReader xr;
                /*XmlDocument xroot;

                xroot = new XmlDocument();
                xroot.Load( args.Srm );
                    // [Response] > Result > ...
                setValue( xroot.DocumentElement.FirstChild.FirstChild.InnerText );*/
                //// [Response] > Result > ...

                if (( xr = args.UserData as XmlReader ) != null) {
                    #region block
                    //// [Response]
                    //xr.ReadToDescendant( CRRMSingleMasterResponse.ParentRootNodeName );
                    // Response > [Result]
                    xr.ReadToDescendant( CRRMSingleMasterResponse.RootNodeName );
                    while (xr.Read()) {
                        #region block
                        if (xr.NodeType == XmlNodeType.Text) {
                            #region block
                            setValue( xr.Value.TrimEnd() );
                            return;
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                return;
                #endregion
            }
        }
        #endregion

        #region Setter
        protected virtual void setValue( string value ) {
        }
        #endregion
    }
}
