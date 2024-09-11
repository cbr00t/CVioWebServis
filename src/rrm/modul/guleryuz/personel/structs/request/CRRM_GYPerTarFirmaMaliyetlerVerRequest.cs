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
    public class CRRM_GYPerTarFirmaMaliyetlerVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYPerTarFirmaMaliyet> {
        #region Accessors
        public Guid DonemID { get; set; }

        public Guid? FirmaID { get; set; }

        /*public string AltTipKod {
            get {
                switch (AltTip) {
                    case CRRM_GYPerTarFirmaMaliyetVer_AltTip.Bolge: return "B";
                    case CRRM_GYPerTarFirmaMaliyetVer_AltTip.CalismaAlani: return "A";
                }

                return "";
            }
        }

        [DefaultValue( typeof( CRRM_GYPerTarFirmaMaliyetVer_AltTip ), "TumFirma" )]
        public CRRM_GYPerTarFirmaMaliyetVer_AltTip AltTip { get; set; }

        [DefaultValue( null )]
        public string AltID { get; set; }*/
        #endregion


        #region Getter
        public override string DefaultWSIslem {
            get { return "perTarFirmaMaliyetlerVer"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYPerTarFirmaMaliyetlerVerResponse ); }
        }
        #endregion

        #region WS Iletisim
        public override void updateRequestArgs( CRRMCallArgs args ) {
            IDictionary<string, object> qsArgs;

            base.updateRequestArgs( args );

            qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut( "donemID", DonemID );
            qsArgs.bosDegilseAtPut( "firmaID", FirmaID );
            /*qsArgs.bosDegilseAtPut( "altTip", AltTipKod );
            //if (AltTip != CRRM_GYPerTarFirmaMaliyetVer_AltTip.TumFirma)
            qsArgs.bosDegilseAtPut( "altID", AltID );*/
        }
        #endregion
    }
}
