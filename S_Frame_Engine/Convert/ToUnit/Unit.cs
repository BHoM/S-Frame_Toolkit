using BH.oM.Adapter.S_Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.S_Frame
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static double ToUnit(this double quantitySI, Units units = Units.Imperial, UnitType uType = UnitType.Length)
        {
            if (units == Units.Imperial)
            {
                switch (uType)
                {
                    case UnitType.Length:
                        return quantitySI / .0254;
                    case UnitType.Force:
                        return quantitySI / 4448.22;
                    case UnitType.Moment:
                        return quantitySI / 0.3048 / 4448.22;
                }
            }
            else if (units == Units.Metric)

                switch (uType)
                {
                    case UnitType.Length:
                    case UnitType.Force:
                    case UnitType.Moment:
                        return 1 / 1000;
                }

            return 1;
        }

        /***************************************************/
    }
}
