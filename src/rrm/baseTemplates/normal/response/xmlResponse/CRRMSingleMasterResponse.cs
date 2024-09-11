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
using System.Xml.Serialization;
using System.Reflection;

namespace CVioWebServis {
    [Serializable()]
    [XmlRoot( CRRMSingleMasterResponse.RootNodeName )]
    public class CRRMSingleMasterResponse : CRRMBasicXmlResponse {
        public const string
            ParentRootNodeName = "Response",
            RootNodeName = "Result",
            DSRecordNodeName = "Data";

        public CRRMSingleMasterResponse()
            : base() {
        }

        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            XmlReader xr;
            if ((xr = args.UserData as XmlReader) != null)
                parseResponseInternal( args, xr );
        }
        protected virtual void parseResponseInternal( CRRMCallArgs args, XmlReader xr ) {
            XmlSerializer serializer;
            Type thisClass;
            CRRMSingleMasterResponse record;

            xr.ReadToDescendant( RootNodeName );
            thisClass = this.GetType();
            serializer = new XmlSerializer( thisClass, new XmlRootAttribute( RootNodeName ) );
            record = (CRRMSingleMasterResponse)serializer.Deserialize( xr );
            foreach (var prop in record.GetType().GetProperties( BindingFlags.Public | BindingFlags.Instance )) {
                #region block
                // if (prop.GetCustomAttributes( typeof( XmlTextAttribute ), true ).Length != 0)
                PropertyInfo thisProp;

                thisProp = thisClass.GetProperty( prop.Name, BindingFlags.Public | BindingFlags.Instance );
                if (thisProp != null && thisProp.GetSetMethod() != null)
                    thisProp.SetValue( this, prop.GetValue( record, null ), null );
                //thisClass.InvokeMember( prop.Name, BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder
                //    , this, new object[] { prop.GetValue( record, null ) } );
                #endregion
            }
        }

        //protected virtual void parseResponseInternal( CRRMCallArgs args, XmlReader xr ) {
        //    XmlSerializer serializer;
        //    CRRMSingleMasterResponseContainer recordContainer;

        //    //xr.ReadToDescendant( RootNodeName );
        //    serializer = new XmlSerializer( typeof( CRRMSingleMasterResponseContainer ), new XmlRootAttribute( ParentRootNodeName ) );
        //    recordContainer = (CRRMSingleMasterResponseContainer)serializer.Deserialize( xr );
        //    if (recordContainer != null) {
        //        CRRMSingleMasterResponse record;
        //        Type thisClass;

        //        record = recordContainer.Record;
        //        thisClass = this.GetType();
        //        foreach (var prop in record.GetType().GetProperties( BindingFlags.Public | BindingFlags.Instance )) {
        //            // if (prop.GetCustomAttributes( typeof( XmlTextAttribute ), true ).Length != 0)
        //            PropertyInfo thisProp;

        //            thisProp = thisClass.GetProperty( prop.Name, BindingFlags.Public | BindingFlags.Instance );
        //            if (thisProp != null && thisProp.GetSetMethod() != null)
        //                thisProp.SetValue( this, prop.GetValue( record, null ), null );
        //            //thisClass.InvokeMember( prop.Name, BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder
        //            //    , this, new object[] { prop.GetValue( record, null ) } );
        //        }
        //    }
        //}
        #endregion
    }
}
