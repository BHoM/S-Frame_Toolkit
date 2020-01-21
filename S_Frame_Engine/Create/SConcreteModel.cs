using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Results;
using BH.oM.Geometry;
using BH.oM.Adapter.SConcrete;
using BH.Engine.Structure;

namespace BH.Engine.SConcrete.Create
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static SConcreteModel SConcreteModel(this Bar bar)
        {
            SConcreteModel model = new SConcreteModel();

            String name = "";
            if (bar.Name != "")
                name = bar.Name;
            else if (bar.SectionProperty.Name != "")
                name = bar.SectionProperty.Name;
            else
                name = "Untitled Section";

            if (bar.SectionProperty.GetType() == typeof(ConcreteSection))
            {
                model.Section = (ConcreteSection)bar.SectionProperty;
                model.LengthYY = model.LengthZZ = bar.Length();
                model.Usage = bar.GetUsage();
                model.Name = name;
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
