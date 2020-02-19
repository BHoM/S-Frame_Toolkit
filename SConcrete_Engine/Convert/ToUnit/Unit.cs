using BH.oM.Adapter.SConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Reflection.Attributes;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Converts from BHoM SI units to specified S-Concrete units")]
        [Input("quantity", "The number to convert from SI to specified S-Concrete units")]
        [Input("units", "The S-Concrete Unit System to convert to. Defaults to Metric (not SI: see S-Concrete documentation)")]
        [Input("uType", "The type of quantity which is to be converted, i.e. length, e.g. length, force, moment, density, etc.")]
        public static double ToUnit(this double quantitySI, Units units = Units.Metric, UnitType uType = UnitType.Length)
        {
            if (units == Units.Imperial)
            {
                switch (uType)
                {
                    case UnitType.Length: //S-Concrete uses inches
                        return quantitySI / .0254;
                    case UnitType.Force: //S-Concrete uses kip
                        return quantitySI / 4448.22;
                    case UnitType.Moment: //S-Concrete uses kip*ft
                        return quantitySI / 0.3048 / 4448.22;
                    case UnitType.Pressure: //S-Concrete uses ksi for everything except fcu
                        return quantitySI / 6894.76;
                    case UnitType.Density: //S-Concrete uses lb/ft^3
                        return quantitySI / 16.018;
                }
            }
            else if (units == Units.Metric)

                switch (uType)
                {
                    case UnitType.Length: //S-Concrete uses mm
                        return quantitySI / 1000;
                    case UnitType.Force: //S-Concrete uses kN
                        return quantitySI / 1000;
                    case UnitType.Moment: //S-Concrete uses kN*m
                        return quantitySI / 1000;
                    case UnitType.Pressure: //S-Concrete uses MPa
                        return quantitySI / 1000000;
                    case UnitType.Density: //S-Concrete uses kg/m^3
                        return quantitySI / 1;
                }

            return 1;
        }

        /***************************************************/
    }
}
