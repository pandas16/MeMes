using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace MeMes.Module.BusinessObjects
{
    public class EquipmentTree : BaseObject, IHCategory {
		private string name;
		private EquipmentTree parent;
		[NonPersistent]
		[RuleFromBoolProperty("EquipmentTreeCircularReferences", DefaultContexts.Save, "Circular refrerence detected. To correct this error, set the Parent property to another value.", UsedProperties = nameof(Parent))]
		[Browsable(false)]
		public bool IsValid {
			get {
				EquipmentTree currentObj = Parent;
				while(currentObj != null) {
					if(currentObj == this) {
						return false;
					}
					currentObj = currentObj.Parent;
				}
				return true;
			}
		}
		public EquipmentTree(Session session) : base(session) { }
		public EquipmentTree(Session session, string name)
			: this(session) {
			this.name = name;
		}
		[Association("EquipmentTreeParent-EquipmentTreeChild")]
		public XPCollection<EquipmentTree> Children {
			get { return GetCollection<EquipmentTree>(nameof(Children)); }
		}
		[Persistent, Association("EquipmentTreeParent-EquipmentTreeChild")]
		public EquipmentTree Parent {
			get { return parent; }
			set { SetPropertyValue(nameof(Parent), ref parent, value); }
		}
		public string Name {
			get { return name; }
			set { SetPropertyValue(nameof(Name), ref name, value); }
		}
		IBindingList ITreeNode.Children {
			get { return Children as IBindingList; }
		}
		ITreeNode IHCategory.Parent {
			get { return Parent as IHCategory; }
			set { Parent = value as EquipmentTree; }
		}
		ITreeNode ITreeNode.Parent {
			get { return Parent as ITreeNode; }
		}
	}
}
