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
using BH.oM.Adapter.S_Frame;
using BH.Engine.S_Frame;
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
        
        private bool CreateCollection(IEnumerable<SConcreteModel> models)
        {
            //Code for creating a bunch of S-Concrete files, one for each 'model' passed in.

            foreach (SConcreteModel model in models)
            {
                string filePath = Path.Combine(paths: new string[] { m_FolderPath, (model.Name.ToString() + ".SCO") });

                List<string> lines = new List<string>();

                if (model.Section != null)
                {
                    lines.Add(TableIdentifiers(model));
                    lines.Add(TableParameters(model));
                    lines.Add(TableSectionalLoads(model.Forces));
                }
                
                File.WriteAllLines(filePath, lines);
            }
            return true;
        }

        /***************************************************/

        private string TableIdentifiers(SConcreteModel model)
        {
            string memberType = model.GetMemberType().ToString("G");

            return "@" + Environment.NewLine
                    + "@Object@S-CONCRETE Identifiers@" + Environment.NewLine
                    + "@Table@2@" + Environment.NewLine
                    + "Version	2019.1" + Environment.NewLine
                    + "Minor	.1" + Environment.NewLine
                    + $"Codes	 {(int)m_config.DesignCodes}" + Environment.NewLine
                    + $"Bar Type	 {(int)m_config.BarType}" + Environment.NewLine
                    + $"Member Type	 {memberType}" + Environment.NewLine
                    + $"Units	 {(int)m_config.Units}" + Environment.NewLine
                    + "Orientation	 0" + Environment.NewLine
                    + @"ID IIh+wBlYGoToe8y8iFOCRXEsa5b4XSl7lG/LFSzg5IwqppG51NQPnq+pMXyyuNu1hP+unQOUHwm1+AXEgPs4UreNkG69CqTRmnDESeRGPGEOrSO2wf1LcjPT1M/C/PVY" + Environment.NewLine
                   + "@EndTable@";
        }

        /***************************************************/

        private string TableParameters(SConcreteModel model)
        {
            string parameterText = model.ToS_Frame(m_config);

            return "@Object@S-CONCRETE Parameters@ 0@" + Environment.NewLine
                    + "@Table@60@" + Environment.NewLine
                    + parameterText + Environment.NewLine
                    + "@EndTable@";
        }

        /***************************************************/

        private string TableSectionalLoads(List<BarForce> forces)
        {
            string loadText = "";

            if (forces.Count() > 0)
            {
                for (int i = 0; i < forces.Count; i++)
                {
                    loadText = loadText + forces[i].ToS_Frame(i, m_config);
                }
            }                

            return "@Object@S-CONCRETE Sectional Loads@" + Environment.NewLine
                    + "@Table@13@" + Environment.NewLine
                    + "LC	Nf	Tf	Vfz	Mfy	Cmy	Vfy	Mfz	Cmz	Pdistr	CheckLC	Load Type	Comment	AutoGen" + Environment.NewLine
                    + loadText
                    + "@EndTable@";
        }

        /***************************************************/

        }
}
