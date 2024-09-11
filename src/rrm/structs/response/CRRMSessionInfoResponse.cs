using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMSessionInfoResponse : CRRMBasicSessionInfoResponse {
        #region Accessors
        [XmlElement( "sessionStartTS" ), SoapIgnore()]
        public string SessionStartTSStr { get; set; }

        public DateTime? SessionStartTS {
            get { return SessionStartTSStr.asDateTimeQ(); }
            set { SessionStartTSStr = value.HasValue ? value.ToString() : null; }
        }

        [XmlElement( "sessionClassName" )]
        public string SessionClassName { get; set; }

        [XmlElement( "dbName" )]
        public string DBName { get; set; }

        [XmlElement( "progKod" )]
        public string ProgKod { get; set; }

        [XmlElement( "progAdi" )]
        public string ProgAdi { get; set; }

        [XmlElement( "progVersion" )]
        public string ProgVersion { get; set; }

        [XmlElement( "digerSubeleriGorebilirmi" )]
        [SoapIgnore()]
        public string DigerSubeleriGorebilirmiStr { get; set; }

        public bool DigerSubeleriGorebilirmi {
            get { return DigerSubeleriGorebilirmiStr.asBool(); }
            set { DigerSubeleriGorebilirmiStr = value.ToString(); }
        }

        [XmlElement( "subeKod" )]
        public string SubeKod { get; set; }

        [XmlElement( "subeAdi" )]
        public string SubeAdi { get; set; }
        #endregion


        #region Parser
        /*protected override void parseResponseInternal( CRRMCallArgs args, XmlNode xnode, string name, string value ) {
            base.parseResponseInternal( args, xnode, name, value );

            if (xnode.NodeType != XmlNodeType.Text)
                return;

            switch (name) {
                case "sessionStartTS":
                    SessionStartTS = ( value.bosmu()
                                        ? (DateTime?)null
                                        : (DateTime?)Convert.ToDateTime( value ) );
                    break;
                case "sessionClass":
                    SessionClassName = ( value.bosmu()
                                            ? null
                                            : value );
                    break;
                case "dbName":
                    DBName = value;
                    break;
                case "progKod":
                    ProgKod = value;
                    break;
                case "progAdi":
                    ProgAdi = value;
                    break;
                case "progVersion":
                    ProgVersion = value;
                    break;
                case "digerSubeleriGorebilirmi":
                    DigerSubeleriGorebilirmi = ( value.bosmu()
                                                    ? false
                                                    : Convert.ToBoolean( value ) );
                    break;
                case "subeKod":
                    SubeKod = value;
                    break;
                case "subeAdi":
                    SubeAdi = value;
                    break;
            }
        }*/
        #endregion

        #region Not Categorized
        public CRRMSessionInfoResponse() : base() {
        }

        public override string ToString() {
            return string.Format( "{0} :: {1} :: {2}  :: [{3}]  :: {4}  ::  {5} "
                , ( HasSession ? "HAS SESSION" : "NO SESSION" )
                , SessionStartTS
                , SessionID
                , SessionClassName
                , string.IsNullOrEmpty( OzelTipKod )
                    ? string.Empty
                    : string.Format( "OZEL TIP: ({0}) {1}", OzelTipKod, OzelTipAdi )
                , string.Format( "{0} :: {1}-{2} v{3}"
                    , DBName
                    , ProgKod
                    , ProgAdi
                    , ProgVersion )
                );

        }
        #endregion
    }
}
