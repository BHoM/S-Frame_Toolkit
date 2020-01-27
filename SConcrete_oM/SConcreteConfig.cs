using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Common.Properties;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Results;

namespace BH.oM.Adapter.SConcrete
{
    public class SConcreteConfig : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DesignCodes DesignCodes { get; set; } = DesignCodes.ACI_2014;
        public BarType BarType { get; set; } = BarType.American;
        public MemberType MemberType { get; set; } = MemberType.RectBeam;
        public Units Units { get; set; } = Units.Imperial;

        /***************************************************/
    }
}
