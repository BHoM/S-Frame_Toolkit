/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using BH.oM.Structure.Results;
using BH.oM.Structure.SectionProperties;
using BH.oM.Base;
using BH.oM.Adapter;
using System.Runtime.CompilerServices;
using BH.oM.Structure.SectionProperties.Reinforcement;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        protected override bool IUpdate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
            bool success = false;
            bool exists = false;

            foreach (IObject objectToUpdate in objects)
            {
                string filePath = GetFilePath(objectToUpdate, ref exists);
                if (exists)
                {
                    UpdateObject(objectToUpdate as dynamic, filePath);
                }
                else
                {
                    CreateObject(objectToUpdate as dynamic, filePath);
                }
            }

            return success;
        }

        /***************************************************/

        private string ParamReplace(string str, string paramName, Object paramVal)
        {
            string pattern = paramName + @"	 [^\s]*";
            string replacement = $"{paramName}	 {paramVal}";
            return System.Text.RegularExpressions.Regex.Replace(str, pattern, replacement);
        }
    }
}



