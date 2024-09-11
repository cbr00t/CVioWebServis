using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CVioWebServis {
    public class CRRM_GYPerUcretPusulaGonderRequest : CRRMDownloadRequest {
        #region Accessors
        public bool Htmlmi { get; set; }
        public Guid PerID { get; set; }
        [DefaultValue( 0 )]
        public int YilAy { get; set; }
        [DefaultValue( 0 )]
        public int Ay { get; set; }
        [DefaultValue( 0 )]
        public int Yil { get; set; }
        #endregion


        #region Getter
        public override string DefaultWSIslem {
            get { return "perUcretPusulaGonder"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerUcretPusulaGonderResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.atPut( "htmlmi", Htmlmi );
            qsArgs.bosDegilseAtPut( "perID", PerID );
            qsArgs.bosDegilseAtPut( "yilAy", YilAy );
            qsArgs.bosDegilseAtPut( "ay", Ay );
            qsArgs.bosDegilseAtPut( "yil", Yil);
        }
        #endregion
    }
}
