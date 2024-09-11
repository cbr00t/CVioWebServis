using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace CVioWebServis {
    public class CRRMBasicMasterRequest : CRRMXmlRequest {
        public virtual Filtre[] Filtreler { get; set; }
        public int? MaxRow { get; set; }
        public override CIOType? DefaultOutputType { get { return CIOType.tab; } }
        public override Type ResponseClass { get { return typeof( CRRMBasicXmlResponse ); } }

		public CRRMBasicMasterRequest() : base() { SkipXMLAutoLoadFlag = true; }
		#region WS Iletisim
		public override void updateRequestArgs( CRRMCallArgs args ) {
            base.updateRequestArgs( args ); var qsArgs = args.QSArgs; /* skipXMLAutoLoad(); */
            if (Filtreler.bosDegilmi()) { foreach (var filtre in Filtreler) filtre.addYourselfToEkArgs( qsArgs ); }
            if (MaxRow.HasValue && MaxRow >= 0) qsArgs.atPut( "maxRow", MaxRow.Value );
        }
        #endregion 
    }
}
