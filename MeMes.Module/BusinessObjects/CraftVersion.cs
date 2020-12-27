﻿using DevExpress.ExpressApp.DC;
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
    [XafDisplayName("工艺版本"), DefaultProperty("VersionOfCraft")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CraftVersion : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CraftVersion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        string remarkOfCraft;
        [FetchOnly]
        [Persistent("VersionOfCraft")]
        private int versionOfCraft;

        MaterialMng material;

        [XafDisplayName("物料"), RuleRequiredField]
        public MaterialMng Material
        {
            get => material;
            set => SetPropertyValue(nameof(Material), ref material, value);
        }

        [XafDisplayName("版本")]
        [PersistentAlias(nameof(versionOfCraft))]
        public int VersionOfCraft
        {
            get => versionOfCraft;
        }

        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfCraft
        {
            get => remarkOfCraft;
            set => SetPropertyValue(nameof(RemarkOfCraft), ref remarkOfCraft, value);
        }
    }
}