using DevExpress.Xpo;
using System;
namespace MeMes.Module.BusinessObjects.fts
{

    public partial class ProductionLine
    {
        public ProductionLine(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
