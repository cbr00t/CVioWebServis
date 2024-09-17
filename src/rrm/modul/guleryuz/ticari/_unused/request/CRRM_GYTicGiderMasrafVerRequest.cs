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
    [Obsolete( "Bu sınıf kullanımdan kaldırılmıştır", true )]
    public class CRRM_GYTicGiderMasrafVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYTicFirmaGiderMasraf> {
        #region Getter
        public override string DefaultWSIslem {
            get { return "ticGiderMasrafVer"; }
        }

        public override Type ResponseClass {
            get { return typeof( CRRM_GYTicFaturaBilgiVerResponse ); }
        }
        #endregion
    }
}
