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
    public class CRRM_GYPerSozlesmeliFirmaMaliyetlerVerRequest : CRRMMasterRequestNonFilterable<CRRMR_GYPerSozlesmeliFirmaMaliyet> {
		public override string DefaultWSIslem { get => "perSozlesmeliFirmaMaliyetlerVer"; }
		public override Type ResponseClass { get => typeof(CRRM_GYPerSozlesmeliFirmaMaliyetlerVerResponse); }
		#region Accessors
		public Guid DonemID { get; set; } public int YilAy { get; set; }
        public int Yil { get; set; } public int Ay { get; set; }
        #endregion

        public override void updateRequestArgs(CRRMCallArgs args) {
            base.updateRequestArgs(args); var qsArgs = args.QSArgs;
            qsArgs.bosDegilseAtPut("donemID", DonemID);
            if (YilAy.bosmu()) { qsArgs.bosDegilseAtPut("yil", Yil); qsArgs.bosDegilseAtPut("ay", Ay); }
            else { qsArgs.bosDegilseAtPut("yilAy", YilAy); }
        }
    }
}
