using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Adapter;
using BH.oM.Base;
using BH.oM.Common;
using BH.Engine.SConcrete;
using System.Reflection;
using System.IO;
using BH.Engine.Adapter;
using BH.oM.Adapter;
using BH.oM.Structure.Results;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter : BHoMAdapter
    {
        public override List<object> Push(IEnumerable<object> objects, string tag = "", PushType pushType = PushType.AdapterDefault, ActionConfig actionConfig = null)
        {
            // BarForces are IObjects, not IBHoMObject: Create doesn't work with them.
            // Create them separately.
            CreateCollection(objects.OfType<BarForce>());

            return base.Push(objects.Where(x => !(x is BarForce)), tag, pushType, actionConfig);
        }
    }
}