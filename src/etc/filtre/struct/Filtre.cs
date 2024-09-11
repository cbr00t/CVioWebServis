using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVioWebServis {
    [Serializable()]
    public class Filtre {
        public delegate string KeyciProc( string postfix );

        public string Saha { get; set; }

		public Filtre(string saha) : this() { this.Saha = saha; }
		public Filtre() { }
        internal void addYourselfToEkArgs(IDictionary<string, object> aKeyedCollection) { addToEkArgs(string.Concat("filtre_", Saha), aKeyedCollection); }
        internal void addToEkArgs(string prefix, IDictionary<string, object> aKeyedCollection) {
            KeyciProc keyci = postfix => string.IsNullOrEmpty(prefix) ? postfix : string.IsNullOrEmpty(postfix) ? prefix : string.Concat(prefix, "_", postfix);
            addToEkArgsInternal(prefix, aKeyedCollection, keyci);
        }
        protected virtual void addToEkArgsInternal(string prefix, IDictionary<string, object> aKeyedCollection, KeyciProc keyci) { }
    }
}
