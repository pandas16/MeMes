using DevExpress.Xpo;
using System;
namespace MeMes.Module.BusinessObjects.fts
{

    public partial class Factory
    {
        public Factory(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
