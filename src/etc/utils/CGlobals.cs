using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace CVioWebServis {
    public class CGlobals {
        public const string
            DotnetFileString_Date = "yyyy-MM-dd"
            , DotnetFileString_Time = "HH:mm:ss"
            , DotnetFileString_DateTime = DotnetFileString_Date + "T" + DotnetFileString_Time
            , GosterimString_Date = "dd.MM.yyyy"
            , GosterimString_Time = "HH:mm:ss"
            , GosterimString_DateTime = GosterimString_Date + " " + GosterimString_Time;
        public static readonly Encoding DefaultEncoding = Encoding.Default;
        public const char WSListeDelim = '|';
    }
}