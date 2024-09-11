using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_FRSecimBilgi : CRRMR_KodVeAdiYapi {
        public string TipKod { get; set; }
        public CRRMR_FRSecimTipi Tip {
            get {
                var result = CRRMR_FRSecimTipi.Belirsiz;
                try { result = (CRRMR_FRSecimTipi)Enum.Parse( typeof( CRRMR_FRSecimTipi ), TipKod, true ); }
                catch (Exception) { }
                return result;
            }
            set {
                TipKod = value == CRRMR_FRSecimTipi.Belirsiz ? null : value.ToString().ToLowerInvariant();
            }
        }
        public string MFSinif { get; set; }
        public int? MaxLength { get; set; }
        public string Basi { get; set; }
        public string Sonu { get; set; }
        public string Ozellik { get; set; }
        public string DefaultValue { get; set; }
        public bool DDListmi { get; set; }
        public bool Hepsimi { get; set; }
        public CRRMR_KodVeAdiYapi[] SubItems { get; set; }

    }
}
