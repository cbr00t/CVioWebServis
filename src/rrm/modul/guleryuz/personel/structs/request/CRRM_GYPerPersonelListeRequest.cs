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
    public class CRRM_GYPerPersonelListeRequest : CRRMMasterRequest<CRRMR_GYPerPersonel> {
        #region Accessors
        [DefaultValue( false )]
        public bool RefIDKontrolEdilmesinmi { get; set; }

        [DefaultValue( false )]
        public bool SadeceCalisanlarmi { get; set; }
        #endregion


        #region Getter
        public override string DefaultWSIslem {
            get { return "perPersonelListe"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerPersonelListeResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "refIDKontrolEdilmesinmi", RefIDKontrolEdilmesinmi );
            qsArgs.bosDegilseAtPut( "sadeceCalisanlarmi", SadeceCalisanlarmi );
        }
        #endregion
    }
}
