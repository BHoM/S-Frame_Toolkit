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

namespace BH.Adapter.S_Frame
{
    public partial class S_Frame_Adapter : BHoMAdapter
    {
        public override List<IObject> Push(IEnumerable<IObject> objects, string tag = "", Dictionary<string, object> config = null)
        {
            bool success = true;

            string pushType;

            object ptObj;
            if (config != null && config.TryGetValue("PushType", out ptObj))
                pushType = ptObj.ToString();
            else
                pushType = "Replace";

            List<IObject> objectsToPush = Config.CloneBeforePush ? objects.Select(x => x is BHoMObject ? ((BHoMObject)x).GetShallowClone() : x).ToList() : objects.ToList(); //ToList() necessary for the return collection to function properly for cloned objects

            Type iBHoMObjectType = typeof(IBHoMObject);
            Type iResultType = typeof(IResult);
            MethodInfo miToList = typeof(Enumerable).GetMethod("Cast");
            foreach (var typeGroup in objectsToPush.GroupBy(x => x.GetType()))
            {
                MethodInfo miListObject = miToList.MakeGenericMethod(new[] { typeGroup.Key });

                var list = miListObject.Invoke(typeGroup, new object[] { typeGroup });

                if (iBHoMObjectType.IsAssignableFrom(typeGroup.Key))
                {
                    if (pushType == "Replace")
                        success &= CRUD(list as dynamic, tag);
                    else if (pushType == "UpdateOnly")
                    {
                        success &= UpdateOnly(list as dynamic, tag);
                    }
                }
                else if (iResultType.IsAssignableFrom(typeGroup.Key))
                {
                    success &= Create(list as dynamic);
                }
            }

            return success ? objectsToPush : new List<IObject>();
        }
    }
}
