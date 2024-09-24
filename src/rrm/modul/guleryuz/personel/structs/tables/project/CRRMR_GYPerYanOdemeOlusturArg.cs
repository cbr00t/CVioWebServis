using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerYanOdemeOlusturArg : CRRMR_GYPerKesintiOdemeOlusturArg {
        #region Accessors
        [XmlElement( "netBrut" )]
        public string NetBrutKod { get; set; }

        public CRRM_GYPerTarNetBrut NetBrut {
            get {
                if (NetBrutKod != null) {
                    #region block
                    switch (NetBrutKod.ToUpper()) {
                        case "N": return CRRM_GYPerTarNetBrut.Net;
                        case "P": return CRRM_GYPerTarNetBrut.AgiDahilNet;
                    }
                    #endregion
                }

                return CRRM_GYPerTarNetBrut.Brut;
            }
            set {
                switch (value) {
                    #region block
                    case CRRM_GYPerTarNetBrut.Net: NetBrutKod = "N"; break;
                    case CRRM_GYPerTarNetBrut.AgiDahilNet: NetBrutKod = "P"; break;
                    default: NetBrutKod = "B"; break;
                    #endregion
                }
            }
        }
        #endregion
    }
}
