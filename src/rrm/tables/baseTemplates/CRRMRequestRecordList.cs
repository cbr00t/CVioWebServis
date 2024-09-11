using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Collections;

namespace CVioWebServis {
    [Serializable()]
    [XmlRoot( RootNodeName )]
    public class CRRMRequestRecordList<T> : CRRMRecordBase where T : CRRMRequestRecord {
        public const string
            RootNodeName = "Records",
            ItemNodeName = "Record";

        #region Accessors
        [XmlElement( "Record" )]
        public T[] Records { get; set; }
        #endregion


        #region Not Categorized
        public CRRMRequestRecordList( T[] records ) {
            Records = ( records == null ? new T[0] : records );
        }

        public CRRMRequestRecordList()
            : this( null ) {
        }
        #endregion
    }
}
