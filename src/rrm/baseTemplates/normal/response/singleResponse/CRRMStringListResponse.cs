using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMStringListResponse : CRRMListResponse<string> {
        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            CIOType? outputType;

            outputType = args.OutputType;
            if (outputType.HasValue) {
                switch (outputType.Value) {
                    case CIOType.csv:
                    case CIOType.tab:
                    case CIOType.tcsv:
                    case CIOType.ttab:
                        StreamReader sr;
                        char[] delims;
                        List<string> result;

                        delims = new char[] { ( outputType.Value == CIOType.tab ? '\t' : ';' ) };
                        sr = new StreamReader( args.RespSrm, CGlobals.DefaultEncoding );
                        sr.ReadLine();
                        if (outputType.Value == CIOType.tcsv || outputType.Value == CIOType.ttab)
                            sr.ReadLine();

                        Value = new List<string>();
                        while (!sr.EndOfStream)
                            Value.Add( sr.ReadLine().Split( delims, 1 )[0].Trim( '"' ).TrimEnd() );
                        if (Value[Value.Count - 1].bosmu())
                            Value.RemoveAt( Value.Count - 1 );
                        return;
                }
            }

            if (!outputType.HasValue || outputType.Value == CIOType.xml) {
                XmlReader xr;
                //XmlDocument xroot;

                //xroot = new XmlDocument();
                //xroot.Load( args.Srm );
                //// [Response] > Result > ...

                if (( xr = args.UserData as XmlReader ) != null) {
                    //// [Response]
                    //xr.ReadToDescendant( CRRMSingleMasterResponse.ParentRootNodeName );
                    // Response > [Result]
                    xr.ReadToDescendant( CRRMSingleMasterResponse.RootNodeName );

                    Value = new List<string>();
                    while (xr.Read()) {
                        if (xr.NodeType == XmlNodeType.Text) {
                            StreamReader sr;

                            sr = new StreamReader( args.RespSrm, CGlobals.DefaultEncoding );
                            while (!sr.EndOfStream)
                                Value.Add( sr.ReadLine().TrimEnd() );
                        }
                    }
                    if (Value[Value.Count - 1].bosmu())
                        Value.RemoveAt( Value.Count - 1 );
                }
                return;
            }
        }
        #endregion
    }
}
