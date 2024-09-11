using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMListResponse<T> : CRRMSingleResponse<List<T>> {
    }
}
