﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_Islem : CRRMRecord {
        #region Data Accessors
        [XmlElement( "islem" )]
        public string Islem { get; set; }
        #endregion
    }
}
