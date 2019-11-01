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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System.IO;

namespace BH.Adapter.S_Frame
{
    public partial class S_Frame_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/
        
        private bool CreateCollection(IEnumerable<Bar> bars)
        {
            //Code for creating a collection of bars in the software


            foreach (Bar bar in bars)
            {
                string filePath = Path.Combine(paths: new string[] { m_FolderPath, (bar.Name.ToString() + ".SCO") });

                List<string> lines = new List<string>();

                lines.Add(TableIdentifiers(bar));
                lines.Add(TableParameters(bar));
                lines.Add(TableSectionalLoads(bar));

                File.WriteAllLines(filePath, lines);
            }
            return true;
        }

        /***************************************************/

        private string TableIdentifiers(Bar bar)
        {
            string memberType = Engine.S_Frame.Convert.GetMemberType(bar).ToString("D");
            return "@" + Environment.NewLine
                    + "@Object@S-CONCRETE Identifiers@" + Environment.NewLine
                    + "@Table@2@" + Environment.NewLine
                    + "Version	2019.1" + Environment.NewLine
                    + "Minor	.1" + Environment.NewLine
                    + "Codes	 17" + Environment.NewLine
                    + "Bar Type	 2" + Environment.NewLine
                    + $"Member Type	 {memberType}" + Environment.NewLine
                    + "Units	 1" + Environment.NewLine
                    + "Orientation	 0" + Environment.NewLine
                    + @"ID IIh+wBlYGoToe8y8iFOCRXEsa5b4XSl7lG/LFSzg5IwqppG51NQPnq+pMXyyuNu1hP+unQOUHwm1+AXEgPs4UreNkG69CqTRmnDESeRGPGEOrSO2wf1LcjPT1M/C/PVY" + Environment.NewLine
                   + "@EndTable@";
        }

        /***************************************************/

        private string TableParameters(Bar bar)
        {
            string parameterText = Engine.S_Frame.Convert.GetSectionData(bar);

            return "@Object@S-CONCRETE Parameters@ 0@" + Environment.NewLine
                    + "@Table@60@" + Environment.NewLine
                    + parameterText + Environment.NewLine
                    + "@EndTable@";
        }

        /***************************************************/

        private string TableSectionalLoads(Bar bar)
        {            
            return "@Object@S-CONCRETE Sectional Loads@" + Environment.NewLine
                    + "@Table@13@" + Environment.NewLine
                    + "LC	Nf	Tf	Vfz	Mfy	Cmy	Vfy	Mfz	Cmz	Pdistr	CheckLC	Load Type	Comment	AutoGen" + Environment.NewLine
                    + "@EndTable@";
        }

        /***************************************************/

        private static string PrintSCODict(Dictionary<string, string> data, int width)
        {
            string lines = "";
            string line = "";

            foreach (KeyValuePair<string, string> param in data)
            {
                if (line.Length <= width)
                {
                    line = line + $"{param.Key}\t{param.Value}\t";
                }
                else
                {
                    lines = lines + line + Environment.NewLine;
                    line = $"{param.Key}\t{param.Value}\t";
                }
            }
            lines = lines + line + Environment.NewLine;

            return lines;
        }

        /***************************************************/

        private static string PrintSCOTable(List<Dictionary<string, string>> data)
        {
            string lines = "";
            string line = "";

            List<string> keys = data[0].Keys.ToList();

            foreach (string key in keys)
            {
                lines += $"{key}\t";
            }
            lines += Environment.NewLine;


            foreach (Dictionary<string, string> item in data)
            {
                foreach (string key in keys)
                {
                    line += $"{item[key]}\t";
                }
                lines += line + Environment.NewLine;
                line = "";
            }

            return lines;
        }

            /***************************************************/

        }
}
