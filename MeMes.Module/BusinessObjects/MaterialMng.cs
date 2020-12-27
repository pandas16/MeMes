using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace MeMes.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("物料管理"), DefaultProperty("MaterialName")]
    public class MaterialMng : BaseObject
    {
        public MaterialMng(Session session) : base(session)
        {

        }

        string remarkOfMaterialMng;
        string materialName;
        string materialNo;

        [Size(10), XafDisplayName("物料编号"), RuleRequiredField, RuleUniqueValue]
        public string MaterialMngaterialName
        {
            get => materialNo;
            set => SetPropertyValue(nameof(MaterialMngaterialName), ref materialNo, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), XafDisplayName("物料名称"), RuleRequiredField]
        public string MaterialName
        {
            get => materialName;
            set => SetPropertyValue(nameof(MaterialName), ref materialName, value);
        }


        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfMaterialMng
        {
            get => remarkOfMaterialMng;
            set => SetPropertyValue(nameof(RemarkOfMaterialMng), ref remarkOfMaterialMng, value);
        }
    }
}
