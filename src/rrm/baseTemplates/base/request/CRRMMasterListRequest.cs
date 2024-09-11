using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    public class CRRMMasterListRequest<TRequestRecord, TResponseRecord> : CRRMMasterRequestNonFilterable<TResponseRecord>
                        where TRequestRecord : CRRMRequestRecord
                        where TResponseRecord : CRRMResponseRecord {
        [XmlArray( CRRMRequestRecordList<TRequestRecord>.RootNodeName ), XmlArrayItem( CRRMRequestRecordList<TRequestRecord>.ItemNodeName )]
        public virtual TRequestRecord[] Records { get; set; }

        #region WS Iletisim
        public override void updateRequest( CRRMCallArgs args ) {
            base.updateRequest( args );
			var srm = new MemoryStream(); args.PostData = srm;
            var xw = new XmlTextWriter( srm, CGlobals.DefaultEncoding ); var recordList = new CRRMRequestRecordList<TRequestRecord>( Records );
            var serializer = new XmlSerializer( typeof( CRRMRequestRecordList<TRequestRecord> ) ); serializer.Serialize( xw, recordList );
            /* args.RespSrm.Write( Content, 0, Content.Length ); */
        }
        #endregion
    }
}
