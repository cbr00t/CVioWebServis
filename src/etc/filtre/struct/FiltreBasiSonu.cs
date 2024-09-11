using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVioWebServis {
    public class FiltreBasiSonu : Filtre {
        public object Basi { get; set; }
        public object Sonu { get; set; }

		public FiltreBasiSonu(string saha, object basi, object sonu) : base(saha) { this.Basi = basi; this.Sonu = sonu; }
		public FiltreBasiSonu(object basi, object sonu) : this(null, basi, sonu) { }
		public FiltreBasiSonu() : this(null, null, null) { }
		protected override void addToEkArgsInternal( string prefix, IDictionary<string, object> aKeyedCollection, KeyciProc keyci ) {
            base.addToEkArgsInternal( prefix, aKeyedCollection, keyci );
            aKeyedCollection.atPut( keyci( "basi" ), Basi ); aKeyedCollection.atPut( keyci( "sonu" ), Sonu );
        }
    }
}
