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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System.IO;
using BH.Engine.Adapters.SConcrete;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/
        
        private bool UpdateObject(BarForce barForce, string filePath)
        {
            //Code for adding additional loads to an existing file 

            m_Config = ReadSConcreteConfig(filePath);

            string[] lines;
            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch
            {
                Engine.Reflection.Compute.RecordError($"Could not read file {filePath}");
                return false;
            }

            StringBuilder lines_out = new StringBuilder();

            bool replace = true;
            int seek = 0;
            int i = 1;
            string startLine = @"@Object@S-CONCRETE Sectional Loads@";
            string endLine = "@EndTable@";

            foreach (string line in lines)
            {
                if (seek == 0)
                {
                    if (line == startLine)
                    {
                        lines_out.Append(line + Environment.NewLine);
                        seek = 1;
                    }
                    else
                    {
                        lines_out.Append(line + Environment.NewLine);
                    }
                }
                if (seek == 1)
                {
                    if (line.StartsWith("@Table"))
                    {
                        lines_out.Append(line + Environment.NewLine);
                    }
                    if (line.StartsWith("LC"))
                    {
                        lines_out.Append(line + Environment.NewLine);
                    }
                    else if (line.StartsWith(" ") && !replace)
                    {
                        i = int.Parse(line.Split('\t')[0].Trim()) + 1;
                        lines_out.Append(line + Environment.NewLine);
                    }
                    else if (line.StartsWith(" ") && replace)
                    {
                        //ignore any existing loads
                    }
                    else if (line == endLine)
                    {
                        lines_out.Append(barForce.ToSConcrete(i, m_Config));
                        lines_out.Append(line + Environment.NewLine);
                        seek = 0;
                    }
                }
            }

            File.WriteAllText(filePath, lines_out.ToString());

            return true;
        }

        /***************************************************/

    }
}




