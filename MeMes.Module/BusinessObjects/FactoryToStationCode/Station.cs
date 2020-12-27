using DevExpress.Xpo;
using System;
namespace MeMes.Module.BusinessObjects.fts
{

    public partial class Station
    {
        public Station(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
