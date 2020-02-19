using BH.Engine.Base.Objects;
using BH.oM.Common.Materials;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System;
using System.Collections.Generic;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Protected Methods                         ****/
        /***************************************************/


        protected void SetupDependencies()
        {
            DependencyTypes = new Dictionary<Type, List<Type>>
            {
                {typeof(MeshResult), new List<Type> { typeof(Panel) } },
                {typeof(BarResult), new List<Type> { typeof(Bar) } }
            };
        }
        
        /***************************************************/
    }
}
