using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Collections;

namespace CVioWebServis {
    [Serializable()]
    [XmlRoot( CRRMSingleMasterResponse.RootNodeName )]
    public class CRRMRecordList<T> where T : CRRMRecordBase {
        #region Accessors
        [XmlElement( CRRMSingleMasterResponse.DSRecordNodeName )]
        public T[] Records { get; set; }
        #endregion


        #region Not Categorized
        public CRRMRecordList( T[] records ) {
            Records = ( records == null ? new T[0] : records );
        }

        public CRRMRecordList()
            : this( null ) {
        }
        #endregion
    }
}
