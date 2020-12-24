using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace MeMes.Module.BusinessObjects.fts
{

    public partial class ProductionLine
    {
        public ProductionLine(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
