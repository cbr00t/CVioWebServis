using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;

namespace CVioWebServis {
    public class CRRMKayitDegistiKontroluRequest : CRRMMasterRequestNonFilterable<CRRMR_KayitDegistiKontrolu> {
        #region Accessors
        public string[] TabloListe { get; set; }
        #endregion


        #region Getter
        public override string DefaultWSIslem {
            get { return "kayitDegistiKontrolu"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRMKayitDegistiKontroluResponse ); }
        }
        #endregion


        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "tabloListe", string.Join( CGlobals.WSListeDelim.ToString(), TabloListe ) );
        }
        #endregion
    }
}
