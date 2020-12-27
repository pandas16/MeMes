using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Linq;
using static MeMes.Module.BusinessObjects.MaterialAttributes;

namespace MeMes.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("物料清单")]
    public class BOM : BaseObject
    {
        public BOM(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string remarkOfBOM;
        int dose;
        UnitOfMaterial minUnit;
        BOMVersion versionOfBOM;
        MaterialMng childrenMaterial;
        MaterialMng parentMaterial;

        [XafDisplayName("父件"), RuleRequiredField]
        public MaterialMng ParentMaterial
        {
            get => parentMaterial;
            set => SetPropertyValue(nameof(ParentMaterial), ref parentMaterial, value);
        }

        [XafDisplayName("子件"), RuleRequiredField]
        [DataSourceCriteria("ChildrenMaterial != ParentMaterial")]
        public MaterialMng ChildrenMaterial
        {
            get => childrenMaterial;
            // TODO 暂时还没有找到通过监听值改变的方法实现父件与子件互异
            set
            {
                if ((childrenMaterial != value) & (ParentMaterial != value))
                {
                    childrenMaterial = value;
                    OnChanged(nameof(ChildrenMaterial), ChildrenMaterial, childrenMaterial);
                }
            }
        }

        [XafDisplayName("版本"), RuleRequiredField]
        public BOMVersion VersionOfBOM
        {
            get => versionOfBOM;
            set => SetPropertyValue(nameof(VersionOfBOM), ref versionOfBOM, value);
        }

        [XafDisplayName("最小单位"), RuleRequiredField]
        public UnitOfMaterial MinUnit
        {
            get => minUnit;
            set => SetPropertyValue(nameof(MinUnit), ref minUnit, value);
        }

        [XafDisplayName("用量")]
        public int Dose
        {
            get => dose;
            set => SetPropertyValue(nameof(Dose), ref dose, value);
        }

        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfBOM
        {
            get => remarkOfBOM;
            set => SetPropertyValue(nameof(RemarkOfBOM), ref remarkOfBOM, value);
        }
    }
}