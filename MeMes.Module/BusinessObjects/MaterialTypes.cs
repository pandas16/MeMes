using DevExpress.ExpressApp;
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
    [XafDisplayName("物料分类"), DefaultProperty("TypeName")]
    public class MaterialTypes : BaseObject
    {
        public MaterialTypes(Session session)
            : base(session)
        {
        }

        TypeLevelEnum typeLevel;
        string remarkOfMaterialType;
        string typeName;
        string typeNo;

        [XafDisplayName("分类编号"), RuleRequiredField, RuleUniqueValue, Size(10)]
        public string TypeNo
        {
            get => typeNo;
            set => SetPropertyValue(nameof(TypeNo), ref typeNo, value);
        }

        [XafDisplayName("分类等级"), RuleRequiredField]
        public TypeLevelEnum TypeLevel
        {
            get => typeLevel;
            set => SetPropertyValue(nameof(TypeLevel), ref typeLevel, value);
        }
        [XafDisplayName("分类名称"), RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TypeName
        {
            get => typeName;
            set => SetPropertyValue(nameof(TypeName), ref typeName, value);
        }
        [XafDisplayName("备注")]
        [Size(SizeAttribute.Unlimited)]
        public string RemarkOfMaterialType
        {
            get => remarkOfMaterialType;
            set => SetPropertyValue(nameof(RemarkOfMaterialType), ref remarkOfMaterialType, value);
        }

        [XafDisplayName("操作记录")]
        private XPCollection<AuditDataItemPersistent> changeHistory;
        [CollectionOperationSet(AllowAdd = false, AllowRemove = false)]
        public XPCollection<AuditDataItemPersistent> ChangeHistory
        {
            get
            {
                if (changeHistory == null)
                {
                    changeHistory = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return changeHistory;
            }
        }

        public enum TypeLevelEnum
        {
            一级_成品,
            二级_半成品,
            三级_原材料,
            四级_附件,
            五级_其它,
        }
    }
}