using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Results;
using BH.oM.Geometry;
using BH.oM.Adapter.S_Frame;
using BH.Engine.Structure;

namespace BH.Engine.S_Frame.Create
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static SConcreteModel SConcreteModel(this Bar bar)
        {
            SConcreteModel model = new SConcreteModel();

            if (bar.SectionProperty.GetType() == typeof(ConcreteSection))
            {
                model.Section = (ConcreteSection)bar.SectionProperty;
                model.LengthYY = model.LengthZZ = bar.Length();
                model.Usage = bar.GetUsage();
            }
            else Engine.Reflection.Compute.RecordError("Bar must have a ConcreteSection");

            return model;
        }

        public static SConcreteModel SConcreteModel(this Bar bar, List<BarForce> forces = null)
        {
            SConcreteModel model = bar.SConcreteModel();

            if (forces != null)
                model.Forces = forces;

            return model;
        }

    }
}
