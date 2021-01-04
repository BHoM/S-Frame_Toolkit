/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Structure.Elements;
using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Adapter.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        public static string ToSConcretePanelInformation(Panel panel, int i)
        {
            string l = "6000";
            string t = "400";
            string x0 = "0";
            string y0 = "3000";
            string angle = "0";
            string zonenoa = "1";
            string zonenob = "2";
            string vertd = "4";
            string horzd = "4";
            string curt = "1";
            string verts = "400";
            string horzs = "400";
            string hooka = "0";
            string hookb = "0";

            return $" {i}	 True	1	 {l}	 {t}	 {x0}    {y0}    {angle}	 {zonenoa}	 {zonenob}	 {vertd}	 {horzd}	 {curt}	 {verts}	 {horzs}	 {hooka}	 {hookb}";
        }

        /***************************************************/
    }
}

