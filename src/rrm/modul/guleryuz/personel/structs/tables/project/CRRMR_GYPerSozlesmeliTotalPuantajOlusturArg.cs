﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliTotalPuantajOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )]
        public Guid PerID { get; set; }

        [XmlElement( "donemID" )]
        public Guid DonemID { get; set; }

        [XmlElement( "yilAy" ), DefaultValue( 0 )]
        public int YilAy { get; set; }

        [XmlElement( "yil" ), DefaultValue( 0 )]
        public int Yil { get; set; }

        [XmlElement( "ay" ), DefaultValue( 0 )]
        public int Ay { get; set; }

        [XmlElement( "eksikNedenKod" )]
        public string EksikNedenKod { get; set; }

        [XmlElement( "eksikGun" ), DefaultValue( 0 )]
        public int EksikGun { get; set; }

        [XmlElement( "eksikSaat" ), DefaultValue( typeof( decimal ), "0" )]
        public decimal EksikSaat { get; set; }

        [XmlElement( "sskGunu" ), DefaultValue( 0 )]
        public int SSKGunu { get; set; }

        [XmlElement( "vergiGunu" ), DefaultValue( 0 )]
        public int VergiGunu { get; set; }

        [XmlArray( "odemeVerileri" )]
        [XmlArrayItem( "odeme" )]
        public CRRMR_GYPerSTP_OdemeVerileri[] OdemeVerileri { get; set; }
        #endregion
    }
}
