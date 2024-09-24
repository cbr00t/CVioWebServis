using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerIseGirisPdfVerResult : CRRMR_GYBasicResult {
        #region Accessors
        [XmlElement( "perID" )]
        public string PerID { get; set; }

        [XmlElement( "perSayac" )]
        public int? PerSayac { get; set; }

        [XmlElement( "perKod" )]
        public string PerKod { get; set; }

        [XmlElement( "perIsim" )]
        public string PerIsim { get; set; }

        [XmlElement( "sgkIsyeriKod" )]
        public string SGKIsyeriKod { get; set; }

        [XmlElement( "dosyaAdi" )]
        public string DosyaAdi { get; set; }

        [XmlElement( "dosyaExt" )]
        public string DosyaExt { get; set; }

        [XmlElement( "contentType" )]
        public string ContentType { get; set; }

        public byte[] PDFIcerik { get; set; }
        #endregion

        #region Accessors: Ozel
        //[SoapIgnore()]
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
