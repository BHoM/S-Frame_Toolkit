/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Common.Materials;
using BH.oM.Adapter;
using BH.oM.Adapter.SConcrete;
using System.Text.RegularExpressions;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        protected override IEnumerable<IBHoMObject> IRead(Type type, IList ids, ActionConfig actionConfig = null)
        {
            List<IBHoMObject> objects = new List<IBHoMObject>();
            

            foreach (object id in ids)
            {
                //find the filepath in the m_folderPath matching the string
                string filePath = GetFilePath(id as string);
                if (File.Exists(filePath))
                {
                    m_Config = ReadSConcreteConfig(filePath);

                    if (type == typeof(SConcreteModel))
                        objects.Add(ReadSConcreteModel(filePath) as IBHoMObject);
                    else if (type == typeof(Bar))
                        objects.Add(ReadBar(filePath) as IBHoMObject);
                    else if (type == typeof(ISectionProperty) || type.GetInterfaces().Contains(typeof(ISectionProperty)))
                        objects.Add(ReadSectionProperty(filePath) as IBHoMObject);
                    else if (type == typeof(ISurfaceProperty) || type.GetInterfaces().Contains(typeof(ISurfaceProperty)))
                        objects.Add(ReadSurfaceProperty(filePath) as IBHoMObject);
                    else if (type == typeof(Material))
                        objects.Add(ReadMaterial(filePath) as IBHoMObject);
                }
            }

            return objects;
        }

        /***************************************************/

        private bool ReadValues(string filePath, ref Dictionary<string, double> values)
        {
            string str = File.ReadAllText(filePath);
            foreach (string key in values.Keys)
            {
                Match m = Regex.Match(str, (key + @"\t (\d+)"));
                float value;
                float.TryParse(m.Captures[0].ToString(), out value);
                values[key] = value;
            }

            return true;
        }
    }
}
