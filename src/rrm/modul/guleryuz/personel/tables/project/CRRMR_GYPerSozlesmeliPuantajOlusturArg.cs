using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliPuantajOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )] public Guid PerID { get; set; }
        [XmlElement( "donemID" )] public Guid DonemID { get; set; }
        [XmlElement( "yilAy" ), DefaultValue( 0 )] public int YilAy { get; set; }
        [XmlElement( "yil" ), DefaultValue( 0 )] public int Yil { get; set; }
        [XmlElement( "ay" ), DefaultValue( 0 )] public int Ay { get; set; }
        [XmlArray( "gunler" ), XmlArrayItem( "gun" )] public CRRMR_GYPerSP_Gun[] Gunler { get; set; }
        [XmlArray( "yanOdemeler" ), XmlArrayItem( "yanOdeme" )] public CRRMR_GYPerSP_YanOdeme[] YanOdemeler { get; set; }
        [XmlArray( "kesintiler" ), XmlArrayItem( "kesinti" )] public CRRMR_GYPerSP_Kesinti[] Kesintiler { get; set; }
        #endregion
    }
}
