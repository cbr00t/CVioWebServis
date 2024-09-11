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
    public class CRRM_FRRaporBilgilerRequest : CRRMXmlRequest {
        public override CIOType? DefaultInputType { get { return CIOType.json; } }
        public override string DefaultWSIslem { get { return "frRaporBilgiler"; } }
        public override Type ResponseClass { get { return typeof( CRRM_FRRaporBilgilerResponse ); } }
        public override bool IsVioWebRequest { get { return true; } }
        public string RaporSinif { get; set; }
		[DefaultValue(false)] public bool OzelliklerDDListOlsun { get; set; }

		#region WS Iletisim
		public override void updateRequestArgs( CRRMCallArgs args ) {
            base.updateRequestArgs( args ); var qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut("raporSinif", RaporSinif);
            qsArgs.atPut("ozelliklerDDListOlsun", this.OzelliklerDDListOlsun);
		}
        #endregion
    }
}
