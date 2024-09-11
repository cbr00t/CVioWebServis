using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliPersonelOlusturArg : CRRMR_GYPerPersonelOlusturArg {
        #region Accessors
        [XmlElement( "firmaCalismaAlanID" )]
        public Guid FirmaCalismaAlanID { get; set; }

        [XmlElement( "emeklimi" ), DefaultValue( false )]
        public bool Emeklimi { get; set; }

        [XmlElement( "telNo" )]
        public string TelNo { get; set; }

        [XmlElement( "eMail" )]
        public string EMail { get; set; }

        [XmlElement( "ibanNo" )]
        public string IBANNo { get; set; }

        [XmlElement( "sakatlikDerecesi" ), DefaultValue( (byte)0 )]
        public byte SakatlikDerecesi { get; set; }

        [XmlElement( "ucretTipi" )]
        public string UcretTipiKod { get; set; }

        public CRRM_GYPerUcretTipi UcretTipi {
            get {
                if (UcretTipiKod != null) {
                    switch (UcretTipiKod.ToUpper()) {
                        case "S": return CRRM_GYPerUcretTipi.SaatUcretli;
                        case "Y": return CRRM_GYPerUcretTipi.Yevmiyeli;
                    }
                }

                return CRRM_GYPerUcretTipi.Aylikli;
            }
            set {
                switch (value) {
                    case CRRM_GYPerUcretTipi.SaatUcretli: UcretTipiKod = "S"; break;
                    case CRRM_GYPerUcretTipi.Yevmiyeli: UcretTipiKod = "Y"; break;
                    default: UcretTipiKod = "A"; break;
                }
            }
        }

        [XmlElement( "netBrut" )]
        public string NetBrutKod { get; set; }

        public CRRM_GYPerNetBrut NetBrut {
            get {
                if (NetBrutKod != null) {
                    switch (NetBrutKod.ToUpper()) {
                        case "N": return CRRM_GYPerNetBrut.Net;
                    }
                }

                return CRRM_GYPerNetBrut.Brut;
            }
            set {
                switch (value) {
                    case CRRM_GYPerNetBrut.Net: NetBrutKod = "N"; break;
                    default: NetBrutKod = "B"; break;
                }
            }
        }

        [XmlElement( "sozlesmeDurumu" )]
        public string SozlesmeDurumuKod { get; set; }

        public CRRM_GYPerSozlesmeDurumu SozlesmeDurumu {
            get {
                if (SozlesmeDurumuKod != null) {
                    switch (SozlesmeDurumuKod.ToUpper()) {
                        case "S": return CRRM_GYPerSozlesmeDurumu.Surekli;
                    }
                }

                return CRRM_GYPerSozlesmeDurumu.Gecici;
            }
            set {
                switch (value) {
                    case CRRM_GYPerSozlesmeDurumu.Surekli: SozlesmeDurumuKod = "S"; break;
                    default: SozlesmeDurumuKod = "G"; break;
                }
            }
        }

        [XmlElement( "asgariUcretmi" )]
        //[DefaultValue( true )]  <--  defaultValue=True verilince true icin xml serialize etmiyor (default value değerini)
        public bool AsgariUcretmi { get; set; }

        [XmlElement( "ucret" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal Ucret { get; set; }
        #endregion
    }
}
