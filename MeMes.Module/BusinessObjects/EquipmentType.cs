using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace MeMes.Module.BusinessObjects
{
    [DefaultClassOptions, XafDisplayName("设备分类"), XafDefaultProperty("Name")]
    public class EquipmentType : HCategory
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [XafDisplayName("设备名称")]
        public new String Name { get; set; }

        [XafDisplayName("父节点"), VisibleInListView(false)]
        public new HCategory Parent { get; set; }

        [XafDisplayName("子节点")]
        public new XPCollection<HCategory> Children { get; set; }

        string remarkOfEqType;
        string eqTypeNo;

        [Size(SizeAttribute.DefaultStringMappingFieldSize), XafDisplayName("设备编号")]
        public string EqTypeNo
        {
            get => eqTypeNo;
            set => SetPropertyValue(nameof(EqTypeNo), ref eqTypeNo, value);
        }

        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfEqType
        {
            get => remarkOfEqType;
            set => SetPropertyValue(nameof(RemarkOfEqType), ref remarkOfEqType, value);
        }
    }
}