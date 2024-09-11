using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_Stok : CRRMR_KodVeAdiYapi {
        #region Data Accessors
        [XmlElement( "tipi" )]
        public string Tip { get; set; }

        [XmlElement( "grupkod" )]
        public string GrupKod { get; set; }

        [XmlElement( "grupadi" )]
        public string GrupAdi { get; set; }

        [XmlElement( "brm" )]
        public string Brm { get; set; }

        [XmlElement( "satfiyat" )]
        public decimal SatisFiyati { get; set; }

        [XmlElement( "satkdvhesapkod" )]
        public string SatisKdvHesapKodu { get; set; }

        [XmlElement( "almkdvhesapkod" )]
        public string AlimKdvHesapKodu { get; set; }

        public int SatisKdvOrani {
            get { return kdvHesapKod2Oran( SatisKdvHesapKodu ); }
            set { }
        }

        public int AlimKdvOrani {
            get { return kdvHesapKod2Oran( AlimKdvHesapKodu ); }
            set { }
        }
        #endregion


        #region Yardimci
        protected int kdvHesapKod2Oran( string hesapKod ) {
            StringBuilder sbTemp;

            if (hesapKod.bosmu())
                return 0;

            sbTemp = new StringBuilder();
            foreach (var ch in hesapKod) {
                if (char.IsDigit( ch ))
                    sbTemp.Append( ch );
            }

            if (sbTemp.bosmu())
                return 0;

            return Convert.ToInt32( sbTemp.ToString() );
        }
        #endregion
    }
}
