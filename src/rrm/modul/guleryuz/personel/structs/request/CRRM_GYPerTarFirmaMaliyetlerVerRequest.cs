using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    public class CRRM_GYPerTarFirmaMaliyetlerVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYPerTarFirmaMaliyet> {
        public override string DefaultWSIslem { get => "perTarFirmaMaliyetlerVer"; }
        public override Type ResponseClass { get => typeof(CRRM_GYPerTarFirmaMaliyetlerVerResponse); }
        #region Accessors
        public Guid DonemID { get; set; } public Guid? FirmaID { get; set; }
        #endregion

        public override void updateRequestArgs(CRRMCallArgs args) {
            base.updateRequestArgs(args); var qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut("donemID", DonemID); qsArgs.bosDegilseAtPut("firmaID", FirmaID);
        }
    }
}
