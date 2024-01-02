/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.oM.Adapters.SConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Engine.Units;  
using System.ComponentModel;
using BH.oM.Reflection.Attributes;

namespace BH.Adapter.SConcrete
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
        public static double ToUnit(this double quantitySI, S_Units units = S_Units.Metric, UnitType uType = UnitType.Length)
        {
            if (units == S_Units.Imperial)
            {
                switch (uType)
                {
                    case UnitType.Length: //S-Concrete uses inches
                        return BH.Engine.Units.Convert.ToInch(quantitySI);
                    case UnitType.Force: //S-Concrete uses kip
                        return BH.Engine.Units.Convert.ToKilopoundForce(quantitySI);
                    case UnitType.Moment: //S-Concrete uses kip*ft
                        return BH.Engine.Units.Convert.ToKilopoundForceFoot(quantitySI);
                    case UnitType.Pressure: //S-Concrete uses ksi for everything except fcu
                        return BH.Engine.Units.Convert.ToKilopoundForcePerSquareInch(quantitySI);
                    case UnitType.Density: //S-Concrete uses lb/ft^3
                        return BH.Engine.Units.Convert.ToPoundPerCubicFoot(quantitySI);
                }
            }
            else if (units == S_Units.Metric)

                switch (uType)
                {
                    case UnitType.Length: //S-Concrete uses mm
                        return BH.Engine.Units.Convert.ToMillimetre(quantitySI);
                    case UnitType.Force: //S-Concrete uses kN
                        return BH.Engine.Units.Convert.ToKilonewton(quantitySI);
                    case UnitType.Moment: //S-Concrete uses kN*m
                        return BH.Engine.Units.Convert.ToKilonewtonMetre(quantitySI);
                    case UnitType.Pressure: //S-Concrete uses MPa
                        return BH.Engine.Units.Convert.ToNewtonPerSquareMillimetre(quantitySI);
                    case UnitType.Density: //S-Concrete uses kg/m^3
                        return quantitySI / 1;
                }

            return 1;
        }

        /***************************************************/
    }
}




