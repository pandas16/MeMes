using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace MeMes.Module.BusinessObjects
{
    [DefaultClassOptions, XafDisplayName("设备单元")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class EquipmentUnit : EquipmentTree
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentUnit(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [XafDisplayName("所属设备"), VisibleInListView(false)]
        public new EquipmentTree Parent { get; set; }

        [XafDisplayName("设备名称")]
        public new String Name { get; set; }

        HCategory eqType;
        string remarkOfEqUnit;
        string eqUnitNo;

        [XafDisplayName("设备分类"), RuleRequiredField]
        public HCategory EqType
        {
            get => eqType;
            set => SetPropertyValue(nameof(EqType), ref eqType, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), XafDisplayName("设备编号"), RuleRequiredField]
        public string EqUnitNo
        {
            get => eqUnitNo;
            set => SetPropertyValue(nameof(EqUnitNo), ref eqUnitNo, value);
        }

        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfEqUnit
        {
            get => remarkOfEqUnit;
            set => SetPropertyValue(nameof(RemarkOfEqUnit), ref remarkOfEqUnit, value);
        }
    }
}