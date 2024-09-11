using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    public class CRRM_GYTicEFaturalariVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYTicEFatura> {
        #region Accessors
        public Guid? DonemID { get; set; }

        public string MustKod { get; set; }

        public Guid? UUID { get; set; }

        public DateTime? TarihBasi { get; set; }

        public DateTime? TarihSonu { get; set; }

        public string[] IslemKodListe { get; set; }

        public bool SadeceHakedislermi { get; set; }
        #endregion

        
        #region Getter
        public override string DefaultWSIslem {
            get { return "ticEFaturalariVer"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicEFaturalariVerResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "donemID", DonemID );
            qsArgs.bosDegilseAtPut( "mustKod", MustKod );
            qsArgs.bosDegilseAtPut( "uuid", UUID );
            qsArgs.bosDegilseAtPut( "tarihBasi", TarihBasi );
            qsArgs.bosDegilseAtPut( "tarihSonu", TarihSonu );
            if (IslemKodListe.bosDegilmi())
                qsArgs.atPut( "islemKodListe", string.Join( CGlobals.WSListeDelim.ToString(), IslemKodListe ) );
            qsArgs.atPut( "sadeceHakedislermi", SadeceHakedislermi );
        }
        #endregion
    }
}
