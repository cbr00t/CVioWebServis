using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliAvansOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )] public Guid PerID { get; set; }
        [XmlElement( "yilAy" ), DefaultValue( 0 )] public int YilAy { get; set; }
        [XmlElement( "yil" ), DefaultValue( 0 )] public int Yil { get; set; }
        [XmlElement( "ay" ), DefaultValue( 0 )] public int Ay { get; set; }
        [XmlElement( "avans" ), DefaultValue( typeof( decimal ), "0" )] public decimal Avans { get; set; }
        #endregion
    }
}
