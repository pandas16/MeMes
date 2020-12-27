using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using MeMes.Module.BusinessObjects.fts;
using System;
using System.Linq;

namespace MeMes.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("生产计划")]
    public class ProductPlan : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ProductPlan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            PlanNum = 1;
            Status = false;
        }

        // TODO 
        // 完善计划单号的自动生成
        // 完善开始时间和结束时间的校验
        // 完善状态控制器，制定单独的下发Action

        bool status;
        string remarkOfProductPlan;
        DateTime dueTime;
        DateTime startTime;
        int planNum;
        ProductionLine production;
        CraftVersion version;
        MaterialMng material;
        string orderNo;
        string planNo;


        [XafDisplayName("计划单号"), RuleRequiredField]
        public string Test
        {
            get => planNo;
            set => SetPropertyValue(nameof(Test), ref planNo, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), XafDisplayName("订单号"), RuleRequiredField]
        public string OrderNo
        {
            get => orderNo;
            set => SetPropertyValue(nameof(OrderNo), ref orderNo, value);
        }

        [XafDisplayName("物料"), RuleRequiredField]
        public MaterialMng Material
        {
            get => material;
            set => SetPropertyValue(nameof(Material), ref material, value);
        }

        [XafDisplayName("版本"), RuleRequiredField]
        public CraftVersion Version
        {
            get => version;
            set
            {
                SetPropertyValue(nameof(Version), ref version, value);
            }
        }

        [XafDisplayName("产线"), RuleRequiredField]
        public ProductionLine Production
        {
            get => production;
            set => SetPropertyValue(nameof(Production), ref production, value);
        }

        [XafDisplayName("计划数量")]
        public int PlanNum
        {
            get => planNum;
            set => SetPropertyValue(nameof(PlanNum), ref planNum, value);
        }

        [XafDisplayName("开始时间"), RuleRequiredField]
        public DateTime StartTime
        {
            get => startTime;
            set => SetPropertyValue(nameof(StartTime), ref startTime, value);
        }

        [XafDisplayName("结束时间"), RuleRequiredField]
        public DateTime DueTime
        {
            get => dueTime;
            set => SetPropertyValue(nameof(DueTime), ref dueTime, value);
        }

        [Size(SizeAttribute.Unlimited), XafDisplayName("备注")]
        public string RemarkOfProductPlan
        {
            get => remarkOfProductPlan;
            set => SetPropertyValue(nameof(RemarkOfProductPlan), ref remarkOfProductPlan, value);
        }

        [CaptionsForBoolValues("已下发", "未下发"), VisibleInDetailView(false), XafDisplayName("状态")]
        public bool Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
    }
}