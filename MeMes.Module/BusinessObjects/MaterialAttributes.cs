using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeMes.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("物料属性")]
    public class MaterialAttributes : BaseObject
    {
        public MaterialAttributes(Session session) : base(session)
        {
        }

        bool isPriority;
        int minStockNum;
        int effectiveDate;
        int packageNum;
        UnitOfMaterial packageUnit;
        UnitOfMaterial minUnit;
        MaterialTypes materialTypes;
        MaterialMng materialName;
        int unitNum;

        /** 给表单赋予初始值 */
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            UnitNum = 1;
            PackageNum = 1;
            MinStockNum = 100;
            EffectiveDate = 30;
            IsPriority = true;
        }

        public enum UnitOfMaterial
        {
            长度单位_cm,
            重量单位_kg,
            面积单位_平方米,
            其它,
        }

        [XafDisplayName("物料名称"), RuleRequiredField]
        public MaterialMng MaterialName
        {
            get => materialName;
            set => SetPropertyValue(nameof(MaterialName), ref materialName, value);
        }

        [XafDisplayName("物料分类"), RuleRequiredField]
        public MaterialTypes MaterialTypes
        {
            get => materialTypes;
            set => SetPropertyValue(nameof(MaterialTypes), ref materialTypes, value);
        }

        [XafDisplayName("最小单位"), RuleRequiredField]
        public UnitOfMaterial MinUnit
        {
            get => minUnit;
            set => SetPropertyValue(nameof(MinUnit), ref minUnit, value);
        }

        [XafDisplayName("单位数量")]
        public int UnitNum
        {
            get => unitNum;
            set => SetPropertyValue(nameof(UnitNum), ref unitNum, value);
        }

        [XafDisplayName("包装单位"), RuleRequiredField]
        public UnitOfMaterial PackageUnit
        {
            get => packageUnit;
            set => SetPropertyValue(nameof(PackageUnit), ref packageUnit, value);
        }

        [XafDisplayName("包装数量")]
        public int PackageNum
        {
            get => packageNum;
            set => SetPropertyValue(nameof(PackageNum), ref packageNum, value);
        }

        [XafDisplayName("有效期（天）")]
        public int EffectiveDate
        {
            get => effectiveDate;
            set => SetPropertyValue(nameof(EffectiveDate), ref effectiveDate, value);
        }

        [XafDisplayName("最小库存")]
        public int MinStockNum
        {
            get => minStockNum;
            set => SetPropertyValue(nameof(MinStockNum), ref minStockNum, value);
        }

        [XafDisplayName("是否先进先出"), CaptionsForBoolValues("是", "否")]
        public bool IsPriority
        {
            get => isPriority;
            set => SetPropertyValue(nameof(IsPriority), ref isPriority, value);
        }
    }
}
