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
    public class CRRM_GYTicEFaturaPdfVerRequest : CRRMDownloadRequest {
        public bool Htmlmi { get; set; }
        [DefaultValue( 0 )] public int VioID { get; set; }
        public Guid? UUID { get; set; }

        #region Getter
        public override string DefaultWSIslem { get { return "ticEFaturaPDFVer"; } }
        public override Type ResponseClass { get { return typeof( CRRM_GYTicEFaturaPdfVerResponse ); } }
        #endregion
        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            base.updateRequestArgs( args );
            var qsArgs = args.QSArgs; qsArgs.atPut( "htmlmi", Htmlmi );
            qsArgs.bosDegilseAtPut( "vioID", VioID );
            qsArgs.bosDegilseAtPut( "uuid", UUID );
        }
        #endregion
    }
}
