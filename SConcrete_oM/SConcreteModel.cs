using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Common.Properties;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Results;
using BH.oM.Structure.Elements;

namespace BH.oM.Adapter.SConcrete
{
    public class SConcreteModel : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        public ConcreteSection Section { get; set; } = null;

        public StructuralUsage1D Usage { get; set; } = StructuralUsage1D.Beam;

        public Double LengthYY { get; set; } = 0;

        public Double LengthZZ { get; set; } = 0;

        public List<BarForce> Forces { get; set; } = new List<BarForce>();

        /***************************************************/
    }
}
