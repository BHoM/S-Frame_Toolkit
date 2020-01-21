using BH.Engine.Structure;
using BH.oM.Adapter.SConcrete;
using BH.oM.Geometry.ShapeProfiles;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static StructuralUsage1D GetUsage(this Bar bar)
        {
            ConcreteSection section = (ConcreteSection)bar.SectionProperty;
            if (bar.IsVertical())
            {
                return StructuralUsage1D.Column;
            }
            else
            {
                return StructuralUsage1D.Beam;
            }

        }

        /***************************************************/
    }
}
