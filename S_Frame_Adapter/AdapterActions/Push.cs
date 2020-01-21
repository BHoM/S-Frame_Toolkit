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
            IEnumerable<object> forceObjects = objects.Where(x => x.GetType() == typeof(BarForce));
            IEnumerable<object> otherObjects = objects.Where(x => x.GetType() != typeof(BarForce));

            if(forceObjects.Count() > 0)
            {
                CreateCollection(forceObjects as IEnumerable<BarForce>);
            }
                
            return base.Push(otherObjects, tag, pushType, actionConfig);
        }
    }
}