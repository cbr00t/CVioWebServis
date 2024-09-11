using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CKV<TKey, TValue> : CRRMRecordBase {
        #region Get/Set
        [XmlElement( "Key" )]
        public TKey Key { get; set; }

        [XmlElement( "Value" )]
        public TValue Value { get; set; }
        #endregion


        #region Not Categorized
        public CKV() {
        }

        public CKV(TKey key, TValue value) : this() {
            this.Key = key;
            this.Value = value;
        }

        public CKV( KeyValuePair<TKey, TValue> kv )
            : this() {
            this.Key = kv.Key;
            this.Value = kv.Value;
        }
        #endregion
    }
}