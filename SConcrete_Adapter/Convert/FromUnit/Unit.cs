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
using System.ComponentModel;
using BH.Engine.Adapters.SConcrete;
using BH.oM.Reflection.Attributes;

namespace BH.Adapter.SConcrete
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
        public static double FromUnit(this double quantity, S_Units units = S_Units.Metric, UnitType uType = UnitType.Length)
        {
            return quantity / Convert.ToUnit(1.0, units, uType);
        }

        /***************************************************/
    }
}




