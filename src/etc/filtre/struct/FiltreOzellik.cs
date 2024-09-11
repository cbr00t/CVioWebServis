using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVioWebServis {
    public class FiltreOzellik : Filtre {
        public string Deger { get; set; }

		public FiltreOzellik(string saha, string deger) : base(saha) { this.Deger = deger; }
		public FiltreOzellik(string deger) : this(null, deger) { }
		public FiltreOzellik() : this(null, null) { }
		protected override void addToEkArgsInternal( string prefix, IDictionary<string, object> aKeyedCollection, KeyciProc keyci ) {
            base.addToEkArgsInternal( prefix, aKeyedCollection, keyci );
            aKeyedCollection.atPut( keyci( null ), Deger );
        }
    }
}
