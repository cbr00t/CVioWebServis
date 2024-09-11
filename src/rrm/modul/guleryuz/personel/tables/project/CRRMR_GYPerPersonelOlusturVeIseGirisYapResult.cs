using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerPersonelOlusturVeIseGirisYapResult : CRRMR_GYPerPersonelOlusturResult {
        #region Accessors
        [XmlElement( "sicilNo" )]
        public string SicilNo { get; set; }

        [XmlElement( "gcTarih" )]
        public DateTime? GCTarih { get; set; }

        [XmlElement( "referansKodu" )]
        public string ReferansKodu { get; set; }

        [XmlElement( "islemSonucu" )]
        public string IslemSonucu { get; set; }

        [XmlElement( "sgkDurum" )]
        public string SGKDurum { get; set; }

        [XmlElement( "sgkDurumDegistimi" ), DefaultValue( false )]
        public bool SGKDurumDegistimi { get; set; }

        [XmlElement( "eslesmeVarmi" ), DefaultValue( false )]
        public bool EslesmeVarmi { get; set; }

        [XmlElement( "eslesmeGCTarih" )]
        public DateTime? EslesmeGCTarih { get; set; }

        [XmlElement( "eslesmeSGKTarih" )]
        public DateTime? EslesmeSGKTarih { get; set; }

        public byte[] PDFIcerik { get; set; }
        #endregion

        #region Accessors: Ozel
        [SoapIgnore()]
        [XmlElement( "pdfIcerik" )]
        public string PDFIcerikBase64 {
            get {
                if (PDFIcerik == null)
                    return null;
                else if (PDFIcerik.bosmu())
                    return "";
                else
                    return Convert.ToBase64String( PDFIcerik, Base64FormattingOptions.None );
            }
            set {
                //if (value == null)
                //    PDFIcerik = null;
                //else if (value.bosmu())
                //    PDFIcerik = new byte[0];
                if (value.bosmu())
                    PDFIcerik = null;
                else
                    PDFIcerik = Convert.FromBase64String( value );
            }
        }
        #endregion
    }
}
