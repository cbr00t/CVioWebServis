using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CXmlDict<TKey, TValue> : CRRMParseable {
        #region Get/Set
        [XmlIgnore()] protected COrdDict<TKey, TValue> Dict { get; set; }
        [XmlArray( ElementName = "Dict" ), XmlArrayItem( ElementName = "Entry" )]
        public CKV<TKey, TValue>[] SerializableDictionary {
            get {
                var result = new List<CKV<TKey, TValue>>();
                foreach (var kv in Dict) result.Add( new CKV<TKey, TValue>( kv ) );
                return result.ToArray();
            }
            set {
                Dict = new COrdDict<TKey, TValue>();
                if (value != null) { foreach (var kv in value) Dict.Add( kv.Key, kv.Value ); }
            }
        }
        #endregion
        #region Not Categorized
        public CXmlDict() { Dict = new COrdDict<TKey, TValue>(); }
        public CXmlDict(IDictionary<TKey, TValue> _dict) : this() { if (_dict != null) { foreach (var kv in _dict) Dict.Add( kv ); } }
        #endregion
    }
}