﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYBasicResultWithID : CRRMR_GYBasicResult {
        [XmlElement("id")] public Guid? ID { get; set; }
    }
}
