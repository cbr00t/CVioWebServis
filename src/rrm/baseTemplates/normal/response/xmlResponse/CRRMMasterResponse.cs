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
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMMasterResponse<T> : CRRMBasicXmlResponse where T : CRRMRecordBase {
        public const string RecordNodeName = "Data";

        #region Accessors
        [XmlArrayItem( CRRMSingleMasterResponse.DSRecordNodeName )]
        public virtual T[] Records { get; set; }
        #endregion


        #region Getter
        public virtual string RootNodeName {
            get { return "DataSet"; }
        }
        #endregion

        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            CIOType? outputType;

            outputType = args.OutputType;
            if (!outputType.HasValue || outputType.Value == CIOType.xml)
                parseResponseInternal( args, (XmlReader)args.UserData );
            else {
                ErrorObject = CRRMResponse.getErrorResponse(
                    category: CRRMErrorCategory.Programci
                    , code: "hataliOutputType"
                    , subCode: "outputType"
                    , extraArg: ( outputType.HasValue ? outputType.Value.ToString() : "xml" )
                    , message: string.Format( "İstenen OutputType({0}) için MultiResult Table işlemi desteklenmiyor"
                                    , ( outputType.HasValue ? outputType.Value.ToString() : "xml" ) )
                    );
            }
        }

        protected virtual void parseResponseInternal( CRRMCallArgs args, XmlReader xr ) {
            XmlSerializer serializer;
            CRRMRecordList<T> recordList;

            xr.ReadToDescendant( RootNodeName );
            serializer = new XmlSerializer( typeof( CRRMRecordList<T> ), new XmlRootAttribute( RootNodeName ) );
            recordList = (CRRMRecordList<T>)serializer.Deserialize( xr );
            Records = recordList.Records;
        }
        #endregion

        
        #region Not Categorized
        public CRRMMasterResponse() : base() {
            this.Records = new T[0];
        }
        #endregion
                
    }
}
