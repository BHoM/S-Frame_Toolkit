using BH.oM.Adapter.SConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.Engine.SConcrete;
using BH.oM.Reflection.Attributes;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Converts from specified S-Concrete units to SI units for use in BHoM")]
        [Input("quantity", "The number to convert from specified S-Concrete units to SI")]
        [Input("units","The S-Concrete Unit System from which to convert. Defaults to Metric (not SI: see S-Concrete documentation)")]
        [Input("uType","The type of quantity which is to be converted, i.e. length, e.g. length, force, moment, density, etc.")]
        public static double FromUnit(this double quantity, Units units = Units.Metric, UnitType uType = UnitType.Length)
        {
            return quantity / Convert.ToUnit(1.0, units, uType);
        }

        /***************************************************/
    }
}
