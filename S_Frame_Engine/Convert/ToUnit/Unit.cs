/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

using BH.oM.Adapter.SConcrete;
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
