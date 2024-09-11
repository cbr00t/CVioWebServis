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
    public class CRRM_GYPerSozlesmeliPersonelOlusturVeIseGirisYapRequest : CRRMMasterListRequest<CRRMR_GYPerSozlesmeliPersonelOlusturVeIseGirisYapArg, CRRMR_GYPerSozlesmeliPersonelOlusturVeIseGirisYapResult> {
        #region Accessors
        [DefaultValue( false )]
        public bool PDFAkibetKontrolYapilirmi { get; set; }
        #endregion


        #region Getter
        public override string DefaultWSIslem {
            get { return "perSozlesmeliPersonelOlusturVeIseGirisYap"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerSozlesmeliPersonelOlusturVeIseGirisYapResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "pdfAkibetKontrolYapilirmi", PDFAkibetKontrolYapilirmi );
        }
        #endregion
    }
}
