using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace CVioWebServis {
    public class FiltreListe : Filtre {
        public string[] DegerListe { get; set; }

		public FiltreListe(string saha, string[] degerListe) : base(saha) { this.DegerListe = degerListe; }
		public FiltreListe(string[] degerListe) : this(null, degerListe) { }
		public FiltreListe() : this(null, null) { }
        protected override void addToEkArgsInternal(string prefix, IDictionary<string, object> aKeyedCollection, KeyciProc keyci) {
            base.addToEkArgsInternal(prefix, aKeyedCollection, keyci); if (DegerListe == null || DegerListe.Length == 0) return;
            var sb = new StringBuilder(DegerListe.Length * 16);
            foreach (var deger in DegerListe) {
                if (deger == null) continue;
                if (sb.Length > 0) { sb.Append(CGlobals.WSListeDelim); } sb.Append(deger);
            }
            aKeyedCollection.atPut(keyci("liste"), sb.ToString());
        }
    }
}
