using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerYanOdeme : CRRMR_KodVeAdiYapi {
        #region Accessors
        [XmlElement( "anatip" ), SoapIgnore()]
        public string AnaTipKod { get; set; }

        public CRRM_GYPerYanOdemeAnaTip AnaTip {
            get {
                if (AnaTipKod != null) {
                    switch (AnaTipKod.ToUpper()) {
                        case "M": return CRRM_GYPerYanOdemeAnaTip.Mevsimlik_Tarim;
                        case "S": return CRRM_GYPerYanOdemeAnaTip.Senaryolu;
                    }
                }

                return CRRM_GYPerYanOdemeAnaTip.Normal;
            }
            set {
                switch (value) {
                    case CRRM_GYPerYanOdemeAnaTip.Mevsimlik_Tarim: AnaTipKod = "M"; break;
                    case CRRM_GYPerYanOdemeAnaTip.Senaryolu: AnaTipKod = "S"; break;
                    default: AnaTipKod = ""; break;
                }
            }
        }
        #endregion
    }
}
