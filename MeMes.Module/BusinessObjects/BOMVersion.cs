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
    [XafDisplayName("物料版本"), DefaultProperty("VersionOfBom")]
    public class BOMVersion : BaseObject
    {
        public BOMVersion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [FetchOnly]
        [Persistent("VersionOfBom")]
        private int versionOfBom;

        string remarkOfBOMVersion;
        MaterialMng material;

        [XafDisplayName("物料"), RuleRequiredField,]
        public MaterialMng Material
        {
            get => material;
            set => SetPropertyValue(nameof(Material), ref material, value);
        }

        [XafDisplayName("版本")]
        [PersistentAlias(nameof(versionOfBom))]
        public int VersionOfBom
        {
            get => versionOfBom;
        }

        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfBOMVersion
        {
            get => remarkOfBOMVersion;
            set => SetPropertyValue(nameof(RemarkOfBOMVersion), ref remarkOfBOMVersion, value);
        }
    }
}