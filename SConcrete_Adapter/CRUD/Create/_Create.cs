using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Common.Materials;
using BH.oM.Structure;
using BH.oM.Base;
using BH.oM.Adapter;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
            bool success = true;
            bool exists = false;

            if (typeof(BH.oM.Base.IBHoMObject).IsAssignableFrom(typeof(T)))
            {
                foreach (IBHoMObject objectToCreate in objects)
                {
                    string filePath = GetFilePath(objectToCreate, ref exists);

                    if (!CreateObject(objectToCreate as dynamic, filePath))
                    {
                        success = false;
                    }
                }
            }            

            return success;
        }

        /***************************************************/
    }
}
