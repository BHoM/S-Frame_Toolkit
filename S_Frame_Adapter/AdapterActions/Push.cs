using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Adapter;
using BH.oM.Base;
using BH.oM.Common;
using BH.Engine.S_Frame;
using System.Reflection;
using System.IO;
using BH.Engine.Adapter;
using BH.oM.Adapter;
using BH.oM.Structure.Results;

namespace BH.Adapter.S_Frame
{
    public partial class S_Frame_Adapter : BHoMAdapter
    {
        public override List<object> Push(IEnumerable<object> objects, string tag = "", PushType pushType = PushType.AdapterDefault, ActionConfig actionConfig = null)
        {
            {
                if (objects.GetType() == typeof(IEnumerable<IBHoMObject>))
                {
                    try
                    {
                        return base.Push(objects, tag, pushType, actionConfig);
                    }
                    catch
                    {
                        Engine.Reflection.Compute.RecordError("Could not push BHoMObjects");
                    }
                }
                else if (objects.GetType() == typeof(IEnumerable<BarForce>))
                {
                    try
                    {
                        CreateCollection(objects as IEnumerable<BarForce>);
                    }
                    catch
                    {
                        Engine.Reflection.Compute.RecordError("Could not push BarForces.");
                    }
                }
                else
                {
                    Engine.Reflection.Compute.RecordError("Could not push Objects.");
                }

                return objects.ToList();
            }
        }
    }
}