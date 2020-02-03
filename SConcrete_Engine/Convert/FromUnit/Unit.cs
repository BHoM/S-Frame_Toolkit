using BH.oM.Adapter.SConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Engine.SConcrete;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static double FromUnit(this double quantity, Units units = Units.Imperial, UnitType uType = UnitType.Length)
        {
            return quantity / Convert.ToUnit(1.0, units, uType);
        }

        /***************************************************/
    }
}
